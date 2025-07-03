using UnityEngine;

namespace Assets.Code.Common.Events
{
    public class SwordEquipedEventData : EventData
    {
        public readonly Sprite _swordSpriteUnevolved;
        public readonly Sprite _swordSpriteEvolved;
        public readonly int _swordUpgradeValue;
        public readonly string _id;
        public readonly int _level;
        public readonly int _hp;
        public readonly float _fire;
        public readonly float _poison;
        public readonly float _ice;
        public readonly float _water;
        public readonly float _electric;
        public readonly float _ghost;
        public readonly float _rainbow;
        public readonly float _speed;
        public readonly float _turnSpeed;
        public readonly Color _deepBackground;
        public readonly Color _background;
        public readonly Color _iconBackground;
        public readonly Color _nameColor;
        public readonly Color _levelColor;
        public readonly Vector2 _unevolvedFirstColliderOffset;
        public readonly Vector2 _unevolvedFirstColliderSize;
        public readonly Vector2 _unevolvedSecondColliderOffset;
        public readonly Vector2 _unevolvedSecondColliderSize;
        public readonly Vector2 _evolvedFirstColliderOffset;
        public readonly Vector2 _evolvedFirstColliderSize;
        public readonly Vector2 _evolvedSecondColliderOffset;
        public readonly Vector2 _evolvedSecondColliderSize;
        public readonly int InstanceId;


        public SwordEquipedEventData(Sprite swordSpriteUnevolved, Sprite swordSpriteEvolved, int swordUpgradeValue, string swordName,
                                     int swordLevel, int swordHp, float swordFire, float swordPoison, float swordIce, float swordWater,
                                     float swordElectric, float swordGhost, float swordRainbow, float swordSpeed, float swordTurnSpeed,
                                     Color deepBackground, Color background, Color iconBackground, Color nameColor,
                                     Color levelColor, Vector2 unevolvedFirstColliderOffset, Vector2 unevolvedFirstColliderSize,
                                     Vector2 unevolvedSecondColliderOffset, Vector2 unevolvedSecondColliderSize,
                                     Vector2 evolvedFirstColliderOffset, Vector2 evolvedFirstColliderSize,
                                     Vector2 evolvedSecondColliderOffset, Vector2 evolvedSecondColliderSize,
                                     int instanceId) : base(EventIds.SwordEquiped)
        {
            _swordSpriteUnevolved = swordSpriteUnevolved;
            _swordSpriteEvolved = swordSpriteEvolved;
            _swordUpgradeValue = swordUpgradeValue;
            _id = swordName;
            _level = swordLevel;
            _hp = swordHp;
            _fire = swordFire;
            _poison = swordPoison;
            _ice = swordIce;
            _water = swordWater;
            _electric = swordElectric;
            _ghost = swordGhost;
            _rainbow = swordRainbow;
            _speed = swordSpeed;
            _turnSpeed = swordTurnSpeed;
            _deepBackground = deepBackground;
            _background = background;
            _iconBackground = iconBackground;
            _nameColor = nameColor;
            _levelColor = levelColor;
            _unevolvedFirstColliderOffset = unevolvedFirstColliderOffset;
            _unevolvedFirstColliderSize = unevolvedFirstColliderSize;
            _unevolvedSecondColliderOffset = unevolvedSecondColliderOffset;
            _unevolvedSecondColliderSize = unevolvedSecondColliderSize;
            _evolvedFirstColliderOffset = evolvedFirstColliderOffset;
            _evolvedFirstColliderSize = evolvedFirstColliderSize;
            _evolvedSecondColliderOffset = evolvedSecondColliderOffset;
            _evolvedSecondColliderSize = evolvedSecondColliderSize;
            InstanceId = instanceId;
        }
    }
}