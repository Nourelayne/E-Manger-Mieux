namespace Models.Entities;

using Models.Enums;

public class Profile
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public DateTimeOffset DateOfBirth { get; set; }

    public GenderType Gender { get; set; }

    public decimal Height { get; set; } 

    public HeightUnit HeightUnit { get; set; } = HeightUnit.Cm;

    public decimal Weight { get; set; } 

    public WeightUnit WeightUnit { get; set; } = WeightUnit.Kg;

    public virtual User User { get; set; } = null!;
}
