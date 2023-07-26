using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Application.Notes.Queries.GetNoteDescriptions
{
    public class GetNoteDescriptionsQueryValidator: AbstractValidator<GetNoteDescriptionsQuery>
    {
        public GetNoteDescriptionsQueryValidator()
        {
            RuleFor(note=> note.Id).NotEqual(Guid.Empty);
            RuleFor(note => note.UserId).NotEqual(Guid.Empty);
        }
    }
}
