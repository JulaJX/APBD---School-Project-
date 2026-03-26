using MyProject.Models;

namespace MyProject.Services.Rents;

public interface IRentingService
{
    public void CreateUser(string fName, string lName, string userType);
    public void viewUsers();
    public void viewHardware();
    public void viewAvailableHardware();
    public void FullReport();
    public void createProjector(string model, string brand, bool hasZoomLens, int projectionSize);
    public void createCamera(string model, string brand, bool has4K, int internalMemory);
    public void createLaptop(string model, string brand, bool hasRamSlots, int ramMemory);
    public void makeUnavailable(Hardware hardware);
    public void CreateRent(User user, Hardware hardware, DateTime from, DateTime to);
    public void ReturnRent(int rentId, DateTime returnDate);
    public List<Rent> GetActiveRents();
    public List<Rent> GetReturnedRents();
    public void CancelRent(int rentId);

}