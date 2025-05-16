using System.Collections.Generic;
using Core.StateMachineModule.Scripts;

namespace Content.Features.GameFlowStateMachineModule.Scripts {
    public class GameFlowStateMachine : StateMachineBehaviour<GameFlowStateBase> {
        public GameFlowStateMachine(GlobalGameFlowState bootstrapGameFlowState, EnterSurfaceFlowState enterSurfaceFlowState, EnterDungeonFlowState enterDungeonFlowState) =>
            SetStates(new List<GameFlowStateBase>() {
                bootstrapGameFlowState, enterSurfaceFlowState , enterDungeonFlowState
            });
    }
}