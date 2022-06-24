namespace HomeAutomator.NfcTags
{
    using System.Collections.Generic;
    using HomeAutomator.NfcTags.Domain;

    public interface INfcTagsRepository
    {
        IReadOnlyList<NfcTag> RetrieveAllNfcTags();

        void AddOrUpdateNfcTag(string tagId, string tagName);
    }
}