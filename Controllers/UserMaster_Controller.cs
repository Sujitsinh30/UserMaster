using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;
using System.Dynamic;
using UserMaster.Model;
using UserMaster.Service;

namespace UserMaster.Controllers
{
    public class UserMaster_Controller : ControllerBase
    {
        private readonly IUserMaster _IUserMaster;

        public UserMaster_Controller(IUserMaster IUserMasterService)
        {
            this._IUserMaster = IUserMasterService;
        }
        [HttpPost("/AutenticateUser")]
        public IActionResult AuthenticateUser([FromBody] PROP_AuthRequestParam param)
        {
            DataResponse res = new DataResponse();
            var isValid = param.UMID == 0 ? (param.UM_UserName != "" && param.UM_Password != "") : Convert.ToString(param.UMID) != "";
            if (isValid)
            {
                try
                {
                    DataTable dataTable = new DataTable();
                    try
                    {
                        string json = "";
                        using (StreamReader r = new StreamReader("JSON/UserMaster_VerifyCalll.json"))
                        {
                            json = r.ReadToEnd();
                        }
                        dataTable = (DataTable)JsonConvert.DeserializeObject(json, typeof(DataTable));

                    }
                    catch (Exception ex)
                    { }

                    dataTable.DefaultView.RowFilter = string.Concat("VerifyCall = '", param.Key, "'");
                    dataTable = dataTable.DefaultView.ToTable();

                    if (dataTable.Rows.Count > 0)
                    {
                        dynamic d = new ExpandoObject();
                        d.UMID = param.UMID;
                        d.UM_UserName = param.UM_UserName;
                        d.UM_Password = param.UM_Password;
                        DataTable dtResponse = _IUserMaster.AuthenticateUser(d);
                        if (dtResponse.Rows.Count > 0)
                        {
                            res.status = 200;
                            res.message = "Success";
                            res.data = (dtResponse);
                            return Ok(res);
                        }
                        else
                        {
                            res.status = 200;
                            res.message = "User Not found";
                            return Ok(res);
                        }
                    }
                    else
                    {
                        res.status = 400;
                        res.message = "Unautorized Request";
                        return BadRequest(res);
                    }
                }
                catch (Exception ex)
                {
                    res.status = 500;
                    res.message = $"Unexpected Error Occurred{ex.Message}";
                    return BadRequest(res);
                }
                finally { }
            }
            else
            {
                res.status = 400;
                res.message = "All Parameters Are Required";
                return BadRequest(res);
            }
        }

        [HttpPost("/UserInsert")]
        public IActionResult InsertUser([FromBody] PROP_InsertRequestParam param)
        {
            DataResponse res = new DataResponse();
            var isValid = VerifyPropsNotNullOrWhitespace(param);
            if (isValid)
            {
                try
                {
                    DataTable dataTable = new DataTable();
                    try
                    {
                        string json = "";

                        using (StreamReader r = new StreamReader("JSON/UserMaster_VerifyCall.json"))
                        {
                            json = r.ReadToEnd();
                        }
                        dataTable = (DataTable)JsonConvert.DeserializeObject(json, typeof(DataTable));

                    }
                    catch (Exception ex)
                    { }

                    dataTable.DefaultView.RowFilter = string.Concat("VerifyCall = '", param.Key, "'");
                    dataTable = dataTable.DefaultView.ToTable();

                    if (dataTable.Rows.Count > 0)
                    {
                        dynamic d = new ExpandoObject();
                        d.UMID = 0;
                        d.UM_UserName = param.UM_UserName;
                        d.UM_Password = param.UM_Password;
                        d.UM_FName = param.UM_FName;
                        d.UM_LName = param.UM_LName;
                        d.UM_MobileNo = param.UM_MobileNo;
                        d.UM_Email = param.UM_Email;
                        d.UM_IpAddress = Convert.ToString(HttpContext.Connection.RemoteIpAddress);
                        DataTable dtResponse = _IUserMaster.InsertUpdateUser(d);
                        res.status = 200;
                        res.message = Convert.ToString(dtResponse.Rows[0]["Response"]) == "Success" ? "User Saved Successfully" : "User Not Saved";
                        res.data = (dtResponse);
                        return Ok(res);
                    }
                    else
                    {
                        res.status = 400;
                        res.message = "Unautorized Request";
                        return BadRequest(res);
                    }
                }
                catch (Exception ex)
                {
                    res.status = 500;
                    res.message = $"Unexpected Error Occurred:{ex.Message}";
                    return BadRequest(res);
                }
                finally { }
            }
            else
            {
                res.status = 400;
                res.message = "All Parameters Are Required";
                return BadRequest(res);
            }
        }

        [HttpPost("/UserUpdate")]
        public IActionResult UpdateUser([FromBody] PROP_UpdateRequestParam param)
        {
            DataResponse res = new DataResponse();
            var isValid = VerifyPropsNotNullOrWhitespace(param);
            if (isValid)
            {
                try
                {
                    DataTable dataTable = new DataTable();
                    try
                    {
                        string json = "";
                        using (StreamReader r = new StreamReader("JSON/UserMaster_VerifyCall.json"))
                        {
                            json = r.ReadToEnd();
                        }
                        dataTable = (DataTable)JsonConvert.DeserializeObject(json, typeof(DataTable));

                    }
                    catch (Exception ex)
                    { }

                    dataTable.DefaultView.RowFilter = string.Concat("VerifyCall = '", param.Key, "'");
                    dataTable = dataTable.DefaultView.ToTable();

                    if (dataTable.Rows.Count > 0)
                    {
                        dynamic d = new ExpandoObject();
                        d.UMID = param.UMID;
                        d.UM_UserName = param.UM_UserName;
                        d.UM_Password = param.UM_Password;
                        d.UM_FName = param.UM_FName;
                        d.UM_LName = param.UM_LName;
                        d.UM_MobileNo = param.UM_MobileNo;
                        d.UM_Email = param.UM_Email;
                        d.UM_IpAddress = Convert.ToString(HttpContext.Connection.RemoteIpAddress);
                        DataTable dtResponse = _IUserMaster.InsertUpdateUser(d);
                        res.status = 200;
                        res.message = Convert.ToString(dtResponse.Rows[0]["Response"]) == "Success" ? "User Update Successfully" : "User Not Updated";
                        res.data = (dtResponse);
                        return Ok(res);
                    }
                    else
                    {
                        res.status = 400;
                        res.message = "Unautorized Request";
                        return BadRequest(res);
                    }
                }
                catch (Exception ex)
                {
                    res.status = 500;
                    res.message = "Unexpected Error Occurred";
                    return BadRequest(res);
                }
                finally { }
            }
            else
            {
                res.status = 400;
                res.message = "All Parameters Are Required";
                return BadRequest(res);
            }
        }
        public static bool VerifyPropsNotNullOrWhitespace(object obj)
        {
            if (obj == null) throw new ArgumentNullException(nameof(obj));

            var properties = obj.GetType().GetProperties();

            foreach (var prop in properties)
            {
                var value = prop.GetValue(obj);

                if (value is string str && string.IsNullOrWhiteSpace(str))
                {
                    return false;
                }

                if (value is int intValue && intValue == 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
