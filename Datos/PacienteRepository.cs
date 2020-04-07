using System.Collections.Generic;
using System.Data.SqlClient;
using Entity;

namespace Datos
{
    public class PacienteRepository
    {
        private readonly SqlConnection _connection;
        private readonly List<Paciente> _pacientes= new List<Paciente>();
        public PacienteRepository(ConnectionManager connection)
        {
            _connection= connection._conexion;            
        }


    public void Guardar(Paciente paciente){
        using (var command = _connection.CreateCommand())
        {
        command.CommandText = @"Insert Into Paciente (identificacion,valorServicio,tarifa,salario,copago)
        values (@identificacion,@valorServicio,@tarifa,@salario,@copago)";
        command.Parameters.AddWithValue("@identificacion", paciente.identificacion);
        command.Parameters.AddWithValue("@valorServicio", paciente.valorServicio);
        command.Parameters.AddWithValue("@tarifa", paciente.tarifa);
        command.Parameters.AddWithValue("@salario", paciente.salario);
        command.Parameters.AddWithValue("@copago", paciente.copago);
        var filas = command.ExecuteNonQuery();
        }

        }
        public List<Paciente> ConsultarTodos()
        {
            SqlDataReader dataReader;
            List<Paciente> pacientes = new List<Paciente>();
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "Select * from paciente ";
                dataReader = command.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        Paciente paciente = DataReaderMapToPerson(dataReader);
                        pacientes.Add(paciente);
                        }
                        }
                        }
                        return pacientes;
                        }
    private Paciente DataReaderMapToPerson(SqlDataReader dataReader)
    {
        if(!dataReader.HasRows) return null;
        Paciente paciente = new Paciente();
        paciente.identificacion = (string)dataReader["identificacion"];
        paciente.valorServicio = (double)dataReader["valorServicio"];
        paciente.tarifa = (double)dataReader["tarifa"];
        paciente.salario = (double)dataReader["salario"];
        return paciente;
        }
            
      }
      
}
