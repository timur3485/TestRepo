﻿using System;
using UnityEngine;

namespace Geekbrains
{
    public sealed class GameController : MonoBehaviour, IDisposable
    {
        private InteractiveObject[] _interactiveObjects;
        private SavedData<string> _savedData;

        private void Awake()
        {
            _interactiveObjects = FindObjectsOfType<InteractiveObject>();
            _savedData = new SavedData<string>();
        }

        private void Update()
        {
            for (var i = 0; i < _interactiveObjects.Length; i++)
            {
                var interactiveObject = _interactiveObjects[i];

                if (interactiveObject == null)
                {
                    continue;
                }

                if (interactiveObject is IFlay flay)
                {
                    flay.Flay();
                }
                if (interactiveObject is IFlicker flicker)
                {
                    flicker.Flicker();
                }
                if (interactiveObject is IRotation rotation)
                {
                    rotation.Rotation();
                }
                
            }
        }

        public void Dispose()
        {
            foreach (var o in _interactiveObjects)
            {
                Destroy(o.gameObject);
            }
        }
    }
}
