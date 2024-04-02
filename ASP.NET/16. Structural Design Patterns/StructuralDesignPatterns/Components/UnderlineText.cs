using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructuralDesignPatterns.Components
{
    public class UnderlineText : ITextFormat
    {
        public string Apply(string text)
        {
            return $"<u>{text}</u>";
        }
    }
}