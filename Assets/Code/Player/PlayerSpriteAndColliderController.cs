using UnityEngine;

namespace Assets.Code.Player
{
    public class PlayerSpriteAndColliderController : MonoBehaviour
    {
        [SerializeField] SpriteRenderer _spriteRenderer;
        [SerializeField] BoxCollider2D _firstCollider;
        [SerializeField] BoxCollider2D _secondCollider;


        private Sprite _unevolvedSwordSpriteValue;
        private Sprite _evolvedSwordSpriteValue;
        private Vector2 _unevolvedFirstColliderOffset;
        private Vector2 _unevolvedFirstColliderSize;
        private Vector2 _unevolvedSecondColliderOffset;
        private Vector2 _unevolvedSecondColliderSize;
        private Vector2 _evolvedFirstColliderOffset;
        private Vector2 _evolvedFirstColliderSize;
        private Vector2 _evolvedSecondColliderOffset;
        private Vector2 _evolvedSecondColliderSize;
        private float _swordLevel;

        public void Configuration(Sprite unevolvedSwordSpriteValue, Sprite evolvedSwordSpriteValue, Vector2 unevolvedFirstColliderOffset,
                                  Vector2 unevolvedFirstColliderSize, Vector2 unevolvedSecondColliderOffset, Vector2 unevolvedSecondColliderSize,
                                  Vector2 evolvedFirstColliderOffset, Vector2 evolvedFirstColliderSize, Vector2 evolvedSecondColliderOffset,
                                  Vector2 evolvedSecondColliderSize, int swordLevel)
        {
            _unevolvedSwordSpriteValue = unevolvedSwordSpriteValue;
            _evolvedSwordSpriteValue = evolvedSwordSpriteValue;
            _unevolvedFirstColliderOffset = unevolvedFirstColliderOffset;
            _unevolvedFirstColliderSize = unevolvedFirstColliderSize;
            _unevolvedSecondColliderOffset = unevolvedSecondColliderOffset;
            _unevolvedSecondColliderSize = unevolvedSecondColliderSize;
            _evolvedFirstColliderOffset = evolvedFirstColliderOffset;
            _evolvedFirstColliderSize = evolvedFirstColliderSize;
            _evolvedSecondColliderOffset = evolvedSecondColliderOffset;
            _evolvedSecondColliderSize = evolvedSecondColliderSize;
            _swordLevel = swordLevel;
            SetComponents();
        }


        private void SetComponents()
        {
            if (_swordLevel >= 50) 
            {
                _spriteRenderer.sprite = _evolvedSwordSpriteValue;
                _firstCollider.offset = _evolvedFirstColliderOffset;
                _firstCollider.size = _evolvedFirstColliderSize;
                _secondCollider.offset = _evolvedSecondColliderOffset;
                _secondCollider.size = _evolvedSecondColliderSize;
            }
            else
            {
                _spriteRenderer.sprite = _unevolvedSwordSpriteValue;
                _firstCollider.offset = _unevolvedFirstColliderOffset;
                _firstCollider.size = _unevolvedFirstColliderSize;
                _secondCollider.offset = _unevolvedSecondColliderOffset;
                _secondCollider.size = _unevolvedSecondColliderSize;
            }
        }
    }
}