using System;
using System.Collections.Generic;

namespace Core.StateMachineModule.Scripts {
    public abstract class StateMachineBehaviour<TStateBase> : IDisposable where TStateBase : StateBase{
        protected TStateBase ActiveStateBase;

        protected Dictionary<Type, TStateBase> States;
        
        public void SetStates(Dictionary<Type, TStateBase> states) =>
            States = states;
        
        public void SetStates(List<TStateBase> states) {
            States = new Dictionary<Type, TStateBase>();
            foreach (TStateBase state in states) {
                States.Add(state.GetType(), state);
            }
        }

        public virtual void Enter<TState>() where TState : TStateBase {
            ActiveStateBase?.Exit();

            ActiveStateBase = States[typeof(TState)];
            ActiveStateBase.Enter();
        }
        
        public virtual void Enter<TState, TPayload>(TPayload payLoad) where TState : PayLoadedStateBase<TPayload> {
            ActiveStateBase.Exit();
            TState newState = States[typeof(TState)] as TState;
            newState?.Enter(payLoad);
            ActiveStateBase = newState as TStateBase;
        }

        public virtual Type GetCurrentState() =>
            ActiveStateBase?.GetType();

        public void Dispose() {
            ActiveStateBase?.Exit();
            States.Clear();
            ActiveStateBase = null;
        }
    }
}