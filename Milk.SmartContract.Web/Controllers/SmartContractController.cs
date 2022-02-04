using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Milk.BlockChain.Web.Core.Interface;
using Milk.SmartContract.Web.Core.Interface;
using Milk.SmartContract.Web.Models.Request;
using Milk.SmartContract.Web.Models.Response;

namespace Milk.SmartContract.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SmartContractController : ControllerBase
    {
        private readonly ISmartContractService _smartContractService;

        public SmartContractController(ISmartContractService smartContractService)
        {
            _smartContractService = smartContractService;
        }

        [HttpPost]
        [Route("AddSmartContract")]
        public async Task<AddSmartContractResponse> AddSmartContract(AddSmartContractRequest request)
        {
            return await _smartContractService.AddSmartContract(request);
        }
    }
}
