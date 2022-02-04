using Milk.SmartContract.Web.Models.Request;
using Milk.SmartContract.Web.Models.Response;

namespace Milk.SmartContract.Web.Core.Interface;

public interface IBlockChainService
{
    AddBlockResponse addBlock(AddBlockRequest request);
}