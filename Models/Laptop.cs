namespace MyProject.Models;

public class Laptop(string model, string brand, bool hasRamSlots, int ramMemory) : Hardware(model, brand)
{
    public bool hasRamSlots{ get; set; } = hasRamSlots;
    public int ramMemory{ get; set; } = ramMemory;
}