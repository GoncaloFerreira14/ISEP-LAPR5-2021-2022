import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, Observable, of } from 'rxjs';
import { util } from 'utils/util';
import { Comentario } from '../model/comentario';
import { Post } from '../model/post';

@Injectable({
  providedIn: 'root'
})
export class ComentariosService {

  private comentariosUrl = util.URL + 'comentarios';

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };

  constructor(private http: HttpClient) { }

  /** GET - obtem todos os comentarios do post */
  getComentariosOfPost(id: string): Observable<Comentario[]> {
    return this.http.get<Comentario[]>(this.comentariosUrl + "/" + id)
      .pipe(
        catchError(this.handleError<Comentario[]>('getComentariosOfPost'))
      );
  }

  /** POST: adiciona um comentario */
  add(comentario: Comentario): Observable<Comentario> {
    console.log(comentario);
    return this.http.post<Comentario>(this.comentariosUrl, comentario, this.httpOptions).pipe(
      catchError(this.handleError<Comentario>('addComentario'))
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
