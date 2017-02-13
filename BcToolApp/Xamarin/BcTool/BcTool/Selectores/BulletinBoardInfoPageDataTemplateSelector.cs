using BcTool.ViewModels;
using Xamarin.Forms;

namespace BcTool.Selectores
{
    /// <summary>
    /// 掲示板情報ページの DataTemplateSelector クラス
    /// </summary>
    public class BulletinBoardInfoPageDataTemplateSelector : DataTemplateSelector
    {
        #region コンストラクタ

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public BulletinBoardInfoPageDataTemplateSelector()
        {

        }

        #endregion

        #region プロパティ

        /// <summary>
        /// 掲示板情報ページの DataTemplate
        /// </summary>
        public DataTemplate BulletinBoardInfoPage
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
            var vm = item as BulletinBoardInfoPageViewModel;
            if (vm == null)
            {
                return null;
            }

            return BulletinBoardInfoPage;
        }

        #endregion
    }
}
