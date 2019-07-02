using System.Collections.Generic;
using Blog.DataAccessLayer.Entities;
using Blog.DataAccessLayer.EntityFramework;
using Blog.DataAccessLayer.Interfaces;

namespace Blog.DataAccessLayer.Repositories
{
    public class TestResultRepository : IRepository<TestResult>
    {
        private BlogContext context;

        public TestResultRepository(BlogContext context)
        {
            this.context = context;
        }

        public IEnumerable<TestResult> GetAll()
        {
            return context.TestResults;
        }

        public TestResult Get(int id)
        {
            return context.TestResults.Find(id);
        }

        public void Add(TestResult testResult)
        {
            context.TestResults.Add(testResult);
        }
    }
}