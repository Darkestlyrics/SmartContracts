using Milk.SmartContract.Web.Core.Interface;
using Milk.SmartContract.Web.Models.Request;
using Milk.SmartContract.Web.Models.Response;
using RestSharp;

namespace Milk.SmartContract.Web.Core.Implementation
{
    public class SmartContractService :ISmartContractService
    {
        private readonly RestClient _restClient;

        public SmartContractService()
        {
            RestClientOptions options = new RestClientOptions("https://localhost:7111/api/BlockChain/AddBlock"); 
            _restClient = new RestClient(options);
        }

        public async Task<AddSmartContractResponse> AddSmartContract(AddSmartContractRequest request)
        {
            AddSmartContractResponse response = new AddSmartContractResponse("")
            {
                IsSuccessful = true
            };
            try
            {
                RestRequest req = new RestRequest(request.ToString(), Method.Post);
                
                var blockResponse = await _restClient.PostAsync(req);
                response.IsSuccessful = blockResponse.IsSuccessful;
                response.Message = blockResponse.ErrorMessage?? "";
            }
            catch (Exception ex)
            {
                response.IsSuccessful = false;
                response.Message = ex.Message;
            }

            return response;

        }
    }
}
