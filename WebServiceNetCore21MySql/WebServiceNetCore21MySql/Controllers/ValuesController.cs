using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebServiceNetCore21MySql.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpGet("ConsultarRegistros")]
        public JsonResult traer()
        {
            var CP = new PrincipalController();
            CP.ConsultaRegistros();
            return new JsonResult(CP.Informacion);
        }

        [HttpGet("InformacionUsuario")]
        public JsonResult TraerUsuario(int ID)
        {
            var CP = new PrincipalController();
            CP.ConsultarRegistroUsuario(ID);
            return new JsonResult(CP.Informacion);
        }

        [HttpGet("AlmacenaInformacionUsuario")]
        public JsonResult AlmacenarInformacionUsuario(int Id, string Nombre, string Direccion, string Telefono, string correo, int Edad)
        {
            var CP = new PrincipalController();
            return new JsonResult(CP.AlmacenarInformacionUsuario(Id, Nombre, Direccion, Telefono, correo, Edad));
        }
    }
}
