using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoFiller_APP.Model
{
    public class ServerConfigModel
    {
        public string sql_server_name { get; set; }
        public string database_name { get; set; }
        public string sql_user_id { get; set; }
        public string sql_password { get; set; }
        public string web_server_url { get; set; }
        public string jotform_url { get; set; }
        public string jotform_api_key { get; set; }
        public long jotform_id { get; set; }
    }
}
