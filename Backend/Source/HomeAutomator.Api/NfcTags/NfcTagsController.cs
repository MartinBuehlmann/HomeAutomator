namespace HomeAutomator.Api.NfcTags;

using System.Collections.Generic;
using System.Linq;
using HomeAutomator.NfcTags;
using Microsoft.AspNetCore.Mvc;

public class NfcTagsController : ApiController
{
    private readonly INfcTagsRepository nfcTagsRepository;
    private readonly UrlBuilder urlBuilder;

    public NfcTagsController(
        INfcTagsRepository nfcTagsRepository,
        UrlBuilder urlBuilder)
    {
        this.nfcTagsRepository = nfcTagsRepository;
        this.urlBuilder = urlBuilder;
    }

    [HttpGet]
    public IActionResult RetrieveAllAsync()
    {
        IReadOnlyList<NfcTagInfo> nfcTags = this.nfcTagsRepository.RetrieveAllNfcTags()
            .Select(x => new NfcTagInfo(
                x.TagId,
                x.TagName,
                new Url(this.urlBuilder.Build(ApiConstants.Route, nameof(NfcTagsController), x.TagId))))
            .ToList();
        return new JsonResult(nfcTags);
    }

    [HttpGet("{identifier}")]
    public IActionResult Retrieve(string identifier)
    {
        NfcTagInfo? nfcTags = this.nfcTagsRepository.RetrieveAllNfcTags()
            .Where(x => x.TagId == identifier)
            .Select(x => new NfcTagInfo(
                x.TagId,
                x.TagName,
                new Url(this.urlBuilder.Build(ApiConstants.Route, nameof(NfcTagsController), x.TagId))))
            .SingleOrDefault();

        if (nfcTags != null) return new JsonResult(nfcTags);

        return this.NotFound();
    }

    [HttpPut]
    public IActionResult SaveTag([FromBody] NfcTagInfo tag)
    {
        this.nfcTagsRepository.AddOrUpdateNfcTag(tag.TagId, tag.TagName);
        return this.Ok();
    }
}