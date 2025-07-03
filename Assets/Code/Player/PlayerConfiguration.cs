using UnityEngine;

namespace Assets.Code.Player
{
    public class PlayerConfiguration
    {
        public readonly PlayerId PlayerId;

        //Player base stats
        public readonly int Level;
        public readonly int BaseHp;
        public readonly float BaseFire;
        public readonly float BasePoison;
        public readonly float BaseIce;
        public readonly float BaseWater;
        public readonly float BaseElectric;
        public readonly float BaseGhost;
        public readonly float BaseRainbow;

        //Trail stats
        public readonly int TrailHp;
        public readonly float TrailFire;
        public readonly float TrailPoison;
        public readonly float TrailIce;
        public readonly float TrailWater;
        public readonly float TrailElectric;
        public readonly float TrailGhost;
        public readonly float TrailRainbow;
        public readonly float TrailSpeed;
        public readonly float TrailTurnSpeed;
        public readonly Vector2 UnevolvedFirstColliderOffset;
        public readonly Vector2 UnevolvedFirstColliderSize;
        public readonly Vector2 UnevolvedSecondColliderOffset;
        public readonly Vector2 UnevolvedSecondColliderSize;
        public readonly Vector2 EvolvedFirstColliderOffset;
        public readonly Vector2 EvolvedFirstColliderSize;
        public readonly Vector2 EvolvedSecondColliderOffset;
        public readonly Vector2 EvolvedSecondColliderSize;
        public readonly Sprite UnevolvedSprite;
        public readonly Sprite EvolvedSprite;

        //Upgrades stats
        public readonly float UpgradesHp;
        public readonly float UpgradesFire;
        public readonly float UpgradesPoison;
        public readonly float UpgradesIce;
        public readonly float UpgradesWater;
        public readonly float UpgradesElectric;
        public readonly float UpgradesGhost;
        public readonly float UpgradesRainbow;



        public PlayerConfiguration(int level, int baseHp,
                                   float baseFire, float basePoison, float baseIce,
                                   float baseWater, float baseElectric, float baseGhost,
                                   float baseRainbow, PlayerId playerId,


                                   int trailHp,
                                   float trailFire, float trailPoison, float trailIce,
                                   float trailWater, float trailElectric, float trailGhost,
                                   float trailRainbow, float trailSpeed, float trailTurnSpeed, Vector2 unevolvedFirstColliderOffset,
                                   Vector2 unevolvedFirstColliderSize, Vector2 unevolvedSecondColliderOffset,
                                   Vector2 unevolvedSecondColliderSize, Vector2 evolvedFirstColliderOffset,
                                   Vector2 evolvedFirstColliderSize, Vector2 evolvedSecondColliderOffset, Vector2 evolvedSecondColliderSize,
                                   Sprite unevolvedSprite, Sprite evolvedSprite,


                                   float upgradesHp,
                                   float upgradesFire, float upgradesPoison, float upgradesIce,
                                   float upgradesWater, float upgradesElectric, float upgradesGhost,
                                   float upgradesRainbow)
        {
            Level = level;
            BaseHp = baseHp;
            BaseFire = baseFire;
            BasePoison = basePoison;
            BaseIce = baseIce;
            BaseWater = baseWater;
            BaseElectric = baseElectric;
            BaseGhost = baseGhost;
            BaseRainbow = baseRainbow;
            PlayerId = playerId;


            TrailHp = trailHp;
            TrailFire = trailFire;
            TrailPoison = trailPoison;
            TrailIce = trailIce;
            TrailWater = trailWater;
            TrailGhost = trailGhost;
            TrailElectric = trailElectric;
            TrailRainbow = trailRainbow;
            TrailSpeed = trailSpeed;
            TrailTurnSpeed = trailTurnSpeed;
            UnevolvedFirstColliderOffset = unevolvedFirstColliderOffset;
            UnevolvedFirstColliderSize = unevolvedFirstColliderSize;
            UnevolvedSecondColliderOffset = unevolvedSecondColliderOffset;
            UnevolvedSecondColliderSize = unevolvedSecondColliderSize;
            EvolvedFirstColliderOffset = evolvedFirstColliderOffset;
            EvolvedFirstColliderSize = evolvedFirstColliderSize;
            EvolvedSecondColliderOffset = evolvedSecondColliderOffset;
            EvolvedSecondColliderSize = evolvedSecondColliderSize;
            UnevolvedSprite = unevolvedSprite;
            EvolvedSprite = evolvedSprite;


            UpgradesHp = upgradesHp;
            UpgradesFire = upgradesFire;
            UpgradesPoison = upgradesPoison;
            UpgradesIce = upgradesIce;
            UpgradesWater = upgradesWater;
            UpgradesGhost = upgradesGhost;
            UpgradesElectric = upgradesElectric;
            UpgradesRainbow = upgradesRainbow;
        }
    }
}