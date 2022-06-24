namespace HomeAutomator.NfcTags.Domain
{
    using System;

    public class NfcTag
    {
        public NfcTag(string tagId, string tagName, DateTimeOffset registrationDateTime)
        {
            this.TagName = tagName;
            this.RegistrationDateTime = registrationDateTime;
            this.TagId = tagId;
        }

        public string TagId { get; }

        public string TagName { get; }

        public DateTimeOffset RegistrationDateTime { get; }
    }
}