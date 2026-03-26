namespace MyProject.Models;

public class Laptop(string model, string brand, bool hasRamSlots) : Hardware(model, brand)
{
    public bool hasRamSlots{ get; set; } = hasRamSlots;
}