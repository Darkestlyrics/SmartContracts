using Milk.BlockChain.Web.Models.Response;
using Milk.SmartContract.Web.Core.Interface;
using Milk.SmartContract.Web.Models.Request;
using Milk.SmartContract.Web.Models.Response;
using RestSharp;

namespace Milk.SmartContract.Web.Core.Implementation
{
    public class SmartContractService :ISmartContractService
    {
        private RestClient _restClient;

        public SmartContractService(RestClient restClient)
        {
            RestClientOptions options = new RestClientOptions(""); //TODO get this
            _restClient = new RestClient(options);
        }

        public async Task<AddSmartContractResponse> AddSmartContract(AddSmartContractRequest request)
        {
            RestRequest req = new RestRequest(request.ToString(), Method.Post);
            AddBlockResponse? response = await _restClient.PostAsync<AddBlockResponse>(req);
            return new AddSmartContractResponse()
            {
                IsSuccessful = response.IsSuccessful,
                Message = response.Message
            };

        }
    }
}
