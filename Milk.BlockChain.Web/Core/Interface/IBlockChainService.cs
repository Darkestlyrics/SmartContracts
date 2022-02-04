using Milk.BlockChain.Web.Models.Request;
using Milk.BlockChain.Web.Models.Response;

namespace Milk.BlockChain.Web.Core.Interface;

public interface IBlockChainService
{
    AddBlockResponse addBlock(AddBlockRequest request);
}