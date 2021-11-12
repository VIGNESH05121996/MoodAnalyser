using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Text.RegularExpressions;

namespace MoodAnalyser
{
    public class MoodAnalysingFactory
    {
        //Default Constructor
        public static object CreateMoodAnalyse(string className,string constructorName)
        {
            string pattern = "." + constructorName + "$";
            Match result = Regex.Match(className, pattern);

            if(result.Success)
            {
                try
                {
                    Assembly executing = Assembly.GetExecutingAssembly();
                    Type moodAnalyseType = executing.GetType(className);
                    return Activator.CreateInstance(moodAnalyseType);
                }

                catch(CustomException ex)
                {
                    throw new CustomException(CustomException.ExceptionType.CLASS_NOT_FOUND, "Class not found");
                }
            }
            else
            {
                throw new CustomException(CustomException.ExceptionType.CONSTRUCTOR_NOT_FOUND, "Constructor not found");
            }
        }

        public static object CreateMoodAnalyseParaConstructor(string className,string constructorName,string message)
        {
            Type type = typeof(MoodAnalysing);
            if(type.Name.Equals(className) || type.FullName.Equals(className))
            {
                if(type.Name.Equals(constructorName))
                {
                    ConstructorInfo con = type.GetConstructor(new[] { typeof(string) });
                    object instance = con.Invoke(new object[] { message });
                    return instance;
                }
                else
                {
                    throw new CustomException(CustomException.ExceptionType.CONSTRUCTOR_NOT_FOUND, "Constructor not found");
                }
            }
            else
            {
                throw new CustomException(CustomException.ExceptionType.CLASS_NOT_FOUND, "Class not found");
            }
        }

        //Invoking the analyse mood
        public static string InvokeMoodAnalyse(string message,string methodName)
        {
            try
            {
                Type type = typeof(MoodAnalysing);
                MethodInfo methodInfo = type.GetMethod(methodName);
                object moodAnalysingObject = MoodAnalysingFactory.CreateMoodAnalyseParaConstructor("MoodAnalyser.MoodAnalysing", "MoodAnalysing", message);
                object info = methodInfo.Invoke(moodAnalysingObject, null);
                return info.ToString();
            }
            catch(NullReferenceException ex)
            {
                throw new CustomException(CustomException.ExceptionType.NO_SUCH_METHOD, "Method not found");
            }
        }
    }
}
