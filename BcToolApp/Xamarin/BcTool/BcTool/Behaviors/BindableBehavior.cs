﻿using System;
using Xamarin.Forms;

namespace BcTool.Behaviors
{
    /// <summary>
    /// BindablePropertyを持つBehaviorの基底クラス
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <remarks>
    /// https://github.com/nuitsjp/XamarinSamples/blob/master/XFormsEventToCommand/XFormsEventToCommand/XFormsEventToCommand/BindableBehavior.cs
    /// </remarks>
    public class BindableBehavior<T> : Behavior<T> where T : BindableObject
    {
        #region プロパティ

        /// <summary>
        /// ビヘイビアがアタッチされるオブジェクト
        /// </summary>
        protected T AssociatedObject
        {
            get;
            private set;
        }

        #endregion

        #region メソッド

        /// <summary>
        /// アタッチ処理
        /// </summary>
        /// <param name="bindableObject">アタッチ対象のオブジェクト</param>
        protected override void OnAttachedTo(T bindableObject)
        {
            base.OnAttachedTo(bindableObject);

            AssociatedObject = bindableObject;

            // アタッチ対象のオブジェクトにBindingContextが設定されていた場合、ビヘイビアの
            // BindingContextにも同じ値を設定する
            // これをしておかないと、BindablePropertyにXAML上でBinding指定しても実際には
            // 設定されない
            if (bindableObject.BindingContext != null)
            {
                BindingContext = bindableObject.BindingContext;
            }

            // アタッチ対象のBindablePropertyの変更イベントにハンドラを設定する
            bindableObject.BindingContextChanged += OnBindingContextChanged;
        }

        /// <summary>
        /// BindingContextの変更イベント処理
        /// </summary>
        /// <param name="sender">イベント元情報</param>
        /// <param name="e">イベント引数</param>
        private void OnBindingContextChanged(object sender, EventArgs e)
        {
            OnBindingContextChanged();
        }

        /// <summary>
        /// デタッチ時にBindingContextのイベントからハンドラを除去する
        /// </summary>
        /// <param name="bindableObject">bindableObject</param>
        protected override void OnDetachingFrom(T bindableObject)
        {
            bindableObject.BindingContextChanged -= OnBindingContextChanged;
        }

        /// <summary>
        /// アタッチ先のBindingContext、または自分自身のBindingContextが変更された場合
        /// 自分自身のBindingContextにアタッチ先のBindingContextを設定する
        /// </summary>
        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
            BindingContext = AssociatedObject.BindingContext;
        }

        #endregion
    }
}
