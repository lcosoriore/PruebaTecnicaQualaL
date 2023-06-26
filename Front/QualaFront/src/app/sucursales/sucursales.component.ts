import { Component } from '@angular/core';
import { ApiService } from '../services/api.service';

interface Moneda {
  monedaid: number;
  moneda: string;
}
@Component({
  selector: 'app-sucursales',
  templateUrl: './sucursales.component.html',
  styleUrls: ['./sucursales.component.css']
})

export class SucursalesComponent {
  monedas: Moneda[] = [];
  sucursales: any[] = [];
  // Propiedades
  codigo: number;
  descripcion: string;
  direccion: string;
  identificacion: string;
  fechaCreacion: Date;
  moneda: string;
  constructor(private apiService: ApiService) {
    // Inicializar propiedades
    this.codigo = 0;
    this.descripcion = '';
    this.direccion = '';
    this.identificacion = '';
    this.fechaCreacion = new Date();
    this.moneda = '';
  }
  ngOnInit(): void { 

    this.ObtenerMonedas();
    this.obtenerSucursales();

  }
 
  getCurrentDate(): string {
    const currentDate = new Date();
    const year = currentDate.getFullYear();
    const month = ('0' + (currentDate.getMonth() + 1)).slice(-2);
    const day = ('0' + currentDate.getDate()).slice(-2);
    return `${year}-${month}-${day}`;
  }

  guardarSucursal() {
    const nuevaSucursal = {
      codigo: this.codigo,
      descripcion: this.descripcion,
      direccion: this.direccion,
      identificacion: this.identificacion,
      fechaCreacion: this.getCurrentDate(),
      moneda: this.moneda
    };

    this.apiService.guardarSucursal(nuevaSucursal).subscribe(
      () => {
        alert("Sucursal guardada correctamente");
        this.obtenerSucursales();
      },
      (error) => {
        if (error.status === 400) {
          alert("Error en la solicitud: los datos enviados no son válidos");
        } else if (error.status === 500) {
          alert("Error en el servidor: por favor, inténtalo más tarde");
        } else {
          alert("Error desconocido: por favor, inténtalo más tarde");
        }
      }
    );
  }


  actualizarSucursal() {
    const sucursalActualizada = {
      codigo: this.codigo,
      descripcion: this.descripcion,
      direccion: this.direccion,
      identificacion: this.identificacion,
      fechaCreacion: this.fechaCreacion,
      moneda: this.moneda
    };

    this.apiService.actualizarSucursal(0,sucursalActualizada).subscribe(
      () => {
        alert("Sucursal actualizada correctamente");
        this.obtenerSucursales();
      },
      (error) => {
        if (error.status === 400) {
          alert("Error en la solicitud: los datos enviados no son válidos");
        } else if (error.status === 500) {
          alert("Error en el servidor: por favor, inténtalo más tarde");
        } else {
          alert("Error desconocido: por favor, inténtalo más tarde");
        }
      }
    );
  }

  
  eliminarSucursal() {
    const sucursalCodigo = this.codigo;

    this.apiService.eliminarSucursal(sucursalCodigo).subscribe(
      () => {
        alert("Sucursal eliminada correctamente");
        this.obtenerSucursales();
      },
      (error) => {
        if (error.status === 400) {
          alert("Error en la solicitud: los datos enviados no son válidos");
        } else if (error.status === 500) {
          alert("Error en el servidor: por favor, inténtalo más tarde");
        } else {
          alert("Error desconocido: por favor, inténtalo más tarde");
        }
      }
    );
  }




  ObtenerMonedas() {
    this.apiService.obtenerMonedas().subscribe(
      (response: any) => {
        this.monedas = response
        
      },
      (error) => {
        if (error.status === 400) {
          alert("Error en la solicitud: los datos enviados no son válidos");
        } else if (error.status === 500) {
          alert("Error en el servidor: por favor, inténtalo más tarde");
        } else {
          alert("Error desconocido: por favor, inténtalo más tarde");
        }
      }
    );
  }

  obtenerSucursales() {
    this.apiService.obtenerSucursal().subscribe(
      (response: any[]) => {
        this.sucursales = response;
      },
      (error) => {
        if (error.status === 400) {
          alert("Error en la solicitud: los datos enviados no son válidos");
        } else if (error.status === 500) {
          alert("Error en el servidor: por favor, inténtalo más tarde");
        } else {
          alert("Error desconocido: por favor, inténtalo más tarde");
        }
      }
    );
  }

}
