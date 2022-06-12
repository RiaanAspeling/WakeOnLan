using CommandLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WOL
{
    internal class CommandLineOptions
    {
        [Option('m', "mac-address", Required = true, HelpText = "MAC addresses to send Wake On Lan packet to. Seperate addresses with a space.")]
        public IEnumerable<string> Macs { get; set; }

        [Option('p', "port", Required = false, HelpText = "The UDP port to use to send the magic packet. Default 12287.")]
        public int Port { get; set; }
    }
}
