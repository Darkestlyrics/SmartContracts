using NUnit.Framework;

namespace Milk.BlockChain.Test.SmartContract
{
    [TestFixture]
    public class SmartContractTests
    {
        [Test]
        public void IsFulfilled_CurrentDate_ShouldPass()
        {
            // Arrange
            var smartContract = SmartContractFactory.GenerateSmartContract(0, "CurrentDateTest", "");

            // Act
            var result = smartContract.IsFulfilled();

            // Assert
            Assert.True(result);
        }

        [Test]
        public void IsFulfilled_PastDate_ShouldPass()
        {
            // Arrange
            var smartContract = SmartContractFactory.GenerateSmartContract(-10, "CurrentDateTest", "");

            // Act
            var result = smartContract.IsFulfilled();

            // Assert
            Assert.True(result);
        }

        [Test]
        public void IsFulfilled_FutureDate_ShouldPass()
        {
            // Arrange
            var smartContract = SmartContractFactory.GenerateSmartContract(10, "CurrentDateTest", "");

            // Act
            var result = smartContract.IsFulfilled();

            // Assert
            Assert.False(result);
        }

    }
}
