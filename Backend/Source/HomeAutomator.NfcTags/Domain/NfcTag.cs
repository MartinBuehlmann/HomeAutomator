namespace HomeAutomator.NfcTags.Domain
{
    using System;

    public record NfcTag(
        string TagId,
        string TagName,
        DateTimeOffset RegistrationDateTime);
}