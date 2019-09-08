using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using Phonebook.Server.Models.Entities;
using Phonebook.Server.Models.EntityFramework;
using Phonebook.Server.Interfaces;

namespace Phonebook.Server.Repositories
{
    public class SubjectRepository : IRepository<Subject>
    {
        private PhonebookContext context;

        public SubjectRepository(PhonebookContext context)
        {
            this.context = context;
        }

        public IEnumerable<Subject> GetAll()
        {
            return context.Subjects;
        }

        public Subject Add(Subject subject, string text)
        {
            subject.Id = context.Subjects.Count() > 0 ? context.Subjects.Select(s => s.Id).Max() + 1 : 1;
            context.Subjects.Add(subject);
            context.SaveChanges();
            if (text == "undefined")
                text = string.Empty;
            if (subject.Name.Contains(text) || subject.Type.Contains(text) || subject.Address.Contains(text) || subject.Telephone.Contains(text))
                return subject;
            else
                return null;
        }

        public Subject Edit(Subject subject)
        {
            Subject newSubject = context.Subjects.Find(subject.Id);
            context.Entry(newSubject).State = EntityState.Modified;
            context.SaveChanges();
            return subject;
        }

        public Subject Delete(int id)
        {
            Subject subject = context.Subjects.Where(s => s.Id == id).Single();
            context.Entry(subject).State = EntityState.Deleted;
            context.SaveChanges();
            return subject;
        }

        public IEnumerable<Subject> Filter(string text)
        {
            if (text == null)
                text = string.Empty;
            return context.Subjects.Where(s => s.Name.Contains(text) || s.Type.Contains(text) || s.Address.Contains(text) || s.Telephone.Contains(text)).ToList();
        }

        public IEnumerable<Subject> Sort(string direction)
        {
            if (direction == null)
                return context.Subjects;
            else
            {
                if (direction == "asc")
                    return context.Subjects.OrderBy(s => s.Name);
                else
                    return context.Subjects.OrderByDescending(s => s.Name);
            }
        }
    }
}