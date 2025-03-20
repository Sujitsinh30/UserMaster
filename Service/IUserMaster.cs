using System.Data;

namespace UserMaster.Service
{
    public interface IUserMaster
    {
        public DataTable InsertUpdateUser(dynamic param);
        public DataTable AuthenticateUser(dynamic param);
    }
}
