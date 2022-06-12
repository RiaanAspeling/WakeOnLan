using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net;
using System.Net.Sockets;

namespace WOL
{
    internal class WOL : UdpClient
    {
        internal WOL(int port) : base()
        {
            if (port == 0)
                port = 0x2fff;
            SetupConnection(port);
        }

        internal bool WakeMac(string mac)
        {
            try
            {
                var macb = StringToBytes(mac);
                var magic = BuildMagicPacket(macb);
                this.Client.Send(magic);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return false;
        }

        private byte[] StringToBytes(string macText)
        {
            var mac = macText.Replace("-", "").Replace(":", "").Replace(" ", "");
            
            if (mac.Length != 12)
                throw new ArgumentException($"Mac address must contain 6 x HEX pairs, skipping. This mac is incorrect: {macText}");
            
            if (!long.TryParse(mac, System.Globalization.NumberStyles.HexNumber, null, out var macVal))
                throw new ArgumentException($"Mac address must contain only valid HEX pairs, skipping. This mac is incorrect: {macText}");
            
            return Enumerable.Range(0, mac.Length)
                     .Where(x => x % 2 == 0)
                     .Select(x => Convert.ToByte(mac.Substring(x, 2), 16))
                     .ToArray();
        }

        private byte[] BuildMagicPacket(byte[] mac)
        {
            var bytes = new List<byte>() { 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF };

            for (int y = 0; y < 16; y++)
                bytes.AddRange(mac);

            return bytes.ToArray();
        }

        private void SetupConnection(int port)
        {
            this.Client.EnableBroadcast = true;
            this.Client.Connect(new IPAddress(0xffffffff),  // 255.255.255.255  i.e broadcast
                                port);
        }
    }
}
