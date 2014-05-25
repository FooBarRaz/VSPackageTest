using System;
using System.Net.PeerToPeer;

namespace PNRPService
{
    public class PNRPService : IPNRPService
    {
        public PeerNameRecordCollection Records { get; private set; }

        public CloudCollection GetAvailableClouds()
        {
            return Cloud.GetAvailableClouds();
        }

        public PeerNameRegistration RegisterPeerGlobal(PeerName peerName, int port)
        {
            var peerNameRegistration = new PeerNameRegistration(peerName, port) {Cloud = Cloud.Global};
            peerNameRegistration.Start();
            return peerNameRegistration;
        }

        public PeerName CreatePeerName(string name, bool isSecured)
        {
            return new PeerName(name, isSecured? PeerNameType.Secured : PeerNameType.Unsecured);
        }

        public PeerNameRegistration RegisterPeer(PeerName peerName, int port)
        {
            var peerNameRegistration = new PeerNameRegistration(peerName, port);
            peerNameRegistration.Start();
            return peerNameRegistration;
        }

        public PeerNameResolver ResolvePeerName(PeerName peerName)
        {
            var peerNameResolver = new PeerNameResolver();
            peerNameResolver.ResolveCompleted += peerNameResolver_ResolveCompleted;
            peerNameResolver.ResolveAsync(peerName, Guid.NewGuid());
            return peerNameResolver;
        }

        void peerNameResolver_ResolveCompleted(object sender, ResolveCompletedEventArgs e)
        {
            if (e.Cancelled || e.Error != null || e.PeerNameRecordCollection == null) return;
            Records = e.PeerNameRecordCollection;
            ResolutionCompleted(this, e);
        } 

        public event EventHandler<ResolveCompletedEventArgs> ResolutionCompleted; 
    }
}