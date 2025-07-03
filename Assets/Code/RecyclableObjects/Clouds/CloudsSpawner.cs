using Assets.Code.Common.Events;
using Assets.Code.Common.MapsAndLevelsData;
using Assets.Code.Core;
using Assets.Code.RecyclableObjects.Clouds;
using UnityEngine;

namespace Assets.Code.ZOthers
{
    public class CloudsSpawner : MonoBehaviour, EventObserver
    {

        [SerializeField] private float _spawnRate = 0.4f;

        private CloudsFactory _cloudsFactory;
        private Camera _cam;
        private float _camHeight;
        private float _camWidth;
        private bool _isGameOver;
        private bool _isVictory;
        private string _lastMapPlayed;
        private float _cloudsNumber;


        void Start()
        {
            _lastMapPlayed = ServiceLocator.Instance.GetService<MapsAndLevelsSystem>().GetLastMapPlayed();
            
            var eventQueue = ServiceLocator.Instance.GetService<EventQueue>();
            eventQueue.Subscribe(EventIds.GameOver, this);
            eventQueue.Subscribe(EventIds.Victory, this);
            eventQueue.Subscribe(EventIds.ContinueBattleAfterAds, this);
            eventQueue.Subscribe(EventIds.CloudDestroyed, this);


            _cloudsFactory = ServiceLocator.Instance.GetService<CloudsFactory>();
            
            _cam = Camera.main;
            _camHeight = _cam.orthographicSize;
            _camWidth = _cam.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x;

            FirstClouds();
            InvokeRepeating(nameof(Spawn), _spawnRate, _spawnRate);
            
        }

        private void OnDestroy()
        {
            var eventQueue = ServiceLocator.Instance.GetService<EventQueue>();
            eventQueue.Unsubscribe(EventIds.GameOver, this);
            eventQueue.Unsubscribe(EventIds.Victory, this);
            eventQueue.Unsubscribe(EventIds.ContinueBattleAfterAds, this);
            eventQueue.Unsubscribe(EventIds.CloudDestroyed, this);
        }

        void Spawn()
        {
            if (!_isGameOver && !_isVictory && _cloudsNumber < 12)
            {
                float rndPosY;
                float rndPosX;

                if (Random.Range(0, 100) < 30)
                {
                    rndPosY = (Random.Range(0, 100) % 2) == 0 ? (-_camHeight - 2f) : (_camHeight + 2f);
                    rndPosX = Random.Range(-_camWidth, _camWidth);
                }
                else
                {
                    rndPosY = Random.Range(-_camHeight, _camHeight);
                    rndPosX = (Random.Range(0, 100) % 2) == 0 ? (_camWidth + 2) : (-_camWidth - 2);
                }

                Vector2 spawnPos = new Vector2(_cam.transform.position.x + rndPosX, _cam.transform.position.y + rndPosY);

                CreateNewCloudInPosition(spawnPos);
                _cloudsNumber++;
            }
        }


        void CreateNewCloudInPosition(Vector2 pos)
        {
            Quaternion randomRotation = Quaternion.Euler(0, 0, Random.Range(0.0f, 360.0f));
            float rndScale = Random.Range(0.7f, 1.7f);
            float rndAlphaColor = Random.Range(0.25f, 1f);
            int rndSortingOrder = Random.Range(-10, 4);

            var cloudsBuilder = _cloudsFactory.Create(_lastMapPlayed);
            cloudsBuilder.WithPosition(pos)
                         .WithRotation(randomRotation)
                         .WithScale(rndScale)
                         .WithAlplhaColor(rndAlphaColor)
                         .WithSortingOrder(rndSortingOrder)
                         .Build();
        }

        void FirstClouds()
        {
            int rndClouds = Random.Range(2, 5);
            for (int i = 0; i <= rndClouds; i++)
            {
                float rndPosX = Random.Range(-_camWidth, _camWidth);
                float rndPosY = Random.Range(-_camHeight, _camHeight);

                Vector2 spawnPos = new Vector2(_cam.transform.position.x + rndPosX, _cam.transform.position.y + rndPosY);
                CreateNewCloudInPosition(spawnPos);
            }
        }

        public void Process(EventData eventData)
        {
            if (eventData.EventId == EventIds.GameOver)
            {
                _isGameOver = true;
            }

            if (eventData.EventId == EventIds.Victory)
            {
                _isVictory = true;
            }

            if (eventData.EventId == EventIds.ContinueBattleAfterAds)
            {
                _isGameOver = false;
            }
            
            if (eventData.EventId == EventIds.CloudDestroyed)
            {
                if(_cloudsNumber > 0)
                {
                    _cloudsNumber--;
                }
            }
        }
    }
}