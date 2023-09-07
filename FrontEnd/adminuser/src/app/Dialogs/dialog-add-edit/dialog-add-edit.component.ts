import { Component, OnInit, Inject } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Departamentos } from 'src/Interfaces/departamentos';
import { DepartamentosService } from 'src/Services/departamentos.service';
import { Cargos } from 'src/Interfaces/cargos';
import { CargosService } from 'src/Services/cargos.service';
import { Usuarios } from 'src/Interfaces/usuarios';
import { UsuariosService } from 'src/Services/usuarios.service';

@Component({
  selector: 'app-dialog-add-edit',
  templateUrl: './dialog-add-edit.component.html',
  styleUrls: ['./dialog-add-edit.component.sass']
})
export class DialogAddEditComponent implements OnInit{
  formUsuario:FormGroup;
  tituloAccion:string = "Registrar Usuario";
  botonAccion:string = "Registrar";
  listaDepartamentos: Departamentos[]=[];
  listaCargos: Cargos[]=[];
 
  constructor(
    private dialogReferencia: MatDialogRef<DialogAddEditComponent>,
    private fb:FormBuilder,
    private _snackBar:MatSnackBar,
    private _departamentoServicio:DepartamentosService,
    private _cargosServicio:CargosService,
    private  _usuarioServicio:UsuariosService,
    @Inject (MAT_DIALOG_DATA) public dataUsuario:Usuarios

  ){
    this.formUsuario = this.fb.group({
      usuario:['',Validators.required],
      correo:['',Validators.required],
      primerNombre:['',Validators.required],
      segundoNombre:['',Validators.required],
      primerApellido:['',Validators.required],
      segundoApellido:['',Validators.required],
      idDepartamento:['',Validators.required],
      idCargo:['',Validators.required],
    })

    this._departamentoServicio.getList().subscribe({
      next:(dataResponse) => {
        this.listaDepartamentos = dataResponse;
      },error:(e)=>{}
    }),
    this._cargosServicio.getList().subscribe({
      next:(dataResponse) => {
        this.listaCargos = dataResponse;
      },error:(e)=>{}
    })

  }

  alerta(mensaje:string,accion:string){
    this._snackBar.open(mensaje,accion),{
      horizontalPosition:'end',
      verticalPosition:'top',
      duration:3000
    }
  }


  addEditUsuario(){
   
    const modelo:Usuarios = {
    id:0,
    usuario:this.formUsuario.value.usuario,
    correo:this.formUsuario.value.correo,
    primerNombre:this.formUsuario.value.primerNombre,
    segundoNombre:this.formUsuario.value.segundoNombre,
    primerApellido:this.formUsuario.value.primerApellido,
    segundoApellido:this.formUsuario.value.segundoApellido,
    idDepartamento:this.formUsuario.value.idDepartamento,
    idCargo:this.formUsuario.value.idCargo,

  }
  if(this.dataUsuario == null){
    this._usuarioServicio.add(modelo).subscribe({
      next:(data) =>{

        this.alerta("Usuario fue creado","Listo")
        this.dialogReferencia.close("creado")

      },error:(e)=>{
        this.alerta("No se pudo crear","Error")
      }

  })
  }else{
    this._usuarioServicio.update(this.dataUsuario.id,modelo).subscribe({
      next:(data) =>{
          
        this.alerta("Usuario fue Actualizado","Listo")
        this.dialogReferencia.close("editado")

      },error:(e)=>{
        this.alerta("No se pudo Editar","Error")
      }

  })

  }
  }

  
  ngOnInit(): void {
    if(this.dataUsuario){
      console.log(this.dataUsuario.idDepartamento);
      this.formUsuario.patchValue({
        usuario:this.dataUsuario.usuario,
        correo:this.dataUsuario.correo,
        primerNombre:this.dataUsuario.primerNombre,
        segundoNombre:this.dataUsuario.segundoNombre,
        primerApellido:this.dataUsuario.primerApellido,
        segundoApellido:this.dataUsuario.segundoApellido,
        idDepartamento:this.dataUsuario.idDepartamento.id,
        idCargo:this.dataUsuario.idCargo.id,

      })

      this.tituloAccion = "Editar Usuario";
      this.botonAccion = "Actualizar";
    }
  }
}
