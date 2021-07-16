using PCS.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;


namespace PCS.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [AllowAnonymous]
    public class CalendarController : ApiController
    {
        // GET: api/Calendar
        public IHttpActionResult GetClander()
        {

            var connection = new SQLconnection().connect();

            SqlCommand command = new SqlCommand();
            command.Connection = connection; 
            command.CommandText = "select * from Calendar";
            var calendar_reader = command.ExecuteReader();

            List<Calendar> calendar_list = new List<Calendar>();

            if (calendar_reader.HasRows) 
            {
                while (calendar_reader.Read())
                {
                    Calendar data = new Calendar();
                    data.Id = calendar_reader.GetInt32(1);
                    data.Date = calendar_reader["Date"].ToString();
                    data.Title = calendar_reader["Title"].ToString();
                    data.Content = calendar_reader["Content"].ToString();
                    calendar_list.Add(data);
                }   
            }

            //第五部:Close database connection
            connection.Close();
            return Ok(calendar_list);
        }

        // GET: api/Calendar/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Calendar
        public string PostCalendar (Calendar data)
        {
            try
            {

                var connection = new SQLconnection().connect();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                string commandString = "insert into Calendar (Date,Title,Content) output inserted.Id values('{0}','{1}','{2}'); ";
                commandString = string.Format(commandString, data.Date, data.Title, data.Content);
                command.CommandText = commandString;

                //Execute non-query sql statement
                var f = command.ExecuteScalar();
                if (f != null)
                {
                    return f.ToString();
                }
                else
                {
                    return "fail";
                }

            }
            catch (Exception es)
            {
                return es.Message;
            }
        }

        // PUT: api/Calendar/5
        public void Put(Calendar data)
        {

        }

        // DELETE: api/Calendar/5
        public string Delete(string Id)
        {

            try
            {
                int id = Int32.Parse(Id);
                var connection = new SQLconnection().connect();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                string commandString = "delete from Calendar where Id = {0}";
                commandString = string.Format(commandString, id);
                command.CommandText = commandString;

                //Execute non-query sql statement
                var f = command.ExecuteNonQuery();
                if (f != 0)
                {
                    return "ok" ;
                }
                else
                {
                    return "fail";
                }

            }
            catch (Exception es)
            {
                return es.Message;
            }



        }
    }
}
