using Microsoft.Extensions.Diagnostics.HealthChecks;
using NuGet.Protocol.Plugins;
using System.Drawing;

namespace Azuredotnetblobproject.Models
{
    public class Blob
    {
        public string Title { get; set; }
        public string Comment { get; set; } 

        public string Uri { get; set; }
    }
}
