using Xunit;
using SocialNetwork.Domain.Tags;

namespace Test.Domain.Tags
{
    public class TagUnitTest
    {
        [Fact]
        public void validarTagSucesso()
        {
            bool success = false;
            try{
                var tag = new Tag("culinaria");
                success = true;
            }catch{
                success = false;
            }

            Assert.True(success);
        }

        [Fact]
        public void validarTagInsucessoSpecialCharacters()
        {
            bool success = false;
            try{
                var tag = new Tag("#&#%/&%/()&#$hrthtrhr");
                success = true;
            }catch{
                success = false;
            }

            Assert.False(success);
        }

        [Fact]
        public void validarTagInsucessoSize()
        {
            bool success = false;
            try{
                var tag = new Tag("1234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890");
                success = true;
            }catch{
                success = false;
            }

            Assert.False(success);
        }
    }
}