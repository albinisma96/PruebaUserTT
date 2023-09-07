import { Cargos } from "./cargos";
import { Departamentos } from "./departamentos";

export interface Usuarios {
    id:number,
    usuario:string,
    correo:string,
    primerNombre:string,
    segundoNombre:string,
    primerApellido:string,
    segundoApellido:string,
    idDepartamento:Departamentos,
    idCargo:Cargos,
    
}
