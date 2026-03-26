using MyProject.Enums;
using MyProject.Models;


//Hardware instances
var projector = new Projector("XW5000", "Sony", true, 300); 
var camera = new Camera("No1", "IMAX", true, 64); 
var laptop = new Laptop("Extensa", "Acer", true, 16); 

//Users instances
var student = new Student("Julek", "Jakobik");
var employee = new Employee("Michcio", "Tomaszywski");

//Print out all instances
Console.WriteLine("----------------------------------------------------------------------------------------------------");
Console.WriteLine("");
Console.WriteLine($"Student INFO:     ID:{student.Id}      FirstName: {student.FName} , Last Name: {student.LName}");
Console.WriteLine($"Employee INFO:    ID:{employee.Id}     First Name: {employee.FName} , Last Name: {employee.LName}");

Console.WriteLine("");
Console.WriteLine("----------------------------------------------------------------------------------------------------");
Console.WriteLine("");

Console.WriteLine($"Projector INFO:   ID: {projector.Id} , Model: {projector.Model} , Status: {projector.Status}");
Console.WriteLine($"Camera INFO:      ID: {camera.Id} , Model: {camera.Model} ,    Status: {camera.Status}");
Console.WriteLine($"Laptop INFO:      ID: {laptop.Id} , Model: {laptop.Model} ,Status: {laptop.Status}");
Console.WriteLine("");
Console.WriteLine("----------------------------------------------------------------------------------------------------");
