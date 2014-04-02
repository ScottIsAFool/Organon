using System.Linq;
using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Organon.Controls.PinterestPanl
{
    public class PinterestPanel : Panel
    {
        public int ColumnCount
        {
            get { return (int)GetValue(ColumnCountProperty); }
            set { SetValue(ColumnCountProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ColumnCount.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ColumnCountProperty =
            DependencyProperty.Register("ColumnCount", typeof(int), typeof(PinterestPanel), new PropertyMetadata(3));

        protected override Size MeasureOverride(Size availableSize)
        {
            double columnWidth = availableSize.Width / ColumnCount;

            var columnHeights = new double[ColumnCount];

            for (int i = 0; i < Children.Count; i++)
            {
                var columnIndex = GetColumnIndex(columnHeights);

                var child = Children[i];
                child.Measure(new Size(columnWidth, availableSize.Height));
                var elementSize = child.DesiredSize;
                columnHeights[columnIndex] += elementSize.Height;
            }

            double desiredHeight = columnHeights.Max();

            return new Size(availableSize.Width, desiredHeight);
        }

        private int GetColumnIndex(double[] columnHeights)
        {
            int columnIndex = 0;
            double height = columnHeights[0];
            for (int j = 1; j < ColumnCount; j++)
            {
                if (columnHeights[j] < height)
                {
                    columnIndex = j;
                    height = columnHeights[j];
                }
            }
            return columnIndex;
        }

        protected override Size ArrangeOverride(Size finalSize)
        {
            double columnWidth = finalSize.Width / ColumnCount;
            var columnHeights = new double[ColumnCount];

            for (int i = 0; i < Children.Count; i++)
            {
                var columnIndex = GetColumnIndex(columnHeights);

                var child = Children[i];
                var elementSize = child.DesiredSize;

                double elementWidth = elementSize.Width;
                double elementHeight = elementSize.Height;
                if (elementWidth > columnWidth)
                {
                    double differencePercentage = columnWidth / elementWidth;
                    elementHeight = elementHeight * differencePercentage;
                    elementWidth = columnWidth;
                }

                Rect bounds = new Rect(columnWidth * columnIndex, columnHeights[columnIndex], elementWidth, elementHeight);
                child.Arrange(bounds);

                columnHeights[columnIndex] += elementSize.Height;
            }

            return base.ArrangeOverride(finalSize);
        }
    }
}
