using Game.Scripts.Infrastructure.TickManaging;
using System.Collections.Generic;
using Fusion;
using UniRx;

namespace Game.Code.Game
{
    public class NetworkTickService : SimulationBehaviour
    {
        private readonly List<ITickListener> _tickListeners = new();

        public override void FixedUpdateNetwork()
        {
            foreach (var listener in _tickListeners)
                listener.Tick(Runner.DeltaTime);
        }

        public void AddListener(ITickListener listener)
        {
            if (!_tickListeners.Contains(listener))
            {
                listener.OnDisposed += RemoveListener;
                _tickListeners.Add(listener);
            }
        }

        public void RemoveListener(ITickListener listener)
        {
            listener.OnDisposed -= RemoveListener;
            _tickListeners.Remove(listener);
        }

        public void AddListener(params ITickListener[] listenersToAdd)
        {
            foreach (var listener in listenersToAdd)
                AddListener(listener);
        }

        public void RemoveListener(params ITickListener[] listenersToRemove)
        {
            foreach (var listener in listenersToRemove)
                _tickListeners.Remove(listener);
        }
    }
}