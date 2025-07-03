using UnityEngine;

namespace Assets.Code.Enemies
{
    [CreateAssetMenu(fileName = "LevelConfiguration", menuName = "Level/Level Configuration")]
    public class LevelConfiguration : ScriptableObject
    {
        [SerializeField] private SpawnConfiguration[] _spawnConfigurations;
        [SerializeField] private int _projectileLevel;
        [SerializeField] private int _energyToRest;
        [SerializeField] private int _levelNumber;
        [SerializeField] private int _totalLevelNumber;
        [SerializeField] private ProjectileToSpawnConfiguration[] _projectileToSpawnConfiguration;
        [SerializeField] private int _debuffProbability;
        [SerializeField] private float _specialProjectileCastPercentaje;
        [SerializeField] private ProjectileToSpawnConfiguration[] _specialProjectileToSpawnConfiguration;


        public SpawnConfiguration[] SpawnConfigurations => _spawnConfigurations;
        public int ProjectileLevel => _projectileLevel;
        public int EnergyToRest => _energyToRest;
        public int LevelNumber => _levelNumber;
        public int TotalLevelNumber => _totalLevelNumber;
        public int DebuffProbability => _debuffProbability;
        public float SpecialProjectileCastPercentaje => _specialProjectileCastPercentaje;
        public ProjectileToSpawnConfiguration GetRandomProgectileToSpawnConfiguration()
        {
            int projectile = Random.Range(0, _projectileToSpawnConfiguration.Length);
            return _projectileToSpawnConfiguration[projectile];
        }

        public ProjectileToSpawnConfiguration GetRandomSpecialProgectileToSpawnConfiguration()
        {
            int projectile = Random.Range(0, _specialProjectileToSpawnConfiguration.Length);
            return _specialProjectileToSpawnConfiguration[projectile];
        }
    }
}