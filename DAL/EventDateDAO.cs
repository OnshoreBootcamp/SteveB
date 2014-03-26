using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class EventDateDAO
    {
        public List<EventDateDM> ReadEventDate(string statement,
           SqlParameter[] parameters)
        {
            using (SqlConnection connection = new SqlConnection(
                @"Data Source=.\SQLEXPRESS;Initial Catalog=Autocross;
                Integrated Security=SSPI;"))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(statement, connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters);
                    }
                    SqlDataReader data = command.ExecuteReader();
                    List<EventDateDM> Dates = new List<EventDateDM>();
                    while (data.Read())
                    {
                        EventDateDM Date = new EventDateDM();
                        Date.id = Convert.ToInt32(data["id"]);
                        Date.Date = Convert.ToDateTime(data["Date"]);
                        Dates.Add(Date);
                    }
                    try
                    {
                        return Dates;
                    }
                    catch
                    {
                        return null;
                    }
                }
            }
        }
        public List<EventDateDM> GetAllEventDates()
        {
            return ReadEventDate("GetAllEventDates", null);
        }
        public void CreateEventDate(EventDateDM dm)
        {
            DAO dao = new DAO();
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Date", dm.Date),
            };
            dao.Write("CreateEventDate", parameters);
        }
        public List<EventDateDM> GetAllEventDates()
        {
            return ReadEventDate("GetAllEventDates", null);
        }


        public EventDateDM GetEventDateById(int id)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Id",id)
            };
            return ReadEventDate("GetEventDateById", parameters).SingleOrDefault();
        }


        public void UpdateEventDateDB(EventDateDM dm)
        {
            DAO dao = new DAO();
            SqlParameter[] parameters = new SqlParameter[]
               {
                new SqlParameter("@id", dm.id),
                new SqlParameter("@Date", dm.Date),
              
                };
            dao.Write("UpdateEventDate", parameters);
        }
    }
}

