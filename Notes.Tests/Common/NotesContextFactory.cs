using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Notes.Persistence;
using Notes.Application;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.Reflection;
using Notes.Domain;

namespace Notes.Tests.Common
{
	public class NotesContextFactory
	{
		public static Guid UserAId= Guid.NewGuid();
		public static Guid UserBId= Guid.NewGuid();

		public static Guid NoteIdForDelete= Guid.NewGuid();
		public static Guid NoteIdForUpdate= Guid.NewGuid();

		public static NotesDbContext Create()
		{
			var options = new DbContextOptionsBuilder<NotesDbContext>()
				.UseInMemoryDatabase(Guid.NewGuid().ToString())
				.Options;
			var context=new NotesDbContext(options);
			context.Database.EnsureCreated();
			context.Notes.AddRange(
				new Note
				{
					CreationDate = DateTime.Today,
					Description="HELLO WORLD",
					EditDate=null,
					Id=Guid.Parse("8668C599-FF7B-46F8-BEE3-C790FBB6EC0E"),
					Title="Interesting",
					UserId=UserAId


				},
				new Note
				{
					CreationDate = DateTime.Today,
					Description = "Jewish Museum",
					EditDate = null,
					Id = Guid.Parse("FF4E2C46-8C13-48A2-8F7E-4A6E3A43185D"),
					Title = "Museums",
					UserId = UserBId


				},
				new Note
				{
					CreationDate = DateTime.Today,
					Description = "Aganin Lox",
					EditDate = null,
					Id = NoteIdForDelete,
					Title = "Vanya",
					UserId = UserAId


				},
				new Note
				{
					CreationDate = DateTime.Today,
					Description = "Stankin",
					EditDate = null,
					Id =NoteIdForUpdate,
					Title = "Sharaga",
					UserId = UserBId


				}

				);
			context.SaveChanges();
			return context;
				
		
			
				
		}
		public static void Destroy(NotesDbContext context)
		{
			context.Database.EnsureCreated( );
			context.Dispose();
		}

	}
}
