using Cysharp.Threading.Tasks;
using Game.Code.Common.StateMachineBase.Interfaces;
using Game.Code.Menu.UI;

namespace Game.Code.Menu.StateMachine.States
{
    public class StartGame : IState
    {
        private readonly MenuStateMachine _stateMachine;
        private readonly StartGameView _view;

        public StartGame(MenuStateMachine stateMachine, StartGameView view)
        {
            _stateMachine = stateMachine;
            _view = view;
        }

        public UniTask Enter()
        {
            _view.Enable(true);
            _view.CancelButton.onClick.AddListener(SetMainMenuState);

            return UniTask.CompletedTask;
        }

        public UniTask Exit()
        {
            _view.Enable(false);
            _view.CancelButton.onClick.RemoveListener(SetMainMenuState);
            
            return UniTask.CompletedTask;
        }
        

        private void SetMainMenuState()
            => _stateMachine.Enter<MainMenu>().Forget();
    }
}