using CommandLine;

namespace WOL
{
    internal class CommandLineOptions
    {
        [Option('m', "mac", Required = true, HelpText = "The hardware MAC addresses to send Wake On Lan packet for. Delimit addresses with a space.")]
        public IEnumerable<string> Macs { get; set; }

        [Option('p', "port", Required = false, HelpText = "The UDP port to use to send the magic packet. Default 12345.")]
        public int Port { get; set; }
    }
}
