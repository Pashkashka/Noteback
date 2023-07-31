using Microsoft.EntityFrameworkCore;
using Notes.Tests.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Notes.Application.Notes.Commands.CreateNote;

namespace Notes.Tests.Notes.Commands
{
	public class CreateNoteCommandHandlerTests: TestCommandBase
	{
		[Fact]
		public async Task CreateNoteCommandHandler_Success()
		{
			var handler = new CreateNoteCommandHandler(Context);
			var noteName = "note name";
			var noteDescription = "note description";

			var noteId = await handler.Handle(
				new CreateNoteCommand
				{
					Title = noteName,
					Description = noteDescription,
					UserId = NotesContextFactory.UserAId
				},
				CancellationToken.None);

			Assert.NotNull(
				await Context.Notes.SingleOrDefaultAsync(note =>
				note.Id == noteId && note.Title == noteName &&
				note.Description == noteDescription));
				

		}
	}
}
