using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeHub.Models.Entity
{
    public class PasteCode
    {
        public int id { get; set; }
        public string poster { get; set; }
        public string language { get; set; }
        public string languagemode { get; set; }
        public string theme { get; set; }
        public string code { get; set; }
        public string time { get; set; }

        public PasteCode() { }
        public PasteCode(int id, string poster, string language,
                         string languagemode, string theme, string code,
                         string time)
        {
            this.id = id;
            this.poster = poster;
            this.language = language;
            this.languagemode = languagemode;
            this.theme = theme;
            this.code = code;
            this.time = time;
        }
    }
}