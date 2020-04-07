import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Paciente } from '../liquidacion/modals/paciente';
import {catchError,map,tap} from 'rxjs/operators';
import { HandleHttpErrorService } from '../@base/handle-http-error.service';

@Injectable({
  providedIn: 'root'
})
export class PacienteService {
   baseUrl: string;
  constructor(  private http: HttpClient, 
                @Inject('BASE_URL') baseUrl: string,
               private handleErrorService: HandleHttpErrorService)
             {
    this.baseUrl = baseUrl;
                }
  get(): Observable<Paciente[]> { return this.http.get<Paciente[]>(this.baseUrl + 'api/Paciente')   
  .pipe( tap(_ => this.handleErrorService.log('datos enviados')),   
                        catchError(this.handleErrorService.hadleError<Paciente[]>('Consulta Paciente', null))
                        );  }
    post(persona: Paciente): Observable<Paciente> {
    return this.http.post<Paciente>(this.baseUrl + 'api/Persona', persona)
    .pipe(
    tap(_ => this.handleErrorService.log('datos enviados')),
    catchError(this.handleErrorService.hadleError<Paciente>('Registrar Persona', null))
    );
   }
}
