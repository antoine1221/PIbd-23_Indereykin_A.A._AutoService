using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace ProjectAutoService.Data;

internal static class DesktopDatabaseStartup
{
    internal static bool Prepare()
    {
        var custom = Environment.GetEnvironmentVariable("AUTOSERVICE_CONNECTION_STRING");
        using var config = new ConfigurationManager();
        config.SetBasePath(AppContext.BaseDirectory).AddJsonFile("appsettings.json");
        var connection = new NpgsqlConnectionStringBuilder(string.IsNullOrWhiteSpace(custom)
            ? config.GetConnectionString("AutoService") : custom);
        bool isLab = connection.Host == "127.0.0.1" && connection.Port == 55433
            && connection.Database == "autoservice_lab2" && connection.Username == "lab2_owner";
        // Автоматически применяем миграции только к учебной базе.
        if (!isLab) return true;

        StartLabServer();
        bool prompt = string.IsNullOrEmpty(connection.Password) && string.IsNullOrEmpty(Environment.GetEnvironmentVariable("PGPASSWORD"));
        while (true)
        {
            if (prompt)
            {
                using var dialog = new Form { Text = "Подключение к БД", ClientSize = new Size(460, 160),
                    StartPosition = FormStartPosition.CenterScreen, FormBorderStyle = FormBorderStyle.FixedDialog,
                    MaximizeBox = false, MinimizeBox = false };
                var label = new Label { Text = "Пароль:", AutoSize = true, Location = new Point(24, 24) };
                var input = new TextBox { UseSystemPasswordChar = true, Location = new Point(24, 50), Width = 412, TabIndex = 0 };
                var ok = new Button { Text = "Войти", Location = new Point(248, 104), Size = new Size(88, 32), DialogResult = DialogResult.OK };
                var cancel = new Button { Text = "Отмена", Location = new Point(348, 104), Size = new Size(88, 32), DialogResult = DialogResult.Cancel };
                dialog.Controls.AddRange([label, input, ok, cancel]);
                dialog.AcceptButton = ok; dialog.CancelButton = cancel; dialog.ActiveControl = input;
                if (dialog.ShowDialog() != DialogResult.OK) return false;
                if (input.Text.Length == 0) continue;
                DataContext.DesktopPassword = input.Text;
            }
            try
            {
                using var db = new DataContext();
                db.Database.Migrate();
                return true;
            }
            catch (PostgresException ex) when (prompt && ex.SqlState == PostgresErrorCodes.InvalidPassword)
            {
                DataContext.DesktopPassword = null;
                MessageBox.Show("Неверный пароль. Попробуйте ещё раз.",
                    "Подключение к БД", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }

    private static void StartLabServer()
    {
        var root = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "AutoService-Lab2");
        var data = Path.Combine(root, "pg18-data");
        var ctl = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles), "PostgreSQL", "18", "bin", "pg_ctl.exe");
        if (!File.Exists(Path.Combine(data, "PG_VERSION")) || !File.Exists(ctl))
            throw new InvalidOperationException("Учебный экземпляр PostgreSQL 18 не найден. Сначала выполните однократную настройку по README.");
        int Run(params string[] args)
        {
            var start = new ProcessStartInfo(ctl) { UseShellExecute = false, CreateNoWindow = true };
            foreach (var arg in args) start.ArgumentList.Add(arg);
            start.Environment.Remove("PGPASSWORD");
            start.Environment.Remove("AUTOSERVICE_CONNECTION_STRING");
            using var process = Process.Start(start) ?? throw new InvalidOperationException("Не удалось запустить pg_ctl.");
            process.WaitForExit();
            return process.ExitCode;
        }
        var status = Run("-D", data, "status");
        if (status == 0) return;
        if (status != 3 || Run("-D", data, "-l", Path.Combine(root, "postgres.log"), "-t", "15", "-w", "start") != 0)
            throw new InvalidOperationException($"Учебный сервер не запустился. Журнал: {Path.Combine(root, "postgres.log")}");
    }
}
