using MyProject.Enums;
using MyProject.Models;

namespace MyProject.Services.Rents;

public class RentingService : IRentingService
{
    public readonly List<User> _users = new List<User>();
    public readonly List<Hardware> _hardware = new List<Hardware>();
    
    private readonly List<Rent> _rents = new List<Rent>();
    private readonly List<Rent> _returnedRents = new List<Rent>();
    
    //CREATE NEW USER
    public void CreateUser(string fName, string lName, string userType)
    {
        User newUser;
        if (userType == "Student")
        {
            newUser = new Student(fName, lName);
        }
        else
        {
            newUser = new Employee(fName, lName);
        }
        _users.Add(newUser);
        Console.WriteLine("");
        Console.WriteLine($"User of id {newUser.Id} created successfully: {newUser.FName} {newUser.LName} , Type: {userType}");
        Console.WriteLine("");
    }
    //CREATE NEW PROJECTOR
    public void createProjector(string model, string brand, bool hasZoomLens, int projectionSize)
    {
        var newProjector = new Projector(model, brand, hasZoomLens, projectionSize);
        _hardware.Add(newProjector);
        Console.WriteLine("");
        Console.WriteLine($"Projector of id {newProjector.Id} created successfully: Model: {newProjector.Model} , Brand: {newProjector.Brand}");
        Console.WriteLine("");
    }
    //CREATE NEW CAMERA
    public void createCamera(string model, string brand, bool has4K, int internalMemory)
    {
        var newCamera = new Camera(model, brand, has4K, internalMemory);
        _hardware.Add(newCamera);
        Console.WriteLine("");
        Console.WriteLine($"Camera of id {newCamera.Id} created successfully: Model: {newCamera.Model} , Brand: {newCamera.Brand}");
        Console.WriteLine("");
    }
    //CREATE NEW LAPTOP
    public void createLaptop(string model, string brand, bool hasRamSlots, int ramMemory)
    {
        var newLaptop = new Laptop(model, brand, hasRamSlots, ramMemory);
        _hardware.Add(newLaptop);
        Console.WriteLine("");
        Console.WriteLine($"Laptop of id {newLaptop.Id} created successfully: Model: {newLaptop.Model} , Brand: {newLaptop.Brand}");
        Console.WriteLine("");
    }

    public void makeUnavailable(Hardware hardware)
    {
        hardware.Status = RentStatus.Unavailable;
    }

    //VIEW ALL USERS
    public void viewUsers()
    {
        Console.WriteLine("");
        Console.WriteLine("List of users:");
        foreach (var user in _users)
        {
            Console.WriteLine($"ID:{user.Id}      First Name: {user.FName} , Last Name: {user.LName}");
        }
        Console.WriteLine("");
    }

    //VIEW ALL HARDWARE
    public void viewHardware()
    {
        Console.WriteLine("");
        Console.WriteLine("List of hardware:");
        foreach (var hardware in _hardware)
        {
            Console.WriteLine($"ID:{hardware.Id}      Model: {hardware.Model} , Brand: {hardware.Brand} , Status: {hardware.Status}");
        }
        Console.WriteLine("");
    }
    //VIEW ALL AVAILABLE HARDWARE
    public void viewAvailableHardware()
    {
        Console.WriteLine("");
        Console.WriteLine("List of available hardware:");
        foreach (var hardware in _hardware.Where(h => h.Status == RentStatus.Available))
        {
            Console.WriteLine($"ID:{hardware.Id}      Model: {hardware.Model} , Brand: {hardware.Brand}");
        }
        Console.WriteLine("");
    }



