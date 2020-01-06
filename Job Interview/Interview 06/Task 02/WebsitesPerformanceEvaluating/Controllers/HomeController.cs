using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Linq;
using System.Net;
using System.Data.Entity;
using System.Diagnostics;
using System.Web.Mvc;
using HtmlAgilityPack;
using WebsitesPerformanceEvaluating.Models;

namespace WebsitesPerformanceEvaluating.Controllers
{
    public class HomeController : Controller
    {
        private RequestsSpeedEvaluatingContext context = new RequestsSpeedEvaluatingContext();
        private static string website;
        private List<string> sitePagesList = new List<string>();

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Index(Test test)
        {
            List<string> sitemapUrls = new List<string>();
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(new UriBuilder(test.Website).Uri);
            sitePagesList.Clear();
            test.Website = request.RequestUri.Scheme + "://" + request.RequestUri.Host;
            website = test.Website;
            try
            {
                sitemapUrls.Add(GetSitemapByName(website));
            }
            catch (Exception) { }
            if (sitemapUrls.Count == 0)
            {
                try
                {
                    sitemapUrls = GetSitemapsFromRobotsTxt(website);
                }
                catch (Exception) { }
            }
            if (sitemapUrls.Count == 0)
            {
                try
                {
                    sitemapUrls = GetSitemapsFromGoogleSearch(request.RequestUri.Host.Replace("www.", string.Empty));
                }
                catch (Exception) { }
            }
            if (sitemapUrls.Count > 0)
                foreach (string s in sitemapUrls)
                    GetSitemapUrls(s);
            else
            {
                try
                {
                    GetPagesList(website);
                }
                catch (Exception) { }
            }
            return Json(sitePagesList, JsonRequestBehavior.AllowGet);
        }

        public string GetSitemapByName(string website)
        {
            string sitemapUrl = website + "/sitemap.xml";
            string content = new WebClient().DownloadString(sitemapUrl);
            return sitemapUrl;
        }

        public List<string> GetSitemapsFromRobotsTxt(string website)
        {
            List<string> sitemapsUrls = new List<string>();
            string sitemapUrl, keyName = "Sitemap:", robotsTxtContent, sitemapContent;
            robotsTxtContent = new WebClient().DownloadString(website + "/robots.txt");
            foreach (string line in Regex.Split(robotsTxtContent, "\r\n|\r|\n"))
                if (line.StartsWith(keyName))
                {
                    try
                    {
                        sitemapUrl = line.Substring(keyName.Length, line.Length - keyName.Length).Replace(" ", string.Empty);
                        sitemapContent = new WebClient().DownloadString(sitemapUrl);
                        sitemapsUrls.Add(sitemapUrl);
                    }
                    catch (Exception) { }
                }
            return sitemapsUrls;
        }

        public List<string> GetSitemapsFromGoogleSearch(string website)
        {
            List<string> sitemapsUrls = new List<string>();
            string searchResults = "https://www.google.com/search?q=site:" + website + "+filetype:xml", tempString, newsb, hrefValue;
            int count, index;
            byte[] resultsBuffer = new byte[byte.MaxValue];
            StringBuilder sb = new StringBuilder();
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(searchResults);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream resultStream = response.GetResponseStream();
            HtmlDocument html;
            HtmlNode document;
            do
            {
                count = resultStream.Read(resultsBuffer, 0, resultsBuffer.Length);
                if (count != 0)
                {
                    tempString = Encoding.ASCII.GetString(resultsBuffer, 0, count);
                    sb.Append(tempString);
                }
            }
            while (count > 0);
            newsb = sb.ToString();
            html = new HtmlDocument();
            html.OptionOutputAsXml = true;
            html.LoadHtml(newsb);
            document = html.DocumentNode;
            foreach (HtmlNode link in document.SelectNodes("//a[@href]"))
            {
                hrefValue = link.GetAttributeValue("href", string.Empty);
                if (!hrefValue.ToString().ToUpper().Contains("GOOGLE") && hrefValue.ToString().Contains("/url?q="))
                {
                    index = hrefValue.IndexOf("&");
                    if (index > 0)
                    {
                        hrefValue = hrefValue.Substring(0, index);
                        sitemapsUrls.Add(hrefValue.Replace("/url?q=", string.Empty));
                    }
                }
            }
            return sitemapsUrls;
        }

