using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wokarol
{
    /// <summary>
    /// Handles Player Movement without input
    /// </summary>
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] float _speed = default;
        [SerializeField] float _maxSpeedAtDistance = default;
        [SerializeField] float maxSpeed = default;
        

        Rigidbody _rigidbody;

        /// <summary>
        /// Player Movement will try to go to that position
        /// </summary>
        public Vector3 TargetPosition { get; set; }
        public float Speed => _speed;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            TargetPosition = new Vector3(transform.position.x,0,0);
        }

        private void FixedUpdate()
        {
            var difference = TargetPosition- new Vector3(_rigidbody.position.x, 0, 0);
            //_rigidbody.AddForce(difference.normalized * Mathf.Clamp01(difference.magnitude / _maxSpeedAtDistance) * _speed);
            _rigidbody.AddForce((difference.normalized * Mathf.Clamp01(difference.magnitude / _maxSpeedAtDistance) + new Vector3(0, 0, 1)) * _speed);
            if (_rigidbody.velocity.magnitude > maxSpeed)
            {
                _rigidbody.velocity = Vector3.ClampMagnitude(_rigidbody.velocity, maxSpeed);

                //_rigidbody.AddForce(direction * _speed);
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(TargetPosition, 0.4f);
        }
    }
}
