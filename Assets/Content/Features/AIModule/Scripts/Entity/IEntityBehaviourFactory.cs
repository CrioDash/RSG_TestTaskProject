namespace Content.Features.AIModule.Scripts.Entity {
    public interface IEntityBehaviourFactory {
        public TEntityBehaviour GetEntityBehaviour<TEntityBehaviour>() where TEntityBehaviour : IEntityBehaviour;
    }
}