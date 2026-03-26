namespace MyProject.Models;

public class Student(string fName, string lName) : User(fName, lName)
{
    public string Type = "student";
    public override int GetRentLimit() => 2;
}