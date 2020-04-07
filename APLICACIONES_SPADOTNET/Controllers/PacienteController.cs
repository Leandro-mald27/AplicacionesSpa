using System.Collections.Generic;
using System.Linq;
using Entity;
using Logica;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using APLICACIONES_SPADOTNET.Models;
namespace APLICACIONES_SPADOTNET.Controllers
{
    public class PacienteController : ControllerBase
    {
        private readonly PacienteService _pacienteService;
        public IConfiguration Configuration { get; }

        public PacienteController(IConfiguration configuration)
        {
            Configuration = configuration;
            string connectionString = Configuration["ConnectionStrings:DefaultConnection"];
            _pacienteService=new PacienteService(connectionString);
        }
        // GET: api/Persona
        [HttpGet]
        public IEnumerable<PacienteViewModel> Gets()
        {
            var pacientes = _pacienteService.ConsultarTodos().Select(p=> new PacienteViewModel(p));
            return pacientes;
        }
        [HttpPost]
        public ActionResult<PacienteViewModel> Post(PacienteInputModel pacienteInput)
        {
            Paciente paciente = MapearPaciente(pacienteInput);
            var response = _pacienteService.Guardar(paciente);
            if (response.Error) 
            {
                return BadRequest(response.Mensaje);
            }
            return Ok(response.Paciente);
        }

        private Paciente MapearPaciente( PacienteInputModel pacienteInput)
        {
            var paciente = new Paciente
            {
                identificacion = pacienteInput.identificacion,
                valorServicio = pacienteInput.valorServicio,
                tarifa = pacienteInput.tarifa,
                salario = pacienteInput.salario
            };
            return paciente;
        }
    }
}