using System;

namespace MoodAnalyzer
{

	public class MoodAnalyzer
	{
		public string AnalyzeMood(string msg)
		{
			try
			{
				if (msg == null) {
					throw new CustomExceptions(CustomExceptions.CustomExceptiontype.ENTERED_NULL, "The message is null");
				}
				if (msg.Equals(string.Empty))
				{
					throw new CustomExceptions(CustomExceptions.CustomExceptiontype.ENTERED_EMPTY, "The message is empty");
				}
				msg = msg.ToLower();
				if (msg.Contains("happy"))
				{
					return "HAPPY";
				}
				else
				{
					return "SAD";
				}
			}
			catch (Exception e) 
			{
				Console.WriteLine(e.Message);
				return "HAPPY";
				//throw new CustomExceptions(CustomExceptions.CustomExceptiontype.ENTERED_NULL,"The message is null");
			}

			
		}
	}
}