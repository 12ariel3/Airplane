using Assets.Code.Common.Events;
using Assets.Code.Common.SwordsData;
using Assets.Code.Core;
using UnityEngine;

namespace Assets.Code.Player
{
    public class PlayerSpawner : MonoBehaviour, EventObserver
    {

        [SerializeField] private PlayerToSpawnConfiguration _playerConfiguration;
        private PlayerBuilder _playerBuilder;

        private int _swordHp;
        private float _swordFire;
        private float _swordPoison;
        private float _swordIce;
        private float _swordWater;
        private float _swordElectric;
        private float _swordGhost;
        private float _swordRainbow;
        private float _swordSpeed;
        private float _swordTurnSpeed;
        private Vector2 _unevolvedFirstColliderOffset;
        private Vector2 _unevolvedFirstColliderSize;
        private Vector2 _unevolvedSecondColliderOffset;
        private Vector2 _unevolvedSecondColliderSize;
        private Vector2 _evolvedFirstColliderOffset;
        private Vector2 _evolvedFirstColliderSize;
        private Vector2 _evolvedSecondColliderOffset;
        private Vector2 _evolvedSecondColliderSize;
        private Sprite _unevolvedSprite;
        private Sprite _evolvedSprite;


        private void Start()
        {
            ServiceLocator.Instance.GetService<EventQueue>().Subscribe(EventIds.SwordEquiped, this);
            ServiceLocator.Instance.GetService<EventQueue>().Subscribe(EventIds.SwordEquippedLevelUp, this);
            var playerFactory = ServiceLocator.Instance.GetService<PlayerFactory>();
            _playerBuilder = playerFactory.Create(_playerConfiguration.PlayerId.Value)
                                          .WithLevel()
                                          .WithUpgradesStats()
                                          .WithConfiguration(_playerConfiguration);
        }


        private void OnDestroy()
        {
            ServiceLocator.Instance.GetService<EventQueue>().Unsubscribe(EventIds.SwordEquiped, this);
            ServiceLocator.Instance.GetService<EventQueue>().Unsubscribe(EventIds.SwordEquippedLevelUp, this);
        }


        public void SpawnUserShip()
        {
            _playerBuilder.WithTrailStats(_swordHp, _swordFire, _swordPoison,
                                          _swordIce, _swordWater, _swordElectric,
                                          _swordGhost, _swordRainbow, _swordSpeed, _swordTurnSpeed, _unevolvedFirstColliderOffset,
                                          _unevolvedFirstColliderSize, _unevolvedSecondColliderOffset, _unevolvedSecondColliderSize,
                                          _evolvedFirstColliderOffset, _evolvedFirstColliderSize, _evolvedSecondColliderOffset,
                                          _evolvedSecondColliderSize, _unevolvedSprite, _evolvedSprite)
                                          .WithLevel()
                                          .WithUpgradesStats();
            _playerBuilder.Build();
        }

        public void Process(EventData eventData)
        {

            if (eventData.EventId == EventIds.SwordEquiped)
            {
                var swordEquipedEventData = (SwordEquipedEventData)eventData;

                _swordHp = swordEquipedEventData._hp;
                _swordFire = swordEquipedEventData._fire;
                _swordPoison = swordEquipedEventData._poison;
                _swordIce = swordEquipedEventData._ice;
                _swordWater = swordEquipedEventData._water;
                _swordElectric = swordEquipedEventData._electric;
                _swordGhost = swordEquipedEventData._ghost;
                _swordRainbow = swordEquipedEventData._rainbow;
                _swordSpeed = swordEquipedEventData._speed;
                _swordTurnSpeed = swordEquipedEventData._turnSpeed;
                _unevolvedFirstColliderOffset = swordEquipedEventData._unevolvedFirstColliderOffset;
                _unevolvedFirstColliderSize = swordEquipedEventData._unevolvedFirstColliderSize;
                _unevolvedSecondColliderOffset = swordEquipedEventData._unevolvedSecondColliderOffset;
                _unevolvedSecondColliderSize = swordEquipedEventData._unevolvedSecondColliderSize;
                _evolvedFirstColliderOffset = swordEquipedEventData._evolvedFirstColliderOffset;
                _evolvedFirstColliderSize = swordEquipedEventData._evolvedFirstColliderSize;
                _evolvedSecondColliderOffset = swordEquipedEventData._evolvedSecondColliderOffset;
                _evolvedSecondColliderSize = swordEquipedEventData._evolvedSecondColliderSize;
                _unevolvedSprite = swordEquipedEventData._swordSpriteUnevolved;
                _evolvedSprite = swordEquipedEventData._swordSpriteEvolved;


                SpawnUserShip();
            }



            if (eventData.EventId == EventIds.SwordEquippedLevelUp)
            {
                var swordEquippedLevelUpEventData = (SwordEquippedLevelUpEventData)eventData;
                if (ServiceLocator.Instance.GetService<SwordEquippedSystem>().GetSwordEquipped() == swordEquippedLevelUpEventData.Id)
                {
                    _swordHp = swordEquippedLevelUpEventData.Hp;
                    _swordFire = swordEquippedLevelUpEventData.Fire;
                    _swordPoison = swordEquippedLevelUpEventData.Poison;
                    _swordIce = swordEquippedLevelUpEventData.Ice;
                    _swordWater = swordEquippedLevelUpEventData.Water;
                    _swordElectric = swordEquippedLevelUpEventData.Electric;
                    _swordGhost = swordEquippedLevelUpEventData.Ghost;
                    _swordRainbow = swordEquippedLevelUpEventData.Rainbow;
                    _swordSpeed = swordEquippedLevelUpEventData.Speed;
                    _swordTurnSpeed = swordEquippedLevelUpEventData.TurnSpeed;
                }

            }
        }
    }
}