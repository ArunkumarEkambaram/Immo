using System;

namespace Immo.ADO.Day1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region MyRegion1
            //Example1 obj=new Example1();
            ////obj.ConnectedExample();
            //obj.AnotherExample();

            //FileClass fc=new FileClass();
            //fc.Dispose();            
            //fc.Dispose();
            //
            #endregion

            #region MyRegion2
            ConnectedCRUD connected = new ConnectedCRUD();
            ////connected.GetProductByCategoryId(10);

            //connected.CreateNewProduct("P159", "Tata", 1, 900000, 3);

            //connected.GetProductAndCategory();

            //connected.GetMultipleTable();

            //ExecuteScalar
            connected.UseExecuteScalar();

            connected.Dispose();

            #endregion

            #region Disconnected
            //DisconnectedCRUD obj = new DisconnectedCRUD();
            //   obj.GetProducts();

            ////Insert Product
            //obj.InsertProduct(new Models.Product
            //{
            //    ProductId = "P161",
            //    ProductName = "Mobile Phone",
            //    CategoryId = 2,
            //    Price = 55000,
            //    Quantity = 200
            //});

            //Update Product
            //obj.UpdateProduct("P161", 1);

            //Delete Product
            //obj.DeleteProduct("P160");

            //Console.WriteLine("----Get Products----\n");
            //obj.GetAllProducts();
            #endregion


        }
    }
}
