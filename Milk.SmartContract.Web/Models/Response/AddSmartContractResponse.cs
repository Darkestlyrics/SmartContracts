namespace Milk.SmartContract.Web.Models.Response
{
    public class AddSmartContractResponse
    {
        public bool IsSuccessful { get; set; }
        public string Message { get; set; }

        public AddSmartContractResponse(string message)
        {
            Message = message;
        }
    }
}
