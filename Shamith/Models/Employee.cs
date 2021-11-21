using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace Shamith.Models
{
    public class Employee
    {
        private string conStr;
        public Employee()
        {
            //conStr = @"Persist Security Info = False;User ID=LAPTOP-FCM9TLAI\user;password = ;Initial Catalog= ToDo; Data Source=LAPTOP-FCM9TLAI\\SQLEXPRESS ;Connection Timeout = 10000; ";

            conStr = "Data Source=LAPTOP-FCM9TLAI\\SQLEXPRESS; Initial Catalog= ToDo;  Integrated Security = True;";
      
        }

        public IDbConnection Connection
        {
            get 
            {
                return new SqlConnection(conStr);
            }
        }

        //Insert
        public void Add(Uoj uoj)
        {
            using(IDbConnection dbConnection = Connection)
            {
                string sql = @"INSERT INTO Uoj (Todo_Id,Title,Sub_Title,Date)
                               VALUES(@Todo_Id,@Title,@Sub_Title,@Date)";
                dbConnection.Open();
                dbConnection.Execute(sql, uoj);
            }
        }

        //Get All
        public IEnumerable<Uoj>GetAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sql = @"SELECT * FROM Uoj";
                dbConnection.Open();
                return dbConnection.Query<Uoj>(sql);
            }
        }

        //Update
        public void Update(Uoj uoj)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sql = @"UPDATE Uoj SET Title = @Title ,Sub_Title = @Sub_Title,Date = @date WHERE Todo_Id = @Todo_Id";
                dbConnection.Open();
                dbConnection.Query(sql,uoj);
            }
        }

        //Delete
        public void Delete(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sql = @"DELETE From Uoj WHERE Todo_Id = @id";
                dbConnection.Open();
                dbConnection.Query(sql, new {Id = id});
            }
        }
    }
}
