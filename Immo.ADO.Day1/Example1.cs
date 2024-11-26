using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;

namespace Immo.ADO.Day1
{
    public class Example1 : IDisposable
    {
        SqlConnection con = null;
        SqlCommand cmd = null;
        SqlDataReader reader = null;

        //Dispose
        protected bool Disposed { get; set; } = true;

        public void ConnectedExample()
        {
            SqlConnection con = new SqlConnection();
            //con.ConnectionString = "Server=EGAIK-LAPTOP; Database=QuickKartDB; User Id=sa; Password=MyPassword";
            con.ConnectionString = "Server=EGAIK-LAPTOP; Database=QuickKartDB; Integrated Security=true;";
            SqlCommand cmd = new SqlCommand()
            {
                CommandText = "Select * from Products",
                Connection = con
            };

            //Open Connection
            con.Open();
            //Read the Data
            SqlDataReader reader = cmd.ExecuteReader();
            //Read First Row
            reader.Read();
            //Display the records
            Console.WriteLine($"Product Id :{reader[0]}");
            Console.WriteLine($"Product Name :{reader[1]}");
            Console.WriteLine($"Price :{reader["Price"]}");
            reader.Close();
            cmd.Dispose();
            con.Close();
        }

        public void AnotherExample()
        {
            using (con = new SqlConnection(ConfigurationManager.ConnectionStrings["QuickCon"].ConnectionString))
            {
                using (cmd = new SqlCommand("Select * from CardDetails", con))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    reader.Read();
                    Console.WriteLine($"Card No :{reader[0]}");
                    Console.WriteLine($"Card Name :{reader[1]}");
                    Console.WriteLine($"Balance :{reader["Balance"]}");
                }
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
            this.Disposing(Disposed);
        }

        protected virtual void Disposing(bool disposing)
        {
            if (disposing)
            {
                reader.Dispose();
                cmd?.Dispose();
                con?.Close();
                con?.Dispose();
            }
            Disposed = false;
        }
    }

    public class FileClass : Example1
    {
        FileStream fs = new FileStream("Ex1.txt", FileMode.Append, FileAccess.Write);
        protected override void Disposing(bool disposing)
        {
            if (disposing)
            {
                fs.Close();
                fs?.Dispose();
            }
            Disposed = false;
        }
    }
}
