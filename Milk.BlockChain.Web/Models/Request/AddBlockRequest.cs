namespace Milk.SmartContract.Web.Models.Request
{
    public class AddBlockRequest
    {
        public Guid ChainID { get; set; }
        public SmartContract.Core.Implementation.SmartContract Contract { get; set; }
    }
}
