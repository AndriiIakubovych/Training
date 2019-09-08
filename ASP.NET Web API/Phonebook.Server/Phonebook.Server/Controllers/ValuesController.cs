using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;
using Phonebook.Server.Models.Entities;
using Phonebook.Server.Interfaces;

namespace Phonebook.Server.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ValuesController : ApiController
    {
        private IRepository<Subject> repository;

        public ValuesController(IRepository<Subject> repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        [Route("api/values/getsubjects")]
        public IEnumerable<Subject> GetSubjects()
        {
            return repository.GetAll();
        }

        [HttpPost]
        [Route("api/values/addsubject/{text}")]
        public Subject AddSubject([FromBody]Subject subject, string text)
        {
            return repository.Add(subject, text);
        }

        [HttpPut]
        [Route("api/values/editsubject")]
        public Subject EditSubject(Subject subject)
        {
            return repository.Edit(subject);
        }

        [HttpDelete]
        [Route("api/values/deletesubject/{id}")]
        public Subject DeleteSubject(int id)
        {
            return repository.Delete(id);
        }

        [HttpGet]
        [Route("api/values/getfiltereddata")]
        public IEnumerable<Subject> GetFilteredData(string text)
        {
            return repository.Filter(text);
        }

        [HttpGet]
        [Route("api/values/getsorteddata")]
        public IEnumerable<Subject> GetSortedData(string direction)
        {
            return repository.Sort(direction);
        }
    }
}