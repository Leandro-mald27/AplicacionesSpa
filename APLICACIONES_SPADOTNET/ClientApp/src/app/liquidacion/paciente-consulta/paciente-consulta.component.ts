import { Component, OnInit } from '@angular/core';
import {Paciente} from '../modals/paciente';
import {PacienteService} from '../../services/paciente.service';

@Component({
  selector: 'app-paciente-consulta',
  templateUrl: './paciente-consulta.component.html',
  styleUrls: ['./paciente-consulta.component.css']
})
export class PacienteConsultaComponent implements OnInit {

  constructor(private pacienteServise: PacienteService) { }

  pacientes: Paciente[];
  searchText:string;

  ngOnInit() {
    
  }
  get(){
    this.pacienteServise.get().subscribe(result=>{
      this.pacientes=result;
    });
  }

}
