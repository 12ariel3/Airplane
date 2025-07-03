using System.Collections.Generic;
using UnityEngine;

namespace Assets.Code.RecyclableObjects.Clouds
{
    [CreateAssetMenu(menuName = "Clouds/CloudsConfiguration", fileName = "CloudsConfiguration")]
    public class CloudsConfiguration : ScriptableObject
    {
        [SerializeField] private CloudsMediator[] _moonWalkerCloudsPrefabs;
        [SerializeField] private CloudsMediator[] _atlansAbyssCloudsPrefabs;
        [SerializeField] private CloudsMediator[] _villaSoldatiCloudsPrefabs;
        [SerializeField] private CloudsMediator[] _raklionCloudsPrefabs;
        [SerializeField] private CloudsMediator[] _acheronCloudsPrefabs;
        private Dictionary<string, CloudsMediator> _idToCloudPrefab;



        public CloudsMediator[] GetArrayById(string id)
        {
            switch (id)
            {
                case "Moon Walker":

                    return _moonWalkerCloudsPrefabs;

                case "Atlans Abyss":

                    
                    return _atlansAbyssCloudsPrefabs;

                case "Villa Soldati":

                    
                    return _villaSoldatiCloudsPrefabs;

                case "Raklion":

                    return _raklionCloudsPrefabs;

                case "Acheron":

                    return _acheronCloudsPrefabs;
            }

            return _moonWalkerCloudsPrefabs;
        }
    }
}