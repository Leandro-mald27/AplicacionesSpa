using System;

namespace Entity
{
    public class Paciente
    {
        public string identificacion { get; set; }
        public double valorServicio { get; set; }
        public double tarifa { get; set; }
        public double salario { get; set; }
        public double copago { get; set; }

        public void CalcularCopago(){
            if(salario>2500000){
                tarifa=0.20;
                copago=tarifa*valorServicio;
            }else{
                if(salario<=2500000){
                    tarifa=0.10;
                    copago=tarifa*valorServicio;
                }
            }
        }
    }
}
