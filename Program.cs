using MyProject.Enums;
using MyProject.Models;
using MyProject.Services.Rents;

//Renting service instance
var rentingService = new RentingService();

rentingService.CreateUser("Julek", "Jakobik", "Student");
rentingService.CreateUser("Michcio", "Tomaszywski", "Employee");

rentingService.createProjector("XW5000", "Sony", true, 300);
rentingService.createProjector("No1", "IMAX", true, 64);
rentingService.createLaptop("Extensa", "Acer", true, 16);
rentingService.createLaptop("Pavilion", "HP", false, 16);
rentingService.makeUnavailable(rentingService._hardware[3]);

rentingService.viewUsers();
rentingService.viewHardware();
rentingService.viewAvailableHardware();


Console.WriteLine("Testing:");

//Test - rent same hardware for student and employee at the same time, should print error message about conflict
rentingService.CreateRent(rentingService._users[0], rentingService._hardware[0], DateTime.Now, DateTime.Now.AddDays(7));
rentingService.CreateRent(rentingService._users[1], rentingService._hardware[0], DateTime.Now, DateTime.Now.AddDays(7));  

//Test - rent more than 2 items for student and employee at the same time, should print error message about conflict
rentingService.CreateRent(rentingService._users[0], rentingService._hardware[1], DateTime.Now, DateTime.Now.AddDays(7));
rentingService.CreateRent(rentingService._users[0], rentingService._hardware[2], DateTime.Now, DateTime.Now.AddDays(7));

//Test - rent unavailable hardware, should print error message about unavailability
rentingService.CreateRent(rentingService._users[1], rentingService._hardware[3], DateTime.Now, DateTime.Now.AddDays(7));


//Additional rents for testing
rentingService.CreateRent(rentingService._users[1], rentingService._hardware[2], DateTime.Now, DateTime.Now.AddDays(7));


rentingService.GetActiveRents();


rentingService.ReturnRent(1, DateTime.Now.AddDays(8)); //Test - return rent with penalty
rentingService.ReturnRent(2, DateTime.Now.AddDays(6)); //Test - return rent without penalty

rentingService.CreateRent(rentingService._users[1], rentingService._hardware[3], DateTime.Now, DateTime.Now.AddDays(7));

rentingService.FullReport(); // FULL REPORT

//Test if only one remains?

rentingService.GetActiveRents();

rentingService.CancelRent(3); //Test - cancel rent

rentingService.GetActiveRents();

rentingService.GetReturnedRents();