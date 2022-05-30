using AutoMapper;
using L3Lab.EntityFrameworkCore.Entities;
using L3LabDotNetCore.Models;

namespace L3LabDotNetCore
{
    public sealed class NoteMapper
    {
        private NoteDTO noteDTO ;
        private Mapper mapper;

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
            mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<Note, NoteDTO>()));
        }

        public NoteDTO MapToDto(Note note)
        {
            noteDTO = mapper.Map<NoteDTO>(note);
            return noteDTO;
        }
    }
}
