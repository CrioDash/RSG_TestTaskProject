using System;
using Content.Features.PlayerData.Scripts;
using UnityEngine;
using Zenject;

namespace Content.Features.CanvasModule.Scripts
{
    public class CanvasRegister : MonoBehaviour {
        private CanvasModel _canvasModel;

        [Inject]
        public void InjectDependencies(CanvasModel playerCanvasModel) =>
            _canvasModel = playerCanvasModel;

        private void Awake()
        {
            _canvasModel.Canvas = GetComponent<Canvas>();  
        }
        
    }
}