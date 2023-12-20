using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BuildCompanyAPI.Models;

public partial class Order
{
    public int IdOrder { get; set; }

    public int? IdClient { get; set; }

    public int? IdBrigade { get; set; }

    public byte[] Date { get; set; } = null!;

    public int? Cost { get; set; }
    [JsonIgnore]
    public virtual Brigade? IdBrigadeNavigation { get; set; }
    [JsonIgnore]
    public virtual Client? IdClientNavigation { get; set; }
}
