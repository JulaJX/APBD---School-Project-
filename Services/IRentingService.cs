using MyProject.Models;

namespace MyProject.Services.Rents;

public interface IRentingService
{
    public void CreateRent(User user, Hardware hardware, DateTime from, DateTime to);
}