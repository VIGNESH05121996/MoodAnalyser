using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodAnalyser
{
    public class MoodAnalysing
    {
        public string message;

        public MoodAnalysing(string message) //initilizing parameterized constructor
        {
            this.message = message;
        }

        public string AnalyseMood() //declaring AnalyseMood method
        {
            //try and catch is used for exception handling
            try
            {
                if (message.ToLower().Contains("sad"))
                {
                    return "SAD";
                }
                else
                {
                    return "HAPPY";
                }
            }

            catch
            {
                throw new CustomException(CustomException.ExceptionType.NULL_TYPE_EXCEPTION, "Message Should Not Be Null");
            }
            
        }
    }
}
