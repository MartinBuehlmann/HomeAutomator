using System;
using System.Collections.Generic;
using HomeAutomator.FileStorage;
using HomeAutomator.NfcTags.Domain;

namespace HomeAutomator.NfcTags.Persistence
{
    public class NfcTagsRepository : INfcTagsRepository
    {
        private const string Prefix = "NfcTags_";
        private const string NfcTagsName = Prefix + nameof(NfcTags);
        private readonly IFileStorage fileStorage;

        public NfcTagsRepository(IFileStorage fileStorage)
        {
            this.fileStorage = fileStorage;
        }

        public IReadOnlyList<NfcTag> RetrieveAllNfcTags()
        {
            var nfcTags = this.fileStorage.Read<Entities.NfcTags>(NfcTagsName) ?? new Entities.NfcTags();
            return nfcTags.Items;
        }

        // TODO: make thread safe
        public void AddOrUpdateNfcTag(string tagId, string tagName)
        {
            var nfcTags = this.fileStorage.Read<Entities.NfcTags>(NfcTagsName) ??
                          new Entities.NfcTags();
            nfcTags.Items.RemoveAll(x => x.TagId == tagId);
            nfcTags.Items.Add(new NfcTag(tagId, tagName, DateTimeOffset.UtcNow));
            this.fileStorage.Write(nfcTags, NfcTagsName);
        }
    }
}