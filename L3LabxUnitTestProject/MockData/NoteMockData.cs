using L3Lab.EntityFrameworkCore.Entities;
using L3LabDotNetCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L3LabxUnitTestProject.MockData
{
    public class NoteMockData
    {
        public static List<NoteDTO> GetNotesDTO()
        {
            return new List<NoteDTO>{
             new NoteDTO{
                 Id = 1,
                 Content = "MockNoteDTO Id:1 created:DateTime.Now",
                 Created = DateTime.Now
             },
             new NoteDTO{
                 Id = 2,
                 Content = "MockNoteDTO Id:2 created:DateTime.Now",
                 Created = DateTime.Now
             },
             new NoteDTO{
                 Id = 3,
                 Content = "MockNoteDTO Id:3 created:DateTime.Now",
                 Created = DateTime.Now
             }
         };
        }

        internal static List<Note> GetNotes()
        {
            return new List<Note>{
             new Note("MockNoteDTO Id:1 created:DateTime(2000,1,1)", new DateTime(2000,1,1)),
             new Note("MockNoteDTO Id:2 created:DateTime(2000,1,2)", new DateTime(2000,1,2)),
             new Note("MockNoteDTO Id:3 created:DateTime(2000,1,3)", new DateTime(2000,1,3))
         };
        }

        public static List<NoteDTO> GetEmptyNotesDTO()
        {
            return null;
        }

        public static List<Note> GetEmptyNotes()
        {
            return new List<Note>();
        }

        public static NoteDTO NewNoteDTO()
        {
            return new NoteDTO
            {
                Id = 0,
                Content = "MockNoteDTO Id:0 created:DateTime.Now",
                Created = DateTime.Now
            };
        }
        public static NoteDTO NewSameNoteDTO()
        {
            return new NoteDTO
            {
                Id = 1,
                Content = "MockNoteDTO Id:0 created:DateTime.Now",
                Created = DateTime.Now
            };
        }

        public static NoteDTO NewNullNoteDTO()
        {
            return null;
        }

        public static NoteDTO NewPutNoteDTO()
        {
            return new NoteDTO
            {
                Id = 1,
                Content = "MockNoteDTO Id:1 created:DateTime.Now",
                Created = DateTime.Now
            };
        }

        public static Note NewNote()
        {
            return new Note("MockNote Id:0 created:DateTime.Now", DateTime.Now);
        }
        public static Note NewSameNote()
        {
            return new Note("MockNote Id:1 created:DateTime.Now", DateTime.Now);
        }
    }
}
