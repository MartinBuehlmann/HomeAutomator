namespace HomeAutomator.NfcTags.Persistence.Entities
{
    using System.Collections.Generic;
    using HomeAutomator.NfcTags.Domain;

    internal class NfcTags
    {
        public NfcTags()
        {
            this.Items = new List<NfcTag>();
        }

        public List<NfcTag> Items { get; }
    }
}