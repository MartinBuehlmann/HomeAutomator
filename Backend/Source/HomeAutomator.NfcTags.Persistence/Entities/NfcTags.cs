﻿using System.Collections.Generic;
using HomeAutomator.NfcTags.Domain;

namespace HomeAutomator.NfcTags.Persistence.Entities
{
    internal class NfcTags
    {
        public NfcTags()
        {
            this.Items = new List<NfcTag>();
        }

        public List<NfcTag> Items { get; }
    }
}