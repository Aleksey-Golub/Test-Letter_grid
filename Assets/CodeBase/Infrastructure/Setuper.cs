using Assets.CodeBase.Model;
using Assets.CodeBase.Model.MixingStrategy;
using Assets.CodeBase.Presenter;
using Assets.CodeBase.Services;
using Assets.CodeBase.View;
using UnityEngine;

namespace Assets.CodeBase.Infrastructure
{
    public class Setuper : MonoBehaviour
    {
        [SerializeField] private GridView _view;
        [SerializeField] private UIFactory _uIFactory;

        private GridPresenter _presenter;
        private GridModel _model;

        private void Awake()
        {
            _model = new GridModel(new MixStrategy());
            _presenter = new GridPresenter(_view, _model);
            _view.Construct(_uIFactory);
        }

        private void OnEnable() => 
            _presenter.Enable();

        private void OnDisable() => 
            _presenter.Disable();
    }
}
