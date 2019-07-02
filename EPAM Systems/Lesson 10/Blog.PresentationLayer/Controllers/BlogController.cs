using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using Blog.PresentationLayer.Models;
using Blog.BusinessLogicLayer.DataTransferObjects;
using Blog.BusinessLogicLayer.Interfaces;

namespace Blog.PresentationLayer.Controllers
{
    public class BlogController : Controller
    {
        IBlogService blogService;

        public BlogController(IBlogService blogService)
        {
            this.blogService = blogService;
        }

        public IEnumerable<ArticleViewModel> GetArticles()
        {
            IEnumerable<ArticleDataTransferObject> articleDataTransferObjects = blogService.GetArticles();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ArticleDataTransferObject, ArticleViewModel>()).CreateMapper();
            return mapper.Map<IEnumerable<ArticleDataTransferObject>, List<ArticleViewModel>>(articleDataTransferObjects);
        }

        public IEnumerable<CommentViewModel> GetComments()
        {
            IEnumerable<CommentDataTransferObject> commentDataTransferObjects = blogService.GetComments();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<CommentDataTransferObject, CommentViewModel>()).CreateMapper();
            return mapper.Map<IEnumerable<CommentDataTransferObject>, List<CommentViewModel>>(commentDataTransferObjects);
        }

        public IEnumerable<TestResultViewModel> GetTestResults()
        {
            IEnumerable<TestResultDataTransferObject> testResultDataTransferObjects = blogService.GetTestResults();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<TestResultDataTransferObject, TestResultViewModel>()).CreateMapper();
            return mapper.Map<IEnumerable<TestResultDataTransferObject>, List<TestResultViewModel>>(testResultDataTransferObjects);
        }

        public IEnumerable<VoteViewModel> GetVotes()
        {
            IEnumerable<VoteDataTransferObject> voteDataTransferObjects = blogService.GetVotes();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<VoteDataTransferObject, VoteViewModel>()).CreateMapper();
            return mapper.Map<IEnumerable<VoteDataTransferObject>, List<VoteViewModel>>(voteDataTransferObjects);
        }

        public IEnumerable<TagViewModel> GetTags()
        {
            IEnumerable<TagDataTransferObject> tagDataTransferObjects = blogService.GetTags();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<TagDataTransferObject, TagViewModel>()).CreateMapper();
            return mapper.Map<IEnumerable<TagDataTransferObject>, List<TagViewModel>>(tagDataTransferObjects);
        }

        public IEnumerable<ArticleTagViewModel> GetArticleTags()
        {
            IEnumerable<ArticleTagDataTransferObject> articleTagDataTransferObjects = blogService.GetArticleTags();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ArticleTagDataTransferObject, ArticleTagViewModel>()).CreateMapper();
            return mapper.Map<IEnumerable<ArticleTagDataTransferObject>, List<ArticleTagViewModel>>(articleTagDataTransferObjects);
        }

        public ActionResult Index(int? tagId)
        {
            IEnumerable<int> articleIds;
            ViewBag.Tag = tagId != null ? GetTags().Where(t => t.TagId == tagId.Value).FirstOrDefault() : null;
            if (tagId == null)
                return View(GetArticles());
            else
            {
                articleIds = GetArticleTags().Where(at => at.TagId == tagId).Select(at => at.ArticleId);
                return View(GetArticles().Where(a => articleIds.Contains(a.ArticleId)));
            }
        }

        [HttpGet]
        public ActionResult Poll()
        {
            double asusVotesCount, msiVotesCount, evgaVotesCount, gigabyteVotesCount;
            int count = GetVotes().Count();
            asusVotesCount = GetVotes().Where(v => v.VoteName == "Asus").Count();
            msiVotesCount = GetVotes().Where(v => v.VoteName == "MSI").Count();
            evgaVotesCount = GetVotes().Where(v => v.VoteName == "EVGA Corporation").Count();
            gigabyteVotesCount = GetVotes().Where(v => v.VoteName == "Gigabyte").Count();
            ViewBag.AsusVotesPercent = count > 0 ? Math.Round(asusVotesCount / count * 100) : 0;
            ViewBag.MSIVotesPercent = count > 0 ? Math.Round(msiVotesCount / count * 100) : 0;
            ViewBag.EVGAVotesPercent = count > 0 ? Math.Round(evgaVotesCount / count * 100) : 0;
            ViewBag.GigabyteVotesPercent = count > 0 ? Math.Round(gigabyteVotesCount / count * 100) : 0;
            ViewBag.Count = count;
            return PartialView();
        }

        [HttpPost]
        public JsonResult Poll(VoteViewModel vote)
        {
            double asusVotesCount, msiVotesCount, evgaVotesCount, gigabyteVotesCount;
            object data;
            int count;
            VoteDataTransferObject voteDto;
            vote.VoteId = GetVotes().Count() > 0 ? GetVotes().Select(v => v.VoteId).Max() + 1 : 1;
            vote.Date = DateTime.Now;
            voteDto = new VoteDataTransferObject { VoteId = vote.VoteId, VoteName = vote.VoteName, Date = vote.Date };
            blogService.AddVote(voteDto);
            count = GetVotes().Count();
            asusVotesCount = GetVotes().Where(v => v.VoteName == "Asus").Count();
            msiVotesCount = GetVotes().Where(v => v.VoteName == "MSI").Count();
            evgaVotesCount = GetVotes().Where(v => v.VoteName == "EVGA Corporation").Count();
            gigabyteVotesCount = GetVotes().Where(v => v.VoteName == "Gigabyte").Count();
            data = new { AsusVotesPercent = count > 0 ? Math.Round(asusVotesCount / count * 100) : 0, MSIVotesPercent = count > 0 ? Math.Round(msiVotesCount / count * 100) : 0, EVGAVotesPercent = count > 0 ? Math.Round(evgaVotesCount / count * 100) : 0, GigabyteVotesPercent = count > 0 ? Math.Round(gigabyteVotesCount / count * 100) : 0, Count = count };
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult ReadMore(int? articleId)
        {
            ArticleViewModel article;
            ArticleDataTransferObject articleDto;
            IEnumerable<int> tagIds;
            IEnumerable<TagViewModel> tags;
            if (articleId == null)
                return HttpNotFound();
            articleDto = blogService.GetArticle(articleId.Value);
            article = new ArticleViewModel { ArticleId = articleDto.ArticleId, ArticleName = articleDto.ArticleName, PublicationDate = articleDto.PublicationDate, ArticleContent = articleDto.ArticleContent };
            tagIds = GetArticleTags().Where(at => at.ArticleId == articleId.Value).Select(at => at.TagId);
            tags = GetTags().Where(t => tagIds.Contains(t.TagId));
            ViewBag.Tags = tags;
            ViewBag.Count = tags.Count();
            return View(article);
        }

        [HttpGet]
        public ActionResult Guest()
        {
            ViewBag.Comments = GetComments();
            ViewBag.Count = GetComments().Count();
            return View();
        }

        [HttpPost]
        public ActionResult Guest(CommentViewModel comment)
        {
            CommentDataTransferObject commentDto;
            comment.CommentId = GetComments().Count() > 0 ? GetComments().Select(c => c.CommentId).Max() + 1 : 1;
            commentDto = new CommentDataTransferObject { CommentId = comment.CommentId, AuthorName = comment.AuthorName, CommentDate = comment.CommentDate, CommentText = comment.CommentText };
            blogService.AddComment(commentDto);
            return RedirectToAction("Guest");
        }

        [HttpGet]
        public ActionResult Questionnaire()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Questionnaire(TestResultViewModel testResult, bool? internet, bool? social, bool? author, bool? otherway, bool? pc, bool? laptop, bool? monoblock, bool? tablet, bool? othercomputer, bool? windows, bool? macos, bool? linux, bool? unix, bool? otheros)
        {
            TestResultDataTransferObject testResultDto;
            bool trueResult = false;
            bool?[] foundOutByBool = new bool?[] { internet, social, author, otherway };
            bool?[] computerTypeBool = new bool?[] { pc, laptop, monoblock, tablet, othercomputer };
            bool?[] operationSystemBool = new bool?[] { windows, macos, linux, unix, otheros };
            string[] foundOutByString = new string[] { "By searching the Internet", "Through social networks", "Knows the author", "Other" };
            string[] computerTypeString = new string[] { "PC", "Laptop", "Monoblock", "Tablet PC", "Other" };
            string[] operationSystemString = new string[] { "Windows", "Mac OS", "Linux", "Unix", "Other" };
            string foundOutBy = "", computerType = "", operationSystem = "";
            List<string> resultsList = new List<string>();
            if (ModelState.IsValid)
            {
                testResult.ResultId = GetTestResults().Count() > 0 ? GetTestResults().Select(r => r.ResultId).Max() + 1 : 1;
                for (int i = 0; i < foundOutByBool.Length; i++)
                {
                    if (foundOutByBool[i].Value && !trueResult)
                    {
                        trueResult = true;
                        foundOutBy += foundOutByString[i];
                    }
                    else
                        if (foundOutByBool[i].Value)
                        foundOutBy += ", " + foundOutByString[i];
                }
                trueResult = false;
                for (int i = 0; i < computerTypeBool.Length; i++)
                {
                    if (computerTypeBool[i].Value && !trueResult)
                    {
                        trueResult = true;
                        computerType += computerTypeString[i];
                    }
                    else
                        if (computerTypeBool[i].Value)
                        computerType += ", " + computerTypeString[i];
                }
                trueResult = false;
                for (int i = 0; i < operationSystemBool.Length; i++)
                {
                    if (operationSystemBool[i].Value && !trueResult)
                    {
                        trueResult = true;
                        operationSystem += operationSystemString[i];
                    }
                    else
                        if (operationSystemBool[i].Value)
                        operationSystem += ", " + operationSystemString[i];
                }
                testResult.FoundOutBy = foundOutBy;
                testResult.ComputerType = computerType;
                testResult.OperationSystem = operationSystem;
                testResultDto = new TestResultDataTransferObject { ResultId = testResult.ResultId, RespondentName = testResult.RespondentName, Gender = testResult.Gender, Age = testResult.Age, Country = testResult.Country, HasComputerEducation = testResult.HasComputerEducation, FoundOutBy = testResult.FoundOutBy, ComputerType = testResult.ComputerType, OperationSystem = testResult.OperationSystem, ReadsOtherBlogs = testResult.ReadsOtherBlogs };
                blogService.AddTestResult(testResultDto);
                resultsList.Add("Name: " + testResult.RespondentName);
                resultsList.Add("Gender: " + testResult.Gender);
                resultsList.Add("Age: " + testResult.Age);
                resultsList.Add("Country of residence: " + testResult.Country);
                resultsList.Add("Has computer education: " + testResult.HasComputerEducation);
                if (testResult.FoundOutBy.Length > 0)
                    resultsList.Add("Found out about this blog: " + testResult.FoundOutBy);
                if (testResult.ComputerType.Length > 0)
                    resultsList.Add("Has computer types: " + testResult.ComputerType);
                if (testResult.OperationSystem.Length > 0)
                    resultsList.Add("Uses OS: " + testResult.OperationSystem);
                resultsList.Add("Reads other blogs about computer technology: " + testResult.ReadsOtherBlogs);
                TempData["ResultsList"] = resultsList;
                return RedirectToAction("TestResults");
            }
            else
                return RedirectToAction("Questionnaire");
        }

        [HttpGet]
        public ActionResult TestResults()
        {
            ViewBag.ResultsList = TempData["ResultsList"];
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            blogService.Dispose();
            base.Dispose(disposing);
        }
    }
}