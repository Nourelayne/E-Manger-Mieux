namespace Models;

using Models.Enums;

public class ProfileDto
{    
    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public DateTimeOffset? DateOfBirth { get; set; }

    public GenderType? Gender { get; set; }

    public decimal? Height { get; set; } 

    public decimal? Weight { get; set; } 

    public string? AvatarUrl { get; set; }
}
