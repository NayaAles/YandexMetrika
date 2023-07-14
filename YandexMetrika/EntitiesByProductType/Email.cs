
namespace YandexMetrika.Entities;

public partial class Email
{
    public int Id { get; set; }

    public string Email1 { get; set; } = null!;

    public DateOnly? DateCreate { get; set; }

    public string? SourceCreate { get; set; }
}
