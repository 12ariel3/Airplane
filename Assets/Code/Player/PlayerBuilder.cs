using Assets.Code.Common.Level;
using Assets.Code.Common.UpgradesData;
using Assets.Code.Core;
using UnityEngine;

namespace Assets.Code.Player
{
    public class PlayerBuilder
    {
        private PlayerToSpawnConfiguration _playerConfiguration;
        private PlayerMediator _prefab;
        private int _level;
        private Vector3 _position = Vector3.zero;
        private Quaternion _rotation = Quaternion.identity;
        private PlayerMediator _prefabInstantiated;

        // trail stats

        private string _trailId;
        private int _trailHp;
        private float _trailFire;
        private float _trailPoison;
        private float _trailIce;
        private float _trailWater;
        private float _trailElectric;
        private float _trailGhost;
        private float _trailRainbow;
        private float _trailSpeed;
        private float _trailTurnSpeed;
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


        // upgrades stats

        private float _upgradesHp;
        private float _upgradesFire;
        private float _upgradesPoison;
        private float _upgradesIce;
        private float _upgradesWater;
        private float _upgradesElectric;
        private float _upgradesGhost;
        private float _upgradesRainbow;

        public PlayerBuilder WithTrailStats(int trailHp,float trailFire, float trailPoison, float trailIce,
                                            float trailWater, float trailElectric, float trailGhost, float trailRainbow,
                                            float trailSpeed, float trailTurnSpeed, Vector2 unevolvedFirstColliderOffset,
                                            Vector2 unevolvedFirstColliderSize, Vector2 unevolvedSecondColliderOffset,
                                            Vector2 unevolvedSecondColliderSize, Vector2 evolvedFirstColliderOffset,
                                            Vector2 evolvedFirstColliderSize, Vector2 evolvedSecondColliderOffset,
                                            Vector2 evolvedSecondColliderSize, Sprite unevolvedSprite, Sprite evolvedSprite)
        {
            _trailHp = trailHp;
            _trailFire = trailFire;
            _trailPoison = trailPoison;
            _trailIce = trailIce;
            _trailWater = trailWater;
            _trailElectric = trailElectric;
            _trailGhost = trailGhost;
            _trailRainbow = trailRainbow;
            _trailSpeed = trailSpeed;
            _trailTurnSpeed = trailTurnSpeed;
            _unevolvedFirstColliderOffset = unevolvedFirstColliderOffset;
            _unevolvedFirstColliderSize = unevolvedFirstColliderSize;
            _unevolvedSecondColliderOffset = unevolvedSecondColliderOffset;
            _unevolvedSecondColliderSize = unevolvedSecondColliderSize;
            _evolvedFirstColliderOffset = evolvedFirstColliderOffset;
            _evolvedFirstColliderSize = evolvedFirstColliderSize;
            _evolvedSecondColliderOffset = evolvedSecondColliderOffset;
            _evolvedSecondColliderSize = evolvedSecondColliderSize;
            _unevolvedSprite = unevolvedSprite;
            _evolvedSprite = evolvedSprite;
            return this;
        }

        public PlayerBuilder WithUpgradesStats()
        {
            var upgradeSystem = ServiceLocator.Instance.GetService<UpgradesSystem>();
            _upgradesHp = upgradeSystem.GetUpgradeHp();
            _upgradesFire = upgradeSystem.GetUpgradeFire();
            _upgradesPoison = upgradeSystem.GetUpgradePoison();
            _upgradesIce = upgradeSystem.GetUpgradeIce();
            _upgradesWater = upgradeSystem.GetUpgradeWater();
            _upgradesElectric = upgradeSystem.GetUpgradeElectric();
            _upgradesGhost = upgradeSystem.GetUpgradeGhost();
            _upgradesRainbow = upgradeSystem.GetUpgradeRainbow();
            return this;
        }

        public PlayerBuilder WithConfiguration(PlayerToSpawnConfiguration playerConfiguration)
        {
            _playerConfiguration = playerConfiguration;
            return this;
        }


        public PlayerBuilder FromPrefab(PlayerMediator prefab)
        {
            _prefab = prefab;
            return this;
        }

        public PlayerBuilder WithLevel()
        {
            _level = ServiceLocator.Instance.GetService<LevelSystem>().GetCurrentLevel();
            return this;
        }

        public PlayerMediator Build()
        {
            var playerConfiguration = new PlayerConfiguration(_level,
                                                              _playerConfiguration.BaseHp,
                                                              _playerConfiguration.BaseFire,
                                                              _playerConfiguration.BasePoison,
                                                              _playerConfiguration.BaseIce,
                                                              _playerConfiguration.BaseWater,
                                                              _playerConfiguration.BaseElectric,
                                                              _playerConfiguration.BaseGhost,
                                                              _playerConfiguration.BaseRainbow,
                                                              _playerConfiguration.PlayerId,

                                                              _trailHp, _trailFire,
                                                              _trailPoison, _trailIce,
                                                              _trailWater, _trailElectric,
                                                              _trailGhost, _trailRainbow,
                                                              _trailSpeed, _trailTurnSpeed,
                                                              _unevolvedFirstColliderOffset, _unevolvedFirstColliderSize,
                                                              _unevolvedSecondColliderOffset, _unevolvedSecondColliderSize,
                                                              _evolvedFirstColliderOffset, _evolvedFirstColliderSize,
                                                              _evolvedSecondColliderOffset, _evolvedSecondColliderSize,
                                                              _unevolvedSprite, _evolvedSprite,

                                                              _upgradesHp, _upgradesFire,
                                                              _upgradesPoison, _upgradesIce,
                                                              _upgradesWater, _upgradesElectric,
                                                              _upgradesGhost, _upgradesRainbow);
            if (_prefabInstantiated == null)
            {
                var player = Object.Instantiate(_prefab, _position, _rotation);
                _prefabInstantiated = player;
                _prefabInstantiated.Configure(playerConfiguration);
                return _prefabInstantiated;
            }
            else
            {
                _prefabInstantiated.Configure(playerConfiguration);
                return _prefabInstantiated;
            }
        }
    }
}