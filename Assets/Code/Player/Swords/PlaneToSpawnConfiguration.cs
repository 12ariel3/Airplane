using UnityEngine;

namespace Assets.Code.Player.Swords
{
    [CreateAssetMenu(menuName = "Trail/PlaneToSpawnConfiguration", fileName = "PlaneToSpawnConfiguration")]
    public class PlaneToSpawnConfiguration : ScriptableObject
    {
        [SerializeField] private Sprite _swordImage;
        [SerializeField] private Vector2 _firstColliderOffset;
        [SerializeField] private Vector2 _firstColliderSize;
        [SerializeField] private Vector2 _secondColliderOffset;
        [SerializeField] private Vector2 _secondColliderSize;


        public Sprite SwordImage => _swordImage;
        public Vector2 FirstColliderOffset => _firstColliderOffset;
        public Vector2 FirstColliderSize => _firstColliderSize;
        public Vector2 SecondColliderOffset => _secondColliderOffset;
        public Vector2 secondColliderSize => _secondColliderSize;

    }
}