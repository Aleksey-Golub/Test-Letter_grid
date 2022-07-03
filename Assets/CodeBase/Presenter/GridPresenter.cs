using Assets.CodeBase.Model;
using Assets.CodeBase.View;
using System.Collections.Generic;

namespace Assets.CodeBase.Presenter
{
    public class GridPresenter
    {
        private readonly GridView _view;
        private readonly GridModel _model;

        public GridPresenter(GridView view, GridModel model)
        {
            _view = view;
            _model = model;
        }

        public void Enable()
        {
            _view.NeedGenerate += GenerateGrid;
            _view.NeedMix += MixGrid;

            _model.Changed += LettersChanged;
        }

        public void Disable()
        {
            _view.NeedGenerate -= GenerateGrid;
            _view.NeedMix -= MixGrid;

            _model.Changed -= LettersChanged;
        }

        private void LettersChanged(IReadOnlyList<Letter> letters, int width, int height)
        {
            _view.Show(letters, width, height);
        }

        private void MixGrid()
        {
            _model.Mix();
        }

        private void GenerateGrid(int width, int height)
        {
            _model.Generate(width, height);
        }
    }
}