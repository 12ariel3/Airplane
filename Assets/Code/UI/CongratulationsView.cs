﻿using Assets.Code.Core;
using Assets.Code.MusicAndSound;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Code.UI
{
    public class CongratulationsView : MonoBehaviour
    {

        [SerializeField] private Button _backgroundBackToMenuButton;

        private void Awake()
        {
            _backgroundBackToMenuButton.onClick.AddListener(OnBackToMenuPressed);
        }

        private void OnBackToMenuPressed()
        {
            Hide();
        }

        public void Show()
        {
            gameObject.SetActive(true);
            ServiceLocator.Instance.GetService<AudioManager>().PlayOtherSfx("Congratulations");
        }

        public void Hide()
        {
            ServiceLocator.Instance.GetService<AudioManager>().PlayOtherSfx("ReverseBloop");
            gameObject.SetActive(false);
        }

        public void HideFirst()
        {
            gameObject.SetActive(false);
        }
    }
}