using Content.Features.GameFlowStateMachineModule.Scripts;
using UnityEngine;
using Zenject;

namespace Content.Features.GameBootstrapModule.Scripts.Bootstraps {
    public class BootstrapSceneBootstrap : MonoBehaviour {
        private GameFlowStateMachine _gameFlowStateMachine;

        [Inject]
        public void InjectDependencies(GameFlowStateMachine gameFlowStateMachine) =>
            _gameFlowStateMachine = gameFlowStateMachine;

        void Start() =>
            _gameFlowStateMachine.Enter<GlobalGameFlowState>();
    }
}
