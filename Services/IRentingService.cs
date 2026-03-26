using MyProject.Models;

namespace MyProject.Services.Rents;

public interface IRentingService
{
    public void CreateRent(User user, Hardware hardware, DateTime from, DateTime to);
    public void ReturnRent(int rentId, DateTime returnDate);
    public List<Rent> GetActiveRents();
    public List<Rent> GetReturnedRents();
    public void CancelRent(int rentId);
    
}