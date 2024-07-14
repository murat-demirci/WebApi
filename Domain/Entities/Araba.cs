using System.Data.SqlTypes;

namespace Domain.Entities;
public sealed class Araba
{
    public int CarID { get; set; }
    public string Brand { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }
    public string Color { get; set; }
    public decimal EngineSize { get; set; }
    public decimal Price { get; set; }
}
