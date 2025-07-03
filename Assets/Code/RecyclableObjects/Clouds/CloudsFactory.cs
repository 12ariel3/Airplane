using Assets.Code.Common;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Code.RecyclableObjects.Clouds
{
    public class CloudsFactory : MonoBehaviour
    {

        private readonly CloudsConfiguration _configuration;
        private readonly Dictionary<string, ObjectPool> _pools;


        public CloudsFactory(CloudsConfiguration configuration, string currentMapName)
        {
            _configuration = configuration;
            var prefabs = _configuration.GetArrayById(currentMapName);
            _pools = new Dictionary<string, ObjectPool>(prefabs.Length);

            foreach (var particleMediator in prefabs)
            {
                var objectPool = new ObjectPool(particleMediator);
                objectPool.Init(2);
                _pools.Add(particleMediator.Id, objectPool);
            }
        }

        public CloudsBuilder Create(string id)
        {
            int randomInt = Random.Range(0, 2);

            var objectPool = _pools[id+randomInt];

            return new CloudsBuilder().FromObjectPool(objectPool);
        }
    }
}