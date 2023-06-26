import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { ApiService } from '../services/api.service';

interface Moneda {
  monedaid: number;
  moneda: string;
}

@Component({
  selector: 'app-moneda',
  templateUrl: './moneda.component.html',
  styleUrls: ['./moneda.component.css']
})
export class MonedaComponent implements OnInit {
  monedaForm: FormGroup;
  monedas: Moneda[] = [];
  filtro: string = '';
  dtOptions: DataTables.Settings = {};
  constructor(private formBuilder: FormBuilder, private http: HttpClient, private apiService: ApiService) {
    this.monedaForm = this.formBuilder.group({
      moneda: ['', Validators.required]
    });
  }

  ngOnInit(): void {
    this.dtOptions = {
      pagingType: 'full_numbers',
      pageLength: 10,
      processing: true,
      dom: 'Bfrtip'
    };

    this.ObtenerMonedas();   
   
  }
  guardarMoneda() {
    const moneda = this.monedaForm.get('moneda')?.value;
    this.apiService.guardarMoneda(moneda).subscribe(
      (response: Response) => {
        alert("Moneda guardada correctamente");
        this.monedaForm.reset();
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

  editarMoneda(moneda: Moneda) {
    const monedaId = moneda.monedaid;
    const nuevaMoneda = prompt("Ingrese el nuevo valor de la moneda", moneda.moneda);
    if (nuevaMoneda) {
      this.apiService.actualizarMoneda(monedaId, nuevaMoneda).subscribe(
        () => {
          alert("Moneda editada correctamente");
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

  eliminarMoneda(moneda: Moneda) {
    const monedaId = moneda.monedaid;
    this.apiService.eliminarMoneda(monedaId).subscribe(
      () => {
        alert("Moneda eliminada correctamente");
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
        this.dtOptions = {
          data: this.monedas,
          columns: [
            { title: 'ID', data: 'monedaid' },
            { title: 'Moneda', data: 'moneda' }
          ]
        };
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
