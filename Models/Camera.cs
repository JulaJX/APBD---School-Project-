namespace MyProject.Models;

public class Camera(string model, string brand, bool has4K) : Hardware(model, brand)
{
    public bool has4K{ get; set; } = has4K;
}