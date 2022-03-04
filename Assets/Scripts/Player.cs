using UnityEngine;

namespace Geekbrains
{
    public abstract class Player : MonoBehaviour
    {
        public float Speed = 3.0f;
        protected Rigidbody Rigidbody;

        private void Start()
        {
            Rigidbody = GetComponent<Rigidbody>();
        }

        public virtual void Move()
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");
            
            Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
            
            Rigidbody.AddForce(movement * Speed);
        }
    }
}
