using System;
using System.Data;

namespace Product_Review_Mgmt
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<ProductReview> products = new List<ProductReview>();
            ProductReviewManager manager = new ProductReviewManager();
            products = manager.AddData( products );
            manager.IterateList(products);
            Console.WriteLine("\n");
            List<ProductReview> top3 = manager.RetrieveTop3(products);
            Console.WriteLine("\n");
            manager.RetrieveParticularData(products);
            Console.WriteLine("\n");
            DataTable datatable =manager.CreateTable(products);
            manager.DisplayRecords(datatable);



        }
    }
}