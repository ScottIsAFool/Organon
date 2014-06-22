using System;
using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;

namespace Organon.Controls
{
    public class ParallaxListViewItem : ListViewItem
    {
        private Image _image;

        public ParallaxListViewItem()
        {
            DefaultStyleKey = typeof(ParallaxListViewItem);
        }

        public double Offset
        {
            get { return (double)GetValue(OffsetProperty); }
            set { SetValue(OffsetProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Offset.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty OffsetProperty = DependencyProperty.Register(
            "Offset", 
            typeof(double), 
            typeof(ParallaxListViewItem), 
            new PropertyMetadata(0d, OnOffsetChanged));

        public string ImagePath
        {
            get { return (string)GetValue(ImagePathProperty); }
            set { SetValue(ImagePathProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ImagePath.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ImagePathProperty = DependencyProperty.Register(
            "ImagePath", 
            typeof(string), 
            typeof(ParallaxListViewItem), 
            new PropertyMetadata("Image"));

        internal double SliderHeight { get; private set; }

        protected override void OnContentChanged(object oldContent, object newContent)
        {
            base.OnContentChanged(oldContent, newContent);
            if (_image == null) return;

            Binding binding = new Binding() { Path = new PropertyPath(ImagePath), Source = newContent };
            _image.SetBinding(Image.SourceProperty, binding);
        }

        protected override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            FrameworkElement contentContainer = (FrameworkElement)GetTemplateChild("ContentContainer");
            _image = (Image)GetTemplateChild("ParallaxImage");

            Binding binding = new Binding() { Path = new PropertyPath(ImagePath), Source = Content };
            _image.SetBinding(Image.SourceProperty, binding);

            FrameworkElement imageContainer = (FrameworkElement)GetTemplateChild("ImageContainer");

            _image.Margin = new Thickness();

            RoutedEventHandler imageOpened = null;
            imageOpened += (sender, args) =>
            {
                _image.ImageOpened -= imageOpened;
                if (Windows.ApplicationModel.DesignMode.DesignModeEnabled == false)
                {
                    if (imageContainer.Height.Equals(contentContainer.ActualHeight) == false)
                    {
                        SliderHeight = _image.ActualHeight - contentContainer.ActualHeight;
                    }
                }
                imageContainer.Height = contentContainer.ActualHeight;
                imageContainer.Clip = new RectangleGeometry
                {
                    Rect = new Rect(0, 0, contentContainer.ActualWidth, contentContainer.ActualHeight)
                };
            };
            _image.ImageOpened += imageOpened;
            if (contentContainer.ActualHeight == 0d)
            {
                EventHandler<object> updateHandler = null;
                updateHandler = (sender, args) =>
                {
                    contentContainer.LayoutUpdated -= updateHandler;
                };
                contentContainer.LayoutUpdated += updateHandler;
            }

            imageContainer.Height = contentContainer.ActualHeight;
        }

        private static void OnOffsetChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var item = (ParallaxListViewItem)d;
            if (item._image == null) return;

            item._image.Margin = new Thickness(0, item.Offset, 0, 0);
        }
    }
}
