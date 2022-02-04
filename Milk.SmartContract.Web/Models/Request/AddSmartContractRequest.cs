namespace Milk.SmartContract.Web.Models.Request
{
    public class AddSmartContractRequest
    {
        public Guid? ChainId { get; set; }
        public SmartContract.Core.Implementation.SmartContract SmartContract { get; set; }

        public AddSmartContractRequest(SmartContract.Core.Implementation.SmartContract smartContract)
        {
            SmartContract = smartContract;
        }
    }
}
