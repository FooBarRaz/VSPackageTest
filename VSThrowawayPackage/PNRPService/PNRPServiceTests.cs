using System.Net.PeerToPeer;
using System.Net.PeerToPeer.Collaboration;
using System.ServiceModel.ComIntegration;
using NUnit.Framework;

namespace PNRPService
{
    class PNRPServiceTests
    {
        private IPNRPService sut;

        [SetUp]
        public void Setup()
        {
            sut = new PNRPService();
        }

        [Test]
        public void PeerNameRegistry_GetClouds_ReturnsListOfClouds()
        {
            var clouds = sut.GetAvailableClouds();
            Assert.That(clouds.Count, Is.GreaterThan(0));
        }

        [TestCase("UnsecuredPeer", false)]
        [TestCase("SecuredPeer", true)]
        public void CreatePeerName_CreatesPeerNamesWithDesireSecurity(string peerName, bool isSecured)
        {
            IPNRPService sut = new PNRPService();
            var peer = sut.CreatePeerName(peerName, isSecured);
            Assert.That(peer.IsSecured, Is.EqualTo(isSecured));
            Assert.That(peer.Classifier, Is.EqualTo(peerName));
        }

        [Test]
        public void PeerNameRegistry_RegisterPeerLocal_RegisterPeerAllClouds()
        {
            var peer = sut.CreatePeerName("Test", false);
            var registration = sut.RegisterPeer(peer, 9714);
            Assert.That(registration.PeerName, Is.EqualTo(peer));
            Assert.That(registration.Port, Is.EqualTo(9714));
            Assert.That(registration.Cloud.Scope.ToString(), Is.EqualTo("All"));
            Assert.That(registration.IsRegistered(), Is.True);
        }

        [Ignore("Need to figure out how to test async event raising")]
        [Test]
        public void PeerNameRegistry_ResolvePeerName()
        {
            PeerNameRecordCollection records = null;
            sut.ResolutionCompleted += (sender, args) =>
            {
                records = args.PeerNameRecordCollection;
            }; 
            var peerName = sut.CreatePeerName("Test", false);
            var registration = sut.RegisterPeer(peerName, 9714); 
            var peer = sut.ResolvePeerName(peerName);
            Assert.That(records, Is.Not.Null);
        }

    }
}
