using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    class AutoClassDAO
    {
        public List<AutoClassDM> Read(string statement, SqlParameter[] parameters)
        {
            using (SqlConnection connection = new SqlConnection(
                @"Data Source=.\SQLEXPRESS;Initial Catalog=AutocrossDB;Integrated Security=SSPI;"))
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
                    List<AutoClassDM> Classes = new List<AutoClassDM>();
                    while (data.Read())
                    {
                        AutoClassDM Class = new AutoClassDM();
                        Class.id = Convert.ToInt32(data["id"]);
                        Class.autoClass = data["autoClass"].ToString();
                    }
                    return Classes;
                }
            }

        }
    }
}