        public void GetSitemapUrls(string sitemapUrl)
        {
            string content;
            MatchCollection sitemapUrls = null;
            try
            {
                content = new WebClient().DownloadString(sitemapUrl);
                if (sitemapUrl.EndsWith(".xml"))
                    sitemapUrls = new Regex("<loc>(?<url>(.*?))</loc>").Matches(content);
                else
                    sitePagesList.Add(sitemapUrl);
                if (sitemapUrls.Count > 0)
                    foreach (Match s in sitemapUrls)
                    {
                        sitemapUrl = s.Groups["url"].Value;
                        GetSitemapUrls(sitemapUrl);
                    }
            }
            catch (Exception) { }
        }

        public void GetPagesList(string website)
        {
            string pageUrl;
            HtmlWeb hw = new HtmlWeb();
            HtmlDocument document = hw.Load(website);
            foreach (HtmlNode link in document.DocumentNode.SelectNodes("//a[@href]"))
            {
                pageUrl = link.GetAttributeValue("href", string.Empty);
                if (pageUrl.StartsWith(website) && pageUrl[pageUrl.Length - 1] == '/')
                    sitePagesList.Add(pageUrl);
            }
            sitePagesList = sitePagesList.Distinct().ToList();
        }

        public JsonResult SendRequest(string url)
        {
            WebRequest request = WebRequest.Create(url);
            WebResponse response;
            Stopwatch timer = new Stopwatch();
            TimeSpan timeTaken;
            try
            {
                timer.Start();
                response = request.GetResponse();
                response.Close();
                timer.Stop();
                timeTaken = timer.Elapsed;
                return Json(timeTaken.Milliseconds, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(0, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult AddTest(List<Page> testResults)
        {
            int maxColorValue = 255;
            Random rand = new Random();
            Test test = new Test();
            test.TestId = context.Tests.Count() > 0 ? context.Tests.Select(t => t.TestId).Max() + 1 : 1;
            test.Website = website;
            test.TestDate = DateTime.Now;
            context.Tests.Add(test);
            for (int i = 0; i < testResults.Count; i++)
            {
                testResults[i].PageId = context.Pages.Count() > 0 ? context.Pages.Select(p => p.PageId).Max() + i + 1 : 1 + i;
                testResults[i].Color = rand.Next(maxColorValue + 1) + "; " + rand.Next(maxColorValue + 1) + "; " + rand.Next(maxColorValue + 1);
                testResults[i].TestId = test.TestId;
                context.Pages.Add(testResults[i]);
            }
            context.SaveChanges();
            return Json(Url.Action("TestResult", new { testId = test.TestId }));
        }

        public ActionResult History()
        {
            return View(context.Tests.OrderByDescending(t => t.TestDate));
        }

        [HttpGet]
        public ActionResult DeleteTest(int? testId)
        {
            Test test;
            if (testId == null)
                return HttpNotFound();
            test = context.Tests.Find(testId);
            return PartialView(test);
        }

        [HttpPost]
        public JsonResult DeleteTest(Test test)
        {
            context.Entry(test).State = EntityState.Deleted;
            context.SaveChanges();
            return Json(test, JsonRequestBehavior.AllowGet);
        }

        public ActionResult TestResult(int? testId)
        {
            if (testId == null)
                return HttpNotFound();
            ViewBag.TestId = testId;
            ViewBag.Website = context.Tests.First(t => t.TestId == testId).Website;
            return View(context.Pages.Where(p => p.TestId == testId).OrderByDescending(p => p.AverageTime));
        }

        public JsonResult GetTestResultData(int testId)
        {
            return Json(context.Pages.Where(p => p.TestId == testId).OrderByDescending(p => p.AverageTime), JsonRequestBehavior.AllowGet);
        }
    }
}