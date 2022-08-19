using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection_MoodAnalyser
{
    public class MoodAnalyser
    {
        public string message;

        /// <summary>
        /// Default constructor
        /// </summary>
        public MoodAnalyser()
        {
            this.message = null;
        }
        /// <summary>
        /// parameterised constructor with null or empty message 
        /// </summary>
        public MoodAnalyser(string message)
        {
            this.message = message;
        }

        /// <summary>
        /// Method to analyse mood with custom exception
        /// </summary>
        public string AnalyserMood()
        {
            try
            {
                if (this.message.Equals(string.Empty))
                {
                    throw new CustomException(CustomException.ExceptionType.EMPTY_MOOD, "Mood should not be empty");
                }
                if (this.message.Contains("SAD"))
                {
                    return "SAD";
                }
                else
                {
                    return "HAPPY";
                }
            }
            catch (NullReferenceException)
            {
                throw new CustomException(CustomException.ExceptionType.NULL_MOOD, "Mood should not be null message");
            }
        }
    }
}
