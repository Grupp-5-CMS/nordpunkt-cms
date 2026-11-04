
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using nordpunkt_cms.ViewModels;
using Umbraco.Cms.Core.Cache;
using Umbraco.Cms.Core.Logging;
using Umbraco.Cms.Core.Routing;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Infrastructure.Persistence;
using Umbraco.Cms.Web.Website.Controllers;

namespace nordpunkt_cms.Controllers
{
    public class NewsTipFormController : SurfaceController
    {
        private readonly IContentService _contentService;
        private readonly IConfiguration _configuration;

        public NewsTipFormController(
            IUmbracoContextAccessor umbracoContextAccessor,
            IUmbracoDatabaseFactory databaseFactory,
            ServiceContext services,
            AppCaches appCaches,
            IProfilingLogger profilingLogger,
            IPublishedUrlProvider publishedUrlProvider,
            IContentService contentService,
            IConfiguration configuration)
            : base(
                umbracoContextAccessor,
                databaseFactory,
                services,
                appCaches,
                profilingLogger,
                publishedUrlProvider)
        {
            _contentService = contentService;
            _configuration = configuration;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Submit(NewsTipFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return CurrentUmbracoPage();
            }

            var containerKey = _configuration[
                "FormSubmissionsNodeKey"];

            if (!Guid.TryParse(containerKey, out var parentKey))
            {
                TempData["NewsTipError"] =
                    "Det gick inte att hitta lagringsplatsen.";
                return RedirectToCurrentUmbracoPage();
            }

            var parent = _contentService.GetById(parentKey);

            if (parent == null)
            {
                TempData["NewsTipError"] =
                    "Det gick inte att hitta lagringsplatsen.";
                return RedirectToCurrentUmbracoPage();
            }

            var content = _contentService.Create(
                model.TipHeadline,
                parentKey,
                "newsTipSubmission");

            content.SetValue(
                "tipHeadline", model.TipHeadline);

            content.SetValue(
                "tipBody", model.TipBody);

            content.SetValue(
                "senderName", model.SenderName);

            content.SetValue(
                "senderEmail", model.SenderEmail);

            content.SetValue(
                "senderPhone", model.SenderPhone);

            content.SetValue(
                "privacyConsent", model.PrivacyConsent);

            // Alla nya nyhetstips får automatiskt statusen Nytt
            content.SetValue("status", "Nytt");

            var result = _contentService.Save(content);

            if (result.Success)
            {
                TempData["NewsTipSuccess"] =
                    "Tack! Ditt nyhetstips har skickats till redaktionen.";

                return RedirectToCurrentUmbracoPage();
            }

            TempData["NewsTipError"] =
                "Tipset kunde inte sparas. Försök igen.";

            return RedirectToCurrentUmbracoPage();
        }
    }
}
