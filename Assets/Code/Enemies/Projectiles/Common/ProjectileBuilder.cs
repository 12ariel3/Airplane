using Assets.Code.Common;
using Assets.Code.Enemies.CheckDestroyLimitss;
using UnityEngine;

namespace Assets.Code.Enemies.Projectiles.Common
{
    public class ProjectileBuilder
    {
        private ObjectPool _objectPool;
        private Vector3 _position = Vector3.zero;
        private Quaternion _rotation;
        private Transform _directionPosition;
        private ProjectileToSpawnConfiguration _projectileConfiguration;
        private CheckDestroyLimits _checkDestroyLimits;
        private int _projectileLevel;
        private bool _isTop;
        private bool _isLeft;
        private bool _isRight;


        public ProjectileBuilder WithCheckBottomDestroyLimits()
        {
            _checkDestroyLimits = new CheckBottomDestroyLimitsStrategy();
            return this;
        }


        public ProjectileBuilder WithPosition(Vector3 position)
        {
            _position = position;
            return this;
        }

        public ProjectileBuilder WithSpawnPosition(bool isTop, bool isLeft, bool isRight)
        {
            _isTop = isTop;
            _isLeft = isLeft;
            _isRight = isRight;
            return this;
        }

        public ProjectileBuilder WithRotation(Quaternion rotation)
        {
            _rotation = rotation;
            return this;
        }

        public ProjectileBuilder WithDirectionPositions(Transform directionPosition)
        {
            _directionPosition = directionPosition;
            return this;
        }

        public ProjectileBuilder WithProjectileLevel(int projectileLevel)
        {
            _projectileLevel = projectileLevel;
            return this;
        }

        public ProjectileBuilder WithConfiguration(ProjectileToSpawnConfiguration shipConfiguration)
        {
            _projectileConfiguration = shipConfiguration;
            return this;
        }



        public ProjectileBuilder FromObjectPool(ObjectPool objectPool)
        {
            _objectPool = objectPool;
            return this;
        }




        public ProjectileMediator Build()
        {
            var ship = _objectPool.Spawn<ProjectileMediator>(_position, _rotation);
            var shipConfiguration = new ProjectileConfiguration(
                                                          _projectileConfiguration.Name,
                                                          _projectileConfiguration.ExplosionName,
                                                          _projectileConfiguration.Score,
                                                          _projectileConfiguration.Gems,
                                                          _projectileConfiguration.GemsProbability,
                                                          _projectileConfiguration.Experience,
                                                          _projectileLevel,
                                                          _projectileConfiguration.MaxHp,
                                                          _projectileConfiguration.Attack,
                                                          _projectileConfiguration.ProjectileId,
                                                          _directionPosition,
                                                          _checkDestroyLimits,
                                                          _projectileConfiguration.Speed,
                                                          _projectileConfiguration.TurnSpeed,
                                                          _projectileConfiguration.IsSpecial,
                                                          _isTop,
                                                          _isLeft,
                                                          _isRight);
            ship.Configure(shipConfiguration);
            return ship;
        }
    }
}