using MyProject.Enums;

namespace MyProject.Models;

public abstract class Hardware(string model, string brand)
{
    private static int _nextId = 1;
    public int Id { get; } = _nextId++;
    public string Model { get; set; } = model;
    public string Brand {get; set;} = brand;
    public RentStatus Status { get; set; } = RentStatus.Available;
}