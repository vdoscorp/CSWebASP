using MyCoin.Models;

namespace MyCoin.Services
{
    public interface ICoinsData
    {
        public IEnumerable<Coin> Coins { get; }
        public void AddCoin(Coin obj);
        public void ReplaceCoinData(Coin obj);
    }
}
