using Entity;
namespace APLICACIONES_SPADOTNET.Models
{
    public class PacienteInputModel
       {
        public string identificacion { get; set; }
        public double valorServicio { get; set; }
        public double tarifa { get; set; }
        public double salario { get; set; }
       }

    public class PacienteViewModel : PacienteInputModel
     {
        public PacienteViewModel()
        {

        }
        public PacienteViewModel(Paciente paciente)
        {
            identificacion = paciente.identificacion;
            valorServicio = paciente.valorServicio;
            tarifa = paciente.tarifa;
            salario = paciente.salario;
            copago = paciente.copago;
        }
        public double copago { get; set; }
    }
}