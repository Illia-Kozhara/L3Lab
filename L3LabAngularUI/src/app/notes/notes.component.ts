import { Component, OnInit } from '@angular/core';
import { NoteDto } from '../note-dto';
import { NoteService } from '../note.service';
import { MessageService } from '../message.service';
import { Location } from '@angular/common';


@Component({
  selector: 'app-notes',
  templateUrl: './notes.component.html',
  styleUrls: ['./notes.component.css']
})
export class NotesComponent implements OnInit {

  title = 'Notes';

  notes: NoteDto[] = [];
  item: NoteDto | undefined;
  newNote: NoteDto | undefined;
  selectedNote?: NoteDto;

  constructor(
    private noteService: NoteService,
    private messageService: MessageService,
    private location: Location  ) {
    
  }

  ngOnInit(): void {
    this.getNotes();
  }
  onSelect(note: NoteDto): void {
    this.selectedNote = note;
    this.messageService.add(`NoteComponent: Selected note id=${note.id}`);
  }
  getNotes(): void {
    this.noteService.getNotes()
      .subscribe(notes => this.notes = notes);
  }
  add(text: string): void {
    this.newNote = { id: 0, content: text, created: 'Date' };
    this.noteService.createNote(this.newNote)
      .subscribe(() => this.update());
  }
  update(): void {
    this.ngOnInit();;
  }
}
