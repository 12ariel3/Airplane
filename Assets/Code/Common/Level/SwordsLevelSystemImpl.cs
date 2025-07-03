using Assets.Code.Common.Events;
using Assets.Code.Core.DataStorage;
using Assets.Code.Core;

namespace Assets.Code.Common.Level
{
    public class SwordsLevelSystemImpl : EventObserver, SwordsLevelSystem
    {
        private readonly DataStore _dataStore;
        private const string _basicAirplaneLevelData = "BasicAirplaneLevelData";
        private const string _wildAirplaneLevelData = "WildAirplaneLevelData";
        private const string _matchAirplaneLevelData = "MatchAirplaneLevelData";
        private const string _gaiaAirplaneLevelData = "GaiaAirplaneLevelData";
        private const string _dizzyAirplaneLevelData = "DizzyAirplaneLevelData";
        private const string _stunnerAirplaneLevelData = "StunnerAirplaneLevelData";
        private const string _cerberusAirplaneLevelData = "CerberusAirplaneLevelData";
        private const string _meteorAirplaneLevelData = "MeteorAirplaneLevelData";
        private const string _lagoonAirplaneLevelData = "LagoonAirplaneLevelData";
        private const string _thunderboltAirplaneLevelData = "ThunderboltAirplaneLevelData";
        private const string _blazeAirplaneLevelData = "BlazeAirplaneLevelData";

        private const string _basicAirplaneIsUnlockedData = "BasicAirplaneIsUnlockedData";
        private const string _wildAirplaneIsUnlockedData = "WildAirplaneIsUnlockedData";
        private const string _matchAirplaneIsUnlockedData = "MatchAirplaneIsUnlockedData";
        private const string _gaiaAirplaneIsUnlockedData = "GaiaAirplaneIsUnlockedData";
        private const string _dizzyAirplaneIsUnlockedData = "DizzyAirplaneIsUnlockedData";
        private const string _stunnerAirplaneIsUnlockedData = "StunnerAirplaneIsUnlockedData";
        private const string _cerberusAirplaneIsUnlockedData = "CerberusAirplaneIsUnlockedData";
        private const string _meteorAirplaneIsUnlockedData = "MeteorAirplaneIsUnlockedData";
        private const string _lagoonAirplaneIsUnlockedData = "LagoonAirplaneIsUnlockedData";
        private const string _thunderboltAirplaneIsUnlockedData = "ThunderboltAirplaneIsUnlockedData";
        private const string _blazeAirplaneIsUnlockedData = "BlazeAirplaneIsUnlockedData";



        public SwordsLevelSystemImpl(DataStore dataStore)
        {
            _dataStore = dataStore;
            var eventQueue = ServiceLocator.Instance.GetService<EventQueue>();
            eventQueue.Subscribe(EventIds.SwordLevelUp, this);
        }


