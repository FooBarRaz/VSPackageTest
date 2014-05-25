using System.Net.PeerToPeer;

namespace PNRPService
{
    public interface IPNRPService
    {
        CloudCollection GetAvailableClouds();
        PeerNameRegistration RegisterPeerGlobal(PeerName peerName, int port);
        PeerName CreatePeerName(string name, bool isSecured);
    }
}