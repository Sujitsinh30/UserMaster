using Dapper;
using System.Data;
using UserMaster.Service;

namespace UserMaster.Repository
{
    public class CommonRepository : BaseRepository, IUserMaster
    {
        public CommonRepository(IConfiguration configuration) : base(configuration) { }
        public DataTable AuthenticateUser(dynamic param)
        {
            try
            {
                DynamicParameters obj = new DynamicParameters();
                obj.Add("@UMID", param.UMID);
                obj.Add("@UM_UserName", param.UM_UserName);
                obj.Add("@UM_Password", param.UM_Password);
                DataTable dtResponse = GetDataTable("IM_UserMasterSelect", obj);
                return dtResponse;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public DataTable InsertUpdateUser(dynamic param)
        {
            try
            {
                DynamicParameters obj = new DynamicParameters();
                obj.Add("@UMID", param.UMID);
                obj.Add("@UM_UserName", param.UM_UserName);
                obj.Add("@UM_Password", param.UM_Password);
                obj.Add("@UM_MobileNo", param.UM_MobileNo);
                obj.Add("@UM_Email", param.UM_Email);
                obj.Add("@UM_FName", param.UM_FName);
                obj.Add("@UM_LName", param.UM_LName);
                obj.Add("@UM_IpAddress", param.UM_IpAddress);
                DataTable dtResponse = GetDataTable("IM_UserMasterInsertUpdate", obj);
                return dtResponse;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
