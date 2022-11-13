using System;
using System.Collections.Generic;
using System.Text;

namespace ChurchPresenter.Core.Models
{
    public class HymnMeta
    {
        public uint HymnNumber { get; set; }
        public string Authors { get; set; }
        public uint YearWritten { get; set; }
        public string History { get; set; }
        public List<string> Tags { get; set; }
    }
}
