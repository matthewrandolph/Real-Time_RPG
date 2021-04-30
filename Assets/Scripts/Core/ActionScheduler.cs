using System;
using UnityEngine;

namespace RPG.Core
{
    public class ActionScheduler : MonoBehaviour
    {
        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public void StartAction(IAction action)
        {
            if (_currentAction == action) return;
            
            if (_currentAction != null)
            {
                _currentAction.Cancel();
            }
            _currentAction = action;
        }
        
        private IAction _currentAction;
        
        // Cached components
        private Animator _animator;
    }
}