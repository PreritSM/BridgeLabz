using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodAnalyzer
{
    public class CustomExceptions : Exception
    {
        public enum CustomExceptiontype
        {
            ENTERED_NULL, ENTERED_EMPTY,
            NO_SUCH_FIELD, NO_SUCH_METHOD,
            NO_SUCH_CLASS, OBJECT_CREATION_ISSUE
        }

        private readonly CustomExceptiontype type;
       // public string message;

        public CustomExceptions(CustomExceptiontype type,string msg): base(msg)
        {
            this.type = type;  
           // this.message = msg;

        }
    }
}
