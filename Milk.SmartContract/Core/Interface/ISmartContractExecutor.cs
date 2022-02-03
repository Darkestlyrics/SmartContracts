using Milk.SmartContract.Core.Implementation;

namespace Milk.SmartContract.Core.Interface;

public interface ISmartContractExecutor
{
    public ExecutionResult Execute(Implementation.SmartContract contract);
}