import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Evento } from '../models/Evento';

@Injectable(
  //{providedIn: 'root'}
)
export class EventoService {
  baseUrl = 'https://localhost:5001/api/eventos';

  constructor(private http: HttpClient) { }

  public getEvento(): Observable<Evento[]> {
    return this.http.get<Evento[]>(this.baseUrl)
  }

  public getEventosByTema(tema: string): Observable<Evento[]> {
    return this.http.get<Evento[]>(`${this.baseUrl}/${tema}/tema`)
  }

  public getEventoById(id: number): Observable<Evento> {
    return this.http.get<Evento>(`${this.baseUrl}/${id}`)
  }

}
