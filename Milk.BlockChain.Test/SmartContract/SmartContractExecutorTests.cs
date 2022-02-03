using Milk.CodeEngine.Core.Interface;
using Milk.SmartContract.Core.Implementation;
using NUnit.Framework;

namespace Milk.BlockChain.Test.SmartContract
{
    [TestFixture]
    public class SmartContractExecutorTests
    {

        private string _validCode = @"
using System;
using Milk.CodeEngine.Core.Interface;

public class testScript : IScript
{
    public void Execute()
    {
        Console.WriteLine(""test"");
    }

    public void OnError(Exception ex)
    {
        Console.WriteLine(""Fail"");
    }

    public void OnSuccess()
    {
        Console.WriteLine(""Success"");
    }
}";
        private string _invalidCode = @"
using System;
using Milk.CodeEngine.Core.Interface

public class testScript : IScript
{
    public void Execute()
    {
        Console.WriteLine(""test"");
    }

    public void OnError(Exception ex)
    {
        Console.WriteLine(""Fail"");
    }

    public void OnSuccess()
    {
        Console.WriteLine(""Success"");
    }
}";
        private string _emptyCode = @"";


        private SmartContractExecutor CreateSmartContractExecutor()
        {
            return new SmartContractExecutor();
        }


        [Test]
        public void Execute_ExecuteEmptyCodeWithCurrentDate_ShouldFail()
        {
            // Arrange
            var smartContractExecutor = this.CreateSmartContractExecutor();
            Milk.SmartContract.Core.Implementation.SmartContract contract = SmartContractFactory.GenerateSmartContract(0,"Execution Test",_emptyCode);

            // Act
            var result = smartContractExecutor.Execute(
                contract);

            // Assert
            Assert.False(result.Success);

        }

        [Test]
        public void Execute_ExecuteValidCodeWithCurrentDate_ShouldPass()
        {
            // Arrange
            var smartContractExecutor = this.CreateSmartContractExecutor();
            Milk.SmartContract.Core.Implementation.SmartContract contract = SmartContractFactory.GenerateSmartContract(0, "Execution Test", _validCode);

            // Act
            var result = smartContractExecutor.Execute(
                contract);

            // Assert
            Assert.True(result.Success);

        }

        [Test]
        public void Execute_ExecuteInvalidCodeWithCurrentDate_ShouldFail()
        {
            // Arrange
            var smartContractExecutor = this.CreateSmartContractExecutor();
            Milk.SmartContract.Core.Implementation.SmartContract contract = SmartContractFactory.GenerateSmartContract(0, "Execution Test", _invalidCode);

            // Act
            var result = smartContractExecutor.Execute(
                contract);

            // Assert
            Assert.False(result.Success);
        }


        [Test]
        public void Execute_ExecuteEmptyCodeWithFutureDate_ShouldFail()
        {
            // Arrange
            var smartContractExecutor = this.CreateSmartContractExecutor();
            Milk.SmartContract.Core.Implementation.SmartContract contract = SmartContractFactory.GenerateSmartContract(0, "Execution Test", _emptyCode);

            // Act
            var result = smartContractExecutor.Execute(
                contract);

            // Assert
            Assert.False(result.Success);

        }

        [Test]
        public void Execute_ExecuteValidCodeWithFutureDate_ShouldFail()
        {
            // Arrange
            var smartContractExecutor = this.CreateSmartContractExecutor();
            Milk.SmartContract.Core.Implementation.SmartContract contract = SmartContractFactory.GenerateSmartContract(10, "Execution Test", _validCode);

            // Act
            var result = smartContractExecutor.Execute(
                contract);

            // Assert
            Assert.False(result.Success);
        }

        [Test]
        public void Execute_ExecuteInvalidCodeWithFutureDate_ShouldFail()
        {
            // Arrange
            var smartContractExecutor = this.CreateSmartContractExecutor();
            Milk.SmartContract.Core.Implementation.SmartContract contract = SmartContractFactory.GenerateSmartContract(10, "Execution Test", _invalidCode);

            // Act
            var result = smartContractExecutor.Execute(
                contract);

            // Assert
            Assert.False(result.Success);
        }

        [Test]
        public void Execute_ExecuteEmptyCodeWithPastDate_ShouldPass()
        {
            // Arrange
            var smartContractExecutor = this.CreateSmartContractExecutor();
            Milk.SmartContract.Core.Implementation.SmartContract contract = SmartContractFactory.GenerateSmartContract(-10, "Execution Test", _emptyCode);

            // Act
            var result = smartContractExecutor.Execute(
                contract);

            // Assert
            Assert.False(result.Success);

        }

        [Test]
        public void Execute_ExecuteValidCodeWithPastDate_ShouldPass()
        {
            // Arrange
            var smartContractExecutor = this.CreateSmartContractExecutor();
            Milk.SmartContract.Core.Implementation.SmartContract contract = SmartContractFactory.GenerateSmartContract(-10, "Execution Test", _validCode);

            // Act
            var result = smartContractExecutor.Execute(
                contract);

            // Assert
            Assert.True(result.Success);
        }

        [Test]
        public void Execute_ExecuteInvalidCodeWithPastDate_ShouldFail()
        {
            // Arrange
            var smartContractExecutor = this.CreateSmartContractExecutor();
            Milk.SmartContract.Core.Implementation.SmartContract contract = SmartContractFactory.GenerateSmartContract(-10, "Execution Test", _invalidCode);

            // Act
            var result = smartContractExecutor.Execute(
                contract);

            // Assert
            Assert.False(result.Success);
        }


    }
}
