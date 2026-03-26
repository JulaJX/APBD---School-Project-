using MyProject.Enums;
using MyProject.Models;

Console.WriteLine("Hello, World! Przykładowy hardware:");

var projector = new Projector("XW5000", "Sony", true); 
var camera = new Camera("No1", "IMAX", true); 
var laptop = new Laptop("Extensa", "Acer", true); 

Console.WriteLine($"Projector INFO:   ID: {projector.Id} , Model: {projector.Model} , Status: {projector.Status}");
Console.WriteLine($"Camera INFO:      ID: {camera.Id} , Model: {camera.Model} ,    Status: {camera.Status}");
Console.WriteLine($"Laptop INFO:      ID: {laptop.Id} , Model: {laptop.Model} ,Status: {laptop.Status}");