using Geekbrains;
using UnityEngine;

namespace NewNamespace
{
    public sealed class PlayerMoveNew : Player
    {
        private Vector3 _screenPoint;
        private Vector3 _offset;
        
        private void FixedUpdate() => Move();

        public override void Move()
        {
            NewMethod();

            if (Input.GetMouseButton(0))
            {
                var curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, _screenPoint.z);
 
                var curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + _offset;
                curPosition.y = transform.position.y;
                Rigidbody.MovePosition(curPosition);
            }
        }

        private void NewMethod()
        {
            if (Input.GetMouseButtonDown(0))
            {
                var position = transform.position;
                _screenPoint = Camera.main.WorldToScreenPoint(position);
                _offset = position -
                          Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y,
                              _screenPoint.z));
            }
        }
    }
}