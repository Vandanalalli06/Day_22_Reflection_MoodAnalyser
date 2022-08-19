using System;
using System.Reflection;
using System.Text.RegularExpressions;

namespace Reflection_MoodAnalyser
{
    public class MoodAnalyserFactory
    {
        /// <summary>
        /// CreateMoodAnalyse method to create object of MoodAnalyse class.  

        /// </summary>
        /// <param name="className"></param>
        /// <param name="constructorName"></param>
        /// <returns></returns>
        /// <exception cref="MoodAnalysisException"></exception>
        public static object CreateMoodAnalyse(string className, string constructorName)
        {
            string pattern = "." + constructorName + "$";
            Match result = Regex.Match(className, pattern);
            if (result.Success)
            {
                try
                {
                    Assembly executing = Assembly.GetExecutingAssembly();
                    Type moodAnaylseType = executing.GetType(className);
                    return Activator.CreateInstance(moodAnaylseType);

                }
                catch (ArgumentNullException)
                {
                    throw new CustomException(CustomException.ExceptionType.NO_SUCH_CLASS, "Class Not Found");
                }

            }
            else
            {
                throw new CustomException(CustomException.ExceptionType.NO_SUCH_METHOD, "Constructor is Not Found");
            }
        }

        /// <summary>
        /// UC-5 For parameterised constructor by pssing messge parameter to the class method
        /// </summary>

        public static object CreateMoodAnalyseUsingParameterizedConstructor(string className, string constructorName)
        {
            Type type = typeof(MoodAnalyser);
            if (type.Name.Equals(className) || type.FullName.Equals(className))
            {
                if (type.Name.Equals(constructorName))
                {
                    ConstructorInfo construct = type.GetConstructor(new[] { typeof(string) });
                    object instance = construct.Invoke(new object[] { "HAPPY" });
                    return instance;
                }

                else
                {
                    throw new CustomException(CustomException.ExceptionType.NO_SUCH_METHOD, "Method not found");
                }
            }
            else
            {
                throw new CustomException(CustomException.ExceptionType.NO_SUCH_CLASS, "Class not found");
            }
        }
    }
}