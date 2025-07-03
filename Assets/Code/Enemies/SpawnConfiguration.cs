using System;
using UnityEngine;

namespace Assets.Code.Enemies
{
    [Serializable]
    public class SpawnConfiguration
    {
        [SerializeField] private int _projectileNumberToSpawnConfigurations;
        [SerializeField] private float _timeToSpawn;
        [SerializeField] private bool _isRandom;
        [SerializeField] private bool _isTop;
        [SerializeField] private bool _isLeftAside;
        [SerializeField] private bool _isRightAside;

        public int ProjectileNumberToSpawnConfigurations => _projectileNumberToSpawnConfigurations;
        public float TimeToSpawn => _timeToSpawn;
        public bool IsRandom => _isRandom;
        public bool IsTop => _isTop;
        public bool IsLeftAside => _isLeftAside;
        public bool IsRightAside => _isRightAside;
    }
}
