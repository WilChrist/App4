using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms.Xaml;

namespace App4
{
    [Xamarin.Forms.ContentProperty(nameof(Source))]
    public class ImageResourceExtension : IMarkupExtension
    {
        public string Source { get; set; }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (Source == null)
            {
                return null;
            }

            // Do your translation lookup here, using whatever method you require
            var imageSource = Xamarin.Forms.ImageSource.FromResource(Source);

            return imageSource;
        }
    }
}
