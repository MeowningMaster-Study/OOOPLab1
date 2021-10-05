using NUnit.Framework;
using System;
using Lab1Libraries.IP;

namespace Lab1Tests
{
    class IPTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void V4()
        {
            Assert.AreEqual(IPv4.Parse("255.255.255.255/0").ToString(), "255.255.255.255/0");
            Assert.Throws<Exception>(() => IPv6.Parse("256.255.255.255/0"));
            Assert.IsTrue(IPv4.Parse("1.2.3.4/16").HasSubnet(IPv4.Parse("1.2.0.0/0")));
        }

        [Test]
        public void V6()
        {
            Assert.AreEqual(IPv6.Parse("11:22:F3A3:44:55:C66:77:88/16").ToString(), "11:22:F3A3:44:55:C66:77:88/16");
            Assert.AreEqual(IPv6.Parse("11:22:F3A3::C66:77:88/16").ToString(), "11:22:F3A3:0:0:C66:77:88/16");
            Assert.AreEqual(IPv6.Parse("::1").ToString(), "0:0:0:0:0:0:0:1/0");

            Assert.Throws<Exception>(() => IPv6.Parse(":1"));
            Assert.Throws<Exception>(() => IPv6.Parse("L::143"));
            Assert.Throws<Exception>(() => IPv6.Parse("::1/200"));
            Assert.Throws<Exception>(() => IPv6.Parse("::1434//3"));
            Assert.Throws<OverflowException>(() => IPv6.Parse("::14324"));

            Assert.IsTrue(IPv6.Parse("11:22:F3A3:44:55:C66:77:88/16").HasSubnet(IPv6.Parse("11::0")));
        }
    }
}
