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
