using System;
using System.Collections.Generic;
using Datos;
using Entity;

namespace Logica
{
    public class PacienteService
    {
        private readonly ConnectionManager _conexion;
        private readonly PacienteRepository _repositorio;
        public PacienteService(string connectionString )
        {
            _conexion=new  ConnectionManager(connectionString);
            _repositorio=new PacienteRepository(_conexion);
        }


        public GuardarPacienteResponse Guardar(Paciente persona){
            try
            {
                persona.CalcularCopago();
                _conexion.Open();
                _repositorio.Guardar(persona);
                _conexion.Close();
                return new GuardarPacienteResponse(persona);
                }
                catch (Exception e)
                {
                    return new GuardarPacienteResponse($"Error de la Aplicacion: {e.Message}");
                    }
           finally { _conexion.Close(); }
        }

       public class GuardarPacienteResponse{
                        public GuardarPacienteResponse(Paciente persona)
                        {
                            Error = false;
                            Paciente = persona;
                            }
                            public GuardarPacienteResponse(string mensaje){
                                Error = true;
                                Mensaje = mensaje;
                                 }
                public bool Error { get; set; }
                public string Mensaje { get; set; }
                public Paciente Paciente { get; set; }
            }
        public List<Paciente> ConsultarTodos()
        {
            _conexion.Open();
            List<Paciente> paciente = _repositorio.ConsultarTodos();
            _conexion.Close();
            return paciente;
        }
        
 }
}
