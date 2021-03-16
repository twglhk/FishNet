
namespace FishNet
{

    public class NetworkPlayer
    {
        public NetworkConnection Connecton { get; private set; }

        public NetworkPlayer(NetworkConnection connection)
        {
            Connecton = connection;
        }
    }


}