using System;
using System.Collections.Generic;
using System.Linq;

namespace WebService
{
    public class Service : IService
    {
        private CalendarNotesContext context = new CalendarNotesContext();

        public IEnumerable<Note> GetNotes()
        {
            IEnumerable<Note> noteQuery = from noteItem in context.Notes orderby noteItem.BeginningTime select noteItem;
            return noteQuery;
        }

        public int AddNote(string noteName, DateTime beginningDate, DateTime endDate, string description)
        {
            Note note = new Note();
            IEnumerable<int> noteIdQuery = from noteItem in context.Notes select noteItem.NoteId;
            note.NoteId = noteIdQuery.Max() + 1;
            note.NoteName = noteName;
            note.BeginningTime = beginningDate;
            note.EndTime = endDate;
            note.Description = description;
            note.Done = false;
            context.Notes.Add(note);
            context.SaveChanges();
            return note.NoteId;
        }

        public void EditNote(int noteId, string noteName, DateTime beginningDate, DateTime endDate, string description)
        {
            Note note = context.Notes.Find(noteId);
            note.NoteName = noteName;
            note.BeginningTime = beginningDate;
            note.EndTime = endDate;
            note.Description = description;
            context.SaveChanges();
        }

        public void ChangeNoteState(int noteId)
        {
            Note note = context.Notes.Find(noteId);
            note.Done = !note.Done;
            context.SaveChanges();
        }

        public void DeleteNote(int noteId)
        {
            Note note = context.Notes.Find(noteId);
            context.Notes.Remove(note);
            context.SaveChanges();
        }
    }
}