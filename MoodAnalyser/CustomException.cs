using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodAnalyser
{
    public class CustomException:Exception
    {
        public ExceptionType type;

        //enum is user defined value type used to represent a list of named integer constant
        //here it is used for exception type list and is constant
        public enum ExceptionType
        {
            NULL_TYPE_EXCEPTION,
            EMPTY_TYPE_EXCEPTION,
            CLASS_NOT_FOUND,
            CONSTRUCTOR_NOT_FOUND,
            NO_SUCH_METHOD,
            NO_SUCH_CLASS

        }

        public CustomException(ExceptionType type,string message):base(message) //create constructor
        {
            this.type = type;
        }
    }
}
