using Notes.Application.Common.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Notes.Application.Common.Mappings;
using Notes.Domain;
using AutoMapper;

namespace Notes.Application.Notes.Queries.GetNoteDescriptions
{
    public class NoteDescriptionsVm: IMapWith<Note>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? EditDate { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Note, NoteDescriptionsVm>().ForMember(noteVm => noteVm.Title,
                opt => opt.MapFrom(note => note.Title)).ForMember(noteVm => noteVm.Description,
                opt => opt.MapFrom(note => note.Description)).ForMember(noteVm
                => noteVm.Id, opt => opt.MapFrom(note => note.Id)).ForMember(noteVm => noteVm.CreationDate, opt =>
                opt.MapFrom(note => note.CreationDate)).ForMember(noteVm => noteVm.EditDate, opt =>
                opt.MapFrom(note => note.EditDate));
        }
    }
}