        public int GetLevel(string swordId)
        {
            switch (swordId)
            {
                case "Basic":
                    return GetBasicCurrentLevel();

                case "Wild":
                    return GetWildCurrentLevel();

                case "Match":
                    return GetMatchCurrentLevel();

                case "Gaia":
                    return GetGaiaCurrentLevel();

                case "Dizzy":
                    return GetDizzyCurrentLevel();

                case "Stunner":
                    return GetStunnerCurrentLevel();

                case "Cerberus":
                    return GetCerberusCurrentLevel();

                case "Meteor":
                    return GetMeteorCurrentLevel();

                case "Lagoon":
                    return GetLagoonCurrentLevel();

                case "Thunderbolt":
                    return GetThunderboltCurrentLevel();

                case "Blaze":
                    return GetBlazeCurrentLevel();

                default: return 1;
            }
        }
        public int GetBasicCurrentLevel()
        {
            var userData = _dataStore.GetData<UserData>(_basicAirplaneLevelData)
                        ?? new UserData();
            return userData.BasicSword;
        }
        public int GetWildCurrentLevel()
        {
            var userData = _dataStore.GetData<UserData>(_wildAirplaneLevelData)
                        ?? new UserData();
            return userData.WildSword;
        }
        public int GetMatchCurrentLevel()
        {
            var userData = _dataStore.GetData<UserData>(_matchAirplaneLevelData)
                        ?? new UserData();
            return userData.MatchSword;
        }
        public int GetGaiaCurrentLevel()
        {
            var userData = _dataStore.GetData<UserData>(_gaiaAirplaneLevelData)
                        ?? new UserData();
            return userData.GaiaSword;
        }
        public int GetDizzyCurrentLevel()
        {
            var userData = _dataStore.GetData<UserData>(_dizzyAirplaneLevelData)
                        ?? new UserData();
            return userData.DizzySword;
        }
        public int GetStunnerCurrentLevel()
        {
            var userData = _dataStore.GetData<UserData>(_stunnerAirplaneLevelData)
                        ?? new UserData();
            return userData.StunnerSword;
        }
        public int GetCerberusCurrentLevel()
        {
            var userData = _dataStore.GetData<UserData>(_cerberusAirplaneLevelData)
                        ?? new UserData();
            return userData.CerberusSword;
        }
        public int GetMeteorCurrentLevel()
        {
            var userData = _dataStore.GetData<UserData>(_meteorAirplaneLevelData)
                        ?? new UserData();
            return userData.MeteorSword;
        }
        public int GetLagoonCurrentLevel()
        {
            var userData = _dataStore.GetData<UserData>(_lagoonAirplaneLevelData)
                        ?? new UserData();
            return userData.LagoonSword;
        }
        public int GetThunderboltCurrentLevel()
        {
            var userData = _dataStore.GetData<UserData>(_thunderboltAirplaneLevelData)
                        ?? new UserData();
            return userData.ThunderboltSword;
        }
        public int GetBlazeCurrentLevel()
        {
            var userData = _dataStore.GetData<UserData>(_blazeAirplaneLevelData)
                        ?? new UserData();
            return userData.BlazeSword;
        }
        


        public void SaveLevel(string swordId, int swordLevel)
        {
            switch (swordId)
            {
                case "Basic":
                    SaveBasicCurrentLevel(swordLevel); break;

                case "Wild":
                    SaveWildCurrentLevel(swordLevel); break;

                case "Match":
                    SaveMatchCurrentLevel(swordLevel); break;

                case "Gaia":
                    SaveGaiaCurrentLevel(swordLevel); break;

                case "Dizzy":
                    SaveDizzyCurrentLevel(swordLevel); break;

                case "Stunner":
                    SaveStunnerCurrentLevel(swordLevel); break;

                case "Cerberus":
                    SaveCerberusCurrentLevel(swordLevel); break;

                case "Meteor":
                    SaveMeteorCurrentLevel(swordLevel); break;

                case "Lagoon":
                    SaveLagoonCurrentLevel(swordLevel); break;

                case "Thunderbolt":
                    SaveThunderboltCurrentLevel(swordLevel); break;

                case "Blaze":
                    SaveBlazeCurrentLevel(swordLevel); break;

                default:
                    break;
            }
        }


        public void SaveBasicCurrentLevel(int level)
        {
            var userData = new UserData { BasicSword = level };
            _dataStore.SetData(userData, _basicAirplaneLevelData);
        }

        public void SaveWildCurrentLevel(int level)
        {
            var userData = new UserData { WildSword = level };
            _dataStore.SetData(userData, _wildAirplaneLevelData);
        }

        public void SaveMatchCurrentLevel(int level)
        {
            var userData = new UserData { MatchSword = level };
            _dataStore.SetData(userData, _matchAirplaneLevelData);
        }

        public void SaveGaiaCurrentLevel(int level)
        {
            var userData = new UserData { GaiaSword = level };
            _dataStore.SetData(userData, _gaiaAirplaneLevelData);
        }

        public void SaveDizzyCurrentLevel(int level)
        {
            var userData = new UserData { DizzySword = level };
            _dataStore.SetData(userData, _dizzyAirplaneLevelData);
        }

        public void SaveStunnerCurrentLevel(int level)
        {
            var userData = new UserData { StunnerSword = level };
            _dataStore.SetData(userData, _stunnerAirplaneLevelData);
        }

        public void SaveCerberusCurrentLevel(int level)
        {
            var userData = new UserData { CerberusSword = level };
            _dataStore.SetData(userData, _cerberusAirplaneLevelData);
        }

        public void SaveMeteorCurrentLevel(int level)
        {
            var userData = new UserData { MeteorSword = level };
            _dataStore.SetData(userData, _meteorAirplaneLevelData);
        }
        
