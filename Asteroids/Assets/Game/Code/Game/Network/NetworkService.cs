using System.Collections.Generic;
using Fusion.Sockets;
using System;
using Fusion;
using Game.Code.Game.Services;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Game.Code.Game
{
    public class NetworkService : INetworkRunnerCallbacks
    {
        private readonly InputService _inputService;
        private readonly GameFactory _gameFactory;
        
        public NetworkService(InputService inputService, GameFactory gameFactory)
        {
            _inputService = inputService;
            _gameFactory = gameFactory;
        }

        public void OnInput(NetworkRunner runner, NetworkInput input)
        {
            input.Set(_inputService.GetPlayerInput());
        }

        public async void OnPlayerJoined(NetworkRunner runner, PlayerRef player)
        {
            if (runner.CanSpawn)
            {
                await _gameFactory.CreatePlayer(Vector2.one * Random.Range(3f, 3f));

                Debug.Log($"<color=white>Player Created</color>");
            }
        }

        public void OnPlayerLeft(NetworkRunner runner, PlayerRef player)
        {
        }

        public void OnObjectExitAOI(NetworkRunner runner, NetworkObject obj, PlayerRef player)
        {

        }

        public void OnObjectEnterAOI(NetworkRunner runner, NetworkObject obj, PlayerRef player)
        { 
        }

        public void OnInputMissing(NetworkRunner runner, PlayerRef player, NetworkInput input)
        {
        }

        public void OnShutdown(NetworkRunner runner, ShutdownReason shutdownReason)
        {
        }

        public void OnConnectedToServer(NetworkRunner runner)
        {
        }

        public void OnDisconnectedFromServer(NetworkRunner runner, NetDisconnectReason reason)
        {
        }

        public void OnConnectRequest(NetworkRunner runner, NetworkRunnerCallbackArgs.ConnectRequest request, byte[] token)
        {
        }

        public void OnConnectFailed(NetworkRunner runner, NetAddress remoteAddress, NetConnectFailedReason reason)
        {
        }

        public void OnUserSimulationMessage(NetworkRunner runner, SimulationMessagePtr message)
        {
        }

        public void OnSessionListUpdated(NetworkRunner runner, List<SessionInfo> sessionList)
        {
        }

        public void OnCustomAuthenticationResponse(NetworkRunner runner, Dictionary<string, object> data)
        {
        }

        public void OnHostMigration(NetworkRunner runner, HostMigrationToken hostMigrationToken)
        {
        }

        public void OnReliableDataReceived(NetworkRunner runner, PlayerRef player, ReliableKey key, ArraySegment<byte> data)
        {
        }

        public void OnReliableDataProgress(NetworkRunner runner, PlayerRef player, ReliableKey key, float progress)
        {
        }

        public void OnSceneLoadDone(NetworkRunner runner)
        {
        }

        public void OnSceneLoadStart(NetworkRunner runner)
        {
        }
    }
}