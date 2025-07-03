using UnityEngine;
using UnityEngine.UIElements;

namespace Assets.Code.Enemies.Projectiles
{
    public class MovementController : MonoBehaviour
    {

        private float _speed;
        private float _turnSpeed;
        private Transform _targetTransform;
        private Vector2 _centerOfTheScreen;


        [SerializeField] private Rigidbody2D _rb2D;

        public void Configure(Transform target, float speed, float turnSpeed)
        {
            if (_targetTransform == null) 
            {
                _targetTransform = target;
            }
            _centerOfTheScreen = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width / 2f, Screen.height / 2f));
            _speed = speed;
            _turnSpeed = turnSpeed;
        }

        public void RocketMovement()
        {
            _rb2D.velocity = transform.up * _speed;

            if (_targetTransform != null)
            {
                Vector2 direction = (Vector2)_targetTransform.position - _rb2D.position;
                direction.Normalize();
                float angle = Vector3.Cross(direction, transform.up).z;
                _rb2D.angularVelocity = -_turnSpeed * angle;
                
                
            }
            else
            {
                Vector2 direction = _centerOfTheScreen - _rb2D.position;
                direction.Normalize();
                float angle = Vector3.Cross(direction, transform.up).z;
                _rb2D.angularVelocity = -_turnSpeed * angle;
            }
        }

        public void StopProjectileMovement()
        {
            if (_rb2D != null)
            {
                _rb2D.velocity = Vector3.zero;
                _rb2D.angularVelocity = 0;
            }
        }

        public void ContinueProjectileMovement()
        {
            if (_rb2D != null)
            {
                _rb2D.isKinematic = false;
            }
        }

        public void Follow(Transform playerTransform)
        {
            _targetTransform = playerTransform;
        }
    }
}