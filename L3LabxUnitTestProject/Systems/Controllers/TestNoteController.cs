using L3LabDotNetCore.Controllers;
using L3LabDotNetCore.Services.Notes;
using L3LabxUnitTestProject.MockData;
using Microsoft.AspNetCore.Mvc;
using FluentAssertions;
using Moq;
using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L3LabxUnitTestProject.Systems.Controllers
{
    public class TestNoteController
    {
        [Fact]
        public async Task GetNotes_Should_Return_200_Status()
        {
            /// Arrange
            var noteService = new Mock<INoteService>();
            noteService.Setup(x => x.GetAll()).Returns(NoteMockData.GetNotesDTO());
            var sut = new NoteController(noteService.Object);

            /// Act
            var result = (OkObjectResult)sut.GetNotes();


            // /// Assert
            result.StatusCode.Should().Be(200);
        }

        [Fact]
        public async Task GetNotes_Should_Return_204_NoContentStatus()
        {
            /// Arrange
            var noteService = new Mock<INoteService>();
            noteService.Setup(x => x.GetAll()).Returns(NoteMockData.GetEmptyNotesDTO());
            var sut = new NoteController(noteService.Object);

            /// Act
            var result = (NoContentResult)sut.GetNotes();


            /// Assert
            result.StatusCode.Should().Be(204);
            noteService.Verify(x => x.GetAll(), Times.Exactly(1));
        }

        [Fact]
        public async Task GetNoteId_Should_Return_OkObjectResult()
        {
            /// Arrange
            int id = 1;
            var noteService = new Mock<INoteService>();
            noteService.Setup(x => x.GetById(id)).Returns(NoteMockData.NewNoteDTO());
            var sut = new NoteController(noteService.Object);

            /// Act
            var result = sut.GetNote(id);

            // /// Assert
            result.Should().BeOfType<OkObjectResult>();
        }

        [Fact]
        public async Task GetNoteId_Should_Return_NotFoundResult()
        {
            /// Arrange
            int id = 10;
            var noteService = new Mock<INoteService>();
            noteService.Setup(x => x.GetById(id)).Returns(NoteMockData.NewNullNoteDTO());
            var sut = new NoteController(noteService.Object);

            /// Act
            var result = sut.GetNote(id);

            // /// Assert
            result.Should().BeOfType<NotFoundObjectResult>();
        }

        [Fact]
        public async Task PostNote_ShouldCall_INoteService_Insert_AtleastOnce()
        {
            /// Arrange
            var noteService = new Mock<INoteService>();
            var newNoteDTO = NoteMockData.NewNoteDTO();
            var sut = new NoteController(noteService.Object);

            /// Act
            var result = sut.PostNote(newNoteDTO);

            /// Assert
            noteService.Verify(x => x.Insert(newNoteDTO), Times.Exactly(1));
        }

        [Fact]
        public async Task PutNote_Should_Return_200_Status()
        {
            /// Arrange
            var noteService = new Mock<INoteService>();
            var newNoteDTO = NoteMockData.NewNoteDTO();
            var sut = new NoteController(noteService.Object);

            /// Act
            var result = (OkObjectResult)sut.PutNote(newNoteDTO);


            // /// Assert
            result.StatusCode.Should().Be(200);
        }
    }
}
