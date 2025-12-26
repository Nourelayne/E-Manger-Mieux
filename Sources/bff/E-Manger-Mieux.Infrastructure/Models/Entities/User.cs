namespace Models.Entities;

public class User
{
    public Guid Id { get; set; }

    public string AuthSubject { get; set; } = null!;

    public bool IsVerified { get; set; }

    public DateTimeOffset CreateAt { get; set; }

    public DateTimeOffset UpdateAt { get; set; }

    public virtual Profile? Profile { get; set; }
}