    //CREATE NEW RENT WITH VERIFICATIONS
    public void CreateRent(User user, Hardware hardware, DateTime from, DateTime to)
    {   
        if (hardware.Status != RentStatus.Available)
        {
            Console.WriteLine("");
            Console.WriteLine($"Hardware of model {hardware.Model} and id {hardware.Id} is not available");
            Console.WriteLine("");
            return;
        }

        int activeUserRents = _rents.Count(rent => rent.User == user);

        if (activeUserRents >= user.GetRentLimit())
        {
            Console.WriteLine("");
            Console.WriteLine($"Too many active rents, your limit is {user.GetRentLimit()}");
            Console.WriteLine("");
            return;
        } 

        bool rentConflict = _rents.Any(rent => rent.Overlaps(hardware, from, to));

        if (rentConflict)
        {
            Console.WriteLine("");
            Console.WriteLine($"This hardware of model {hardware.Model} and id {hardware.Id} is already rented during this period of time.");
            Console.WriteLine("");
            return;
        }

        var newRent = new Rent(hardware, user, from, to);
        _rents.Add(newRent);
        Console.WriteLine("");
        Console.WriteLine($"Rent of id {newRent.Id} created successfully for {user.FName} {user.LName}.");
        Console.WriteLine("");
    }

    //RETURN RENT WITH VERIFICATIONS
    public void ReturnRent(int rentId, DateTime returnDate)
    {
        var rent = _rents.FirstOrDefault(r => r.Id == rentId);
        if (rent == null)
        {
            Console.WriteLine("");
            Console.WriteLine($"Rent of id {rentId} not found.");
            Console.WriteLine("");
            return;
        }
        string returnInfo = rent.Return(returnDate);
        Console.WriteLine(returnInfo);
        _returnedRents.Add(rent);
        _rents.Remove(rent);
        Console.WriteLine("");
        Console.WriteLine($"Rent of id {rent.Id} returned successfully.");
        Console.WriteLine("");
    }


    //CANCEL RENT
    public void CancelRent(int rentId)
    {
        var rent = _rents.FirstOrDefault(r => r.Id == rentId);
        if (rent == null)
        {
            Console.WriteLine("");
            Console.WriteLine("Rent not found.");
            Console.WriteLine("");
            return;
        }
        _rents.Remove(rent);
        Console.WriteLine("");
        Console.WriteLine($"Rent of id {rent.Id} cancelled successfully.");
        Console.WriteLine("");
    }


    //GET ACTIVE RENTS
    public List<Rent> GetActiveRents()
    {
        Console.WriteLine("");
        var rents = _rents.ToList();
        Console.WriteLine("Active rents:");
        foreach (var rent in rents)
        {
            Console.WriteLine($"--INFO: ID: {rent.Id} , Hardware: {rent.Hardware.Model} , User: {rent.User.FName} {rent.User.LName} , From: {rent.From} , To: {rent.To}");
        }
        Console.WriteLine("");
        return rents;
    }


    //GET RETURNED RENTS
    public List<Rent> GetReturnedRents()
    {
        Console.WriteLine("");
        var rents = _returnedRents.ToList();
        Console.WriteLine("Returned Rents:");
        foreach (var rent in rents)
        {
            
            Console.WriteLine($"--INFO: ID: {rent.Id} , Hardware: {rent.Hardware.Model} , User: {rent.User.FName} {rent.User.LName} , From: {rent.From} , To: {rent.To} , Was returned on time: {rent.WasReturnedOnTime} , Penalty: {rent.Penalty}");
        }
        Console.WriteLine("");
        return rents; 

    }
    //FULL RENTING SERVICE REPORT
    public void FullReport()
    {
        Console.WriteLine("");
        Console.WriteLine("Full renting service report:");
        foreach (var rent in _rents)
        {
            Console.WriteLine($"--INFO: ID: {rent.Id} , Hardware: {rent.Hardware.Model} , User: {rent.User.FName} {rent.User.LName} , From: {rent.From} , To: {rent.To}");
        }
        foreach (var rent in _returnedRents)
        {
            Console.WriteLine($"--INFO: ID: {rent.Id} , Hardware: {rent.Hardware.Model} , User: {rent.User.FName} {rent.User.LName} , From: {rent.From} , To: {rent.To} , Was returned on time: {rent.WasReturnedOnTime} , Penalty: {rent.Penalty}");
         }
        Console.WriteLine("");
    }
}


