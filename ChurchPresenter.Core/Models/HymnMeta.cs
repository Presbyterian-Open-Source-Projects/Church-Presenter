using System;
using System.Collections.Generic;
using System.Text;

namespace ChurchPresenter.Core.Models
{
    public class HymnMeta
    {
        public string HymnBookAbbr { get; set; }
        public uint HymnNumber { get; set; }
        public string Authors { get; set; }
        public uint YearWritten { get; set; }
        public string History { get; set; }
        public string Tags { get; set; }
    }
}
