import { Injectable } from '@angular/core';

import { HttpClient } from '@angular/common/http';
import { Usuarios } from '../Interfaces/usuarios';
import {  Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})



export class UsuariosService {
  private apiurl:string = "https://localhost:44385/api/Usuarios/"
  constructor(private http:HttpClient) { }
  getList():Observable<Usuarios[]>{
    return this.http.get<Usuarios[]>(`${this.apiurl}`)
  }
  add(modelo:Usuarios):Observable<void>{
    return this.http.post<void>(`${this.apiurl}Guardar`,modelo)
  }
  update(idusuario:number,modelo:Usuarios):Observable<void>{
    return this.http.put<void>(`${this.apiurl}Actualizar/${idusuario}`,modelo)
    
  }
  delete(idusuario:number):Observable<void>{
    return this.http.delete<void>(`${this.apiurl}Eliminar/${idusuario}`)
  }

}
