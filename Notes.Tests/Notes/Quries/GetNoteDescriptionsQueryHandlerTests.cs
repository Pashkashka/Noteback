using AutoMapper;
using Notes.Application.Notes.Queries.GetNoteDescriptions;
using Notes.Persistence;
using Notes.Tests.Common;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Tests.Notes.Quries
{
	[Collection("QueryCollection")]
	public class GetNoteDescriptionsQueryHandlerTests
	{
		private readonly NotesDbContext Context;
		private readonly IMapper Mapper;

		[Fact]
		public async Task GetNoteDescriptionsQueryHandler_Success()
		{
			//Arrange
			var handler = new GetNoteDescriptionsQueryHandler(Context, Mapper);

			//Act
			var result = await handler.Handle(
				new GetNoteDescriptionsQuery
				{
					UserId = NotesContextFactory.UserBId,
					Id = Guid.Parse("FF4E2C46-8C13-48A2-8F7E-4A6E3A43185D")
				}, CancellationToken.None);

			//Assert
			result.ShouldBeOfType<NoteDescriptionsVm>();
			result.Title.ShouldBe("Title2");
			result.CreationDate.ShouldBe(DateTime.Today);

		}

	}
}
