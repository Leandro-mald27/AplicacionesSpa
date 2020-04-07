export class Paciente {
    identificacion: string;
    valorServicio: number;
    salario:number;
    copago: number;
    Tarifa: number;


    CalcularCopago(): void{

        if(this.salario>2500000){

            this.Tarifa=0.20;
            this.copago=this.Tarifa*this.valorServicio;
        }else{
            this.Tarifa=0.10;
            this.copago=this.Tarifa*this.valorServicio;
        }
    }
}

