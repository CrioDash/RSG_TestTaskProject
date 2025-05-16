using System;

namespace Content.Features.AIModule.Scripts.Entity {
    public interface IEntityBehaviour {
        public event Action OnBehaviorEnd;
        public void InitContext(EntityContext entityContext);
        public void Start();
        public void Process();
        public void Stop();
    }
}