using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Owin.Security;
using AutoMapper;
using Blog.PresentationLayer.Models;
using Blog.BusinessLogicLayer.DataTransferObjects;
using Blog.BusinessLogicLayer.Interfaces;

namespace Blog.PresentationLayer.Areas.Admin.Controllers
{
    [Authorize]
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

        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.UserName = AuthenticationManager.User.Identity.Name;
            ViewBag.Tags = GetTags().Select(t => t.TagName);
            return View();
        }

        [HttpPost]
        public ActionResult Index(ArticleViewModel article, IEnumerable<string> existingtags, IEnumerable<string> newtags)
        {
            ArticleDataTransferObject articleDto;
            List<TagDataTransferObject> tagDtos = new List<TagDataTransferObject>();
            List<ArticleTagDataTransferObject> articleTagDtos = new List<ArticleTagDataTransferObject>();
            List<string> allTags = new List<string>();
            var tags = GetTags();
            int tagId = tags.Count() > 0 ? tags.Select(t => t.TagId).Max() + 1 : 1;
            article.ArticleId = GetArticles().Count() > 0 ? GetArticles().Select(a => a.ArticleId).Max() + 1 : 1;
            article.PublicationDate = DateTime.Now;
            articleDto = new ArticleDataTransferObject { ArticleId = article.ArticleId, ArticleName = article.ArticleName, PublicationDate = article.PublicationDate, ArticleContent = article.ArticleContent };
            blogService.AddArticle(articleDto);
            if (newtags != null)
            {
                foreach (string nt in newtags)
                    if (!tags.Select(t => t.TagName).Contains(nt))
                        allTags.Add(nt);
                foreach (string rnt in allTags)
                {
                    tagDtos.Add(new TagDataTransferObject { TagId = tagId, TagName = rnt });
                    tagId++;
                }
                blogService.AddTags(tagDtos);
            }
            if (existingtags != null)
                foreach (string et in existingtags)
                    allTags.Add(et);
            tags = GetTags().Where(t => allTags.Contains(t.TagName));
            foreach (var t in tags)
                articleTagDtos.Add(new ArticleTagDataTransferObject { ArticleId = article.ArticleId, TagId = t.TagId });
            blogService.AddArticleTags(articleTagDtos);
            return RedirectToAction("Index", "Blog", new { area = "" });
        }

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }
    }
}