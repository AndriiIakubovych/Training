using System;
using System.Collections.Generic;
using WebClient.ServiceReference;

namespace WebClient
{
    public class ClientData
    {
        private static ServiceClient client = new ServiceClient();
        private static Note[] notes;
        private static DateTime currentDate;
        private static List<int> notesIdList = new List<int>();

        public static void DataInitialize()
        {
            notes = client.GetNotes();
        }

        public static ServiceClient Client
        {
            get { return client; }
        }

        public static Note[] Notes
        {
            get { return notes; }
            set { notes = value; }
        }

        public static DateTime CurrentDate
        {
            get { return currentDate; }
            set { currentDate = value; }
        }

        public static List<int> NotesIdList
        {
            get { return notesIdList; }
            set { notesIdList = value; }
        }
    }
}