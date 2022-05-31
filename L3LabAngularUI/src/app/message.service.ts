import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { NoteDto } from './note-dto';

@Injectable({
  providedIn: 'root'
})
export class MessageService {
  messages: string[] = [];

  constructor() { }

  add(message: string) {
    this.messages.push(message);
  }

  clear() {
    this.messages = [];
  }
}
