using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1Libraries.IP
{
    public class IPv4
    {
        readonly byte[] address;
        readonly int subnetBits;

        public IPv4(byte[] address, int subnetBits)
        {
            this.address = address;
            this.subnetBits = subnetBits;
        }

        public static IPv4 Parse(string text)
        {
            if (text.Length < 7)
            {
                throw new Exception("Too few characters");
            }

            (string rawAddress, int subnetBits) = ParseAddressAndSubnetBits(text);
            var address = ParseAddress(rawAddress);

            return new IPv4(address, subnetBits);
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
            const string acceptableCharacters = "1234567890.";
            foreach (var ch in text)
            {
                if (!acceptableCharacters.Contains(ch))
                {
                    throw new Exception("Character '" + ch + "' is inacceptable");
                }
            }
        }

        static byte[] ParseAddress(string rawAddress)
        {
            CheckForInacceptableCharacters(rawAddress);
            var address = new byte[4];
            var parts = rawAddress.Split('.');
            if (parts.Length != 4)
            {
                throw new Exception("Incorrect parts count");
            }
            for (int i = 0; i < 4; i += 1)
            {
                address[i] = ParsePart(parts[i]);
            }
            return address;
        }

        static byte ParsePart(string part)
        {
            var res = Convert.ToByte(part);
            if (res > 255)
            {
                throw new Exception("The part '" + part + "' is too big");
            }
            return res;
        }

        override public string ToString()
        {
            var text = "";
            for (int i = 0; i < 4; i += 1)
            {
                if (i != 0)
                {
                    text += '.';
                }
                text += address[i].ToString();
            }
            text += '/' + subnetBits.ToString();
            return text;
        }

        public bool HasSubnet(IPv4 trySubnet)
        {
            var pos = 0;

            var fullParts = subnetBits / 8;
            while (pos < fullParts)
            {
                if (address[pos] != trySubnet.address[pos])
                {
                    return false;
                }
                pos += 1;
            }

            uint mask = 0;
            int remaining = subnetBits % 8;

            if (remaining != 0)
            {
                for (int i = 9 - remaining; i <= 8; i += 1)
                {
                    mask |= (uint)1 << i;
                }

                if ((address[pos] & mask) == address[pos])
                {

                }
                pos += 1;
            }

            while (pos < 4)
            {
                if (trySubnet.address[pos] != 0)
                {
                    return false;
                }
                pos += 1;
            }

            return true;
        }

        public IPv6 ToIPv6()
        {
            var mappedAddress = new UInt16[8]{ 0, 0, 0, 0, 0, 65535, 0, 0};
            mappedAddress[6] = (UInt16)(address[0] << 8);
            mappedAddress[6] += address[1];
            mappedAddress[7] = (UInt16)(address[2] << 8);
            mappedAddress[7] += address[3];
            return new IPv6(mappedAddress, 96 + subnetBits);
        }
    }
}
