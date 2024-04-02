using StructuralDesignPatterns.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructuralDesignPatterns.Decorator
{
    internal class CombinedFormat : ITextFormat
    {
        private ITextFormat[] formats;

        public CombinedFormat(params ITextFormat[] formats)
        {
            this.formats = formats;
        }

        public string Apply(string text)
        {
            foreach (var format in formats)
            {
                text = format.Apply(text);
            }
            return text;
        }
    }
}