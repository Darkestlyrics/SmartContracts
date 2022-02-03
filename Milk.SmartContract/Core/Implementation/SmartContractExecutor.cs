using Milk.CodeEngine.Core.Interface;
using Milk.SmartContract.Core.Interface;

namespace Milk.SmartContract.Core.Implementation;

public class SmartContractExecutor :ISmartContractExecutor
{

    private readonly ICodeEngine _codeEngine;

    public SmartContractExecutor()
    {
        _codeEngine = new CodeEngine.Core.Implementation.CodeEngine();
    }

    public ExecutionResult Execute(SmartContract contract)
    {
        ExecutionResult result = new ExecutionResult()
        {
            Success = true
        };
        if (!contract.IsFulfilled())
        {
            result.Success = false;
            result.Message = "Contract Condition(s) are not Fulfilled";
        }

        var codeEngineResult = _codeEngine.CompileCode( contract.Code);
        if (!codeEngineResult.Success)
        {
            result.Success = false;
            result.Message = "Code Compiled with Errors";
            result.Errors = codeEngineResult.Errors;

        }
        return result;
    }

}