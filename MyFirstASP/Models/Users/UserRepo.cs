using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstASP.Models.Users
{
    public class UserRepo
    {
        string conSTR = "Data Source=SQL5080.site4now.net;Initial Catalog=db_a7920a_mkonjibhu;User Id=db_a7920a_mkonjibhu_admin;Password=QwertyuioP123";
        public void Autorez(User new_user)
        {        
            using (IDbConnection db = new SqlConnection(conSTR))
            {
                db.Open();
                using (var transaction = db.BeginTransaction())
                {
                    try
                    {
                        var sqlQuery = "exec [AddAuto] @Date , @Time, @IP ";
                        var values = new
                        {
                            Date = new_user.Date,
                            Time = new_user.Time,
                            IP = new_user.IP
                        };
                        db.Query(sqlQuery, values, transaction);
                        transaction.Commit();                 
                    }
                    catch (Exception) {  transaction.Rollback();  }
                }
            }
          
        }
    }
}
