using System;
using System.Globalization;
using Xamarin.Forms;

namespace BcTool.Converters
{
    /// <summary>
    /// 選択アイテムのコンバータークラス
    /// </summary>
    public class SelectedItemConverter : IValueConverter
    {
        #region コンストラクタ

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public SelectedItemConverter()
        {

        }

        #endregion

        #region 公開メソッド

        /// <summary>
        /// コンバート
        /// </summary>
        /// <param name="value">値</param>
        /// <param name="targetType">型</param>
        /// <param name="parameter">パラメータ</param>
        /// <param name="culture">カルチャー</param>
        /// <returns>コンバートしたオブジェクト</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var args = (SelectedItemChangedEventArgs)value;
            return args.SelectedItem;
        }

        /// <summary>
        /// コンバートバック
        /// </summary>
        /// <param name="value">値</param>
        /// <param name="targetType">型</param>
        /// <param name="parameter">パラメータ</param>
        /// <param name="culture">カルチャー</param>
        /// <returns>コンバートを戻したオブジェクト</returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
