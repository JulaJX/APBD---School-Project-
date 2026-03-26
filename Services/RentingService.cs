using MyProject.Enums;
using MyProject.Models;

namespace MyProject.Services.Rents;

public class RentingService : IRentingService
{
    private readonly List<Rent> _rents = [];
    private readonly List<Rent> _returnedRents = [];
    
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
}


