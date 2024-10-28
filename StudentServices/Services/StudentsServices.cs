using Microsoft.VisualBasic;
using System.ComponentModel;
using System.Data;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Security;
using Model.Shared;
using StudentServices.Class;




namespace StudentServices.Services
{
    public class StudentsServices
    {
        private readonly AppDb _constring;

        public StudentsServices(AppDb appDb)
        {
            _constring = appDb;
        }
        public async Task<List<Students>> StudentsList()
        {

            List<Students> lst = new();

            using (var con = new MySqlConnection(_constring.GetConnection()))
            {
                
                
                try
                {
                    await con.OpenAsync().ConfigureAwait(false);

                    var com = new MySqlCommand("Sproc_StudentList", con)
                    {

                        CommandType = CommandType.StoredProcedure

                    };
                    com.Parameters.Clear();

                    var rdr = await com.ExecuteReaderAsync().ConfigureAwait(false);

                    while (await rdr.ReadAsync().ConfigureAwait(false))
                    {

                        lst.Add(new Students
                        {
                            iD = rdr["ID"].ToString(),
                            date = Convert.ToDateTime(rdr["date"]),
                            studentID = rdr["StudentID"].ToString(),
                            category = rdr["category"].ToString(),
                            course = rdr["course"].ToString(),
                            lrn = rdr["lrn"].ToString(),
                            yearlevel = rdr["yearlevel"].ToString(),
                            year = rdr["Year"].ToString(),
                            enrollmentStatus = rdr["EnrollmentStatus"].ToString(),
                            semester = rdr["Semester"].ToString(),
                            lname = rdr["lname"].ToString(),
                            fname = rdr["fname"].ToString(),
                            middlename = rdr["middlename"].ToString(),
                            ext = rdr["ext"].ToString(),
                            gender = rdr["gender"].ToString(),
                            bdate = Convert.ToDateTime(rdr["bdate"]),
                            email = rdr["email"].ToString(),
                            address = rdr["address"].ToString(),
                            contactNO = rdr["contactNo"].ToString(),
                            guardian = rdr["Guardian"].ToString(),
                            gaddress = rdr["Gaddress"].ToString(),
                            gContactNO = rdr["GContactNO"].ToString(),
                            preenrolled = Convert.ToBoolean(rdr["preenrolled"]),
                            note = rdr["note"].ToString()



                        });
                    }
                    await rdr.CloseAsync().ConfigureAwait(false);
                }
                 catch (Exception ex)
                {
                    
                }
                finally { await con.CloseAsync().ConfigureAwait(false); }
                return lst;
            }
        }
    } 
}           
               
            

        
    



