using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Application.Notes.Queries.GetNoteDescriptions
{
    public class GetNoteDescriptionsQuery: IRequest<NoteDescriptionsVm>
    {
        public Guid UserId { get; set; }
        public Guid Id { get; set; }
    }
}
