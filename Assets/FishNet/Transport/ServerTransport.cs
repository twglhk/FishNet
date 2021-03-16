using System;

namespace FishNet
{


    public abstract class ServerTransport : Transport
    {
        /// <summary>
        /// Sends to all clients.
        /// </summary>
        /// <param name="channelId"></param>
        /// <param name="segment"></param>
        public abstract void Send(int channelId, ArraySegment<byte> segment);
        /// <summary>
        /// Sends to a single client.
        /// </summary>
        /// <param name="connectionId"></param>
        /// <param name="channelId"></param>
        /// <param name="segment"></param>
        public abstract void SendToClient(int connectionId, int channelId, ArraySegment<byte> segment);
        /// <summary>
        /// Disconnects a client.
        /// </summary>
        public abstract void DisconnectClient(int connectionId);
        /// <summary>
        /// Returns the address of a client.
        /// </summary>
        /// <param name="connectionId"></param>
        public abstract void GetClientAddress(int connectionId);
    }


}