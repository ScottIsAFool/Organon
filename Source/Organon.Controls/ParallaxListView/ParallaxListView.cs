using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace Organon.Controls
{
    public class ParallaxListView : ListView
    {
        private readonly ICollection<ParallaxListViewItem> _realizedItems = new Collection<ParallaxListViewItem>();
        private ScrollViewer _scrollViewer;

        protected override void PrepareContainerForItemOverride(DependencyObject element, object item)
        {
            base.PrepareContainerForItemOverride(element, item);

            var listBoxItem = element as ParallaxListViewItem;
            if (listBoxItem != null)
            {
                _realizedItems.Add(listBoxItem);
                UpdateParallax();
            }
        }

        protected override void ClearContainerForItemOverride(DependencyObject element, object item)
        {
            base.ClearContainerForItemOverride(element, item);

            var listBoxItem = element as ParallaxListViewItem;
            if (listBoxItem != null)
                _realizedItems.Remove(listBoxItem);
        }

        protected override DependencyObject GetContainerForItemOverride()
        {
            return new ParallaxListViewItem();
        }

        protected override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            _scrollViewer = (ScrollViewer)GetTemplateChild("ScrollViewer");
            //_scrollViewer.Loaded += (sender, args) =>
            //{
            //    ScrollBar scrollBar = _scrollViewer.GetChildOfType<ScrollBar>();
            //    scrollBar.ValueChanged += ScrollBarOnValueChanged;
            //    scrollBar.Scroll += ScrollBarOnScroll;
            //};
            _scrollViewer.ViewChanging += ScrollViewerOnViewChanging;
        }

        private void ScrollViewerOnViewChanging(object sender, ScrollViewerViewChangingEventArgs e)
        {
            UpdateParallax();
        }

        private void UpdateParallax()
        {
            foreach (var parallaxListBoxItem in _realizedItems)
            {
                var transform = (MatrixTransform)parallaxListBoxItem.TransformToVisual(this);

                if (transform.Matrix.OffsetY > this.Height) continue;
                if (transform.Matrix.OffsetY + parallaxListBoxItem.ActualHeight < 0) continue;

                // an transform offset of 800 (Height) = 0 parallax
                double offsetFraction = 1 - (transform.Matrix.OffsetY / Height);
                var offset = Math.Min(parallaxListBoxItem.SliderHeight * offsetFraction, parallaxListBoxItem.SliderHeight);

                parallaxListBoxItem.Offset = -offset;
            }
        }
    }
}
