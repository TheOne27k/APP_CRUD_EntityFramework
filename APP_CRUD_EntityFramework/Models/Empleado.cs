using System;
using System.Collections.Generic;

namespace APP_CRUD_EntityFramework.Models;

public partial class Empleado
{
    public int Idempleado { get; set; }

    public string NomEmp { get; set; } = null!;

    public string? MailEmp { get; set; }

    public string? TelEmp { get; set; }

    public string EstEmp { get; set; } = null!;

    public int Idcargo { get; set; }

    public virtual Cargo oCargo { get; set; } = null!;
}
