using Assets.Code.Common;
using UnityEngine;

namespace Assets.Code.RecyclableObjects.Clouds
{
    public class CloudsBuilder
    {
        private ObjectPool _objectPool;
        private Vector3 _position = Vector3.zero;
        private Quaternion _rotation = Quaternion.identity;
        private float _scale = 1f;
        private float _alphaColor = 1f;
        private int _sortingOrder = 0;

        public CloudsBuilder FromObjectPool(ObjectPool objectPool)
        {
            _objectPool = objectPool;
            return this;
        }


        public CloudsBuilder WithPosition(Vector3 position)
        {
            _position = position;
            return this;
        }

        public CloudsBuilder WithRotation(Quaternion rotation)
        {
            _rotation = rotation;
            return this;
        }

        public CloudsBuilder WithScale(float scale)
        {
            _scale = scale;
            return this;
        }

        public CloudsBuilder WithAlplhaColor(float alphaColor)
        {
            _alphaColor = alphaColor;
            return this;
        }
        
        public CloudsBuilder WithSortingOrder(int sortingOrder)
        {
            _sortingOrder = sortingOrder;
            return this;
        }


        public CloudsMediator Build()
        {
            var Cloud = _objectPool.Spawn<CloudsMediator>(_position, _rotation);
            Cloud.Configure(_scale, _alphaColor, _sortingOrder);
            return Cloud;
        }
    }
}