using System;

namespace line_comp{
    
    class line_comp{

        public double lineLengthCalculation(){
            
            int x1,y1,x2,y2;
            Console.WriteLine("Enter the X coordinate of first end point : ");
            x1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the Y coordinate of first end point : ");
            y1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the X coordinate of second end point : ");
            x2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the y coordinate of second end point : ");
            y2 = Convert.ToInt32(Console.ReadLine());

            double length = Math.Sqrt( Math.Pow((x2-x1),2) + Math.Pow((y2-y1),2) );

            Console.WriteLine("The length of the given line : " + length);
            return length;
            
        }

        // Function for USE CASE - 1
        public void lineLength(){
            Console.WriteLine("Calculating the Length of the Line");
            double length = lineLengthCalculation();

        }

        // Function for USE CASE - 2
        public void equalLengthChecker(){
            Console.WriteLine("Checking for Equality in Length of 2 lines");
            Console.WriteLine("Enter coordinates for first line");
            double length1 = lineLengthCalculation();

            Console.WriteLine("Enter coordinates for second line");
            double length2 = lineLengthCalculation();

            if(length1 == length2){
                Console.WriteLine("The lines are equal in length. ");
            }
            else{
                Console.WriteLine("The lines are unequal in length. ");
            }
        }

        // Function for USE CASE - 3
        public void lineLengthComparison(){
            Console.WriteLine("Comparing the Length of 2 lines");
            Console.WriteLine("Enter coordinates for first line");
            double length1 = lineLengthCalculation();

            Console.WriteLine("Enter coordinates for second line");
            double length2 = lineLengthCalculation();

            if(length1 == length2){
                Console.WriteLine("The lines are equal in length. ");
            }
            else if (length1>length2){
                Console.WriteLine("The first line is longer than the second. ");
            }
            else {
                Console.WriteLine("The first line is shorter than the second line. ");
            }
        }

    }
}