using System;
using System.Collections.Generic;

namespace YandexMetrika.Entities;

public partial class InnDomain
{
    public int Id { get; set; }

    public string Inn { get; set; } = null!;

    public string DomainCorp { get; set; } = null!;

    public string? DomainSecondCorp { get; set; }
}
