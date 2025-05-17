using UnityEngine;

namespace Content.Features.CanvasModule.Scripts
{
    public class CanvasModel
    {
        private Canvas _canvas;
        
        public Canvas Canvas { 
            get => _canvas;
            set
            {
                _canvas = value;
            }
        }
    }
}