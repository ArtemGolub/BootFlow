using System;
using UnityEngine;

namespace Code.UI.Abstractions
{
    public abstract class UIView : MonoBehaviour
    {
        public abstract void Initialize();
        public abstract void Release();
    }

    public abstract class UIView<TVm> : UIView where TVm : IUIViewModel
    {
        protected TVm ViewModel { get; private set; }

        public void Initialize(TVm viewModel)
        {
            ViewModel = viewModel;
            OnInitialize();
        }

        public override void Initialize()
        {
            throw new InvalidOperationException($"Use {nameof(Initialize)}({nameof(TVm)}) on {GetType().Name}.");
        }

        protected abstract void OnInitialize();

        public override void Release()
        {
            OnRelease();
            ViewModel = default;
        }

        protected abstract void OnRelease();
    }
}
