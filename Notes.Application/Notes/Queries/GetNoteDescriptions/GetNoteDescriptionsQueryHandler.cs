using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Notes.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Notes.Domain;
using Notes.Application.Common.Exceptions;
using System.Threading;

namespace Notes.Application.Notes.Queries.GetNoteDescriptions
{
    public class GetNoteDescriptionsQueryHandler: IRequestHandler<GetNoteDescriptionsQuery, NoteDescriptionsVm>
    {
        private readonly INotesDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetNoteDescriptionsQueryHandler(INotesDbContext dbContext, IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);
        public async Task<NoteDescriptionsVm>  Handle (GetNoteDescriptionsQuery request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Notes
                .FirstOrDefaultAsync(note=>note.Id== request.Id, cancellationToken);
            if(entity == null || entity.UserId!=request.UserId) 
            { 
                throw new NotFoundException(nameof(Note), request.Id);
            }
            return _mapper.Map<NoteDescriptionsVm>(entity);
        }

    }
}
