using System.Net;
using System.Net.Sockets;

if (Environment.GetCommandLineArgs().Count() < 2)
{
    Console.WriteLine(@"Usage:
    wol [mac address] .... [n mac accress]");
    return;
}

var macs = Environment.GetCommandLineArgs();
var client = new WOL.WOL();

for(var i = 1; i < macs.Length; i++)
{
    if (client.WakeMac(macs[i]))
        Console.WriteLine($"Wake up {macs[i]} successfull.");
}
