using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoodAnalyser;

namespace MoodAnalyserTest
{
    [TestClass]
    public class UnitTest1
    {
        // Given sad should return sad and happy should return happy

        [TestMethod]
        [TestCategory ("CheckMood")]
        public void SadReturnsSad()
        {
            // TC 1.1 Given "I am in Sad Mood" message should Return Sad

            //Arrange
            string message = "I am in Sad Mood ";
            string expected = "SAD";
            MoodAnalysing moodAnalysing = new MoodAnalysing(message);

            //Act
            string mood = moodAnalysing.AnalyseMood();

            //Assert
            Assert.AreEqual(expected, mood);
        }

        [TestMethod]
        [TestCategory ("CheckMood")]
        public void HappyShouldReturn()
        {
            // TC 1.1 Given "I am in Sad Mood" message should Return Sad

            //Arrange
            string message = "I am in Happy Mood ";
            string expected = "HAPPY";
            MoodAnalysing moodAnalysing = new MoodAnalysing(message);

            //Act
            string mood = moodAnalysing.AnalyseMood();

            //Assert
            Assert.AreEqual(expected, mood);
        }

        //[TestMethod]
        //public void NullReturnsHappy()
        //{
        //    //TC 2.1  Given Null Mood Should Return Happy

        //    //Arrange
        //    string message = null;
        //    string expected = "HAPPY";

        //    //Act
        //    MoodAnalysing moodAnalysing = new MoodAnalysing(message);
        //    string actual = moodAnalysing.AnalyseMood();

        //    //Assert
        //    Assert.AreEqual(expected, actual);
        //}

        [TestMethod]
        [TestCategory ("CustomException")]
        public void getCustomException()
        {
            //Arrange
            string message = null;
            string expected = "Message Should Not Be Null";

            //Act
            try
            {
                MoodAnalysing moodAnalysing = new MoodAnalysing(message);
                string actual = moodAnalysing.AnalyseMood();
            }

            //Assert
            catch(CustomException ex)
            {
                Assert.AreEqual(expected, ex.Message);
            }
        }

        [TestMethod]
        //TC 4.1 given mood Analyse class name should return mood analyser object.

        public void ReturnObject()
        {
            string message = null;
            object expected = new MoodAnalysing(message);
            object obj = MoodAnalysingFactory.CreateMoodAnalyse("MoodAnalyser.MoodAnalysing", "MoodAnalysing");
            expected.Equals(obj);
        }

        [TestMethod]
        //TC 4.2 Given mood Analyse wrong class name should return exception stating no such class name exist 

        public void ReturnWrongClassName()
        {
            try
            {
                string message = null;
                object expected = new MoodAnalysing(message);
                object obj = MoodAnalysingFactory.CreateMoodAnalyse("MoodAnalyser.MoodAnalysingWrong", "MoodAnalysingWrong");
                expected.Equals(obj);
            }

            catch (CustomException ex1)
            {
                Assert.AreEqual("Class not found", ex1.Message);
            }
        }

        [TestMethod]
        //TC 4.3 Given wrong constructor name should return improper message in exception  

        public void ReturnWronConstructorName()
        {
            try
            {
                string message = null;
                object expected = new MoodAnalysing(message);
                object obj = MoodAnalysingFactory.CreateMoodAnalyse("MoodAnalyser.MoodAnalysing", "MoodAnalysingWrong");
                expected.Equals(obj);
            }

            catch (CustomException ex2)
            {
                Assert.AreEqual("Constructor not found", ex2.Message);
            }
        }

        [TestMethod]
        //TC 5.1 given mood Analyse class name should return mood analyser object with parameterised constructor

        public void Given_ParameterisedConstructor_MoodAnalyseClassName_Should_return_MoodAnalyseObject()
        {
            object expected = new MoodAnalysing("HAPPY");
            object obj = MoodAnalysingFactory.CreateMoodAnalyseParaConstructor("MoodAnalyser.MoodAnalysing", "MoodAnalysing");
            expected.Equals(obj);
        }


        [TestMethod]
        //TC 5.2 Given mood Analyse wrong class name should return exception stating no such class name exist 

        public void Given_ParameterisedConstructor_WrongClassName_Should_return_MoodAnalyseObjectException_Message()
        {
            try
            {
                object expected = new MoodAnalysing("HAPPY");
                object obj = MoodAnalysingFactory.CreateMoodAnalyseParaConstructor("MoodAnalyser.MoodAnalyserWrong", "MoodAnalysing");
                expected.Equals(obj);
            }

            catch (CustomException ex)
            {
                Assert.AreEqual("Class not found", ex.Message);
            }
        }


        //Test Case 5.3 Given mood Analyse wrong constructor name should return exception stating no such consrtructor exist 
        [TestMethod]
        public void Given_ParameterisedConstructor_WrongConstrcutorName_Should_return_MoodAnalyseObjectException_Message()
        {
            try
            {
                object expected = new MoodAnalysing("HAPPY");
                object obj = MoodAnalysingFactory.CreateMoodAnalyseParaConstructor("MoodAnalyser.MoodAnalysing", "MoodAnalyserWrong");
                expected.Equals(obj);
            }

            catch (CustomException ex)
            {
                Assert.AreEqual("Constructor not found", ex.Message);
            }
        }
    }
}
