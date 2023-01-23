using System;

namespace MoodAnalyzer
{

	public class MoodAnalyzer
	{
		public string AnalyzeMood( string msg)
		{
			msg= msg.ToLower();
			if (msg.Contains("happy")) {
				return "HAPPY";
			}
			else
			{
				return "SAD";
			}
		}
	}
}