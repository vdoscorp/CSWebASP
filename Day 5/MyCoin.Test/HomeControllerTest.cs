
using Moq;
using MyCoin.Controllers;
using MyCoin.Models;
using MyCoin.Services;

namespace MyCoin.Test
{
    public class CoinsDataTest
    {
        [Fact]
        public void ReplaceCoinDataTest()
        {
            //Arrange
            CoinsData coinsData = new CoinsData();

            // Act
            coinsData.ReplaceCoinData(new Coin() { Id=6, Country="Italy", Year=1970, Metal="Silver",
                Face="/images/img6.jpg", Denomination="500 lire" });

            // Assert
            Assert.True(coinsData.Coins.ElementAt(5).Year == 1970);
        }
    }
}