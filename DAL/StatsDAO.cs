using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    class StatsDAO
    {
        public List<StatsDM> ReadStats(string statement,
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
                    List<StatsDM> Statis = new List<StatsDM>();
                    while (data.Read())
                    {
                        StatsDM Stats = new StatsDM();
                        Stats.id = Convert.ToInt32(data["id"]);
                        Stats.DateID = Convert.ToInt32(data["DateID"]);
                        Stats.memberID = Convert.ToInt32(data["memberID"]);
                        Stats.carNumberID = Convert.ToInt32(data["carNumberID"]);
                        Stats.autoClassID = Convert.ToInt32(data["autoClassID"]);
                        Stats.runID = Convert.ToInt32(data["runID"]);
                        Stats.runTimeID = Convert.ToInt32(data["runTimeID"]);
                    }
                    return Statis;
                }
            }
        }
    }
}
