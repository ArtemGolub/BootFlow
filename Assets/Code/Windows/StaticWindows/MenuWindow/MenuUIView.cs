using System;
using Code.UI.Abstractions;
using R3;
using UnityEngine;
using UnityEngine.UI;

namespace Code.Windows.StaticWindows.MenuWindow
{
    public sealed class MenuUIView : UIView<MenuUIViewModel>
    {
        [SerializeField] private Button _restartButton;

        private IDisposable _restartSubscription;

        protected override void OnInitialize()
        {
            gameObject.SetActive(true);

            if (_restartButton == null)
                return;

            _restartSubscription = ViewModel.BindRestart(_restartButton.OnClickAsObservable());
        }

        protected override void OnRelease()
        {
            _restartSubscription?.Dispose();
            _restartSubscription = null;
            gameObject.SetActive(false);
        }
    }
}
