using Microsoft.AspNetCore.Mvc.Rendering;

namespace APP_CRUD_EntityFramework.Models.ViewModels
{
    public class EmpleadoVM
    {
        public Empleado? oEmpleado { get; set; }
        public List<SelectListItem>? oListaCargo { get; set; }
    }
}
