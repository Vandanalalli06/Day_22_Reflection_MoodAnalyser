using System;
using Reflection_MoodAnalyser;

namespace Reflection_MoodAnalyser
{

    public class AnalyseMoodTestCases
    {
        MoodAnalyserFactory moodAnalyserFactory = new MoodAnalyserFactory();
        [SetUp]
        public void Setup()
        {
            moodAnalyserFactory = new MoodAnalyserFactory();
        }

        //TC 4.1 - Proper class details are provided and expected to return the MoodAnalyser Object

        [TestCase("MoodAnalyser.MoodAnalysis", "MoodAnalysis")]
        public void GivenMoodAnalyzerClassName_ReturnMoodAnalysisObject(string className, string constructorName)
        {
            MoodAnalysis expected = new MoodAnalysis();
            object obj;

            MoodAnalyserFactory factory = new MoodAnalyserFactory();
            obj = factory.CreatemoodAnalyse(className, constructorName);
            expected.Equals(obj);
        }
        //TC 4.2 - improper class details are provided and expected to throw exception Class not found

        [TestCase("Mood.MoodAnalysis", "MoodAnalysis", "class not found")]
        public void GivenImproperClassName_ShouldThrowCustomException(string className, string constructorName, string expected)
        {
            try
            {
                MoodAnalyserFactory factory = new MoodAnalyserFactory();
                object actual = factory.CreatemoodAnalyse(className, constructorName);
            }
            catch (CustomException ex)
            {
                Assert.AreEqual(expected, ex.Message);
            }
        }
        //TC 4.3 - improper constructor details are provided and expected to throw exception Constructor not found

        [TestCase("MoodAnalyser.MoodAnalysis", "Mood", "constructor not found")]
        public void GivenImproperConstructorName_ShouldThrowCustomException(string className, string constructorName, string expected)
        {
            try
            {
                MoodAnalyserFactory factory = new MoodAnalyserFactory();
                object actual = factory.CreatemoodAnalyse(className, constructorName);
            }
            catch (CustomException ex)
            {
                Assert.AreEqual(expected, ex.Message);
            }
        }

    }
}

//UC-4
//Use Reflection to Create MoodAnalyser with default Constructor 
//- Create MoodAnalyserFactory and specify static method to create MoodAnalyser Object