using System;
using System.Globalization;
using System.Reflection;
using Xamarin.Forms;

namespace BcTool.Converters
{
    /// <summary>
    /// 画像パスから ImageSourceを返却するコンバータークラス
    /// </summary>
    public class ImageSourceConverter : IValueConverter
    {
        #region コンストラクタ

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public ImageSourceConverter()
        {

        }

        #endregion

        #region 公開メソッド

        /// <summary>
        /// Convert
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            ImageSource result = default(ImageSource);

            if (value is string)
            {
                result = GetEmbeddedResourceImageSource((string)value);
            }

            return result;
        }

        /// <summary>
        /// ConvertBack
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region メソッド

        /// <summary>
        /// 埋め込みリソースの ImageSource を取得
        /// </summary>
        /// <param name="path">namespaceを含むファイルパス</param>
        /// <returns>埋め込みリソースの ImageSource</returns>
        private ImageSource GetEmbeddedResourceImageSource(string path)
        {
            if (Device.RuntimePlatform == Device.iOS || Device.RuntimePlatform == Device.Android)
            {
                return ImageSource.FromResource(path);
            }
            else
            {
                var assembly = typeof(App).GetTypeInfo().Assembly;
                return ImageSource.FromResource(path, assembly);
            }
        }

        #endregion
    }
}
