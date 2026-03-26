using MyProject.Enums;
using MyProject.Models;

namespace MyProject.Services.Rents;

public class RentingService : IRentingService
{
    private readonly List<Rent> _rents = [];
    
    
    //CREATE NEW RENT WITH VERIFICATIONS
    public void CreateRent(User user, Hardware hardware, DateTime from, DateTime to)
    {
        if (hardware.Status != RentStatus.Available)
        {
            Console.WriteLine("Hardware is not available");
            return;
        }

        int activeUserRents = _rents.Count(rent => 
                                        !rent.IsCancelled 
                                        && rent.User == user);

        if (activeUserRents >= user.GetRentLimit())
        {
            Console.WriteLine($"Too many active rents, your limit is {user.GetRentLimit()}");
            return;
        } 

        bool rentConflict = _rents.Any(rent =>
                                        !rent.IsCancelled
                                        && rent.Overlaps(hardware, from, to));

        if (rentConflict)
        {
            Console.WriteLine($"This hardware is already rented during this period of time.");
            return;
        }

        var newRent = new Rent(hardware, user, from, to);
        _rents.Add(newRent);
        
        Console.WriteLine("Rent created successfully.");
    }
}