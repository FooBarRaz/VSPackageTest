using System.Net.PeerToPeer;

namespace PNRPService
{
    public class PNRPService : IPNRPService
    {
        public CloudCollection GetAvailableClouds()
        {
            return Cloud.GetAvailableClouds();
        }

        public PeerNameRegistration RegisterPeerGlobal(PeerName peerName, int port)
        {
            PeerNameRegistration peerNameRegistration = new PeerNameRegistration(peerName, port);
            peerNameRegistration.Cloud = Cloud.Global;
            peerNameRegistration.Start();
            return peerNameRegistration;
        }
    }
}