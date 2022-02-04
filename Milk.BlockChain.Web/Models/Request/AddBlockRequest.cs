namespace Milk.BlockChain.Web.Models.Request
{
    public class AddBlockRequest
    {
        public Guid ChainID { get; set; }
        public SmartContract.Core.Implementation.SmartContract Contract { get; set; }

        public AddBlockRequest(SmartContract.Core.Implementation.SmartContract contract)
        {
            Contract = contract;
        }
    }
}
