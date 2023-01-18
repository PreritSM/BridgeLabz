using System;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Security.Cryptography.X509Certificates;

namespace line_comp
{
    public interface IComparison
    {
        public void Linepts(int x1, int y1, int x2, int y2);
        public void lenComp();

    }
    public class line_par
    {
        public int[] endPoint1;
        public int[] endPoint2;

        public double length = 0;

        public void setLength(int length)
        {
            this.length = length;
        }
    }

    public class Comparison : line_par, IComparison
    {   
        public LinkedList<line_par> Linelist;
        public double lengthCalc (int x1,int y1,int x2,int y2)
        {
            return Math.Sqrt(Math.Pow((x2 - x1), 2) + Math.Pow((y2 - y1), 2));
        }

        public Comparison()
        {
            this.Linelist= new LinkedList<line_par>();
        }
        public void Linepts( int x1, int y1, int x2,int y2)
        {
            line_par obj= new line_par();
            obj.endPoint1 = new int[2];
            obj.endPoint2 = new int[2];

            obj.endPoint1[0] = x1;
            obj.endPoint1[1] = y1;
            obj.endPoint2[0] = x2;
            obj.endPoint2[1] = y2;

            Linelist.AddLast(obj);
        }

        public void lenComp()
        {
            double[] lengths = new double[2];
            int i = 0;
            foreach(line_par obj in Linelist)
            {
               double l =  lengthCalc(obj.endPoint1[0], obj.endPoint1[1], obj.endPoint2[0], obj.endPoint2[1]);
               lengths[i] = l; i++;

            }

            if (lengths[0] > lengths[1] )
            {
                Console.WriteLine("The first line is longer than the second");
            }
            else if (lengths[0] < lengths[1] )
            {
                Console.WriteLine("The first line is shorter than the second");
            }
            else{
                Console.WriteLine("Both the lines are equal in size");
            }

        }
    }
}

