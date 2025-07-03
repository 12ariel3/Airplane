using System.Collections;
using UnityEngine;

namespace Assets.Code.Player
{
    public class PlayerMovementController : MonoBehaviour
    {
        private float _speed = 1;
        private float _originalSpeed = 1;
        private float _turnSpeed = 100f;
        private float _originalTurnSpeed = 100f;

        [SerializeField] Rigidbody2D _rb2D;
        float _turnDirection;

        private float _iceDebuffSpeed;
        private float _iceDebuffTurnSpeed;
        private bool _iceDebuffIsActive;
        private bool _rainbowDebuffIsActive;

        private Joystick _joystick;

        public void ConfigureMovement(float speed, float turnSpeed)
        {
            _originalSpeed = speed;
            _originalTurnSpeed = turnSpeed;
            _speed = _originalSpeed;
            _turnSpeed = _originalTurnSpeed;
            _iceDebuffSpeed = _speed - (_speed / 10);
            _iceDebuffTurnSpeed = _turnSpeed - (_turnSpeed / 10);
        }

        public void SetJoystick(Joystick joystick)
        {
            _joystick = joystick;
        }

        public void GetTurnDirection()
        {
            if(_joystick == null)
            {
                return;
            }
            _turnDirection = _joystick.Horizontal;
        }

        public void PlayerMovement()
        {
            if (_rb2D != null)
            {
                if (_iceDebuffIsActive)
                {
                    _speed = _iceDebuffSpeed;
                    _turnSpeed = _iceDebuffTurnSpeed;
                }
                else
                {
                    _speed = _originalSpeed;
                    _turnSpeed = _originalTurnSpeed;
                }
                if (_rainbowDebuffIsActive)
                {
                    _rb2D.velocity = transform.up * _speed;
                    _rb2D.angularVelocity = _turnDirection * _turnSpeed;
                }
                else
                {
                    _rb2D.velocity = transform.up * _speed;
                    _rb2D.angularVelocity = -_turnDirection * _turnSpeed;
                }
            }
        }

        public void PlayerStopMovement()
        {
            _rb2D.velocity = Vector2.zero;
        }

        IEnumerator IceDebuff()
        {
            yield return new WaitForSeconds(13);
            _iceDebuffIsActive = false;
            yield return null;
        }

        IEnumerator RainbowDebuff()
        {
            yield return new WaitForSeconds(15);
            _rainbowDebuffIsActive = false;
            yield return null;
        }

        public void StopAllDebuffCoroutines()
        {
            StopAllCoroutines();
            _iceDebuffIsActive = false;
            _rainbowDebuffIsActive = false;
        }

        public void FilterAndStartCoroutine(string debuffName)
        {
            switch (debuffName)
            {
                case "Ice":
                    if (!_iceDebuffIsActive)
                    {
                        _iceDebuffIsActive = true;
                        StartCoroutine(IceDebuff());
                    }
                    return;

                case "Rainbow":
                    if (!_rainbowDebuffIsActive)
                    {
                        _rainbowDebuffIsActive = true;
                        StartCoroutine(RainbowDebuff());
                    }
                    return;
            }
        }
    }
}