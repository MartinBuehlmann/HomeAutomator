using System.Collections.Generic;
using HomeAutomator.NfcTags.Domain;

namespace HomeAutomator.NfcTags
{
    public interface INfcTagsRepository
    {
        IReadOnlyList<NfcTag> RetrieveAllNfcTags();
        
        void AddOrUpdateNfcTag(string tagId, string tagName);
    }
}