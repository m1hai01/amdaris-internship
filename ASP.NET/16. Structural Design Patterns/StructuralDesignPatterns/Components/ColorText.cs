using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructuralDesignPatterns.Components
{
    public class ColorText : ITextFormat
    {
        private string color;

        public ColorText(string color)
        {
            this.color = color;
        }

        public string Apply(string text)
        {
            return $"<span style='color:{color}'>{text}</span>";
        }
    }
}