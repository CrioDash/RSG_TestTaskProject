using System.Collections.Generic;
using Core.SceneLoaderServiceModule.Scripts;
using Global.Scripts.Generated;

namespace Content.Features.GameFlowStateMachineModule.Scripts {
    public class EnterSurfaceFlowState : GameFlowStateBase {
        private readonly ISceneLoaderService _sceneLoaderService;

        public EnterSurfaceFlowState(ISceneLoaderService sceneLoaderService) =>
            _sceneLoaderService = sceneLoaderService;

        public override void Enter() {
            List<string> enabledScenes = new() {
                SceneInBuild.GlobalScene,
                SceneInBuild.SurfaceScene,
            };

            _sceneLoaderService.LoadScenesAsync(enabledScenes, SceneInBuild.SurfaceScene, true);
        }

        public override void Exit() { }
    }
}