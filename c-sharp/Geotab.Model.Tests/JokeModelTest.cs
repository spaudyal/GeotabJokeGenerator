using Xunit;

namespace Geotab.Model.Tests
{
    public class JokeModelTest
    {
        [Fact]
        public void JokeModel_UpdateName_IsValid()
        {
            // Assign the new model
            JokeModel model = new JokeModel() { 
                Value = "This is a test joke from Chuck Norris"
            };

            // Act upon the name property
            model.UpdateSubjectNameBy("John Doe");

            // Assert the result
            var expectedResult = "This is a test joke from John Doe";
            Assert.Equal(expectedResult, model.Value);
        }
    }
}
