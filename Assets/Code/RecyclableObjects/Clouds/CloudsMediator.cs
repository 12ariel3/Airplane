using Assets.Code.Common;
using Assets.Code.Common.Events;
using Assets.Code.Core;
using Assets.Code.RecyclableObjects.PopUps;
using UnityEngine;

namespace Assets.Code.RecyclableObjects.Clouds
{
    public class CloudsMediator : RecyclableObject
    {

        [SerializeField] private SpriteRenderer _image;
        [SerializeField] private PopUpId _popUpId;

        public string Id => _popUpId.Value;

        private Color _imageColor;
        private Camera _camera;
        private float _camWidth;
        private float _camHeight;
        private float _counter;

        internal override void Init()
        {
            _counter = 0.2f;
        }

        internal override void Release()
        {
        }

        public void Configure(float scale, float alphaColor, int sortingOrder)
        {
            transform.localScale = (Vector2.one * (scale * 1.8f));
            _imageColor = _image.color;
            _imageColor.a = alphaColor;
            _image.color = _imageColor;
            _image.sortingOrder = sortingOrder;
        }

        private void Start()
        {
            _camera = Camera.main;
            _camWidth = _camera.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x;
            _camHeight = _camera.orthographicSize;

        }

        private void Update()
        {
            if (_counter <= 0)
            {
                _counter = 0.2f;
                DeactivateCloud();
            }
            else
            {
                _counter -= Time.deltaTime;
            }
        }

        void DeactivateCloud()
        {
            if (transform.position.x > _camera.transform.position.x + 2.5 * _camWidth ||
                transform.position.x < _camera.transform.position.x - 2.5 * _camWidth ||
                transform.position.y > _camera.transform.position.y + 2 * _camHeight ||
                transform.position.y < _camera.transform.position.y - 2 * _camHeight)
            {
                ServiceLocator.Instance.GetService<EventQueue>().EnqueueEvent(new EventData(EventIds.CloudDestroyed));
                Recycle();
            }
        }
    }
}