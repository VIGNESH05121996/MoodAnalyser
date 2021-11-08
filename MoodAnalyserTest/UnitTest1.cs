using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoodAnalyser;

namespace MoodAnalyserTest
{
    [TestClass]
    public class UnitTest1
    {
        // Given sad should return sad and happy should return happy

        [TestMethod]
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

        [TestMethod]
        public void NullReturnsHappy()
        {
            //TC 2.1  Given Null Mood Should Return Happy

            //Arrange
            string message = null;
            string expected = "HAPPY";

            //Act
            MoodAnalysing moodAnalysing = new MoodAnalysing(message);
            string actual = moodAnalysing.AnalyseMood();

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
