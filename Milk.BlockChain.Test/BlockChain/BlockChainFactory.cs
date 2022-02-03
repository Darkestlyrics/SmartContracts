namespace Milk.BlockChain.Test.BlockChain;

public class BlockChainFactory<T>
{
    public static Chain<T> GenrateChain(T data,int difficulty)
    {
        Chain<T> chain = new Chain<T>(data, difficulty);
        return chain;
    }

}