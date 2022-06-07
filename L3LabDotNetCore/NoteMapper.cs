using AutoMapper;
using L3Lab.EntityFrameworkCore.Entities;
using L3LabDotNetCore.Models;

namespace L3LabDotNetCore
{
    public sealed class NoteMapper
    {
        private NoteDTO _noteDTO;
        private Note _note; 
        private readonly Mapper _mapperDto;
        private readonly Mapper _mapperNote;


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
            _mapperDto = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<Note, NoteDTO>()));
            _mapperNote = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<NoteDTO, Note>()));

        }

        public NoteDTO MapToDto(Note note)
        {
            _noteDTO = _mapperDto.Map<NoteDTO>(note);
            return _noteDTO;
        }

        internal Note MapToNote(NoteDTO noteDTO)
        {
            _note = _mapperNote.Map<Note>(noteDTO);
            return _note;
        }
    }
}
