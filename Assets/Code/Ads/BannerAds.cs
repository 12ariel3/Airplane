using Assets.Code.Common.AdsData;
using Assets.Code.Common.Events;
using Assets.Code.Core;
using System.Collections;
using UnityEngine;
using UnityEngine.Advertisements;

namespace Assets.Code.Ads
{
    public class BannerAds : MonoBehaviour, EventObserver
    {

        [SerializeField] string _androidAdUnitId = "Rewarded_Android";
        [SerializeField] string _iOSAdUnitId = "Rewarded_iOS";
        string _adUnitId = null; // This will remain null for unsupported platforms

        BannerPosition _bannerPosition = BannerPosition.TOP_CENTER;

        private bool _adsWereRemoved;


        void Awake()
        {
            // Get the Ad Unit ID for the current platform:
#if UNITY_IOS
        _adUnitId = _iOSAdUnitId;
#elif UNITY_ANDROID || UNITY_EDITOR
            _adUnitId = _androidAdUnitId;
#endif
        }

        private void Start()
        {

            Advertisement.Banner.SetPosition(_bannerPosition);
            ServiceLocator.Instance.GetService<EventQueue>().Subscribe(EventIds.ReturnToMainMenu, this);
            _adsWereRemoved = ServiceLocator.Instance.GetService<AdsSystem>().GetIfIsAdsRemoved();
            if (!_adsWereRemoved)
            {
                StartCoroutine(ShowBannerWithDelay());
            }
        }

        IEnumerator ShowBannerWithDelay()
        {
            yield return new WaitForSeconds(3f);
            LoadBanner();
        }

        private void OnDestroy()
        {
            ServiceLocator.Instance.GetService<EventQueue>().Unsubscribe(EventIds.ReturnToMainMenu, this);
        }


        // Call this public method when you want to get an ad ready to show.
        public void LoadBanner()
        {
            BannerLoadOptions options = new BannerLoadOptions
            {
                loadCallback = OnBannerLoaded,
                errorCallback = OnBannerLoadError
            };

            Advertisement.Banner.Load(_adUnitId, options);
        }


        private void OnBannerLoaded()
        {
            ShowBannerAd();
        }

        private void OnBannerLoadError(string error)
        {

        }

        public void ShowBannerAd()
        {
            BannerOptions options = new BannerOptions
            {
                showCallback = OnBannerShown,
                clickCallback = OnBannerClicked,
                hideCallback = OnBannerHidden,
            };

            Advertisement.Banner.Show(_adUnitId, options);
        }

        private void OnBannerShown()
        {

        }
        private void OnBannerClicked()
        {

        }
        private void OnBannerHidden()
        {
            HideBannerAd();
        }

        public void HideBannerAd()
        {
            Advertisement.Banner.Hide();
        }

        public void Process(EventData eventData)
        {
            if (eventData.EventId == EventIds.ReturnToMainMenu)
            {
                Advertisement.Banner.Hide(true);
            }
        }
    }
}