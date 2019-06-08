using System.Data;

namespace Lab.Common.Extensions
{
    public static class DataTableExtensions
    {
        /// <summary>
        /// Método que verifica se existem linhas no DataTable.
        /// </summary>
        /// <param name="dataTable"></param>
        /// <returns></returns>
        public static bool HasRows(this DataTable dataTable)
        {
            return dataTable.Rows != null && dataTable.Rows.Count > 0;
        }
    }
}
