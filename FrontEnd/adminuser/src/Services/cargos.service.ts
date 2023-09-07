import { Injectable } from '@angular/core';
import {  Observable } from 'rxjs';
import { Cargos } from '../Interfaces/cargos';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class CargosService {
  private apiurl:string = "https://localhost:44385/api/Cargos"
  constructor(private http:HttpClient) { }

  getList():Observable<Cargos[]>{
    return this.http.get<Cargos[]>(this.apiurl)
  }
}
