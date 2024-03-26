namespace MyCoins.Models;

public class CoinsData {
    private List<Coin> coins = new List<Coin> {
        new Coin { Id=1, Country="Italy", Year=1973, Metal="Aluminum", Face="5 lire", Denomination="5 lire" },
        new Coin { Id=2, Country="Italy", Year=1980, Metal="Aluminum", Face="10 lire", Denomination="10 lire" },
        new Coin { Id=3, Country="Italy", Year=1967, Metal="Steel",    Face="50 lire", Denomination="50 lire" },
        new Coin { Id=4, Country="Italy", Year=1975, Metal="Steel",    Face="100 lire", Denomination="100 lire" },
        new Coin { Id=5, Country="Italy", Year=1978, Metal="Bronze", Face="200 lire", Denomination="200 lire" },
        new Coin { Id=6, Country="Italy", Year=1965, Metal="Silver", Face="500 lire", Denomination="500 lire" }
    };
    public IEnumerable<Coin> Coins { get { return coins; } }
    public void AddCoin(Coin obj)  { coins.Add(obj); } 
}