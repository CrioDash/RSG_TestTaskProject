using Zenject;

namespace Content.Features.GameFlowStateMachineModule.Scripts {
    public class GameFlowStateMachineInstaller : Installer<GameFlowStateMachineInstaller> {
        public override void InstallBindings() {
            Container.Bind<GameFlowStateMachine>()
                .AsSingle();

            Container.Bind<GlobalGameFlowState>()
                .AsSingle();
 
            Container.Bind<EnterSurfaceFlowState>()
                .AsSingle();
            
            Container.Bind<EnterDungeonFlowState>()
                .AsSingle();
        }
    }
}