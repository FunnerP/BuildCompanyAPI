using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BuildCompanyAPI.Models;

public partial class Worker
{
    public int IdWorker { get; set; }

    public string? Firstname { get; set; }

    public string? Surname { get; set; }

    public string? Lastname { get; set; }

    public string? Post { get; set; }

    public string? Adress { get; set; }

    public string? Number { get; set; }
    [JsonIgnore]
    public virtual ICollection<Brigade> Brigades { get; set; } = new List<Brigade>();
}
