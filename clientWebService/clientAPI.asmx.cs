using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;
using Newtonsoft.Json;

namespace clientWebService
{
    /// <summary>
    /// Summary description for clientAPI
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class clientAPI : System.Web.Services.WebService
    {
        DBAccess db = new DBAccess();
        DataTable dt = new DataTable();

        // The below functions uses the dbaccess class and serach by stock id

        [WebMethod]
        public string usersDT(string symbol)
        {
            string query = @"Select * From Stocks Where StockSymbol= '" + symbol + "' ";
            db.readDatathroughAdapter(query, dt);
            string result = JsonConvert.SerializeObject(dt);

            return result;

        }


        // The below function uses date ranges and stored procedure
        [WebMethod]
        //public string UsersDateSearch(DateTime startDate, DateTime endDate)
        //{
        //    //A list of type "Stocks"
        //    List<Stocks> listStocks = new List<Stocks>();

        //    //Make a connection our db via stored procedure
        //    string cs = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
        //    using (SqlConnection con = new SqlConnection(cs))
        //    {
        //        SqlCommand cmd = new SqlCommand();
        //        cmd.Connection = con;
        //        cmd.CommandType = System.Data.CommandType.StoredProcedure;
        //        //Put the name of the stored procedure 
        //        cmd.CommandText = "UserDateSearch";

        //        //Assign stored procedure parameters to our function parametres 
        //        cmd.Parameters.Add(new SqlParameter("@StartDate", Convert.ToDateTime(startDate)));
        //        cmd.Parameters.Add(new SqlParameter("@EndDate", Convert.ToDateTime(endDate)));

        //        con.Open();
        //        SqlDataReader rdr = cmd.ExecuteReader();
        //        // while we haven't reach the end of the table, do the following staements
        //        while (rdr.Read())
        //        {

        //            Stocks stock = new Stocks();

        //            stock.date = Convert.ToDateTime(rdr["date"]);
        //            stock.StockSymbol = rdr["StockSymbol"].ToString();
        //            stock.StockPriceOpen = (float)Convert.ToDouble(rdr["StockPriceOpen"]);
        //            stock.StockPriceClose = (float)Convert.ToDouble(rdr["StockPriceClose"]);
        //            stock.StockPriceIo = (float)Convert.ToDouble(rdr["StockPriceIo"]);
        //            stock.StockPriceHigh = (float)Convert.ToDouble(rdr["StockPriceHigh"]);
        //            stock.StockPriceAdjClose = (float)Convert.ToDouble(rdr["StockPriceAdjClose"]);
        //            stock.StockVolume = Convert.ToInt32(rdr["StockVolume"]);
        //            stock.StockExchange = rdr["StockExchange"].ToString();


        //            listStocks.Add(stock);
        //        }
        //    }
        public string UsersDateSearch(DateTime startDate, DateTime endDate)
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString);
            SqlCommand cmd = new SqlCommand("UserDateSearch", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            con.Open();
            cmd.Parameters.AddWithValue("@StartDate", startDate);
            cmd.Parameters.AddWithValue("@EndDate", endDate);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            cmd.ExecuteNonQuery();
            con.Close();
            return JsonConvert.SerializeObject(dt);
        }



            //JavaScriptSerializer js = new JavaScriptSerializer();
            //Context.Response.Write(js.Serialize(listStocks));
            //string query = @"Select * From Products Where Date='" + startDate + "'";
            //objDBAccess.readDatathroughAdapter(query, usersDT);
            //string result = JsonConvert.SerializeObject(usersDT);
            //return result;
            //string query = @"Select * From Products Where Date='" + startDate + "'";
            //objDBAccess.readDatathroughAdapter(query, usersDT);
            //return JsonConvert.SerializeObject(listStocks);
            //return result;
        
    }

}









