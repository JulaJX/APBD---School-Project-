namespace MyProject.Models;

public class Projector(string model, string brand, bool hasZoomLens, int projectionSize) : Hardware(model, brand)
{
    public bool hasZoomLens{ get; set; } = hasZoomLens;
    public int projectionSize{ get; set; } = projectionSize;
}