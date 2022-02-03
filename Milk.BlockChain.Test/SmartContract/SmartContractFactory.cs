using System;
using System.Collections.Generic;
using Milk.SmartContract.Core.Implementation.Conditions;
using Milk.SmartContract.Core.Interface;
using NUnit.Framework;

namespace Milk.BlockChain.Test.SmartContract;

public static class SmartContractFactory
{
    public static Milk.SmartContract.Core.Implementation.SmartContract GenerateSmartContract(int days,string description,string code)
    {
        List<ICondition> conditions = new List<ICondition>()
        {
            generateDateCondition(days)
        };
        return new Milk.SmartContract.Core.Implementation.SmartContract(conditions, description, code);
    }

    private static ICondition generateDateCondition(int days)
    {
        return new DateCondition(DateTime.Now.AddDays(days));
    }
}