        public void SaveLagoonCurrentLevel(int level)
        {
            var userData = new UserData { LagoonSword = level };
            _dataStore.SetData(userData, _lagoonAirplaneLevelData);
        }

        public void SaveThunderboltCurrentLevel(int level)
        {
            var userData = new UserData { ThunderboltSword = level };
            _dataStore.SetData(userData, _thunderboltAirplaneLevelData);
        }

        public void SaveBlazeCurrentLevel(int level)
        {
            var userData = new UserData { BlazeSword = level };
            _dataStore.SetData(userData, _blazeAirplaneLevelData);
        }




        public bool GetIfIsSwordUnlocked(string swordId)
        {
            switch (swordId)
            {
                case "Basic":
                    return GetBasicIfIsUnlocked();

                case "Wild":
                    return GetWildIfIsUnlocked();

                case "Match":
                    return GetMatchIfIsUnlocked();

                case "Gaia":
                    return GetGaiaIfIsUnlocked();

                case "Dizzy":
                    return GetDizzyIfIsUnlocked();

                case "Stunner":
                    return GetStunnerIfIsUnlocked();

                case "Cerberus":
                    return GetCerberusIfIsUnlocked();

                case "Meteor":
                    return GetMeteorIfIsUnlocked();

                case "Lagoon":
                    return GetLagoonIfIsUnlocked();

                case "Thunderbolt":
                    return GetThunderboltIfIsUnlocked();

                case "Blaze":
                    return GetBlazeIfIsUnlocked();

                default: return false;
            }
        }


        public bool GetBasicIfIsUnlocked()
        {
            var userData = _dataStore.GetData<UserData>(_basicAirplaneIsUnlockedData)
                        ?? new UserData();
            return userData.BasicSwordIsUnlocked;
        }
        public bool GetWildIfIsUnlocked()
        {
            var userData = _dataStore.GetData<UserData>(_wildAirplaneIsUnlockedData)
                        ?? new UserData();
            return userData.WildSwordIsUnlocked;
        }
        public bool GetMatchIfIsUnlocked()
        {
            var userData = _dataStore.GetData<UserData>(_matchAirplaneIsUnlockedData)
                        ?? new UserData();
            return userData.MatchSwordIsUnlocked;
        }
        public bool GetGaiaIfIsUnlocked()
        {
            var userData = _dataStore.GetData<UserData>(_gaiaAirplaneIsUnlockedData)
                        ?? new UserData();
            return userData.GaiaSwordIsUnlocked;
        }
        public bool GetDizzyIfIsUnlocked()
        {
            var userData = _dataStore.GetData<UserData>(_dizzyAirplaneIsUnlockedData)
                        ?? new UserData();
            return userData.DizzySwordIsUnlocked;
        }
        public bool GetStunnerIfIsUnlocked()
        {
            var userData = _dataStore.GetData<UserData>(_stunnerAirplaneIsUnlockedData)
                        ?? new UserData();
            return userData.StunnerSwordIsUnlocked;
        }
        public bool GetCerberusIfIsUnlocked()
        {
            var userData = _dataStore.GetData<UserData>(_cerberusAirplaneIsUnlockedData)
                        ?? new UserData();
            return userData.CerberusSwordIsUnlocked;
        }
        public bool GetMeteorIfIsUnlocked()
        {
            var userData = _dataStore.GetData<UserData>(_meteorAirplaneIsUnlockedData)
                        ?? new UserData();
            return userData.MeteorSwordIsUnlocked;
        }
        public bool GetLagoonIfIsUnlocked()
        {
            var userData = _dataStore.GetData<UserData>(_lagoonAirplaneIsUnlockedData)
                        ?? new UserData();
            return userData.LagoonSwordIsUnlocked;
        }
        public bool GetThunderboltIfIsUnlocked()
        {
            var userData = _dataStore.GetData<UserData>(_thunderboltAirplaneIsUnlockedData)
                        ?? new UserData();
            return userData.ThunderboltSwordIsUnlocked;
        }
        public bool GetBlazeIfIsUnlocked()
        {
            var userData = _dataStore.GetData<UserData>(_blazeAirplaneIsUnlockedData)
                        ?? new UserData();
            return userData.BlazeSwordIsUnlocked;
        }



