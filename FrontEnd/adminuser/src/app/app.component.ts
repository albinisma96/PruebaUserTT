import {AfterViewInit, Component, ViewChild, OnInit} from '@angular/core';
import {MatPaginator, MatPaginatorModule} from '@angular/material/paginator';
import {MatTableDataSource, MatTableModule} from '@angular/material/table';

import { Usuarios } from 'src/Interfaces/usuarios';
import { UsuariosService } from 'src/Services/usuarios.service';
import {MatDialog, MatDialogModule,} from '@angular/material/dialog';
import { DialogAddEditComponent } from './Dialogs/dialog-add-edit/dialog-add-edit.component';
import { MatSnackBar } from '@angular/material/snack-bar';
import { DialogoDeleteComponent } from './Dialogs/dialogo-delete/dialogo-delete.component';
import { Departamentos } from 'src/Interfaces/departamentos';
import { DepartamentosService } from 'src/Services/departamentos.service';
import { Cargos } from 'src/Interfaces/cargos';
import { CargosService } from 'src/Services/cargos.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.sass']
})
export class AppComponent  implements AfterViewInit,OnInit {
  displayedColumns: string[] = ['usuario', 'primerNombre', 'primerApellido', 'idDepartamento','idCargo','correo','Acciones'];
  dataSource = new MatTableDataSource<Usuarios>();
  listaDepartamentos: Departamentos[]=[];
  listaCargos: Cargos[]=[];
  filas = 0;
  constructor (private _usuario : UsuariosService,
    public dialog: MatDialog,
    private _snackBar:MatSnackBar,
    private _departamentoServicio:DepartamentosService,
    private _cargosServicio:CargosService,
    
    ){

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
  dialogNuevoUsuario() {
    this.dialog.open(DialogAddEditComponent,{
      height: '725px',
      width: '600px',
      disableClose:true,

    }).afterClosed().subscribe(resultado => {
      if(resultado =="creado"){
        this.mostrarUsuarios();
      }
    });
  }



  dialogEditarUsuario(dataUsuario:Usuarios) {
    console.log(dataUsuario)
    this.dialog.open(DialogAddEditComponent,{
      height: '725px',
      width: '600px',
      disableClose:true,
      data:dataUsuario

    }).afterClosed().subscribe(resultado => {
      if(resultado =="editado"){
        this.mostrarUsuarios();
      }
    });
  }

  alerta(mensaje:string,accion:string){
    this._snackBar.open(mensaje,accion),{
      horizontalPosition:'end',
      verticalPosition:'top',
      duration:3000
    }
  }

  dialogEliminarUsuario(dataUsuario:Usuarios) {
    this.dialog.open(DialogoDeleteComponent,{
      position: {right:'40%', top: '50px'} ,
      disableClose:true,
      data:dataUsuario

    }).afterClosed().subscribe(resultado => {
      if(resultado =="eliminar"){
        this._usuario.delete(dataUsuario.id).subscribe({
          next:(data) =>{

            this.alerta("Usuario fue Eliminado","Listo");
            this.mostrarUsuarios();
    
          },error:(e)=>{
            this.alerta("No se pudo Eliminar","Error");
          }
        });
      }
    });
  }

  ngOnInit(): void {
    this.mostrarUsuarios()
  }


  @ViewChild(MatPaginator) paginator!: MatPaginator;

  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
  }

  mostrarUsuarios(){
    this._usuario.getList().subscribe({
    
      next:(dataResponse) => {
        this.filas =dataResponse.length;

        console.log(dataResponse.length);
        this.dataSource.data = dataResponse;
      },error:(e)=>{}
    })
  }
}

