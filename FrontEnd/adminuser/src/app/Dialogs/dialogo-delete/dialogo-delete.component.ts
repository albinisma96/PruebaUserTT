import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Usuarios } from 'src/Interfaces/usuarios';
import { UsuariosService } from 'src/Services/usuarios.service';
@Component({
  selector: 'app-dialogo-delete',
  templateUrl: './dialogo-delete.component.html',
  styleUrls: ['./dialogo-delete.component.sass']
})
export class DialogoDeleteComponent implements OnInit {

  tituloAccion:string = "Registrar Usuario";
  botonAccion:string = "Aceptar";
  constructor(
    private dialogReferencia: MatDialogRef<DialogoDeleteComponent>,

    @Inject (MAT_DIALOG_DATA) public dataUsuario:Usuarios

  ){

  }

  ngOnInit(): void {
    
  }

  confirmar_Eliminar(){
    if(this.dataUsuario){
      this.dialogReferencia.close("eliminar")
    }
  }

}
