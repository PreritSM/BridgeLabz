using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndianStateCensusData
{
    public class CensusAnalyserException: Exception
    {
        public enum ExceptionType
        {
            FILE_NOT_FOUND,INVALID_FILE_TYPE,INCORRECT_DELIMITER,INCORRECT_HEADER,NO_SUCH_COUNTRY
        }
        public ExceptionType Type;

        public CensusAnalyserException(string message,ExceptionType type): base (message)
        {
            this.Type = type;
        }
    }
}
