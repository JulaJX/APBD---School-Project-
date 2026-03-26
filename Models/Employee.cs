namespace MyProject.Models;

public class Employee(string fName, string lName) : User(fName, lName)
{
    public override int GetRentLimit() => 5;
}