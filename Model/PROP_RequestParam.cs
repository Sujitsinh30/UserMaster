namespace UserMaster.Model
{
    public class PROP_InsertRequestParam
    {
        public string UM_UserName { get; set; }
        public string UM_Password { get; set; }
        public string UM_FName { get; set; }
        public string UM_LName { get; set; }
        public string UM_MobileNo { get; set; }
        public string UM_Email { get; set; }
        public string Key { get; set; }
    }
    public class PROP_UpdateRequestParam
    {
        public int UMID { get; set; }
        public string UM_UserName { get; set; }
        public string UM_Password { get; set; }
        public string UM_FName { get; set; }
        public string UM_LName { get; set; }
        public string UM_MobileNo { get; set; }
        public string UM_Email { get; set; }
        public string Key { get; set; }
    }
    public class PROP_AuthRequestParam
    {
        public int UMID { get; set; }
        public string UM_UserName { get; set; }
        public string UM_Password { get; set; }
        public string Key { get; set; }
    }
}
