using System.Net.PeerToPeer;
using System.ServiceModel;
using NUnit.Framework;

namespace PNRPService
{
    class PNRPServiceTests
    {
        [Test]
        public void PeerNameRegistry_GetClouds_ReturnsListOfClouds()
        {
            IPNRPService sut = new PNRPService();
            var clouds = sut.GetAvailableClouds();
            Assert.That(clouds.Count, Is.GreaterThan(0));
        }

        [Test]
        public void PeerNameRegistry_RegisterPeerGlobal_RegistersPeerOnGlobalCloud()
        {
            PeerName peerName = new PeerName("Test", PeerNameType.Unsecured);
            IPNRPService sut = new PNRPService();
            var registration = sut.RegisterPeerGlobal(peerName, 9714);
            Assert.That(registration.IsRegistered(), Is.True);
            Assert.That(registration.Cloud, Is.EqualTo(Cloud.Global));
        }

        [Test]
        public void PeerNameRegistry_RegisterPeerLocal_RegisterPeerOnLocalClouds()
        {
            
            
        }
    }
}
