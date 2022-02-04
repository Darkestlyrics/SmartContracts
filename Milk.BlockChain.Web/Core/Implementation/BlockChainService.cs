using Milk.BlockChain.Web.App;
using Milk.BlockChain.Web.Core.Interface;
using Milk.BlockChain.Web.Models.Request;
using Milk.BlockChain.Web.Models.Response;

namespace Milk.BlockChain.Web.Core.Implementation
{
    public class BlockChainService : IBlockChainService
    {
        public AddBlockResponse addBlock(AddBlockRequest request)
        {
            AddBlockResponse response = new AddBlockResponse();
            try
            {

                Chain<SmartContract.Core.Implementation.SmartContract> chain =
                    InMemoryStorage.SmartContracts.SingleOrDefault(o => o.Id == request.ChainID);
                if (chain != null)
                {
                    chain.AddPending(request.Contract);
                }
                else
                {
                    chain = new Chain<SmartContract.Core.Implementation.SmartContract>(request.Contract, 1);
                    InMemoryStorage.SmartContracts.Add(chain);
                }
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
