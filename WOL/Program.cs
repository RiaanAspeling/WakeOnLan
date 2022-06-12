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
    if (client.WakeMac(mac))
        Console.WriteLine($"Wake up {mac} successfull.");
}
