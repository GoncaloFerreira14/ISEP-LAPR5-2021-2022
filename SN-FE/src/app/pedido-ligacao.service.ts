import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';
import { PedidoLigacaoDto } from './pedidoLigacao';
import { util } from 'utils/util';
@Injectable({
  providedIn: 'root'
})
export class PedidoLigacaoService {
  private pedidosLigacaoUrl = util.URL+'PedidosLigacao'; // URL to web api

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };

  constructor(
    private http : HttpClient,
  ) { }

  addPedidosLigacao(pedido : PedidoLigacaoDto): Observable<PedidoLigacaoDto[]> {
    return this.http.post<PedidoLigacaoDto[]>(this.pedidosLigacaoUrl, pedido, this.httpOptions)
    .pipe(
      catchError(this.handleError<Array<PedidoLigacaoDto>>('addPedidosLigacao'))
      );
  }

  updatePedidoLigacao(pedido : PedidoLigacaoDto) : Observable<any>{
  return this.http.put(this.pedidosLigacaoUrl + "/" + pedido.id, pedido, this.httpOptions)
    .pipe(
      catchError(this.handleError<PedidoLigacaoDto>('updatePedidoLigacao'))
      );
    }

    apagarPedidosLigacaoJog(pedidoId: string): Observable<PedidoLigacaoDto> {
      console.log("AQUI PI ! "+pedidoId);
      return this.http.delete<PedidoLigacaoDto>(this.pedidosLigacaoUrl+ "/"+ pedidoId+"/hard", this.httpOptions).pipe(
        catchError(this.handleError<PedidoLigacaoDto>('delRelacao'))
      );
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