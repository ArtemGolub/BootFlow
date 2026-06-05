using System;
using Code.UI.Abstractions;
using R3;
using UnityEngine;
using UnityEngine.UI;

namespace Code.Windows.UpdatableWindows.LoadingWindow
{
    public sealed class LoadingUIView : UIView<LoadingUIViewModel>
    {
        [SerializeField] private Slider _progressSlider;

        private IDisposable _progressSubscription;

        protected override void OnInitialize()
        {
            gameObject.SetActive(true);

            if (_progressSlider != null)
            {
                _progressSlider.gameObject.SetActive(true);
                _progressSlider.minValue = 0f;
                _progressSlider.maxValue = 1f;
                _progressSlider.interactable = false;
            }

            _progressSubscription = ViewModel.Progress.Subscribe(progress =>
            {
                if (_progressSlider != null)
                    _progressSlider.value = progress;
            });
        }

        protected override void OnRelease()
        {
            _progressSubscription?.Dispose();
            _progressSubscription = null;
            gameObject.SetActive(false);
        }
    }
}
