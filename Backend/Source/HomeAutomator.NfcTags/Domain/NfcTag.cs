using System;

namespace HomeAutomator.NfcTags.Domain
{
    public class NfcTag
    {
        public NfcTag(string tagId, string tagName, DateTimeOffset registrationDateTime)
        {
            TagName = tagName;
            RegistrationDateTime = registrationDateTime;
            TagId = tagId;
        }
        
        public string TagId { get; }

        public string TagName { get; }
        
        public DateTimeOffset RegistrationDateTime { get; }
    }
}