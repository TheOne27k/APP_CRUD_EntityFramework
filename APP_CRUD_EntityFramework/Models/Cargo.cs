using System;
using System.Collections.Generic;

namespace APP_CRUD_EntityFramework.Models;

public partial class Cargo
{
    public int Idcargo { get; set; }

    public string DesCargo { get; set; } = null!;

    public virtual ICollection<Empleado> Empleados { get; set; } = new List<Empleado>();
}
