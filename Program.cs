using MyProject.Enums;
using MyProject.Models;
using MyProject.Services.Rents;


//Available Hardware instances
var projector = new Projector("XW5000", "Sony", true, 300); 
var camera = new Camera("No1", "IMAX", true, 64); 
var laptop = new Laptop("Extensa", "Acer", true, 16); 
//Unavailable hardware instance
var unavailableLaptop = new Laptop("Pavilion", "HP", false, 16);
unavailableLaptop.Status = RentStatus.Unavailable;

//Users instances
var student = new Student("Julek", "Jakobik");
var employee = new Employee("Michcio", "Tomaszywski");

//Renting service instance
var rentingService = new RentingService();

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


Console.WriteLine("----------------------------------------------------------------------------------------------------");
//Test - rent same hardware for student and employee at the same time, should print error message about conflict
rentingService.CreateRent(student, projector, DateTime.Now, DateTime.Now.AddDays(7));
rentingService.CreateRent(employee, projector, DateTime.Now, DateTime.Now.AddDays(7));  
Console.WriteLine("----------------------------------------------------------------------------------------------------");


Console.WriteLine("");
Console.WriteLine("");


Console.WriteLine("----------------------------------------------------------------------------------------------------");
//Test - rent more than 2 items for student and employee at the same time, should print error message about conflict
rentingService.CreateRent(student, camera, DateTime.Now, DateTime.Now.AddDays(7));
rentingService.CreateRent(student, laptop, DateTime.Now, DateTime.Now.AddDays(7));
Console.WriteLine("----------------------------------------------------------------------------------------------------");


Console.WriteLine("");
Console.WriteLine("");


Console.WriteLine("----------------------------------------------------------------------------------------------------");
//Test - rent unavailable hardware, should print error message about unavailability
rentingService.CreateRent(employee, unavailableLaptop, DateTime.Now, DateTime.Now.AddDays(7));
Console.WriteLine("----------------------------------------------------------------------------------------------------");