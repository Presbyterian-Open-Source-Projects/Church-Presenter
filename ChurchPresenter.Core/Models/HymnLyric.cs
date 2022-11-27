using System;
using System.Collections.Generic;
using System.Text;

namespace ChurchPresenter.Core.Models
{
    public class HymnLyric
    {
        public int Id { get; set; }
        public string HymnBookAbbr { get; set; }
        public uint HymnNumber { get; set; }
        public uint VerseNumber { get; set; }
        public uint LineNumber { get; set; }
        public string Lyrics { get; set; }
        public string Language { get; set; }

    }
}
