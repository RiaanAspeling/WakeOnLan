using CommandLine;
using WOL;

var cmdLine = Parser.Default.ParseArguments<CommandLineOptions>(args);

if (cmdLine.Errors.Any())
    return;

var macs = cmdLine.Value.Macs;
var port = cmdLine.Value.Port;
var client = new WOL.WOL(port);

foreach(var mac in macs)
{
    try
    {
        client.WakeMac(mac);
        Console.WriteLine($"Successfully sent wake-on-lan (WOL) broadcast message for {mac}");
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}