using Assets.Code.Common.Level;
using Assets.Code.Core;
using UnityEngine;

namespace Assets.Code.Player.Swords
{
    public class Trail : MonoBehaviour
    {

        [SerializeField] private TrailToSpawnConfiguration _trailConfiguration;

        private int _trailUpgradeValue;
        private int _trailUnlockScoreCost;
        private int _trailUnlockGemsCost;
        private string _id;
        private int _level;
        private int _hp;
        private float _fire;
        private float _poison;
        private float _ice;
        private float _water;
        private float _electric;
        private float _ghost;
        private float _rainbow;
        private float _speed;
        private float _turnSpeed;
        private Color _deepBackground;
        private Color _background;
        private Color _iconBackground;
        private Color _nameColor;
        private Color _levelColor;
        private Sprite _swordSpriteUnevolved;
        private Sprite _swordSpriteEvolved;
        private Vector2 _unevolvedFirstColliderOffset;
        private Vector2 _unevolvedFirstColliderSize;
        private Vector2 _unevolvedSecondColliderOffset;
        private Vector2 _unevolvedSecondColliderSize;
        private Vector2 _evolvedFirstColliderOffset;
        private Vector2 _evolvedFirstColliderSize;
        private Vector2 _evolvedSecondColliderOffset;
        private Vector2 _evolvedSecondColliderSize;


        public int TrailUpgradeValue => _trailUpgradeValue;
        public int TrailUnlockScoreCost => _trailUnlockScoreCost;
        public int TrailUnlockGemsCost => _trailUnlockGemsCost;
        public string Id => _id;
        public int Level => _level;
        public int HP => _hp;
        public float Fire => _fire;
        public float Poison => _poison;
        public float Ice => _ice;
        public float Water => _water;
        public float Electric => _electric;
        public float Ghost => _ghost;
        public float Rainbow => _rainbow;
        public float Speed => _speed;
        public float TurnSpeed => _turnSpeed;
        public Color DeepBackground => _deepBackground;
        public Color Background => _background;
        public Color IconBackground => _iconBackground;
        public Color NameColor => _nameColor;
        public Color LevelColor => _levelColor;
        public Sprite SwordSpriteUnevolved => _swordSpriteUnevolved;
        public Sprite SwordSpriteEvolved => _swordSpriteEvolved;
        public Vector2 UnevolvedFirstColliderOffset => _unevolvedFirstColliderOffset;
        public Vector2 UnevolvedFirstColliderSize => _unevolvedFirstColliderSize;
        public Vector2 UnevolvedSecondColliderOffset => _unevolvedSecondColliderOffset;
        public Vector2 UnevolvedSecondColliderSize => _unevolvedSecondColliderSize;
        public Vector2 EvolvedFirstColliderOffset => _evolvedFirstColliderOffset;
        public Vector2 EvolvedFirstColliderSize => _evolvedFirstColliderSize;
        public Vector2 EvolvedSecondColliderOffset => _evolvedSecondColliderOffset;
        public Vector2 EvolvedSecondColliderSize => _evolvedSecondColliderSize;


        private void Start()
        {
            _trailUnlockScoreCost = _trailConfiguration.TrailUnlockScoreCost;
            _trailUnlockGemsCost = _trailConfiguration.TrailUnlockGemsCost;
            _id = _trailConfiguration.TrailId.Value;
            _deepBackground = _trailConfiguration.DeepBackground;
            _background = _trailConfiguration.Background;
            _iconBackground = _trailConfiguration.IconBackground;
            _nameColor = _trailConfiguration.NameColor;
            _levelColor = _trailConfiguration.LevelColor;
            _swordSpriteUnevolved = _trailConfiguration.UnevolvedSword.SwordImage;
            _swordSpriteEvolved = _trailConfiguration.EvolvedSword.SwordImage;
            _unevolvedFirstColliderOffset = _trailConfiguration.UnevolvedSword.FirstColliderOffset;
            _unevolvedFirstColliderSize = _trailConfiguration.UnevolvedSword.FirstColliderSize;
            _unevolvedSecondColliderOffset = _trailConfiguration.UnevolvedSword.SecondColliderOffset;
            _unevolvedSecondColliderSize = _trailConfiguration.UnevolvedSword.secondColliderSize;
            _evolvedFirstColliderOffset = _trailConfiguration.EvolvedSword.FirstColliderOffset;
            _evolvedFirstColliderSize = _trailConfiguration.EvolvedSword.FirstColliderSize;
            _evolvedSecondColliderOffset = _trailConfiguration.EvolvedSword.SecondColliderOffset;
            _evolvedSecondColliderSize = _trailConfiguration.EvolvedSword.secondColliderSize;
            _level = ServiceLocator.Instance.GetService<SwordsLevelSystem>().GetLevel(Id);
            SetStatsCalculation();
        }


        public void LevelUp(int level)
        {
            _level = level;
            SetStatsCalculation();
        }

        private void SetStatsCalculation()
        {
            _trailUpgradeValue = Mathf.FloorToInt((10 * _level) * (1 + (_trailConfiguration.TrailUpgradeBaseValue * (_level / 10f))));
            _hp = Mathf.FloorToInt(((_trailConfiguration.TrailBaseHp * (_level / 2f) * (_level / 4f)) / 100f) + 10);
            _fire = _trailConfiguration.TrailFire * _level;
            _poison = _trailConfiguration.TrailPoison * _level;
            _ice = _trailConfiguration.TrailIce * _level;
            _water = _trailConfiguration.TrailWater * _level;
            _electric = _trailConfiguration.TrailElectric * _level;
            _ghost = _trailConfiguration.TrailGhost * _level;
            _rainbow = _trailConfiguration.TrailRainbow * _level;
            _speed = _trailConfiguration.TrailSpeed + (_level / 250f);
            _turnSpeed = _trailConfiguration.TrailTurnSpeed + (_level / 10);
        }
    }
}