        public void SaveIfIsSwordUnlocked(string swordId, bool isSwordUnlocked)
        {
            switch (swordId)
            {
                case "Basic":
                    SaveBasicIfIsUnlocked(isSwordUnlocked); break;

                case "Wild":
                    SaveWildIfIsUnlocked(isSwordUnlocked); break;

                case "Match":
                    SaveMatchIfIsUnlocked(isSwordUnlocked); break;

                case "Gaia":
                    SaveGaiaIfIsUnlocked(isSwordUnlocked); break;

                case "Dizzy":
                    SaveDizzyIfIsUnlocked(isSwordUnlocked); break;

                case "Stunner":
                    SaveStunnerIfIsUnlocked(isSwordUnlocked); break;

                case "Cerberus":
                    SaveCerberusIfIsUnlocked(isSwordUnlocked); break;

                case "Meteor":
                    SaveMeteorIfIsUnlocked(isSwordUnlocked); break;

                case "Lagoon":
                    SaveLagoonIfIsUnlocked(isSwordUnlocked); break;

                case "Thunderbolt":
                    SaveThunderboltIfIsUnlocked(isSwordUnlocked); break;

                case "Blaze":
                    SaveBlazeIfIsUnlocked(isSwordUnlocked); break;

                default:
                    break;
            }
        }


        public void SaveBasicIfIsUnlocked(bool isUnlocked)
        {
            var userData = new UserData { BasicSwordIsUnlocked = isUnlocked };
            _dataStore.SetData(userData, _basicAirplaneIsUnlockedData);
        }

        public void SaveWildIfIsUnlocked(bool isUnlocked)
        {
            var userData = new UserData { WildSwordIsUnlocked = isUnlocked };
            _dataStore.SetData(userData, _wildAirplaneIsUnlockedData);
        }

        public void SaveMatchIfIsUnlocked(bool isUnlocked)
        {
            var userData = new UserData { MatchSwordIsUnlocked = isUnlocked };
            _dataStore.SetData(userData, _matchAirplaneIsUnlockedData);
        }

        public void SaveGaiaIfIsUnlocked(bool isUnlocked)
        {
            var userData = new UserData { GaiaSwordIsUnlocked = isUnlocked };
            _dataStore.SetData(userData, _gaiaAirplaneIsUnlockedData);
        }

        public void SaveDizzyIfIsUnlocked(bool isUnlocked)
        {
            var userData = new UserData { DizzySwordIsUnlocked = isUnlocked };
            _dataStore.SetData(userData, _dizzyAirplaneIsUnlockedData);
        }

        public void SaveStunnerIfIsUnlocked(bool isUnlocked)
        {
            var userData = new UserData { StunnerSwordIsUnlocked = isUnlocked };
            _dataStore.SetData(userData, _stunnerAirplaneIsUnlockedData);
        }

        public void SaveCerberusIfIsUnlocked(bool isUnlocked)
        {
            var userData = new UserData { CerberusSwordIsUnlocked = isUnlocked };
            _dataStore.SetData(userData, _cerberusAirplaneIsUnlockedData);
        }

        public void SaveMeteorIfIsUnlocked(bool isUnlocked)
        {
            var userData = new UserData { MeteorSwordIsUnlocked = isUnlocked };
            _dataStore.SetData(userData, _meteorAirplaneIsUnlockedData);
        }

        public void SaveLagoonIfIsUnlocked(bool isUnlocked)
        {
            var userData = new UserData { LagoonSwordIsUnlocked = isUnlocked };
            _dataStore.SetData(userData, _lagoonAirplaneIsUnlockedData);
        }

        public void SaveThunderboltIfIsUnlocked(bool isUnlocked)
        {
            var userData = new UserData { ThunderboltSwordIsUnlocked = isUnlocked };
            _dataStore.SetData(userData, _thunderboltAirplaneIsUnlockedData);
        }

        public void SaveBlazeIfIsUnlocked(bool isUnlocked)
        {
            var userData = new UserData { BlazeSwordIsUnlocked = isUnlocked };
            _dataStore.SetData(userData, _blazeAirplaneIsUnlockedData);
        }



        public void Process(EventData eventData)
        {

            if (eventData.EventId == EventIds.SwordLevelUp)
            {
                var swordLevelUpEventData = (SwordLevelUpEventData)eventData;
                SaveLevel(swordLevelUpEventData.SwordId, swordLevelUpEventData.SwordLevel);

                return;
            }
        }
    }
}