using Milk.SmartContract.Core.Interface;

namespace Milk.SmartContract.Core.Implementation.Conditions;

public class DateCondition : ICondition
{
    private readonly DateTime _date;

    public DateCondition(DateTime date)
    {
        _date = date;
    }

    public bool IsConditionFulfilled()
    {
        return DateTime.Now >= _date;
    }
}