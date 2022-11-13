using System;
using System.Collections.Generic;
using System.Text;

namespace ChurchPresenter.Core.Models
{
    public class Song
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Artist { get; set; }
        public string Tags { get; set; }    
        public uint VerseNumber { get; set; }
        public uint LineNumber { get; set; }
        public string Lyrics { get; set; }
        public string Language { get; set; }
    }
}
