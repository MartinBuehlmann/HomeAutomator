using System.Collections.Generic;
using System.Linq;
using HomeAutomator.NfcTags;
using Microsoft.AspNetCore.Mvc;

namespace HomeAutomator.Api.NfcTags
{
    [Route(ApiConstants.Route + "/[controller]")]
    public class NfcTagsController : ApiController
    {
        private readonly INfcTagsRepository nfcTagsRepository;

        public NfcTagsController(INfcTagsRepository nfcTagsRepository)
        {
            this.nfcTagsRepository = nfcTagsRepository;
        }

        [HttpGet]
        public IActionResult RetrieveAllAsync()
        {
            IReadOnlyList<NfcTagInfo> nfcTags = this.nfcTagsRepository.RetrieveAllNfcTags()
                .Select(x => new NfcTagInfo(x.TagId, x.TagName))
                .ToList();
            return new JsonResult(nfcTags);
        }

        [HttpGet("{identifier}")]
        public IActionResult Retrieve(string identifier)
        {
            IReadOnlyList<NfcTagInfo> nfcTags = this.nfcTagsRepository.RetrieveAllNfcTags()
                .Where(x => x.TagId == identifier)
                .Select(x => new NfcTagInfo(x.TagId, x.TagName))
                .ToList();
            return new JsonResult(nfcTags);
        }

        [HttpPut]
        public IActionResult SaveTag([FromBody]NfcTagInfo tag)
        {
            this.nfcTagsRepository.AddOrUpdateNfcTag(tag.TagId, tag.TagName);
            return Ok();
        }
    }
}