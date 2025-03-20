using Dapper;
using Newtonsoft.Json;
using System.Data.SqlClient;
using System.Data;

namespace UserMaster.Repository
{
    public class BaseRepository
    {
        private readonly IConfiguration _configuration;
        protected BaseRepository(IConfiguration configuration)
        {
            _configuration = configuration;

        }

        protected IDbConnection CreateConnection()
        {
            return new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
        }
        protected string GetDataReader(string query, DynamicParameters param)
        {
            try
            {
                DataSet ds = new DataSet();

                using (var connection = CreateConnection())
                {
                    // int index = 1;
                    var reader = connection.ExecuteReader(query, param, commandType: CommandType.StoredProcedure);
                    while (!reader.IsClosed)
                    {
                        DataTable dt = new DataTable();
                        //   dt.TableName = "Table" + index;
                        dt.Load(reader);
                        ds.Tables.Add(dt);
                        // index++;
                    }
                }
                int t = ds.Tables.Count;
                var jsonResult = JsonConvert.SerializeObject(ds);
                return jsonResult;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        protected DataTable GetDataTable(string query, DynamicParameters param)
        {
            try
            {
                DataTable dt = new DataTable();
                using (var connection = CreateConnection())
                {
                    var reader = connection.ExecuteReader(query, param, commandType: CommandType.StoredProcedure);
                    while (!reader.IsClosed)
                    {
                        dt.Load(reader);
                    }
                }
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        protected DataSet GetDataSet(string query, DynamicParameters param)
        {
            try
            {

                DataSet ds = new DataSet();
                using (var connection = CreateConnection())
                {
                    var reader = connection.ExecuteReader(query, param, commandType: CommandType.StoredProcedure);
                    while (!reader.IsClosed)
                    {
                        DataTable dt = new DataTable();
                        dt.Load(reader);
                        ds.Tables.Add(dt);
                    }
                }
                int t = ds.Tables.Count;
                return ds;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        protected string GetDataTableString(string query, DynamicParameters param)
        {
            try
            {
                DataTable dt = new DataTable();
                using (var connection = CreateConnection())
                {
                    int index = 1;
                    var reader = connection.ExecuteReader(query, param, commandType: CommandType.StoredProcedure);
                    while (!reader.IsClosed)
                    {
                        dt.TableName = "Table" + index;
                        dt.Load(reader);
                        index++;
                    }
                }
                var jsonResult = JsonConvert.SerializeObject(dt);
                return jsonResult;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
