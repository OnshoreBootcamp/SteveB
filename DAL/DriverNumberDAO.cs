using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DriverNumberDAO
    {
        public List<DriverNumberDM> ReadDriverNumber(string statement,
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
                    List<DriverNumberDM> numbers = new List<DriverNumberDM>();
                    while (data.Read())
                    {
                        DriverNumberDM number = new DriverNumberDM();
                        number.id = Convert.ToInt32(data["id"]);
                        number.carNumberID = Convert.ToInt32(data["carNumberID"]);
                        numbers.Add(number);
                    }
                    try
                    {
                        return numbers;
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
