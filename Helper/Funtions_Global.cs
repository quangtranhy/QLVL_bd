using Newtonsoft.Json;
using System.Dynamic;
using System.Security.Cryptography;
using System.Text;

namespace QLViecLam.Helper
{
    public class Funtions_Global
    {
        public static string GetSsAdmin(ISession session, string key)
        {
            string value = "";
            if (session != null)
            {
                string ssAdminJson = session?.GetString("SsAdmin") ?? "";

                if (!string.IsNullOrEmpty(ssAdminJson) && ssAdminJson != "")
                {
                    dynamic sessionInfo = JsonConvert.DeserializeObject(ssAdminJson) ?? new ExpandoObject(); ;

                    if (sessionInfo != null)
                    {
                        if (sessionInfo[key] != null)
                        {
                            value = sessionInfo[key].ToString();
                        }
                    }
                }
            }

            return value;
        }

        public static bool CheckPermission(ISession session, string roles, string key)
        {
            if (!string.IsNullOrEmpty(session.GetString("SsAdmin")))
            {
                string ssadmin = session.GetString("SsAdmin");
                dynamic sessionInfo = JsonConvert.DeserializeObject(ssadmin);
                if (sessionInfo["PhanLoai"] == "SSA")
                {
                    return true;
                }
                else
                {
                    string per = session.GetString("Permission");
                    if (!string.IsNullOrEmpty(per))
                    {
                        dynamic info = JsonConvert.DeserializeObject(per);

                        foreach (var item in info)
                        {
                            if (item["Roles"] == roles && item[key] == true)
                            {
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }

        public static string GetMd5Hash(MD5 md5Hash, string input)
        {
            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

        public static string ConvertDateToStr(DateTime date)
        {

            string str = date.Date.ToString("dd/MM/yyyy");
            if (str == "01/01/0001")
            {
                return "";
            }
            else
            {
                return str;
            }
        }

        public static string ConvertDateToText(DateTime date)
        {

            string date_convert = date.Date.ToString("dd/MM/yyyy");
            if (date_convert == "01/01/0001")
            {
                return " Ngày .. tháng .. năm ....";
            }
            else
            {
                string str = "";
                str += " Ngày " + date.ToString("dd");
                str += " tháng " + date.ToString("MM");
                str += " năm " + date.ToString("yyyy");
                return str;
            }
        }

        public static string ConvertDateToFormView(DateTime date)
        {
          
            string str = date.Date.ToString("yyyy-MM-dd");
            return str;
            
        }
    }
}
