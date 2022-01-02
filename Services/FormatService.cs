using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace devTalksASP.Services
{
    public class FormatService
    {
        public FormatService() { }
        public string TextReduction(string text)
        {
            return text.Length > 300 ? text.Substring(0, 300) + "..." : text;
        }
    }
}
