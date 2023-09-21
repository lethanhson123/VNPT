﻿namespace Helper
{
    public static class SQLHelper
    {
        public static string ExecuteNonQuery(string connectionString, string storedProcedureName, params SqlParameter[] parameters)
        {
            string result = "";
            try
            {

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(storedProcedureName, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddRange(parameters);
                        conn.Open();
                        result = cmd.ExecuteNonQuery().ToString();
                    }
                }
            }
            catch (Exception e)
            {
                result = e.Message;
            }
            return result;
        }
        public static async Task<string> ExecuteNonQueryAsync(string connectionString, string storedProcedureName, params SqlParameter[] parameters)
        {
            string result = "";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(storedProcedureName, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddRange(parameters);
                        await conn.OpenAsync();
                        int result01 = await cmd.ExecuteNonQueryAsync();
                        result = result01.ToString();
                    }
                }
            }
            catch (Exception e)
            {
                result = e.Message;
            }
            return result;
        }

        public static object ExecuteScalar(string connectionString, string storedProcedureName, params SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(storedProcedureName, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddRange(parameters);
                    conn.Open();
                    var result = cmd.ExecuteScalar();
                    return result;
                }
            }
        }

        public static async Task<object> ExecuteScalarAsync(string connectionString, string storedProcedureName, params SqlParameter[] parameters)
        {

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(storedProcedureName, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddRange(parameters);
                    await conn.OpenAsync();
                    var result = await cmd.ExecuteScalarAsync();
                    return result;
                }
            }
        }

        public static SqlDataReader ExecuteReader(string connectionString, string storedProcedureName, params SqlParameter[] parameters)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            using (SqlCommand cmd = new SqlCommand(storedProcedureName, conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddRange(parameters);
                conn.Open();
                SqlDataReader result = cmd.ExecuteReader();
                return result;

            }
        }

        public static async Task<SqlDataReader> ExecuteReaderAsync(string connectionString, string storedProcedureName, params SqlParameter[] parameters)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            using (SqlCommand cmd = new SqlCommand(storedProcedureName, conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddRange(parameters);
                await conn.OpenAsync();
                var result = await cmd.ExecuteReaderAsync();
                return result;
            }
        }

        public static DataTable FillDataTable(string connectionString, string storedProcedureName, params SqlParameter[] parameters)
        {
            DataTable dt = new DataTable();
            string result = "";
            try
            {
                SqlConnection conn = new SqlConnection(connectionString);
                using (SqlCommand cmd = new SqlCommand(storedProcedureName, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddRange(parameters);
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.SelectCommand = cmd;
                    conn.Open();
                    adapter.Fill(dt);
                }
            }
            catch (Exception e)
            {
                result = e.Message;
            }
            return dt;
        }

        public static async Task<DataTable> FillDataTableAsync(string connectionString, string storedProcedureName, params SqlParameter[] parameters)
        {
            DataTable dt = new DataTable();
            string result = "";
            try
            {
                SqlConnection conn = new SqlConnection(connectionString);
                using (SqlCommand cmd = new SqlCommand(storedProcedureName, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddRange(parameters);
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.SelectCommand = cmd;
                    await conn.OpenAsync();
                    adapter.Fill(dt);
                }
            }
            catch (Exception e)
            {
                result = e.Message;
            }
            return dt;
        }

        public static DataSet FillDataSet(string connectionString, string storedProcedureName, params SqlParameter[] parameters)
        {
            DataSet ds = new DataSet();
            string result = "";
            try
            {
                SqlConnection conn = new SqlConnection(connectionString);
                using (SqlCommand cmd = new SqlCommand(storedProcedureName, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddRange(parameters);
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.SelectCommand = cmd;
                    conn.Open();
                    adapter.Fill(ds);
                }
            }
            catch (Exception e)
            {
                result = e.Message;
            }
            return ds;
        }

        public static async Task<DataSet> FillDataSetAsync(string connectionString, string storedProcedureName, params SqlParameter[] parameters)
        {
            DataSet ds = new DataSet();
            string result = "";
            try
            {
                SqlConnection conn = new SqlConnection(connectionString);
                using (SqlCommand cmd = new SqlCommand(storedProcedureName, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddRange(parameters);
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.SelectCommand = cmd;
                    await conn.OpenAsync();
                    adapter.Fill(ds);
                }
            }
            catch (Exception e)
            {
                result = e.Message;
            }
            return ds;
        }

        public static List<T> ToList<T>(DataTable dataTable)
        {
            List<T> data = new List<T>();
            foreach (DataRow row in dataTable.Rows)
            {
                T item = GetItem<T>(row);
                data.Add(item);
            }
            return data;
        }

        public static IEnumerable<T> ToEnumerable<T>(DataTable dataTable)
        {
            foreach (DataRow row in dataTable.Rows)
            {
                T item = GetItem<T>(row);
                yield return item;
            }
        }

        private static T GetItem<T>(DataRow dr)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();

            foreach (DataColumn column in dr.Table.Columns)
            {
                foreach (PropertyInfo pro in temp.GetProperties())
                {
                    try
                    {
                        if (pro.Name == column.ColumnName && dr[column.ColumnName] != DBNull.Value)
                        {
                            Type t = Nullable.GetUnderlyingType(pro.PropertyType) ?? pro.PropertyType;

                            pro.SetValue(obj, System.Convert.ChangeType(dr[column.ColumnName], t), null);
                        }
                    }
                    catch (Exception)
                    {
                    }
                }
            }
            return obj;
        }
    }
}
