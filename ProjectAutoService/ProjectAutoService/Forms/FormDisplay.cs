using Microsoft.EntityFrameworkCore;
using Npgsql;
using ProjectAutoService.Entities.Enums;

namespace ProjectAutoService.Forms
{
    internal static class FormDisplay
    {
        internal static void ConfigureListColumns(DataGridView grid, params (string PropertyName, string HeaderText)[] columns)
        {
            grid.AutoGenerateColumns = false;
            foreach (var (propertyName, headerText) in columns)
            {
                grid.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = propertyName,
                    DataPropertyName = propertyName,
                    HeaderText = headerText
                });
            }
        }

        internal static string DirectoryDeleteError(Exception error)
        {
            if (error is DbUpdateException && error.GetBaseException() is PostgresException postgres &&
                postgres.SqlState is PostgresErrorCodes.RestrictViolation or PostgresErrorCodes.ForeignKeyViolation)
            {
                return postgres.TableName switch
                {
                    "ServiceOrders" => "Нельзя удалить запись: она используется в заказе.",
                    "PartUsages" or "SparePartPartUsages" => "Нельзя удалить запись: она используется в расходе запчастей.",
                    _ => "Нельзя удалить запись: она используется в других записях."
                };
            }

            return error is KeyNotFoundException
                ? "Запись уже удалена или не найдена."
                : "Не удалось удалить запись. Подробности см. в журнале приложения.";
        }

        internal static string QualificationName(MechanicQualification qualification) => qualification switch
        {
            MechanicQualification.None => "Не выбрана",
            MechanicQualification.ThirdCategory => "Третья категория",
            MechanicQualification.SecondCategory => "Вторая категория",
            MechanicQualification.FirstCategory => "Первая категория",
            _ => "Неизвестная категория"
        };
    }
}
