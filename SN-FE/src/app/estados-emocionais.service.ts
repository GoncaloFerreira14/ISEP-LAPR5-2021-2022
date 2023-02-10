import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';
import { EstadoEmocionalDto } from './estadoEmocional';
import { util } from 'utils/util';
@Injectable({
  providedIn: 'root'
})
export class EstadosEmocionaisService {

  private Url = util.URL+'EstadosEmocionais';
  
  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };
  constructor(private http: HttpClient) { }

  editEstado(estado: EstadoEmocionalDto) {
    console.log(this.Url);
    return this.http.put(this.Url + "/" + estado.id, estado, this.httpOptions).pipe(catchError(this.handleError('EditEstado')));
  }

  /**
   * Handle Http operation that failed.
   * Let the app continue.
   * @param operation - name of the operation that failed
   * @param result - optional value to return as the observable result
   */
  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {

      // TODO: send the error to remote logging infrastructure
      console.error(error); // log to console instead

      // Let the app keep running by returning an empty result.
      return of(result as T);
    };
  }
}
