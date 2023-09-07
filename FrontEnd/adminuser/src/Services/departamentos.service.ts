import { Injectable } from '@angular/core';
import { Departamentos } from '../Interfaces/departamentos';
import { HttpClient } from '@angular/common/http';

import {  Observable } from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class DepartamentosService {
  private apiurl:string = "https://localhost:44385/api/Departamentos"
  constructor(private http:HttpClient) { }

  getList():Observable<Departamentos[]>{
    return this.http.get<Departamentos[]>(this.apiurl)
  }
}
