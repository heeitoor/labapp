using System;
using System.Collections.Generic;
using System.Data;

namespace Lab.App.Data
{
    public interface IDataAccess
    {
        int Execute(string query);

        DataTable Query(string query);

        List<T> Query<T>(string query, Func<DataRow, T> mapping);
    }
}
