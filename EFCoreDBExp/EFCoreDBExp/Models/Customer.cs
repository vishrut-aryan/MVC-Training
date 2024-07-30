using System;
using System.Collections.Generic;

namespace EFCoreDBExp.Models;

public partial class Customer
{
    public int Custid { get; set; }

    public string? Custname { get; set; }

    public string? Custemail { get; set; }

    public string? Custmobile { get; set; }
}
