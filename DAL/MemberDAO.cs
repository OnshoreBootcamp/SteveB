using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class MemberDAO
     {
        public List<MemberDM> ReadMember(string statement, SqlParameter[] parameters)
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
                    List<MemberDM> members = new List<MemberDM>();
                    while (data.Read())
                    {
                        MemberDM member = new MemberDM();
                        member.id = Convert.ToInt32(data["id"]);
                        member.lastName = data["lastname"].ToString();
                        member.firstName = data["firstName"].ToString();
                        member.street = data["street"].ToString();
                        member.city = data["city"].ToString();
                        member.state = data["state"].ToString();
                        member.zip = Convert.ToInt32(data["zip"]);
                        member.phone = Convert.ToInt32(data["phone"]);
                        member.email = data["email"].ToString();
                        members.Add(member);
                    }
                    try
                    {
                        return members;
                    }
                    catch (Exception)
                    {
                        return null;
                    }
                }
            }
        }

        public List<MemberDM> GetAllMembers()
        {
            return ReadMember("GetAllMembers", null);
        }
        public void CreateMember(MemberDM dm)
        {
            DAO dao = new DAO();
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@lastName", dm.lastName),
                new SqlParameter("@firstName", dm.firstName),
                new SqlParameter("@street", dm.street),
                new SqlParameter("@city", dm.city),
                new SqlParameter("@state",dm.state),
                new SqlParameter("@zip", dm.zip),
                new SqlParameter("@phone",dm.phone),
                new SqlParameter("@email",dm.email)
            };
            dao.Write("CreateMember", parameters);
        }


        public void DeleteMember(int id)
        {
            DAO dao = new DAO();
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@id",id),
            };
            dao.Write("DeleteMemberById", parameters);
        }

        public MemberDM GetMemberById(int id)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Id",id)
            };
            return ReadMember("GetMemberById", parameters).SingleOrDefault();
        }

        public MemberDM GetMember(MemberDM dm)
        {
            SqlParameter[] parameters = new SqlParameter[]
                {
                new SqlParameter("@lastName", dm.lastName),
                new SqlParameter("@firstName", dm.firstName),
                new SqlParameter("@street", dm.street),
                new SqlParameter("@city", dm.city),
                new SqlParameter("@state",dm.state),
                new SqlParameter("@zip", dm.zip),
                new SqlParameter("@phone",dm.phone),
                new SqlParameter("@email",dm.email)
                };
            MemberDM mo = new MemberDM();
            List<MemberDM> movie = new List<MemberDM>();
            movie = ReadMember("GetMember", parameters);
            foreach (MemberDM movieDm in movie)
            {
                mo = movieDm;
            }
            return mo;
        }
         public void UpdateMemberDB(MemberDM dm)
         {
             DAO dao = new DAO();
             SqlParameter[] parameters = new SqlParameter[]
               {
                new SqlParameter("@id", dm.id),
                new SqlParameter("@lastName", dm.lastName),
                new SqlParameter("@firstName", dm.firstName),
                new SqlParameter("@street", dm.street),
                new SqlParameter("@city", dm.city),
                new SqlParameter("@state",dm.state),
                new SqlParameter("@zip", dm.zip),
                new SqlParameter("@phone",dm.phone),
                new SqlParameter("@email",dm.email)
                };
             dao.Write("UpdateMember", parameters);
         }
    }
}
     

