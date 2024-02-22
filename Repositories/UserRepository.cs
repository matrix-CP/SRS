using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Npgsql;
using NpgsqlTypes;
using SRS.Models;

namespace SRS.Repositories
{
    public class UserRepository : CommonRepository, IUserRepository
    {
        public void Register(tblUser user)
        {
            using (conn)
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand("INSERT INTO t_user(c_username, c_email, c_password) VALUES(@username, @email, @password)", conn))
                {
                    cmd.Parameters.AddWithValue("@username", user.c_username);
                    cmd.Parameters.AddWithValue("@email", user.c_email);
                    cmd.Parameters.AddWithValue("@password", user.c_password);
                    cmd.ExecuteNonQuery();
                }
                conn.Close();
            }
        }
        public tblUser Login(tblUser user)
        {
            tblUser user2=new tblUser();
            using (conn)
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand("SELECT c_userid,c_email FROM t_user WHERE c_email = @email AND c_password = @password;", conn))
                {
                    cmd.Parameters.AddWithValue("@email", user.c_email);
                    cmd.Parameters.AddWithValue("@password", user.c_password);

                    DataTable td = new DataTable();
                    td.Load(cmd.ExecuteReader());
                    
                    if (td.Rows.Count == 1)
                    {
                        
                        user2.c_userid = Convert.ToInt32(td.Rows[0]["c_userid"]);
                        user2.c_email = td.Rows[0]["c_email"].ToString();
                        return user2;
                    }
                    user2.c_userid = 0;
                    conn.Close();
                    
                }
            }
            return user2;
        }
    }
}