using Milk.SmartContract.Core.Interface;

namespace Milk.SmartContract.Core.Implementation
{
    public class SmartContract
    {
        internal Guid Id { get; set; }
        internal string Description { get; set; }
        internal string Code { get; set; } //TODO make byte[]

        private readonly List<ICondition> _conditions;

        public SmartContract(List<ICondition> conditions,string description, string code)
        {
            Id = Guid.NewGuid();
            Description = description;
            Code = code;
            _conditions = conditions;
        }

        public bool IsFulfilled()
        {
            return _conditions.All(cond => cond.IsConditionFulfilled());
        }
    }
}