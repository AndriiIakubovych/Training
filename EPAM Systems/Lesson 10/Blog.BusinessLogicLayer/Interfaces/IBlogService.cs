using System.Collections.Generic;
using Blog.BusinessLogicLayer.DataTransferObjects;

namespace Blog.BusinessLogicLayer.Interfaces
{
    public interface IBlogService
    {
        IEnumerable<ArticleDataTransferObject> GetArticles();
        ArticleDataTransferObject GetArticle(int id);
        void AddArticle(ArticleDataTransferObject articleDto);
        IEnumerable<CommentDataTransferObject> GetComments();
        void AddComment(CommentDataTransferObject commentDto);
        IEnumerable<TestResultDataTransferObject> GetTestResults();
        void AddTestResult(TestResultDataTransferObject testResultDto);
        IEnumerable<VoteDataTransferObject> GetVotes();
        void AddVote(VoteDataTransferObject voteDto);
        IEnumerable<TagDataTransferObject> GetTags();
        void AddTag(TagDataTransferObject tagDto);
        void AddTags(IEnumerable<TagDataTransferObject> tagDtos);
        IEnumerable<ArticleTagDataTransferObject> GetArticleTags();
        void AddArticleTag(ArticleTagDataTransferObject articleTagDto);
        void AddArticleTags(IEnumerable<ArticleTagDataTransferObject> articleTagDtos);
        void Dispose();
    }
}