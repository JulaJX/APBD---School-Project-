using MyProject.Enums;
using MyProject.Models;

Console.WriteLine("Hello, World! Przykładowy hardware:");
var projector = new Projector("Model1", "Brand1", true); 
Console.WriteLine($"ID: {projector.Id}, Model: {projector.Model}, Status: {projector.Status}");
