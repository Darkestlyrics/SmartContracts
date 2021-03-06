using Milk.SmartContract.Web.Models.Request;
using Milk.SmartContract.Web.Models.Response;

namespace Milk.SmartContract.Web.Core.Interface
{
    public interface ISmartContractService
    {
        Task<AddSmartContractResponse> AddSmartContract(AddSmartContractRequest request);
    }
}
