using Code.UI.Abstractions;
using UnityEngine;
using UnityEngine.UI;

namespace Code.Windows.StaticWindows.SplashWindow
{
    public sealed class SplashUIView : UIView<SplashUIViewModel>
    {
        [SerializeField] private Image _logo;

        protected override void OnInitialize()
        {
            gameObject.SetActive(true);

            if (_logo != null)
                _logo.gameObject.SetActive(true);
        }

        protected override void OnRelease()
        {
            if (_logo != null)
                _logo.gameObject.SetActive(false);

            gameObject.SetActive(false);
        }
    }
}
