using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace Docutain_SDK_Example_Xamarin
{
    public class ThemeImageSrcConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string ImgSrc = (string)value;

            OSAppTheme oSAppTheme = Application.Current.RequestedTheme;
            if (oSAppTheme == OSAppTheme.Light)
            {
                return ImgSrc + "black.png";
            }
            else
            {
                return ImgSrc + "white.png";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return OSAppTheme.Dark;
        }
    }
}
