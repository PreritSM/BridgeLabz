using System;

namespace GenericDemo
{
	public class GenericLearn
	{
        public void PrintArray<T>(T[] array)
        {
            foreach (var item in array)
            {
                Console.WriteLine($"The item displayed using Generic fn : {item}");
            }
        }
    }
	public class Generic_Max

	{
		public int Find_Max_Int(int a, int b, int c)
		{
		int max = a;
		if (b > max)
		{
			max = b;
		}
		if (c > max)
		{
			max = c ;
		}
		return max;
		}

		public float Find_Max_Float(float a, float b, float c)
		{
			float max = a;
			if (b > max)
			{
				max = b;
			}
			if (c > max)
			{
				max = c;
			}
			return max;
		}

		public string Find_Max_String(string a, string b, string c)
		{
			string max = a;
			if (string.Compare(b,max)==1)
			{
				max = b;
			}
			if (string.Compare(c, max) == 1)
			{
				max = c;
			}
			return max;
		}

        public T Generic_Max_Find<T>(T[] arr)
        {
            var max = arr[0];
            foreach (T t in arr)
            {
                if (Comparer<T>.Default.Compare(max, t) < 0)
                {
                    max = t;
                }
            }

			return max;

        }

        public T Generic_Max_GenericVar<T>(T a, T b, T c)
        {
            if (Comparer<T>.Default.Compare(a, b) > 0 && Comparer<T>.Default.Compare(a, c) > 0)
            {
                return a;
            }
            else if (Comparer<T>.Default.Compare(b, a) > 0 && Comparer<T>.Default.Compare(b, c) > 0)
            {
                return b;
            }
            else
            {
                return c;
            }

        }
    }
}
