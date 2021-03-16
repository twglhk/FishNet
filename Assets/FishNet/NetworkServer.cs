using Cysharp.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;

namespace FishNet
{

    /// <summary>
    /// The NetworkServer.
    /// </summary>
    /// <remarks>
    /// <para>NetworkServer handles remote connections from remote clients, and also has a local connection for a local client.</para>
    /// </remarks>
    [AddComponentMenu("FishNet/NetworkServer")]
    [DisallowMultipleComponent]
    public class NetworkServer : MonoBehaviour
    {
        public Transport Transport;


        public readonly Dictionary<NetworkConnection, NetworkPlayer> Players = new Dictionary<NetworkConnection, NetworkPlayer>();
        public ServerStates State { get; private set; }

        public UnityEvent OnStart = new UnityEvent();

        public UnityEvent OnStop = new UnityEvent();

        public NetworkConnectionEvent OnClientConnected { get; } = new NetworkConnectionEvent();

        public NetworkConnectionEvent OnClientAuthenticated { get; } = new NetworkConnectionEvent();
        public NetworkConnectionEvent OnClientDisconnected { get; } = new NetworkConnectionEvent();

        
        public void Stop()
        {
            //throw new NotImplementedException();
        }

        public void Start()
        {
        //    UniTask task = ListenAsync();
        }

        private async UniTask StartAsync()
        {
            await Task.Run(() => Transport.ServerStart());

            Debug.Log(Transport.ServerActive());

        }
    }


}