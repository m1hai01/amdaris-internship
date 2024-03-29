using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCode.Domain.Models
{
    public class WebBrowser
    {
        public string Name { get; set; }
        public int MajorVersion { get; set; }

        // You can add more properties as needed
        public enum BrowserName
        {
            InternetExplorer,
            Chrome,
            Firefox,
            Safari,
            Edge
            // Add more browsers as needed
        }
    }
}