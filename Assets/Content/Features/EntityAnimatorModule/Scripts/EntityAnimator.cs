using System;
using UnityEngine;

namespace Content.Features.EntityAnimatorModule.Scripts {
    public class EntityAnimator : MonoBehaviour {
        [SerializeField] protected Animator _animator;
        [SerializeField] protected BaseAnimatorConfiguration _baseAnimatorConfiguration;
    
        public event Action OnAttackTriggered;

        public void SetIsAttacking(bool value) =>
            _animator.SetBool(_baseAnimatorConfiguration.IsAttackingValueName, value);

        public void SetSpeed(float value) =>
            _animator.SetFloat(_baseAnimatorConfiguration.SpeedValueName, value);

        /// <summary>
        /// Animation event
        /// </summary>
        private void OnAttacked() =>
            OnAttackTriggered?.Invoke();
    }
}
