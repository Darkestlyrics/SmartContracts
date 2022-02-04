using Milk.BlockChain.Web.Models.Response;
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
            RestClientOptions options = new RestClientOptions("http://localhost:5111"); 
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
                AddBlockResponse? blockResponse = await _restClient.PostAsync<AddBlockResponse>(req);
                response.IsSuccessful = blockResponse.IsSuccessful;
                response.Message = blockResponse.Message;
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
