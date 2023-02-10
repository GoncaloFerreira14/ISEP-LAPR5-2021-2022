import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';
import { PedidoIntroducaoDto } from './pedidoIntroducao';
import { util } from 'utils/util';
@Injectable({
  providedIn: 'root'
})
export class PedidoIntroducaoService {
  private pedidosIntroducaoUrl = util.URL+'PedidosIntroducao'; // URL to web api


  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };

  constructor(
    private http: HttpClient,
  ) { }


  addPedidosIntroducao(pedido: PedidoIntroducaoDto): Observable<PedidoIntroducaoDto> {
   
    console.log(pedido.jogadorId);
    return this.http.post<PedidoIntroducaoDto>(this.pedidosIntroducaoUrl, pedido, this.httpOptions)
      .pipe(
        catchError(this.handleError<PedidoIntroducaoDto>('addPedidosIntroducao'))
      );
  }

  /** GET pedidosIntroducao of user */
  getPedidosIntroducaoOfUser(id: string): Observable<PedidoIntroducaoDto[]> {
    return this.http.get<PedidoIntroducaoDto[]>(this.pedidosIntroducaoUrl + "/JogadorInterm/" + id)
      .pipe(
        catchError(this.handleError<Array<PedidoIntroducaoDto>>('getPedidosIntroducao'))
      )
  }

  /** GET pedidosIntroducao from the web api */
  getPedidosIntroducao(): Observable<PedidoIntroducaoDto[]> {
    return this.http.get<PedidoIntroducaoDto[]>(this.pedidosIntroducaoUrl)
      .pipe(
        catchError(this.handleError<Array<PedidoIntroducaoDto>>('getPedidosIntroducao'))
      );
  }

  /** PUT: update pedidoIntroducao on the server */
  updatePedidoIntroducao(pedidoIntroducao: PedidoIntroducaoDto): Observable<any> {
    return this.http.put(this.pedidosIntroducaoUrl + "/" + pedidoIntroducao.id, pedidoIntroducao, this.httpOptions).pipe(
      catchError(this.handleError<Array<PedidoIntroducaoDto>>('updatePedidoIntroducao'))
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
