using UnityEngine;

namespace Assets.Code.Enemies.CheckDestroyLimitss
{
    public class CheckBottomDestroyLimitsStrategy : CheckDestroyLimits
    {
        public bool IsInsideTheLimits(Vector3 position)
        {
            if (position.y < -10.5)
            {
                return false;
            }
            if (position.x > 6.7)
            {
                return false;
            }
            if (position.x < -7)
            {
                return false;
            }
            return true;
        }
    }
}