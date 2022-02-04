namespace Milk.BlockChain
{
    public class Chain<T>
    {
        public Guid Id { get; set; }
        public List<Block<T>> Blocks;

        private readonly int _difficulty;

        private List<T> _pending = new();

        public Chain(T data, int difficulty)
        {
            Id = Guid.NewGuid();
            _difficulty = difficulty;
            Blocks = new List<Block<T>>()
            {
                CreateGenesisBlock(data ?? Activator.CreateInstance<T>())
            };
        }
        

        public bool IsValidChain()
        {
            for (int i = 1; i < Blocks.Count; i++)
            {
                Block<T> previousBlock = Blocks[i - 1];
                Block<T> currentBlock = Blocks[i];
                if (currentBlock.Hash != currentBlock.CreateHash())
                    return false; 
                if (currentBlock.PreviousHash != previousBlock.Hash)
                    return false;
            }
            return true;
        }

        public void AddPending(T pending)
        {
            _pending.Add(pending);
        }

        public void MineBlock()
        {
            _pending.ForEach(o =>
            {
                Block<T> block = new Block<T>(DateTime.UtcNow, "",o);
                block.MineBlock(_difficulty);
                block.PreviousHash = Blocks.Last().Hash;
                Blocks.Add(block);
            });
            _pending.Clear();

        }

        private Block<T> CreateGenesisBlock(T data)
        {
            return new Block<T>(DateTime.UtcNow, "", data);
        }

        public Block<T> SearchChainByPosition(int i)
        {
            return Blocks[i];
        }

        //public T GetBlockContent(string Hash)
        //{
        //    return Blocks.SingleOrDefault(block => block.Hash == Hash)!.MineBlock(_difficulty);
        //}
    }
}