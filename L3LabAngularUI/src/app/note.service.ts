import { Injectable } from '@angular/core';
import { MessageService } from './message.service';
import { NoteDto } from './note-dto';
import { NOTES } from './mock-notes';
import { Observable, of, throwError } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { TextDto } from './TextDto';

@Injectable({
  providedIn: 'root'
})
export class NoteService {

  private apiUrl = 'https://localhost:7141/api/Note';  // URL to web api
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
      'accept': '/*'
    })
  };

  constructor(private http: HttpClient, private messageService: MessageService) {

  }
  /** Log a NoteService message with the MessageService */
  private log(message: string) {
    this.messageService.add(`NoteService: ${message}`);
  }

  /** GET notes from the server */
  getNotes(): Observable<NoteDto[]> {
    const notes = this.http.get<NoteDto[]>(this.apiUrl)
      .pipe(catchError(this.handleError<NoteDto[]>('api/notes', []))
      );
    this.messageService.add('NoteService: getNotes()');
    return notes;
  }

  /** GET NoteDTO by id. Return `undefined` when id not found */
  getNote(id: number): Observable<NoteDto> {
    const url = `${this.apiUrl}/${id}`;
    const note = this.http.get<NoteDto>(url).pipe(
      tap(_ => this.log(`fetched note id=${id}`)),
      catchError(this.handleError<NoteDto>(`getNote id=${id}`))
    );
    this.messageService.add(`NoteService: getNote(id=${id})`);
    return note;
  }

  /** POST: add a new note to the server */
  createNote(note: NoteDto): Observable<NoteDto> {
    const body = JSON.stringify(note);
    console.log("body > " + body);
    var response = this.http.post<any>(this.apiUrl, body, this.httpOptions).pipe(
      map(this.extractData),
      catchError(this.handleError<NoteDto>('addNote1'))
      //console.log("!!!! > " + body);
    );
    this.messageService.add(`NoteService: createNote(note ${response})`);
    return response;
  }

  /** DELETE: delete the note from the server */
  deleteNote(id: number): Observable<NoteDto> {
    const url = `${this.apiUrl}/${id}`;
    var result = this.http.delete<NoteDto>(url, this.httpOptions).pipe(
      tap(_ => this.log(`deleted note id=${id}`)),
      catchError(this.handleError<NoteDto>('deleteHero'))
    );
    this.messageService.add(`NoteService: deleteNote(id: ${id}) ${result}`);
    return result;
  }

  /** PUT: update the hero on the server */
  updateNote(note: NoteDto): Observable<any> {
    var result = this.http.put(this.apiUrl, note, this.httpOptions).pipe(
      tap(_ => this.log(`updated note id=${note.id}`)),
      catchError(this.handleError<any>('updateNote'))
    );
    this.messageService.add(`NoteService: updateNote(id: ${note.id}) ${result}`);
    return result;
  }

  private extractData(res: any) {
    let body = res;
    return body;
  }

  private handleErrorObservable(error: any) {
    console.error(error.message || error);
    this.messageService.add(`POST errorObservable : ${error.message}`);
    return throwError(error);
  }

  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {

      // TODO: send the error to remote logging infrastructure
      console.error(error); // log to console instead

      // TODO: better job of transforming error for user consumption
      this.log(`${operation} failed: ${error.message}`);

      // Let the app keep running by returning an empty result.
      return of(result as T);
    };
  }
}
