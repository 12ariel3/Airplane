using Assets.Code.Common.Events;
using Assets.Code.Common.MapsAndLevelsData;
using Assets.Code.Core;
using Assets.Code.Enemies.Projectiles;
using Assets.Code.MusicAndSound;
using Assets.Code.Player;
using Assets.Code.Projectiles.Common;
using UnityEngine;

namespace Assets.Code.Enemies
{
    public class EnemySpawner : MonoBehaviour, EventObserver
    {
        [SerializeField] private Transform _centerDirectionPosition;
        

        [SerializeField] private MapsConfiguration _mapsConfiguration;
        private ProjectileFactory _projectileFactory;

        private LevelConfiguration _levelConfiguration;
        private float _currentTimeInSeconds;
        private int _currentConfigurationIndex;
        private bool _canSpawn;
        private string _lastMapPlayed;

        private Camera _cam;
        private float _camHeight;
        private float _camWidth;
        private bool _isGameOver;
        private bool _isVictory;
        private string _finalPosition;
        private bool _sentOnce;

        private void Start()
        {
            _projectileFactory = ServiceLocator.Instance.GetService<ProjectileFactory>();
            GetCurrentLevelCofiguration();
            ServiceLocator.Instance.GetService<AudioManager>().PlayGameMusic(_lastMapPlayed);

            _cam = Camera.main;
            _camHeight = _cam.orthographicSize;
            _camWidth = _cam.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x;
            

            var eventQueue = ServiceLocator.Instance.GetService<EventQueue>();
            eventQueue.Subscribe(EventIds.PlayerSpamedAndSendHisTransform, this);
        }

        private void OnDestroy()
        {
            var eventQueue = ServiceLocator.Instance.GetService<EventQueue>();
            eventQueue.Unsubscribe(EventIds.PlayerSpamedAndSendHisTransform, this);
        }

        private void GetCurrentLevelCofiguration()
        {
            var serviceLocator = ServiceLocator.Instance;
            int currentLevel = serviceLocator.GetService<MapsAndLevelsSystem>().GetLastLevelPlayed();
            _lastMapPlayed = serviceLocator.GetService<MapsAndLevelsSystem>().GetLastMapPlayed();
            MapConfiguration mapConfiguration = _mapsConfiguration.GetMapById(_lastMapPlayed);
            _levelConfiguration = mapConfiguration.GetCurrentLevelConfiguration(currentLevel);
        }

        public void StartSpawn()
        {
            _canSpawn = true;
        }

        public void RestartSpawn()
        {
            _canSpawn = true;
            if (_currentConfigurationIndex >= _levelConfiguration.SpawnConfigurations.Length)
            {
                ServiceLocator.Instance.GetService<EventQueue>()
                              .EnqueueEvent(new EventData(EventIds.AllProjectilesSpawned));
            }
        }


        public void Stop()
        {
            _canSpawn = false;
        }


        private void Update()
        {
            if (!_canSpawn)
            {
                return;
            }

            if (_currentConfigurationIndex >= _levelConfiguration.SpawnConfigurations.Length)
            {
                return;
            }

            _currentTimeInSeconds += Time.deltaTime;

            var spawnConfiguration = _levelConfiguration.SpawnConfigurations[_currentConfigurationIndex];
            if (spawnConfiguration.TimeToSpawn > _currentTimeInSeconds)
            {
                return;
            }

            SpawnShips(spawnConfiguration);
            _currentConfigurationIndex += 1;

            if (_currentConfigurationIndex >= _levelConfiguration.SpawnConfigurations.Length)
            {
                ServiceLocator.Instance.GetService<EventQueue>()
                              .EnqueueEvent(new EventData(EventIds.AllProjectilesSpawned));
            }
        }


