using System;
using System.Collections.Generic;

namespace EFCoreDBExp.Models;

public partial class Userdetail
{
    public int Userid { get; set; }

    public string? Username { get; set; }

    public string? Gender { get; set; }

    public DateTime? Dob { get; set; }

    public string? City { get; set; }

    public string? Resumefilename { get; set; }
}
