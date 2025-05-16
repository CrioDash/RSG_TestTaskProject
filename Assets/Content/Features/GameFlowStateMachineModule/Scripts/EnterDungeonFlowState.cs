using System.Collections.Generic;
using Core.SceneLoaderServiceModule.Scripts;
using Global.Scripts.Generated;

namespace Content.Features.GameFlowStateMachineModule.Scripts {
    public class EnterDungeonFlowState : GameFlowStateBase {
        private readonly ISceneLoaderService _sceneLoaderService;

        public EnterDungeonFlowState(ISceneLoaderService sceneLoaderService) =>
            _sceneLoaderService = sceneLoaderService;

        public override void Enter() {
            List<string> enabledScenes = new() {
                SceneInBuild.GlobalScene, 
                SceneInBuild.DungeonScene
            };
        
            _sceneLoaderService.LoadScenesAsync(enabledScenes, SceneInBuild.DungeonScene, true);
        }

        public override void Exit() { }
    }
}