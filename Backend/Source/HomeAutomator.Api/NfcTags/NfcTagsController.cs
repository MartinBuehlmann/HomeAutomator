using System.Collections.Generic;
using System.Linq;
using HomeAutomator.NfcTags;
using HomeAutomator.NfcTags.Domain;
using Microsoft.AspNetCore.Mvc;

namespace HomeAutomator.Api.NfcTags
{
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
            NfcTagInfo? nfcTags = this.nfcTagsRepository.RetrieveAllNfcTags()
                .Where(x => x.TagId == identifier)
                .Select(x => new NfcTagInfo(x.TagId, x.TagName))
                .SingleOrDefault();

            if (nfcTags != null)
            {
                return new JsonResult(nfcTags);
            }

            return NotFound();
        }

        [HttpPut]
        public IActionResult SaveTag([FromBody]NfcTagInfo tag)
        {
            this.nfcTagsRepository.AddOrUpdateNfcTag(tag.TagId, tag.TagName);
            return Ok();
        }
    }
}