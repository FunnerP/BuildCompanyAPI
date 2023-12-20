using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BuildCompanyAPI.Models;

public partial class Brigade
{
    public int IdBrigade { get; set; }

    public int? IdWorker { get; set; }
    [JsonIgnore]
    public virtual Worker? IdWorkerNavigation { get; set; }
    [JsonIgnore]
    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
