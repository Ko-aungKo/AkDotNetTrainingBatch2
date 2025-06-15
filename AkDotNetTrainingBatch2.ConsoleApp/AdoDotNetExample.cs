using Microsoft.Data.SqlClient;
using System;
using System.Data;

namespace AkDotNetTrainingBatch2.ConsoleApp
{
    public class AdoDotNetExample
    {

        SqlConnectionStringBuilder _sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
        {
            DataSource = ".",
            InitialCatalog = "DotNetTrainingBatch2",
            UserID = "sa",
            Password = "sasa@123",
            TrustServerCertificate = true
        };
        public void Read()
        {
            //    SqlConnectionStringBuilder sqlConnectionString = new SqlConnectionStringBuilder();
            //    sqlConnectionString.DataSource = ".";
            //    sqlConnectionString.InitialCatalog = "DotNetTrainingBatch2";
            //    sqlConnectionString.UserID = "sa";
            //    sqlConnectionString.Password = "sasa@123";
            //    sqlConnectionString.TrustServerCertificate = true;

                SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);

            connection.Open();
            Console.WriteLine("Database open");

            string query = "select * from Tbl_Blog";
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            connection.Close();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow row = dt.Rows[i];
                Console.WriteLine(i);
                Console.WriteLine("BlogId => " + row["BlogId"]);
                Console.WriteLine("BlogTitle => " + row["BlogTitle"]);
                Console.WriteLine("BlogAuthor => " + row["BlogAuthor"]);
                Console.WriteLine("BlogContent => " + row["BlogContent"]);
            }

        }
        public void Edit()
        {
            Console.Write("Enter Id: ");
            string blogId = Console.ReadLine()!;

        SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
        connection.Open();

        string query = $"select * from Tbl_Blog Where BlogId = @BlogId";
        SqlCommand cmd = new SqlCommand(query, connection);
        cmd.Parameters.AddWithValue("@BlogId", blogId);

        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adapter.Fill(dt);

            connection.Close();

            for (int i = 0; i<dt.Rows.Count; i++)
            {
                DataRow row = dt.Rows[i];
        Console.WriteLine(i);
                Console.WriteLine("BlogId => " + row["BlogId"]);
                Console.WriteLine("BlogTitle => " + row["BlogTitle"]);
                Console.WriteLine("BlogAuthor => " + row["BlogAuthor"]);
                Console.WriteLine("BlogContent => " + row["BlogContent"]);
            }
}

        public void Create()
        {
            Console.Write("Enter Title: ");
            string title = Console.ReadLine()!;

        Console.Write("Enter Author: ");
            string author = Console.ReadLine()!;

        Console.Write("Enter Content: ");
            string content = Console.ReadLine()!;
        string query = $@"INSERT INTO [dbo].[Tbl_Blog]
           ([BlogTitle]
           ,[BlogAuthor]
           ,[BlogContent])
     VALUES
           (@Title
           ,@Author
           ,@Content)";

        SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
        connection.Open();

            SqlCommand cmd = new SqlCommand(query, connection);
        cmd.Parameters.AddWithValue("@Title", title);
            cmd.Parameters.AddWithValue("@Author", author);
            cmd.Parameters.AddWithValue("@Content", content);
            int result = cmd.ExecuteNonQuery();

        connection.Close();

            Console.WriteLine(result > 0 ? "Insert Success!" : "Insert Failed!");
        }
        public void Update()
        {
            Console.Write("Enter BlogId to update: ");
            string blogId = Console.ReadLine()!;

            Console.Write("Enter New Title: ");
            string title = Console.ReadLine()!;

            Console.Write("Enter New Author: ");
            string author = Console.ReadLine()!;

            Console.Write("Enter New Content: ");
            string content = Console.ReadLine()!;
            string query = @"UPDATE Tbl_Blog 
                     SET BlogTitle = @Title, 
                         BlogAuthor = @Author, 
                         BlogContent = @Content 
                     WHERE BlogId = @BlogId";

            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
        connection.Open();

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@Title", title);
            cmd.Parameters.AddWithValue("@Author", author);
            cmd.Parameters.AddWithValue("@Content", content);
            cmd.Parameters.AddWithValue("@BlogId", blogId);

            int result = cmd.ExecuteNonQuery();

            connection.Close();

            Console.WriteLine(result > 0 ? "Update Success!" : "Update Failed!");
        }

        public void Delete()
        {
            Console.Write("Enter BlogId to delete: ");
            string blogId = Console.ReadLine()!;

            string query = @"DELETE FROM Tbl_Blog WHERE BlogId = @BlogId";

            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            connection.Open();

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@BlogId", blogId);

            int result = cmd.ExecuteNonQuery();


            connection.Close();

            Console.WriteLine(result > 0 ? "Delete Success!" : "Delete Failed!");
        }

}


}
