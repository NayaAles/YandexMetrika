
namespace YandexMetrika.EntitiesYandexMetrika;

public partial class InProgress
{
    public int Id { get; set; }

    public string EmailsMd5 { get; set; } = null!;

    public string PhonesMd5 { get; set; } = null!;

    public string OrderStatus { get; set; } = null!;

    public DateTime? CreateDateTime { get; set; }
}
