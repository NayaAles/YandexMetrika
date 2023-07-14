
namespace YandexMetrika.Entities;

public partial class PhonesInn
{
    public int Id { get; set; }

    public string Inn { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public DateOnly? DateCreate { get; set; }

    public string? SourceCreate { get; set; }
}
