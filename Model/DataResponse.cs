namespace UserMaster.Model
{
    public class DataResponse
    {
        public DataResponse()
        {
            this.status = 0;
            this.data = new List<Object>();
            this.message = "";
        }
        public int status { get; set; }
        public string message { get; set; }
        public Object data { get; set; }
    }
}
