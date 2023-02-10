import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';
import { util } from 'utils/util';
import { AlgoritmosDto } from './algoritmos';
@Injectable({
  providedIn: 'root'
})
export class AlgoritmosService {

 
  private algoritmosUrl = 'https://vs-gate.dei.isep.ipp.pt:30782/'; // URL to web api

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json'})
  };

  constructor(
    private http: HttpClient,
  ) { }

   getCaminhoCurto(orig: string, dest : string): Observable<string[]> {
    return this.http.get<string[]>(this.algoritmosUrl + "/caminhoCurto" + orig+"/"+dest)
      .pipe(
        catchError(this.handleError<string[]>('getCaminhoCurto'))
      );
  }

  getBfs(orig: string, dest : string, n : number): Observable<AlgoritmosDto> {
    return this.http.get<AlgoritmosDto>(this.algoritmosUrl + "bfs?orig="+orig+"&dest="+dest+"&n="+n)
      .pipe(
        catchError(this.handleError<AlgoritmosDto>('getBfs'))
      );
  }

  getBfsE(orig: string, dest : string, n : number): Observable<AlgoritmosDto> {
    return this.http.get<AlgoritmosDto>(this.algoritmosUrl + "bfsE?orig="+orig+"&dest="+dest+"&n="+n)
      .pipe(
        catchError(this.handleError<AlgoritmosDto>('getBfsE'))
      );
  }

  getSugerir(id: string, n : number, t : number): Observable<AlgoritmosDto> {
    return this.http.get<AlgoritmosDto>(this.algoritmosUrl + "sugerirgrupo?id="+id+"&n="+n+"&t="+t)
      .pipe(
        catchError(this.handleError<AlgoritmosDto>('getSugerir'))
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
