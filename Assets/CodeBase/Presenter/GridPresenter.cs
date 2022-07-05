using Assets.CodeBase.Data;
using Assets.CodeBase.Model;
using Assets.CodeBase.View;
using System;
using System.Collections.Generic;

namespace Assets.CodeBase.Presenter
{
    public class GridPresenter
    {
        private readonly IGridView _view;
        private readonly IGridModel _model;

        public GridPresenter(IGridView view, IGridModel model)
        {
            _view = view;
            _model = model;
        }

        public void Enable()
        {
            _view.NeedGenerate += OnNeedGenerate;
            _view.NeedMix += OnNeedMix;

            _model.Generated += OnGenerated;
            _model.Mixed += OnMixed;
        }

        public void Disable()
        {
            _view.NeedGenerate -= OnNeedGenerate;
            _view.NeedMix -= OnNeedMix;

            _model.Generated -= OnGenerated;
            _model.Mixed -= OnMixed;
        }

        private void OnMixed()
        {
            _view.ShowMix();
        }

        private void OnGenerated(IReadOnlyList<ILetter> letters, int width, int height, Action<Vector3Data[]> callback)
        {
            _view.ShowGenerated(letters, width, height, callback);
        }

        private void OnNeedMix()
        {
            if (_view.Interactable)
                _model.Mix();
        }

        private void OnNeedGenerate(int width, int height)
        {
            if (_view.Interactable)
                _model.Generate(width, height);
        }
    }
}