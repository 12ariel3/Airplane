using Assets.Code.Common.Events;
using Assets.Code.Core;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Code.ZOthers
{
    public class MainCharacterPlatformMovement : MonoBehaviour, EventObserver
    {
        [SerializeField] private Image _characterSprite;

        private Vector3 _platformTranslation = new Vector3(0, .8f, 0);
        private Vector3 _platformRotation = new Vector3(0, 0, 1);
        private bool _isGoingUp;

        private void Start()
        {
            var eventQueue = ServiceLocator.Instance.GetService<EventQueue>();
            eventQueue.Subscribe(EventIds.SwordEquiped, this);
        }

        private void OnDestroy()
        {
            var eventQueue = ServiceLocator.Instance.GetService<EventQueue>();
            eventQueue.Unsubscribe(EventIds.SwordEquiped, this);
        }
    

        void Update()
        {
            if (_isGoingUp)
            {
                var offset = Time.deltaTime * _platformTranslation;
                _characterSprite.rectTransform.localPosition += offset;
                _characterSprite.rectTransform.eulerAngles += _platformRotation;
            }
            else
            {
                var offset = Time.deltaTime * _platformTranslation;
                _characterSprite.rectTransform.localPosition -= offset;
                _characterSprite.rectTransform.eulerAngles += _platformRotation;
            }

            CheckingAndChangingDirection();
        }


        private void CheckingAndChangingDirection()
        {
            if (_characterSprite.rectTransform.localPosition.y >= .35 && _isGoingUp)
            {
                _platformTranslation.y = .4f;
                _platformRotation.z = -.6f;
            }
            if (_characterSprite.rectTransform.localPosition.y <= -.35 && !_isGoingUp)
            {
                _platformTranslation.y = .4f;
                _platformRotation.z = +.6f;
            }
            if (_characterSprite.rectTransform.localPosition.y >= .9)
            {
                _isGoingUp = false;
                _platformTranslation.y = .7f;
                _platformRotation.z = -.15f;
            }
            if (_characterSprite.rectTransform.localPosition.y <= -.9)
            {
                _isGoingUp = true;
                _platformTranslation.y = .7f;
                _platformRotation.z = .15f;
            }
        }

        public void Process(EventData eventData)
        {
            if (eventData.EventId == EventIds.SwordEquiped)
            {
                var swordEquipedEventData = (SwordEquipedEventData)eventData;

                if (swordEquipedEventData._level >= 50)
                {
                    _characterSprite.sprite = swordEquipedEventData._swordSpriteEvolved;
                }
                else
                {
                    _characterSprite.sprite = swordEquipedEventData._swordSpriteUnevolved;
                }
            }
        }
    }
}