using System.ComponentModel.DataAnnotations;

namespace MyCoin.Models;

public class Coin {
    
    public int Id   { get; set; }

    [Range(1900,2023)]
    public int Year { get; set; }
    public string Comment { get; set; } =".";

    [Required] public string? Country { get; set; }
    [Required] public string? Metal   { get; set; }
    [Required] public string? Face    { get; set; }
    [Required] public string? Denomination   { get; set; }
}   