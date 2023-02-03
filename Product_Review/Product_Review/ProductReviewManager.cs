using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product_Review_Mgmt
{
    public class ProductReviewManager
    {
        public List<ProductReview> AddData(List<ProductReview> products) {
            products.Add(new ProductReview() { ProductID = 1, UserID = 1, Rating = 4, Review = "Very Good", IsLike = true });
            products.Add(new ProductReview() { ProductID = 2, UserID = 5, Rating = 5, Review = "Excellent", IsLike = true });
            products.Add(new ProductReview() { ProductID = 4, UserID = 3, Rating = 2, Review = "Bad", IsLike = true });
            products.Add(new ProductReview() { ProductID = 9, UserID = 5, Rating = 5, Review = "Excellent", IsLike = true });
            products.Add(new ProductReview() { ProductID = 6, UserID = 6, Rating = 4, Review = "Very Good", IsLike = true });
            products.Add(new ProductReview() { ProductID = 7, UserID = 2, Rating = 2, Review = "Bad", IsLike = true });
            products.Add(new ProductReview() { ProductID = 3, UserID = 2, Rating = 1, Review = "Worst", IsLike = true });
            return products;
        }

        public void IterateList(List<ProductReview> products)
        {
            foreach (ProductReview product in products)
            {
                Console.WriteLine(product.ToString());
            }
        }

        public List<ProductReview> RetrieveTop3(List<ProductReview> products)
        {
            var productlist = products.OrderByDescending(p => p.Rating).Take(3).ToList();
            Console.WriteLine("The top 3 products are ");
            IterateList(productlist);
            return productlist;
        }
        
        public void RetrieveParticularData(List<ProductReview> products)
        {
            var productlist = (from product in products
                               where
                               (product.ProductID == 1 || product.ProductID == 3) &&
                               product.Rating > 3
                               select product).ToList();
            Console.WriteLine("Printing Rating greater than 3");
            IterateList(productlist);
            return;
        }

        public int RetrieveProductReviewCount(List<ProductReview> products)
        {
            int PCount =0;
            var ResProductCount = products.GroupBy(p => p.ProductID)
                .Select(p=> new {productID = p.Key, count = p.Count()});
            Console.WriteLine("Printing All Reviews");
            foreach (var product in ResProductCount)
            {
                Console.WriteLine($"Product ID : {product.productID}, Count : {product.count}");
                PCount++;
            }
            return PCount;
        }

        public List<ProductReview> SkipTopFive(List<ProductReview> products)
        {
            var ProductRating= (from p in products orderby p.Rating select p).Skip(5).ToList();
            Console.WriteLine();
            IterateList(ProductRating);
            return ProductRating;
        }

        public DataTable CreateTable(List<ProductReview> products)
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("ProductID",typeof(int));
            dataTable.Columns.Add("UserID", typeof(int));
            dataTable.Columns.Add("Rating", typeof(double));
            dataTable.Columns.Add("Review", typeof(string));
            dataTable.Columns.Add("IsLike", typeof(bool));

            foreach(var data in products)
            {
                dataTable.Rows.Add(data.ProductID,data.UserID,data.Rating,data.Review,data.IsLike);
            }
            Console.WriteLine("Data added successfully");

            return dataTable;
        }

        public void DisplayRecords(DataTable dt)
        {
            var response = (from product in dt.AsEnumerable()
                            select product.Field<int>("ProductID"));
            Console.WriteLine("ProductID");
            foreach (var product in response)
            {
                Console.WriteLine(product);
            }
        }
    }
        
    
}
