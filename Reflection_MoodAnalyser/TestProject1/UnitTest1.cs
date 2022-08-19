using System;
using Reflection_MoodAnalyser;

namespace Reflection_MoodAnalyser
{
    public class Tests
    {
        MoodAnalyserFactory moodAnalyserfactory;
        [SetUp]
        public void Setup()
        {
            moodAnalyserfactory = new MoodAnalyserFactory();
        }

        /// <summary>
        /// TC-7.1  Given Hppy Should Return Happy
        /// </summary>
        [Test]
        public void Given_HAPPYMessage_WithReflector_Should_ReturnHAPPY()
        {
            string result = MoodAnalyserFactory.SetField("HAPPY", "message");
            Assert.AreEqual("HAPPY", result);
        }

        /// <summary>
        /// TC-7.2  Set Field When Improper Should Throw Exception 
        /// </summary>
        [Test]
        public void SetField_ImProper_ShouldThrowException()
        {
            try
            {
                string result = MoodAnalyserFactory.SetField("HAPPY", "me");
            }
            catch (CustomException exception)
            {
                Assert.AreEqual("Field is not found", exception.Message);
            }
        }

        /// <summary>
        /// TC-7.3  Set Null Messge  Should Throw Exception 
        /// </summary>
        [Test]
        public void Setting_NullMessge_ShouldThrowException()
        {
            try
            {
                string result = MoodAnalyserFactory.SetField(null, "message");
            }
            catch (CustomException exception)
            {
                Assert.AreEqual("Message should not be null", exception.Message);
            }
        }
    }
}

