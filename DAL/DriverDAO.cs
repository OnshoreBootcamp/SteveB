using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    class DriverDAO
    {
        public List<DriverDM> ReadDriver(string statement, SqlParameter[] parameters)
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
                    List<DriverDM> drivers = new List<DriverDM>();
                    while (data.Read())
                    {
                        DriverDM driver = new DriverDM();
                        driver.id = Convert.ToInt32(data["id"]);
                        driver.DateId = Convert.ToInt32(data["DateId"]);
                        driver.lastNameId = Convert.ToInt32(data["lastNameId"]);
                        driver.firstNameId = Convert.ToInt32(data["firstNameId"]);
                        driver.carNumber = data["carNumberId"].ToString();
                        driver.autoClass = data["autoClassId"].ToString();
                        drivers.Add(driver);
                    }
                    try
                    {
                        return drivers;
                    }
                    catch (Exception e)
                    {
                        return null;
                    }
                }
            }
        }
        public void CreateDriver(int DateId, int lastNameId, int firstNameId, int carNumberId, int autoClassId)
        {
            DAO dao = new DAO();
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@DateId",DateId),
                new SqlParameter("@LastNameId",lastNameId),
                new SqlParameter("@FirstNameId",firstNameId),
                new SqlParameter("@CarNumberId",carNumberId),
                new SqlParameter("@AutoClassId",autoClassId),
            };
            dao.Write("CreateDriver", parameters);
        }
        public void DeleteDriver(int id)
        {
            DAO dao = new DAO();
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Id",id)
            };
            dao.Write("DeleteDriverById", parameters);
        }
        public List<DriverDM> GetAllDriver()
        {
            List<DriverDM> allDrivers = ReadDriver("GetAllDrivers", null);
            if (allDrivers != null)
            {
                return allDrivers;
            }
            else
            {
                allDrivers.Take(0).ToList();
                return allDrivers;
            }
        }
        public DriverDM GetDriver(int DateId, int lastNameId, int firstNameId, int carNumberId, int autoClassId)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@DateId",DateId),
                new SqlParameter("@LastNameId",lastNameId),
                new SqlParameter("@FirstNameId",firstNameId),
                new SqlParameter("@CarNumberId",carNumberId),
                new SqlParameter("@AutoClassId",autoClassId),
            };
            DriverDM us = new DriverDM();
            List<DriverDM> driver = new List<DriverDM>();
            driver = ReadDriver("GetDriver", parameters);
            foreach (DriverDM driverDm in driver)
            {
                us = driverDm;
            }
            return us;
        }
        public DriverDM GetDriverById(int id)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Id",id)
            };
            return ReadDriver("GetDriverById", parameters).SingleOrDefault();
        }
        public void UpdateDriverDB(int id, int DateId, int lastNameId, int firstNameId, int carNumberId, int autoClassId)
        {
            DAO dao = new DAO();
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@DateId",DateId),
                new SqlParameter("@LastNameId",lastNameId),
                new SqlParameter("@FirstNameId",firstNameId),
                new SqlParameter("@CarNumberId",carNumberId),
                new SqlParameter("@AutoClassId",autoClassId),
            };
            dao.Write("UpdateDriver", parameters);
        }
        public bool DoesDriverExist(int id)
        {
            if (id != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

