using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helper
{
    public class DBHelper
    {
        private static readonly string SqlConnection = @"Data Source=172.31.27.22\Sql2012;Initial Catalog=Lks;Persist Security Info=True;User ID=kaifa;Password=[LksDev.KaiFa.~~!!QQ];Max Pool Size=10000;MultipleActiveResultSets=True;Connect Timeout=60";


        public static void Insert()
        {
            IDbConnection connection = new SqlConnection(SqlConnection);
            var result = connection.Execute("Insert into Users values (@UserName, @Email, @Address)",
                                   new { UserName = "jack", Email = "380234234@qq.com", Address = "上海" });
        }
    }
}
