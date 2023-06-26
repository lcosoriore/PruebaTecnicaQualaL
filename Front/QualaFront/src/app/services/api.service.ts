import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class ApiService {
  private apiUrl = 'https://localhost:7226/api';

  constructor(private http: HttpClient) { }

  guardarMoneda(moneda: any): Observable<any> {
    const url = `${this.apiUrl}/Moneda`;
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    return this.http.post(url, { moneda }, { headers }).pipe(
      catchError(this.handleError)
    );
  }

  obtenerMonedas(): Observable<any> {
    const url = `${this.apiUrl}/Moneda`;
    return this.http.get(url).pipe(
      catchError(this.handleError)
    );
  }

  obtenerMonedaPorId(id: number): Observable<any> {
    const url = `${this.apiUrl}/Moneda/${id}`;
    return this.http.get(url).pipe(
      catchError(this.handleError)
    );
  }

  actualizarMoneda(id: number, moneda: any): Observable<any> {
    const url = `${this.apiUrl}/Moneda/${id}`;
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    return this.http.put(url, { moneda }, { headers }).pipe(
      catchError(this.handleError)
    );
  }

  eliminarMoneda(id: number): Observable<any> {
    const url = `${this.apiUrl}/Moneda/${id}`;
    return this.http.delete(url).pipe(
      catchError(this.handleError)
    );
  }

  guardarSucursal(nuevaSucursal: any): Observable<any> {
    const url = `${this.apiUrl}/Sucursal`;
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    return this.http.post(url, { nuevaSucursal }, { headers }).pipe(
      catchError(this.handleError)
    );
  }

  obtenerSucursal(): Observable<any> {
    const url = `${this.apiUrl}/Sucursal`;
    return this.http.get(url).pipe(
      catchError(this.handleError)
    );
  }

  obtenerSucursalPorId(id: number): Observable<any> {
    const url = `${this.apiUrl}/Sucursal/${id}`;
    return this.http.get(url).pipe(
      catchError(this.handleError)
    );
  }

  actualizarSucursal(id: number, sucursal: any): Observable<any> {
    const url = `${this.apiUrl}/Sucursal/${id}`;
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    return this.http.put(url, { sucursal }, { headers }).pipe(
      catchError(this.handleError)
    );
  }

  eliminarSucursal(id: number): Observable<any> {
    const url = `${this.apiUrl}/Sucursal/${id}`;
    return this.http.delete(url).pipe(
      catchError(this.handleError)
    );
  }

  private handleError(error: HttpErrorResponse): Observable<never> {
    if (error.error instanceof ErrorEvent) {
      // Error del lado del cliente
      console.error('Error del lado del cliente:', error.error.message);
    } else {
      // Error del lado del servidor
      console.error('Error del lado del servidor:', error);
    }
    return throwError('Ocurrió un error. Por favor, inténtalo de nuevo más tarde.');
  }
}
