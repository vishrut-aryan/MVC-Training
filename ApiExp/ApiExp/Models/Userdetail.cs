using System;
using System.Collections.Generic;

namespace ApiExp.Models;

public partial class Userdetail
{
    public int Userid { get; set; }

    public string? Username { get; set; }

    public string? Password { get; set; }

    public string? Email { get; set; }

    public string? Mobile { get; set; }
}
