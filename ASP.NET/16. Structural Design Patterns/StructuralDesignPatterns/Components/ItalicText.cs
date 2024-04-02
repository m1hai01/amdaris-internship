using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructuralDesignPatterns.Components
{
    public class ItalicText : ITextFormat
    {
        public string Apply(string text)
        {
            return $"<i>{text}</i>";
        }
    }
}