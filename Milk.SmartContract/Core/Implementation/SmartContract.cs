using Milk.SmartContract.Core.Interface;

namespace Milk.SmartContract.Core.Implementation
{
    public class SmartContract
    {
        internal Guid Id { get; set; }
        public string Description { get; set; }
        public string Code { get; set; } //TODO make byte[]

        public readonly List<ICondition> Conditions;

        public SmartContract(List<ICondition> conditions,string description, string code)
        {
            Id = Guid.NewGuid();
            Description = description;
            Code = code;
            Conditions = conditions;
        }

        public bool IsFulfilled()
        {
            return Conditions.All(cond => cond.IsConditionFulfilled());
        }
    }
}