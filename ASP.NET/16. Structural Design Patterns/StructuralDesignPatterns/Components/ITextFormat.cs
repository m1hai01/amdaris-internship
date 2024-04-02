using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructuralDesignPatterns.Components
{
    internal interface ITextFormat
    {
        string Apply(string text);
    }
}