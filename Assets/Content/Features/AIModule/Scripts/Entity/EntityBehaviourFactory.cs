using Zenject;

namespace Content.Features.AIModule.Scripts.Entity {
    public class EntityBehaviourFactory : IEntityBehaviourFactory {
        private readonly DiContainer _container;

        public EntityBehaviourFactory(DiContainer container) =>
            _container = container;

        public TEntityBehaviour GetEntityBehaviour<TEntityBehaviour>() where TEntityBehaviour : IEntityBehaviour =>
            _container.Instantiate<TEntityBehaviour>();
    }
}