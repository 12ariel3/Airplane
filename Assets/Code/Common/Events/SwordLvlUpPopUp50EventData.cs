using UnityEngine;

namespace Assets.Code.Common.Events
{
    public class SwordLvlUpPopUp50EventData : EventData
    {
        public readonly Vector3 Position;
        public readonly int InstanceId;

        public SwordLvlUpPopUp50EventData(Vector3 position, int instanceId) : base(EventIds.SwordLevelUp50)
        {
            Position = position;
            InstanceId = instanceId;
        }
    }
}