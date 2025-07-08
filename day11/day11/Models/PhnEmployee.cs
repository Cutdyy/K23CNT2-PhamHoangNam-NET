using System;
using System.Collections.Generic;

namespace day11.Models;

public partial class PhnEmployee
{
    public int PhnEmpId { get; set; }

    public string? PhnEmpName { get; set; }

    public string? PhnEmpLevel { get; set; }

    public DateOnly? PhnEmpStartDate { get; set; }

    public bool? PhnEmpStatus { get; set; }
}
