using Immo.ADO.Day1.Models;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Immo.ADO.Day1
{

    internal class DisconnectedCRUD
    {
        private SqlConnection _conn = null;
        private SqlDataAdapter _adapter = null;
        private SqlDataAdapter _adapter1 = null;
        private DataSet _ds = null;
        private DataTable _dt = null;
        private SqlCommandBuilder _builder = null;

        public DisconnectedCRUD()
        {
            _ds = new DataSet();
        }
        public DataSet GetData()
        {
            _conn = new SqlConnection(ConfigurationManager.ConnectionStrings["QuickCon"].ConnectionString);

            _adapter = new SqlDataAdapter("Select * from Products", _conn);
            _builder = new SqlCommandBuilder(_adapter);
            _adapter.Fill(_ds, "Product");

            using (_adapter1 = new SqlDataAdapter("Select * from Categories", _conn))
            {
                _adapter1.Fill(_ds, "Category");
            }

            return _ds;
        }

        public void GetProducts()
        {
            //  var products = ds.Tables["Product"];
            var dsProducts = GetData().Tables["Product"];
            Console.WriteLine($"Product Id :{dsProducts.Rows[0]["ProductId"]}");
            Console.WriteLine($"Product Name :{dsProducts.Rows[0][1]}");
        }

        //Get Product using LINQ
        public void GetAllProducts()
        {
            var _dt = GetData().Tables["Product"];
            var products = _dt.AsEnumerable()
                                       .Select(x => new Product
                                       {
                                           ProductId = x.Field<string>("ProductId"),
                                           ProductName = x.Field<string>("ProductName"),
                                           Price = x.Field<decimal>("Price")
                                       }).ToList();

            //get all products
            foreach (var product in products)
            {
                Console.WriteLine($"Id :{product.ProductId}\tName :{product.ProductName}\tPrice :{product.Price}");
            }
        }

        //Get Product based on Prices
        public void GetProduct(decimal fromPrice, decimal toPrice)
        {
            var _dt = GetData().Tables["Product"];
            var products = _dt.AsEnumerable()
                                       .Select(x => new Product
                                       {
                                           ProductId = x.Field<string>("ProductId"),
                                           ProductName = x.Field<string>("ProductName"),
                                           Price = x.Field<decimal>("Price")
                                       })
                                       .ToList();
           // var oneProcduct = products.FirstOrDefault(x => x.ProductId == "P101");
            var finalProduct = products.Where(p => p.Price >= fromPrice && p.Price <= toPrice).OrderBy(x => x.Price);

            //get all products
            Console.WriteLine($"Product Id\tProduct Name\t\t\t\t\tPrice");
            Console.WriteLine("------------------------------------------------------------------------------------");
            foreach (var product in finalProduct)
            {
                Console.WriteLine($"{product.ProductId,-10}\t{product.ProductName,-40}\t{product.Price}");
            }
        }

        //Create new product using Sqlcommandbuilder
        public void InsertProduct(Product product)
        {
            var _dt = GetData().Tables["Product"];
            DataRow dr = _dt.NewRow();//
            dr["ProductId"] = product.ProductId;
            dr["ProductName"] = product.ProductName;
            dr["Price"] = product.Price;
            dr["CategoryId"] = product.CategoryId;
            dr["QuantityAvailable"] = product.Quantity;
            _dt.Rows.Add(dr);
            //Update to DB
            _adapter.Update(_dt);
        }

        //Update Product
        public void UpdateProduct(string productId, decimal price)
        {
            var _dt = GetData().Tables["Product"];

            //Set Primary Key           
            _dt.PrimaryKey = new DataColumn[1] { _dt.Columns["ProductId"] };

            var dataRow = _dt.Rows.Find(productId);
            dataRow.BeginEdit();
            dataRow["Price"] = price;
            dataRow.EndEdit();
            _adapter.Update(_dt);
        }

        //Delete Product
        public void DeleteProduct(string productId)
        {
            var _dt = GetData().Tables["Product"];
            _dt.PrimaryKey = new DataColumn[1] { _dt.Columns["ProductId"] };
            var dataRow = _dt.Rows.Find(productId);
            dataRow?.Delete();
            //var dr = _dt.Select("Price > 50000");
            //foreach (DataRow row in dr)
            //{
            //    row.Delete();
            //}         
            _adapter.Update(_dt);
        }

        //Get XML from Dataset
        public void GetXML()
        {
            var ds = GetData();
            ds.WriteXml("Product.xml");
        }
    }
}


