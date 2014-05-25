using System.Net.PeerToPeer;

namespace PNRPService
{
    public interface IPNRPService
    {
        CloudCollection GetAvailableClouds();
        PeerNameRegistration RegisterPeerGlobal(PeerName peerName, int port);
    }
}