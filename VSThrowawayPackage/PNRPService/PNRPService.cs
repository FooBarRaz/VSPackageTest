using System.Net.PeerToPeer;
using System.Runtime.InteropServices.WindowsRuntime;

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

        public PeerName CreatePeerName(string name, bool isSecured)
        {
            return new PeerName(name, isSecured? PeerNameType.Secured : PeerNameType.Unsecured);
        }
    }
}