using System;
using System.Collections.Generic;
using System.Text;
namespace RepositoryLayer.Helpers
{
    public class CustomException : Exception
    {
        public ExceptionType type;
        public enum ExceptionType { ObjectNullException, MethodNotFound, ClassNotFound }
        public CustomException(ExceptionType type, string message) : base(message)
        {
            this.type = type;
        }
    }
}