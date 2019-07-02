using System;
using System.Collections.Generic;
using AutoMapper;
using Blog.DataAccessLayer.Entities;
using Blog.DataAccessLayer.Interfaces;
using Blog.BusinessLogicLayer.DataTransferObjects;
using Blog.BusinessLogicLayer.Interfaces;

namespace Blog.BusinessLogicLayer.Services
{
    public class BlogService : IBlogService
    {
        IUnitOfWork Database { get; set; }

        public BlogService(IUnitOfWork database)
        {
            Database = database;
        }

        public IEnumerable<ArticleDataTransferObject> GetArticles()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Article, ArticleDataTransferObject>()).CreateMapper();
            return mapper.Map<IEnumerable<Article>, List<ArticleDataTransferObject>>(Database.Articles.GetAll());
        }

        public ArticleDataTransferObject GetArticle(int id)
        {
            var article = Database.Articles.Get(id);
            return new ArticleDataTransferObject { ArticleId = article.ArticleId, ArticleName = article.ArticleName, PublicationDate = article.PublicationDate, ArticleContent = article.ArticleContent };
        }

        public void AddArticle(ArticleDataTransferObject articleDto)
        {
            Article article = new Article { ArticleId = articleDto.ArticleId, ArticleName = articleDto.ArticleName, PublicationDate = articleDto.PublicationDate, ArticleContent = articleDto.ArticleContent };
            Database.Articles.Add(article);
            Database.Save();
        }

        public IEnumerable<CommentDataTransferObject> GetComments()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Comment, CommentDataTransferObject>()).CreateMapper();
            return mapper.Map<IEnumerable<Comment>, List<CommentDataTransferObject>>(Database.Comments.GetAll());
        }

        public void AddComment(CommentDataTransferObject commentDto)
        {
            Comment comment = new Comment { CommentId = commentDto.CommentId, AuthorName = commentDto.AuthorName, CommentDate = DateTime.Now, CommentText = commentDto.CommentText };
            Database.Comments.Add(comment);
            Database.Save();
        }

        public IEnumerable<TestResultDataTransferObject> GetTestResults()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<TestResult, TestResultDataTransferObject>()).CreateMapper();
            return mapper.Map<IEnumerable<TestResult>, List<TestResultDataTransferObject>>(Database.TestResults.GetAll());
        }

        public void AddTestResult(TestResultDataTransferObject testResultDto)
        {
            TestResult testResult = new TestResult { ResultId = testResultDto.ResultId, RespondentName = testResultDto.RespondentName, Gender = testResultDto.Gender, Age = testResultDto.Age, Country = testResultDto.Country, HasComputerEducation = testResultDto.HasComputerEducation, FoundOutBy = testResultDto.FoundOutBy, ComputerType = testResultDto.ComputerType, OperationSystem = testResultDto.OperationSystem, ReadsOtherBlogs = testResultDto.ReadsOtherBlogs };
            Database.TestResults.Add(testResult);
            Database.Save();
        }

        public IEnumerable<VoteDataTransferObject> GetVotes()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Vote, VoteDataTransferObject>()).CreateMapper();
            return mapper.Map<IEnumerable<Vote>, List<VoteDataTransferObject>>(Database.Votes.GetAll());
        }

        public void AddVote(VoteDataTransferObject voteDto)
        {
            Vote vote = new Vote { VoteId = voteDto.VoteId, VoteName = voteDto.VoteName, Date = DateTime.Now };
            Database.Votes.Add(vote);
            Database.Save();
        }

        public IEnumerable<TagDataTransferObject> GetTags()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Tag, TagDataTransferObject>()).CreateMapper();
            return mapper.Map<IEnumerable<Tag>, List<TagDataTransferObject>>(Database.Tags.GetAll());
        }

        public void AddTag(TagDataTransferObject tagDto)
        {
            Tag tag = new Tag { TagId = tagDto.TagId, TagName = tagDto.TagName };
            Database.Tags.Add(tag);
            Database.Save();
        }

        public void AddTags(IEnumerable<TagDataTransferObject> tagDtos)
        {
            Tag tag;
            foreach (TagDataTransferObject t in tagDtos)
            {
                tag = new Tag { TagId = t.TagId, TagName = t.TagName };
                Database.Tags.Add(tag);
            }
            Database.Save();
        }

        public IEnumerable<ArticleTagDataTransferObject> GetArticleTags()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ArticleTag, ArticleTagDataTransferObject>()).CreateMapper();
            return mapper.Map<IEnumerable<ArticleTag>, List<ArticleTagDataTransferObject>>(Database.ArticleTags.GetAll());
        }

        public void AddArticleTag(ArticleTagDataTransferObject articleTagDto)
        {
            ArticleTag articleTag = new ArticleTag { ArticleId = articleTagDto.ArticleId, TagId = articleTagDto.TagId };
            Database.ArticleTags.Add(articleTag);
            Database.Save();
        }

        public void AddArticleTags(IEnumerable<ArticleTagDataTransferObject> articleTagDtos)
        {
            ArticleTag articleTag;
            foreach (ArticleTagDataTransferObject at in articleTagDtos)
            {
                articleTag = new ArticleTag { ArticleId = at.ArticleId, TagId = at.TagId };
                Database.ArticleTags.Add(articleTag);
            }
            Database.Save();
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}