using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using APP_CRUD_EntityFramework.Models.ViewModels;

using APP_CRUD_EntityFramework.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace APP_CRUD_EntityFramework.Controllers
{
    public class HomeController : Controller
    {
        private readonly BdCrudcoreEfContext _BD;

        public HomeController(BdCrudcoreEfContext contexto)
        {
            _BD = contexto;
        }

        public IActionResult Index()
        {
            List<Empleado> lista = _BD.Empleados.Include(c => c.oCargo).Where(e => e.EstEmp == "A")  .ToList();
            return View(lista);
        }
        [HttpGet]
        public IActionResult Empleado_Detalle(int idEmpleado)
        {
            EmpleadoVM oEmpleadoMV = new EmpleadoVM()
            {
                oEmpleado = new Empleado(),
                oListaCargo = _BD.Cargos.Select(cargo => new SelectListItem()
                {
                    Text = cargo.DesCargo,
                    Value = cargo.Idcargo.ToString()
                }).ToList()
            };
            if(idEmpleado != 0)
            {
                oEmpleadoMV.oEmpleado = _BD.Empleados.Find(idEmpleado);
            }
            return View(oEmpleadoMV);
        }
        [HttpPost]
        public IActionResult Empleado_Detalle(EmpleadoVM oEmpleadoVM)
        {
            if(oEmpleadoVM.oEmpleado?.Idempleado == 0)
            {
                oEmpleadoVM.oEmpleado.EstEmp = "A";
                _BD.Empleados.Add(oEmpleadoVM.oEmpleado);
            }
            else
            {
                oEmpleadoVM.oEmpleado.EstEmp = "A";
                _BD.Empleados.Update(oEmpleadoVM.oEmpleado);
            }
            _BD.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public IActionResult eliminar (int idEmpleado)
        {
            Empleado oEmpleado = _BD.Empleados.Include(c => c.oCargo).Where(e => e.Idempleado == idEmpleado).FirstOrDefault();
            return View(oEmpleado);
        }
        [HttpPost]
        public IActionResult eliminar(Empleado oEmpleado)
        {
            oEmpleado.EstEmp = "E";
            _BD.Empleados.Update(oEmpleado);
            _BD.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}