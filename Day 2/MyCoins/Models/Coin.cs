using System.ComponentModel.DataAnnotations;

namespace MyCoins.Models;

public class Coin {
    public int Id   { get; set; }
    public int Year { get; set; }
    public string? Country { get; set; }
    public string? Metal   { get; set; }
    public string? Face    { get; set; }
    public string? Denomination   { get; set; }
}   