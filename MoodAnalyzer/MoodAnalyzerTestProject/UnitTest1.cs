namespace MoodAnalyzer
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void SadMsgReturnsSad()
        {
            //Arrange
            string st = "I am in a Sad mood";
            string expected = "SAD";

            // Act
            MoodAnalyzer mood= new MoodAnalyzer();
            string actual = mood.AnalyzeMood(st);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void HappyMsgReturnsHAPPY() {
            //Arrange
            string st = "I am in a Happy mood";
            string expected = "HAPPY";
            
            // Act
            MoodAnalyzer mood= new MoodAnalyzer();
            string actual = mood.AnalyzeMood(st);

            //Assert
            Assert.AreEqual(expected, actual);

        }
    }
}