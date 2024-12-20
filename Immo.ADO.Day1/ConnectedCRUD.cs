﻿using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Immo.ADO.Day1
{
    public class ConnectedCRUD : IDisposable
    {
        private SqlConnection _conn = null;
        private SqlCommand _command = null;
        private SqlDataReader _reader = null;

        public ConnectedCRUD()
        {
            _conn = new SqlConnection(ConfigurationManager.ConnectionStrings["QuickCon"].ConnectionString);
        }
        protected bool Disposed { get; set; } = true;

        public void Dispose()
        {
            GC.SuppressFinalize(this);
            this.Disposing(Disposed);
        }

        protected virtual void Disposing(bool disposing)
        {
            if (disposing)
            {
                _reader?.Close();
                _command?.Dispose();
                _conn?.Close();
                _conn?.Dispose();
            }
            Disposed = false;
        }

        //Read from Database
        public void GetProductByCategoryId(int categoryId)
        {
            using (_conn = new SqlConnection(ConfigurationManager.ConnectionStrings["QuickCon"].ConnectionString))
            {
                using (_command = new SqlCommand("usp_GetProductbyCategoryId", _conn))
                {
                    _command.CommandType = CommandType.StoredProcedure;
                    //_command.Parameters.AddWithValue("@categoryId", categoryId);
                    SqlParameter catParam = new SqlParameter("@categoryId", SqlDbType.TinyInt)
                    {
                        Value = categoryId
                    };

                    _command.Parameters.Add(catParam);

                    if (_conn.State == ConnectionState.Closed)
                    {
                        _conn.Open();
                    }
                    _reader = _command.ExecuteReader(CommandBehavior.CloseConnection);
                    if (_reader.HasRows)
                    {
                        _reader.Read();
                        Console.WriteLine($"Product Name :{_reader[0]}");
                        Console.WriteLine($"Category Name :{_reader[1]}");
                        Console.WriteLine($"Price :{_reader[2]}");
                    }
                    else
                    {
                        Console.WriteLine($"No Record found!");
                    }
                }
            }
        }

        //Create New Row - usp_CreaeteNewProduct
        public void CreateNewProduct(string productId, string productName, byte categoryId, int price, int quantity)
        {
            using (_conn = new SqlConnection(ConfigurationManager.ConnectionStrings["QuickCon"].ConnectionString))
            {
                using (_command = new SqlCommand("usp_CreaeteNewProduct", _conn))
                {
                    _command.CommandType = CommandType.StoredProcedure;
                    //Pass all the parameters
                    _command.Parameters.AddWithValue("@ProductId", productId);
                    _command.Parameters.AddWithValue("@ProductName", productName);
                    _command.Parameters.AddWithValue("@CategoryId", categoryId);
                    _command.Parameters.AddWithValue("@Price", price);
                    _command.Parameters.AddWithValue("@Quantity", quantity);
                    if (_conn.State == ConnectionState.Closed)
                    {
                        _conn.Open();
                    }
                    var result = _command.ExecuteNonQuery();
                    if (result == 1)
                    {
                        Console.WriteLine("Product created successfully");
                    }
                    else
                    {
                        Console.WriteLine("Failed to Creare Procduct");
                    }
                }
            }
        }

        //Multiple Active Result sets
        public void GetProductAndCategory()
        {
            using (_command = new SqlCommand("Select * from Products", _conn))
            {
                if (_conn.State == ConnectionState.Closed) _conn.Open();
                _reader = _command.ExecuteReader();
                while (_reader.Read())
                {
                    Console.WriteLine($"Product Id :{_reader[0]}\tName :{_reader[1]}");
                }
            }

            using (_command = new SqlCommand("Select * from Categories", _conn))
            {
                if (_conn.State == ConnectionState.Closed) _conn.Open();
                _reader = _command.ExecuteReader();
                while (_reader.Read())
                {
                    Console.WriteLine($"Category Id :{_reader[0]}\tName :{_reader[1]}");
                }
            }
        }

        //NextResult
        public void GetMultipleTable()
        {
            using (_command = new SqlCommand("Select * from Products; Select * from Categories", _conn))
            {
                if (_conn.State == ConnectionState.Closed) _conn.Open();
                _reader = _command.ExecuteReader();
                while (_reader.Read())
                {
                    Console.WriteLine($"Product Id :{_reader[0]}\tName :{_reader[1]}");
                }
                //Read the second table
                _reader.NextResult();
                Console.WriteLine("--------------Category Table-----------------");
                while (_reader.Read())
                {
                    Console.WriteLine($"Category Id :{_reader[0]}\tName :{_reader[1]}");
                }
            }
        }

        //Scalar
        public void UseExecuteScalar()
        {
            //using (_command = new SqlCommand("Select * from Products;", _conn))
            using (_command = new SqlCommand("Select sum(Price) from Products;", _conn))
            {
                if (_conn.State == ConnectionState.Closed) _conn.Open();
                decimal sumOfPrice = (decimal)_command.ExecuteScalar();
                Console.WriteLine("Total Price :" + sumOfPrice);
            }
        }
    }
}
