using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace WebService
{
    [ServiceContract]
    public interface IService
    {
        [OperationContract]
        IEnumerable<Note> GetNotes();

        [OperationContract]
        int AddNote(string noteName, DateTime beginningDate, DateTime endDate, string description);

        [OperationContract]
        void EditNote(int noteId, string noteName, DateTime beginningDate, DateTime endDate, string description);

        [OperationContract]
        void ChangeNoteState(int noteId);

        [OperationContract]
        void DeleteNote(int noteId);
    }
}