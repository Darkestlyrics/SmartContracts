using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Milk.BlockChain.Web.Core.Interface;
using Milk.BlockChain.Web.Models.Request;
using Milk.BlockChain.Web.Models.Response;

namespace Milk.BlockChain.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlockChainController : ControllerBase
    {
        private readonly IBlockChainService _blockChainService;

        public BlockChainController(IBlockChainService blockChainService)
        {
            _blockChainService = blockChainService;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("AddBlock")]
        public AddBlockResponse AddBlock(AddBlockRequest request)
        {
            return _blockChainService.addBlock(request);
        }
    }
}
