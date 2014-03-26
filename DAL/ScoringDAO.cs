using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    class ScoringDAO
    {
        public List<ScoringDM> ReadScoring(string statement,
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
                    List<ScoringDM> Score = new List<ScoringDM>();
                    while (data.Read())
                    {
                        ScoringDM Scoring = new ScoringDM();
                        Scoring.id = Convert.ToInt32(data["id"]);
                        Scoring.DateID = Convert.ToInt32(data["DateID"]);
                        Scoring.memberID = Convert.ToInt32(data["memberID"]);
                        Scoring.carNumberID = Convert.ToInt32(data["carNumberID"]);
                        Scoring.autoClassID = Convert.ToInt32(data["autoClassID"]);
                        Scoring.run = data["runID"].ToString();
                        Scoring.runTime = Convert.ToDecimal(data["runTimeID"]);
                    }
                    try
                    {
                        return Score;
                    }
                    catch (Exception)
                    {
                        return null;
                    }
                }
            }
        }
    }
}

