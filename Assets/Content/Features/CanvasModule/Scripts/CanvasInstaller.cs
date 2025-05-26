using Zenject;

namespace Content.Features.CanvasModule.Scripts
{ 
    public class CanvasInstaller : Installer<CanvasInstaller> {
        public override void InstallBindings() {
            Container.Bind<CanvasModel>()
                .AsSingle();
            
            
        }
    }
}