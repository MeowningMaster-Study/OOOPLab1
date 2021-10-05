using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1Libraries.IP
{
    public class IPv6
    {
        readonly UInt16[] address;
        readonly int subnetBits;

        public IPv6(UInt16[] address, int subnetBits)
        {
            this.address = address;
            this.subnetBits = subnetBits;
        }

        public static IPv6 Parse(string text)
        {
            if (text.Length < 2)
            {
                throw new Exception("Too few characters");
            }

            (string rawAddress, int subnetBits) = ParseAddressAndSubnetBits(text);
            var address = ParseAddress(rawAddress);

            return new IPv6(address, subnetBits);
        }

        static (string, int) ParseAddressAndSubnetBits(string text)
        {
            int subnetBits = 0;
            var parts = text.Split('/');
            if (parts.Length > 2)
            {
                throw new Exception("Only one slash permitted");
            }
            if (parts.Length == 2)
            {
                subnetBits = Convert.ToInt32(parts[1]);
            }
            if (subnetBits > 128)
            {
                throw new Exception("Subnet bits sould be less than 128");
            }
            return (parts[0], subnetBits);
        }

        static void CheckForInacceptableCharacters(string text)
        {
            const string acceptableCharacters = "1234567890ABCDEF:";
            foreach (var ch in text)
            {
                if (!acceptableCharacters.Contains(ch))
                {
                    throw new Exception("Character '" + ch + "' is inacceptable");
                }
            }
        }

        static UInt16[] ParseAddress(string rawAddress)
        {
            CheckForInacceptableCharacters(rawAddress);
            var address = new UInt16[8];

            var doubleSemicolonIndex = rawAddress.IndexOf("::");
            if (rawAddress.IndexOf("::", doubleSemicolonIndex + 1) != -1)
            {
                throw new Exception("Too much double semicolons");
            }
            var semicolonsCount = rawAddress.Count(x => x == ':');
            if (semicolonsCount > 7)
            {
                throw new Exception("Too much semicolons");
            }
            if (doubleSemicolonIndex != -1)
            {
                var semicolonsToAdd = 7 - semicolonsCount;
                rawAddress = rawAddress.Insert(doubleSemicolonIndex, new string(':', semicolonsToAdd));
            } else if (semicolonsCount < 7)
            {
                throw new Exception("Double semicolon expected");
            }

            var parts = rawAddress.Split(':');
            for(int i = 0; i < 8; i += 1)
            {
                address[i] = ParsePart(parts[i]);
            }
            return address;
        }

        static UInt16 ParsePart(string part)
        {
            if (part == "")
            {
                return 0;
            }
            var res = Convert.ToUInt16(part, 16);
            if (res > 65535)
            {
                throw new Exception("The part '" + part + "' is too big");
            }
            return res;
        }

        override public string ToString()
        {
            var text = "";
            for(int i = 0; i < 8; i += 1)
            {
                if (i != 0)
                {
                    text += ':';
                }
                text += address[i].ToString("X");
            }
            text += '/' + subnetBits.ToString();
            return text;
        }

        public bool HasSubnet(IPv6 trySubnet)
        {
            var pos = 0;

            var fullParts = subnetBits / 16;
            while (pos < fullParts)
            {
                if (address[pos] != trySubnet.address[pos])
                {
                    return false;
                }
                pos += 1;
            }

            uint mask = 0;
            int remaining = subnetBits % 16;

            if (remaining != 0)
            {
                for (int i = 17 - remaining; i <= 16; i += 1)
                {
                    mask |= (uint)1 << i;
                }

                if ((address[pos] & mask) == address[pos])
                {

                }
                pos += 1;
            }

            while (pos < 8)
            {
                if (trySubnet.address[pos] != 0)
                {
                    return false;
                }
                pos += 1;
            }

            return true;
        }
    }
}
