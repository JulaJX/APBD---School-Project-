namespace MyProject.Models;

public class Rent(Hardware hardware, User user, DateTime from, DateTime to)
{
    private static int _nextId = 1;
    
    public int Id { get; set; } = _nextId++;
    public Hardware Hardware { get; set; } = hardware;
    public User User { get; set; } = user;
    public DateTime From { get; set; } = from >= to ? throw new ArgumentException("Starting date cannot be after End date.") : from;
    public DateTime To { get; set; } = to;
    public bool IsCancelled { get; private set; } = false;
    
    public void Cancel()
    {
        IsCancelled = true;
    }

    public bool Overlaps(DateTime from, DateTime to)
    {
        return !(From > to || from > To);
    }
}