using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PCS
{
    public class SQLconnection
    {
        public SqlConnection connect()
        {
            
    //第一步:新建連接對象
        SqlConnection connection = new SqlConnection();
    /*
        Data source: 服務器名稱
        Initial Catalog: 哪個數據庫
     */
            //第二步:Specify parameters for the link object
            connection.ConnectionString = "Data Source=roger;Initial Catalog=PCS;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework";

            //第三部:Start linking
            if (connection.State != System.Data.ConnectionState.Open) //Determine if the database is connected
            {
                connection.Open();
            }
            return connection;
        }
    }
}