using UnityEngine;

namespace Assets.Code.Common.Events
{
    public class ProjectileDestroyedEventData : EventData
    {
        public readonly int ScoreToAdd;
        public readonly int GemsToAdd;
        public readonly int GemsProbability;
        public readonly int ExperienceToAdd;
        public readonly int AttackToRest;
        public readonly string ProjectileId;
        public readonly Vector3 ProjectilePosition;
        public readonly Quaternion ProjectileRotation;
        public readonly int InstanceId;

        public ProjectileDestroyedEventData(int scoreToAdd, int gemsToAdd, int gemsProbability, int experienceToAdd, int attackToRest,
                                            string projectileId, Vector3 position, Quaternion rotation, int instanceId)
                                            : base(EventIds.ProjectileDestroyed)
        {
            ScoreToAdd = scoreToAdd;
            GemsToAdd = gemsToAdd;
            GemsProbability = gemsProbability;
            ExperienceToAdd = experienceToAdd;
            AttackToRest = attackToRest;
            ProjectileId = projectileId;
            ProjectilePosition = position;
            ProjectileRotation = rotation;
            InstanceId = instanceId;
        }
    }
}