using NUnit.Framework;

namespace Milk.BlockChain.Test.BlockChain
{
    [TestFixture]
    public class ChainTests
    {
        [Test]
        public void IsValidChain_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var chain = BlockChainFactory<string>.GenrateChain("test1", 1);
            chain.AddPending("test2");
            chain.AddPending("test3");
            chain.AddPending("test4");
            chain.AddPending("test5");
            chain.MineBlock();
            // Act
            var result = chain.IsValidChain();

            // Assert
            Assert.Fail();
        }

        //[Test]
        //public void SearchChainByPosition_StateUnderTest_ExpectedBehavior()
        //{
        //    // Arrange
        //    var chain = new Chain(TODO);
        //    int i = 0;

        //    // Act
        //    var result = chain.SearchChainByPosition(
        //        i);

        //    // Assert
        //    Assert.Fail();
        //}

        //[Test]
        //public void GetBlockContent_StateUnderTest_ExpectedBehavior()
        //{
        //    // Arrange
        //    var chain = new Chain(TODO);
        //    string Hash = null;

        //    // Act
        //    var result = chain.GetBlockContent(
        //        Hash);

        //    // Assert
        //    Assert.Fail();
        //}
    }
}
