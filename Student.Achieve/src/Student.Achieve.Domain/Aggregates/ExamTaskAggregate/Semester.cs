using Fabricdot.Domain.ValueObjects;

public class Semester:Enumeration
{
    public static readonly Semester LastSemester=new (1,nameof(LastSemester));
    public static readonly Semester NextSemester=new (2,nameof(NextSemester));

    internal Semester(
            int value,
            string name) : base(value, name)
        {
        }

}