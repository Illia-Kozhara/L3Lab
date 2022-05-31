import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { NoteDto } from '../note-dto';
import { NoteService } from '../note.service';
import { Location } from '@angular/common';

@Component({
  selector: 'app-note-detail',
  templateUrl: './note-detail.component.html',
  styleUrls: ['./note-detail.component.css']
})
export class NoteDetailComponent implements OnInit {

  note: NoteDto | undefined;
  constructor(
    private route: ActivatedRoute,
    private noteService: NoteService,
    private location: Location
  ) { }

  ngOnInit(): void {
    this.getNote();
  }
  edit(): void {
    if (this.note) {
      this.noteService.updateNote(this.note)
        .subscribe(() => this.goBack());
    }
  }

  delete(): void {
    if (this.note) {
      this.noteService.deleteNote(this.note.id)
        .subscribe(() => this.goBack());
    }
  }
  getNote(): void {
    const id = Number(this.route.snapshot.paramMap.get('id'));
    this.noteService.getNote(id)
      .subscribe(note => this.note = note);
  }

  goBack(): void {
    this.location.back();
  }
}
