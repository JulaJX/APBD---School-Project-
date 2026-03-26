namespace MyProject.Models;

public class Camera(string model, string brand, bool has4K, int internalMemory) : Hardware(model, brand)
{
    public bool has4K{ get; set; } = has4K;
    public int internalMemory{get; set; } = internalMemory;
}