﻿using Assets.CodeBase.Model;
using Assets.CodeBase.Presenter;
using Assets.CodeBase.View;
using UnityEngine;

namespace Assets.CodeBase.Infrastructure
{
    public class GridSetup : MonoBehaviour
    {
        [SerializeField] private GridView _view;
        [SerializeField] private UIFactory _uIFactory;

        private GridPresenter _presenter;
        private GridModel _model;

        private void Awake()
        {
            _model = new GridModel();
            _presenter = new GridPresenter(_view, _model);
            _view.Construct(_uIFactory);
        }

        private void OnEnable() => 
            _presenter.Enable();

        private void OnDisable() => 
            _presenter.Disable();
    }
}
