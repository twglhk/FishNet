using System;

namespace FishNet
{


    public abstract class ClientTransport : Transport
    {
        /// <summary>
        /// Sends to the server.
        /// </summary>
        /// <param name="channelId"></param>
        /// <param name="segment"></param>
        public abstract void Send(int channelId, ArraySegment<byte> segment);
        /// <summary>
        /// Starts using a specified address.
        /// </summary>
        /// <param name="address"></param>
        public abstract void Start(string address);
    }


}