using Prism.Behaviors;
using Xamarin.Forms;

namespace BcTool.Behaviors
{
    /// <summary>
    /// ListViewの選択した行を色を付けないビヘイビアクラス
    /// </summary>
    public class NotSelectableListViewBehavior : BehaviorBase<ListView>
    {
        #region コンストラクタ

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public NotSelectableListViewBehavior()
        {

        }

        #endregion

        #region 公開メソッド

        /// <summary>
        /// アタッチ
        /// </summary>
        /// <param name="bindable">ListViewのインスタンス</param>
        protected override void OnAttachedTo(ListView bindable)
        {
            base.OnAttachedTo(bindable);
            bindable.ItemSelected += OnItemSelected;
        }

        /// <summary>
        /// デタッチ
        /// </summary>
        /// <param name="bindable">ListView</param>
        protected override void OnDetachingFrom(ListView bindable)
        {
            base.OnDetachingFrom(bindable);
            bindable.ItemSelected -= OnItemSelected;
        }

        #endregion

        #region イベントメソッド

        /// <summary>
        /// アイテム選択イベント処理
        /// </summary>
        /// <param name="sender">イベント元情報</param>
        /// <param name="e">イベント引数</param>
        private void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ((ListView)sender).SelectedItem = null;
        }

        #endregion
    }
}
