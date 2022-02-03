using System.Security.Cryptography;
using System.Text;

namespace Milk.BlockChain;

public class Block<T>
{
    private readonly DateTime _timeStamp;

    private long _nonce;
    public string PreviousHash { get; set; }
    public T Data { get; set; }
    public string Hash { get; set; }


    public Block(DateTime timeStamp, string previousHash, T data)
    {
        _timeStamp = timeStamp;
        PreviousHash = previousHash;
        Data = data;
        Hash = CreateHash();
        _nonce = 0;
    }

    public void MineBlock(int proofOfWorkDifficulty)
    {
        string hashValidationTemplate = new string('0', proofOfWorkDifficulty);

        while (Hash.Substring(0, proofOfWorkDifficulty) != hashValidationTemplate)
        {
            _nonce++;
            Hash = CreateHash();
        }
    }

    internal string CreateHash()
    {
        using (SHA256 sha256 = SHA256.Create())
        {
            string rawData = PreviousHash + _timeStamp + Data + _nonce; 
            byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(rawData));
            return Encoding.Default.GetString(bytes);
        }
    }
}

