using System.Net;
using System.Net.Sockets;

namespace WOL
{
    internal class WOL : UdpClient
    {
        private const string _broadcastAddress = "255.255.255.255";
        private const int _defaultPort = 12345;

        internal WOL(int port) : base()
        {
            if (port == 0)
                port = _defaultPort;
            SetupConnection(port);
        }

        internal void WakeMac(string mac)
        {
            var macb = StringToBytes(mac);
            var magic = BuildMagicPacket(macb);
            this.Client.Send(magic);
        }

        private static byte[] StringToBytes(string macText)
        {
            var mac = macText.Trim().Replace("-", "").Replace(":", "").Replace(" ", "");
            
            if (mac.Length != 12)
                throw new ArgumentException($"The MAC address must contain 6 hex value pairs. Ignored MAC : {macText}");
            
            if (!long.TryParse(mac, System.Globalization.NumberStyles.HexNumber, null, out var macVal))
                throw new ArgumentException($"The MAC address must contain only valid hex value pairs. Ignored MAC : {macText}");
            
            return Enumerable.Range(0, mac.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(mac.Substring(x, 2), 16))
                             .ToArray();
        }

        private static byte[] BuildMagicPacket(byte[] mac)
        {
            var bytes = new List<byte>() { 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF };

            for (int y = 0; y < 16; y++)
                bytes.AddRange(mac);

            return bytes.ToArray();
        }

        private void SetupConnection(int port)
        {
            this.Client.EnableBroadcast = true;
            this.Client.Connect(IPAddress.Parse(_broadcastAddress), port);
        }
    }
}
