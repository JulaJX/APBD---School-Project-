namespace MyProject.Models;

public class Rent(Hardware hardware, User user, DateTime from, DateTime to)
{
    private static int _nextId = 1;
    
    public int Id { get; set; } = _nextId++;
    public Hardware Hardware { get; set; } = hardware;
    public User User { get; set; } = user;
    public DateTime From { get; set; } = from >= to ? throw new ArgumentException("Starting date cannot be after End date.") : from;
    public DateTime To { get; set; } = to;

    public bool WasReturnedOnTime { get; private set; } = false; 
    public decimal Penalty { get; private set; } = 0;
    
    public string Return(DateTime returnDate)
    {
        WasReturnedOnTime = returnDate <= To;
        Penalty = WasReturnedOnTime ? 0 : 500; 
        return $"Rent returned. Was returned on time: {WasReturnedOnTime}, Penalty: {Penalty}";
    }
    
    public bool Overlaps(Hardware hardware,DateTime from, DateTime to)
    {
        return Hardware.Id == hardware.Id && !(From > to || from > To);
    }
}