        private Vector3 FilterSpawnPosition(SpawnConfiguration spawnConfiguration)
        {
            float rndPosY;
            float rndPosX;


            if (spawnConfiguration.IsRandom)
            {
                if (Random.Range(0, 100) < 30)
                {
                    rndPosY = (Random.Range(0, 100) % 2) == 0 ? (-_camHeight - 2f) : (_camHeight + 2f);
                    rndPosX = Random.Range(-_camWidth, _camWidth);
                    if(rndPosY == _camHeight + 2f)
                    {
                        _finalPosition = "Top";
                    }
                    else
                    {
                        _finalPosition = "Bottom";
                    }
                }
                else
                {
                    rndPosY = Random.Range(-_camHeight, _camHeight);
                    rndPosX = (Random.Range(0, 100) % 2) == 0 ? (_camWidth + 2) : (-_camWidth - 2);
                    if (rndPosX == _camWidth + 2)
                    {
                        _finalPosition = "Right";
                    }
                    else
                    {
                        _finalPosition = "Left";
                    }
                }
                var spawnPosition = new Vector3(_cam.transform.position.x + rndPosX, _cam.transform.position.y + rndPosY);
                return spawnPosition;
            }
            if (spawnConfiguration.IsTop)
            {
                rndPosY = _camHeight + 2f;
                rndPosX = Random.Range(-_camWidth, _camWidth);
                var spawnPosition = new Vector3(_cam.transform.position.x + rndPosX, _cam.transform.position.y + rndPosY);
                return spawnPosition;
            }
            if (spawnConfiguration.IsRightAside)
            {
                rndPosY = Random.Range(-_camHeight, _camHeight);
                rndPosX = _camWidth + 2f;
                var spawnPosition = new Vector3(_cam.transform.position.x + rndPosX, _cam.transform.position.y + rndPosY);
                return spawnPosition;
            }
            if (spawnConfiguration.IsLeftAside)
            {
                rndPosY = Random.Range(-_camHeight, _camHeight);
                rndPosX = -_camWidth - 2f;
                var spawnPosition = new Vector3(_cam.transform.position.x + rndPosX, _cam.transform.position.y + rndPosY);
                return spawnPosition;
            }
            else
            {
                rndPosY = -_camHeight - 2f;
                rndPosX = Random.Range(-_camWidth, _camWidth);
                var spawnPosition = new Vector3(_cam.transform.position.x + rndPosX, _cam.transform.position.y + rndPosY);
                return spawnPosition;
            }
        }

        private Quaternion FilterSpawnRotation(SpawnConfiguration spawnConfiguration)
        {
            Quaternion spawnRotation;

            if (spawnConfiguration.IsTop || _finalPosition == "Top")
            {
                spawnRotation = new Quaternion(0, 0, 0, 0);
                spawnRotation.eulerAngles = new Vector3(0, 0, -180);
                return spawnRotation;
            }
            if (spawnConfiguration.IsRightAside || _finalPosition == "Right")
            {
                spawnRotation = new Quaternion(0, 0, 0, 0);
                spawnRotation.eulerAngles = new Vector3(0, 0, 90);
                return spawnRotation;
            }
            if (spawnConfiguration.IsLeftAside || _finalPosition == "Left")
            {
                spawnRotation = new Quaternion(0, 0, 0, 0);
                spawnRotation.eulerAngles = new Vector3(0, 0, -90);
                return spawnRotation;
            }
            else
            {
                spawnRotation = new Quaternion(0, 0, 0, 0);
                spawnRotation.eulerAngles = new Vector3(0, 0, 0);
                return spawnRotation;
            }
        }


        private void SpawnShips(SpawnConfiguration spawnConfiguration)
        {
            ServiceLocator.Instance.GetService<AudioManager>().PlayOtherSfx("Spawn");
            for (var i = 0; i < spawnConfiguration.ProjectileNumberToSpawnConfigurations; i++)
            {
                float randomNumber = Random.Range(0f, 100f);
                ProjectileToSpawnConfiguration shipConfiguration;

                if (randomNumber < _levelConfiguration.SpecialProjectileCastPercentaje)
                {
                    shipConfiguration = _levelConfiguration.GetRandomSpecialProgectileToSpawnConfiguration();
                }
                else
                {
                    shipConfiguration = _levelConfiguration.GetRandomProgectileToSpawnConfiguration();
                }

                var shipBuilder = _projectileFactory.Create(shipConfiguration.ProjectileId.Value);
                Vector3 spawnPosition = FilterSpawnPosition(spawnConfiguration);
                Quaternion spawnRotation = FilterSpawnRotation(spawnConfiguration);
                shipBuilder
                          .WithPosition(spawnPosition)
                          .WithRotation(spawnRotation)
                          .WithSpawnPosition(spawnConfiguration.IsTop, spawnConfiguration.IsLeftAside, spawnConfiguration.IsRightAside)
                          .WithDirectionPositions(_centerDirectionPosition)
                          .WithProjectileLevel(_levelConfiguration.ProjectileLevel)
                          .WithConfiguration(shipConfiguration)
                          .WithCheckBottomDestroyLimits()
                          .Build();
                ServiceLocator.Instance.GetService<EventQueue>()
                              .EnqueueEvent(new EventData(EventIds.ProjectileSpawned));
            }
        }

        public void Process(EventData eventData)
        {
            if (eventData.EventId == EventIds.PlayerSpamedAndSendHisTransform)
            {
                if (_sentOnce == false)
                {
                    var levelDebuffProbabilityEventData = new LevelDebuffProbabilityEventData(_levelConfiguration.DebuffProbability, GetInstanceID());
                    ServiceLocator.Instance.GetService<EventQueue>().EnqueueEvent(levelDebuffProbabilityEventData);
                    _sentOnce = true;
                }
            }
        }
    }
}