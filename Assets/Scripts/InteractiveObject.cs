using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Geekbrains
{
    public abstract class InteractiveObject : MonoBehaviour, IInteractable, IComparable<InteractiveObject>
    {
        public bool IsInteractable { get; private set; } = true;

        private void OnTriggerEnter(Collider other)
        {
            if (!IsInteractable || !other.CompareTag("Player"))
            {
                return;
            }
            Interaction();
            Destroy(gameObject);
        }

        protected abstract void Interaction();

        private void Start()
        {
            ((IAction)this).Action();
        }

        void IAction.Action()
        {
            if (TryGetComponent(out Renderer renderer))
            {
                renderer.material.color = Random.ColorHSV();
            } 
        }

        void IInitialization.Action()
        {
            if (TryGetComponent(out Renderer renderer))
            {
                renderer.material.color = Color.cyan;
            }
        }
        
        public virtual int CompareTo(InteractiveObject other)
        {
            return name.CompareTo(other.name);
        }
    }
}
