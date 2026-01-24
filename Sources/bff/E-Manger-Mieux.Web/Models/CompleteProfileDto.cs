namespace Models;

using Models.Enums;

public class CompleteProfileDto
{
    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public DateTimeOffset DateOfBirth { get; set; }

    public GenderType Gender { get; set; }

    public decimal Height { get; set; } 

    public decimal Weight { get; set; }
}
