namespace MyProject.Models;

public class Projector(string model, string brand, bool hasZoomLens) : Hardware(model, brand)
{
    public bool hasZoomLens{ get; set; } = hasZoomLens;
}