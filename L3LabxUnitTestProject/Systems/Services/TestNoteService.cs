using FluentAssertions;
using L3Lab.EntityFrameworkCore;
using L3Lab.EntityFrameworkCore.Entities;
using L3LabDotNetCore.Models;
using L3LabDotNetCore.Repositories;
using L3LabDotNetCore.Services.Notes;
using L3LabxUnitTestProject.MockData;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L3LabxUnitTestProject.Systems.Services
{
    public class TestNoteService
    {
        protected readonly AppDBContext _context;
        public TestNoteService()
        {
            var options = new DbContextOptionsBuilder<AppDBContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

            _context = new AppDBContext(options);

            _context.Database.EnsureCreated();
        }

        [Fact]
        public async Task GetAll_ReturnNoteDTOCollectionSameLength()
        {
            /// Arrange
            _context.Notes.AddRange(MockData.NoteMockData.GetNotes());
            _context.SaveChanges();

            var noteServ = new NoteService(new GenericRepository<Note>(_context));

            /// Act
            var result = noteServ.GetAll();

            /// Assert
            result.Should().HaveCount(NoteMockData.GetNotesDTO().Count);
        }

        [Fact]
        public async Task GetAll_ShouldReturnNull()
        {
            /// Arrange
            _context.Notes.AddRange(MockData.NoteMockData.GetEmptyNotes());
            _context.SaveChanges();

            var noteServ = new NoteService(new GenericRepository<Note>(_context));

            /// Act
            var result = noteServ.GetAll();

            /// Assert
            result.Should().BeNull();
        }

        [Fact]
        public async Task GetById_ReturnNoteDTOWithCorrectId()
        {
            /// Arrange
            int validId = 1;
            _context.Notes.AddRange(MockData.NoteMockData.GetNotes());
            _context.SaveChanges();

            var noteServ = new NoteService(new GenericRepository<Note>(_context));

            /// Act
            var result = noteServ.GetById(1);

            /// Assert
            result.Id.Should().Be(validId);
        }

        [Fact]
        public async Task GetById_ShouldReturnNull()
        {
            /// Arrange
            _context.Notes.AddRange(MockData.NoteMockData.GetEmptyNotes());
            _context.SaveChanges();

            var noteServ = new NoteService(new GenericRepository<Note>(_context));

            /// Act
            var result = noteServ.GetById(1);

            /// Assert
            result.Should().BeNull();
        }

        [Fact]
        public async Task Insert_AddNewNote()
        {
            /// Arrange
            var newNote = NoteMockData.NewNoteDTO();
            _context.Notes.AddRange(MockData.NoteMockData.GetNotes());
            _context.SaveChanges();

            var sut = new NoteService(new GenericRepository<Note>(_context));

            /// Act
            sut.Insert(newNote);

            ///Assert
            int expectedRecordCount = (NoteMockData.GetNotes().Count() + 1);
            _context.Notes.Count().Should().Be(expectedRecordCount);
        }

        [Fact]
        public async Task Insert_GetNoteId_Should_Return_StatusCode_OkData()
        {
            /// Arrange
            int valid = 100; // Static fields dosen`t exists(StatusCodes.OkData)?
            var newNote = NoteMockData.NewNoteDTO();
            _context.Notes.AddRange(MockData.NoteMockData.GetNotes());
            _context.SaveChanges();

            var sut = new NoteService(new GenericRepository<Note>(_context));

            /// Act
            var result = sut.Insert(newNote);

            ///Assert
            result.Should().Be(valid);
        }

        [Fact]
        public async Task Insert_GetNoteId_Should_Return_StatusCode_EmptyData()
        {
            /// Arrange
            int valid = 0; // Static fields dosen`t exists(StatusCodes.EmptyData)?
            var newNote = NoteMockData.NewNoteDTO();
            _context.Notes.AddRange(MockData.NoteMockData.GetNotes());
            _context.SaveChanges();

            var sut = new NoteService(new GenericRepository<Note>(_context));

            /// Act
            var result = sut.Insert(null);

            ///Assert
            result.Should().Be(valid);
        }

        [Fact]
        public async Task Insert_GetNoteId_Should_Return_StatusCode_DataAllredyExistData()
        {
            /// Arrange
            int valid = 2; // Static fields dosen`t exists(StatusCodes.DataAllredyExistData)?
            var newSameNote = NoteMockData.NewSameNoteDTO();
            _context.Notes.AddRange(MockData.NoteMockData.GetNotes());
            _context.SaveChanges();

            var sut = new NoteService(new GenericRepository<Note>(_context));

            /// Act
            var result = sut.Insert(newSameNote);

            ///Assert
            result.Should().Be(valid);
        }

        [Fact]
        public async Task Update_ShuldChangeNoteDate()
        {
            /// Arrange
            var newNote = NoteMockData.NewPutNoteDTO();
            var newDate = newNote.Created;
            var id = newNote.Id;
            var oldDate = NoteMockData.GetNotes()[id].Created;
            _context.Notes.AddRange(MockData.NoteMockData.GetNotes());
            await _context.SaveChangesAsync();

            var sut = new NoteService(new GenericRepository<Note>(_context));

            /// Act
            sut.Update(newNote);

            ///Assert
            _context.Notes.Find(id).Created.Should().NotBe(oldDate);
        }

        public void Dispose()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }
    }
}
