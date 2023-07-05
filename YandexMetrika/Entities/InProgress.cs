using System;
using System.Collections.Generic;

namespace YandexMetrika.Entities;

public partial class InProgress
{
    public string Id { get; set; } = null!;

    public string ContactData { get; set; } = null!;

    public string DataType { get; set; } = null!;

    public DateTime CreateDateTime { get; set; }
}
