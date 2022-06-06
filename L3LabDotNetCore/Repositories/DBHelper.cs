using L3Lab.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace L3LabDotNetCore.Repositories
{
    public class DBHelper: IDBHelper
    {
        private readonly AppDBContext _appDBContext;
        public DBHelper(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }
        /// <summary>
        /// Method for Adding and Updating stored procedure
        /// </summary>
        /// <param name="commandText">Name of the stored procedure or the query text</param>
        /// <param name="parameters">List of Sql Parameters</param>
        /// <returns></returns>
        public int ExecuteNonQuery(string commandText, SqlParameter[] parameters)
        {

            var conn = _appDBContext.Database.GetDbConnection();
            conn.Open();

            var command = conn.CreateCommand();
            command.CommandText = commandText;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandTimeout = 9000;
            foreach (var parameter in parameters)
            {
                command.Parameters.Add(parameter);
            }

            var result = command.ExecuteNonQuery();
            conn.Close();
            return result;
        }

        /// <summary>
        /// Create a parameter for stored procedure
        /// </summary>
        /// <param name="name">Name of the parameter</param>
        /// <param name="value">Value of the parameter</param>
        /// <param name="dbType">Data type of the parameter in the database</param>
        /// <returns></returns>
        public SqlParameter CreateParameter(string name, object value, SqlDbType dbType, ParameterDirection direction = ParameterDirection.Input)
        {
            SqlParameter parameter = new SqlParameter()
            {
                ParameterName = name,
                SqlDbType = dbType,
                Value = value,
                Direction = direction
            };

            return parameter;
        }
    }
}
