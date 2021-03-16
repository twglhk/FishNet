using System;
using UnityEngine;

namespace FishNet
{

    public abstract class Transport
    {

        #region Types.
        /// <summary>
        /// States the connection can be in.
        /// </summary>
        public enum ConnectionStates : byte
        {
            Stopped = 0,
            Starting = 1,
            Started = 2,
            Stopping = 3
        }
        #endregion

        #region Events.
        /// <summary>
        /// Called when data is received.
        /// </summary>
        public event Action<ArraySegment<byte>, uint> OnDataReceived;
        /// <summary>
        /// Called when a socket encounters an error.
        /// </summary>
        public event Action<uint, Exception> OnSocketError;
        /// <summary>
        /// Called when a socket disconnects.
        /// </summary>
        public event Action<uint, Exception> OnSocketDisconnect;
        /// <summary>
        /// Called when the connection state changes.
        /// </summary>
        public event Action<ConnectionStates> OnConnectionState;
        #endregion.

        /// <summary>
        /// Current state of the connection.
        /// </summary>
        public ConnectionStates ConnectionState { get; private set; } = ConnectionStates.Stopped;
        /// <summary>
        /// Sets the current connection state.
        /// </summary>
        /// <param name="state"></param>
        protected void SetConnectionState(ConnectionStates state)
        {
            ConnectionState = state;
            OnConnectionState?.Invoke(ConnectionState);
        }

        /// <summary>
        /// Starts the socket using configured settings.
        /// </summary>
        public abstract void Start();
        /// <summary>
        /// Stops the socket.
        /// </summary>
        public abstract void Stop();


        protected virtual void Awake()
        {
            Application.quitting += Application_Quitting;
        }

        protected virtual void Application_Quitting()
        {
            Shutdown();
        }

        /// <summary>
        /// Shut down the transport.
        /// </summary>
        public abstract void Shutdown();

    }
}
