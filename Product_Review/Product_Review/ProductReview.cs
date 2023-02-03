using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product_Review_Mgmt
{
    public class ProductReview
    {
        public int ProductID { get; set; }
        public int UserID { get; set; }
        public double Rating { get; set; }
        public string Review { get; set; }
        public bool IsLike { get; set; }

        public override string ToString()
        {
            return $"Product ID : {ProductID}, User ID : {UserID}, Product Rating : {Rating}," +
                $" Review : {Review}, IsLike : {IsLike}";
        }


    }
}
