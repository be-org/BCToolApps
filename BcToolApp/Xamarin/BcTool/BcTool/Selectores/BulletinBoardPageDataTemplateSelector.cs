using BcTool.ViewModels;
using Xamarin.Forms;

namespace BcTool.Selectores
{
    /// <summary>
    /// 掲示板情報ページの DataTemplateSelector クラス
    /// </summary>
    public class BulletinBoardPageDataTemplateSelector : DataTemplateSelector
    {
        #region コンストラクタ

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public BulletinBoardPageDataTemplateSelector()
        {

        }

        #endregion

        #region プロパティ

        /// <summary>
        /// 掲示板ページの DataTemplate
        /// </summary>
        public DataTemplate BulletinBoardPage
        {
            get;
            set;
        }

        #endregion

        #region メソッド

        /// <summary>
        /// テンプレート選択処理
        /// </summary>
        /// <param name="item">選択されたテンプレート</param>
        /// <param name="container">コンテナー</param>
        /// <returns>データテンプレート</returns>
        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            var vm = item as BulletinBoardPageViewModel;
            if (vm == null)
            {
                return null;
            }

            return BulletinBoardPage;
        }

        #endregion
    }
}
