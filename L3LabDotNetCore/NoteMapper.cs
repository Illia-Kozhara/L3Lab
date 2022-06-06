using AutoMapper;
using L3Lab.EntityFrameworkCore.Entities;
using L3LabDotNetCore.Models;

namespace L3LabDotNetCore
{
    public sealed class NoteMapper
    {
        private NoteDTO noteDTO;
        private Note note; 
        private Mapper mapperDto;
        private Mapper mapperNote;


        private static NoteMapper instance = null;

        public static NoteMapper GetInstance
        {
            get
            {
                if (instance == null)
                    instance = new NoteMapper();
                return instance;
            }
        }

        private NoteMapper()
        {
            mapperDto = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<Note, NoteDTO>()));
            mapperNote = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<NoteDTO, Note>()));

        }

        public NoteDTO MapToDto(Note note)
        {
            noteDTO = mapperDto.Map<NoteDTO>(note);
            return noteDTO;
        }

        internal Note MapToNote(NoteDTO noteDTO)
        {
            note = mapperNote.Map<Note>(noteDTO);
            return note;
        }
    }
}
