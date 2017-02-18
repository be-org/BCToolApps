using System;
using System.Reflection;
using System.Windows.Input;
using Xamarin.Forms;

namespace BcTool.Behaviors
{
    /// <summary>
    /// イベントにCommandをバインドするBehaviorクラス
    /// </summary>
    public class EventToCommandBehavior : BindableBehavior<VisualElement>
    {
        #region フィールド変数

        /// <summary>
        /// イベントハンドラー
        /// </summary>
        private Delegate _EventHandler;
        /// <summary>
        /// VisualElement
        /// </summary>
        private VisualElement _AssociatedObject;

        #endregion

        #region プロパティ

        /// <summary>
        /// イベント名称プロパティ
        /// </summary>
        public static readonly BindableProperty EventNameProperty =
            BindableProperty.Create(
                nameof(EventName),
                typeof(string),
                typeof(EventToCommandBehavior),
                string.Empty,
                propertyChanged: (bindable, oldEvent, newEvent) =>
                {
                    var behavior = bindable as EventToCommandBehavior;
                    if (behavior._AssociatedObject == null)
                    {
                        return;
                    }

                    var oldEventName = oldEvent as string;
                    var newEventName = newEvent as string;

                    behavior.DeregisterEvent(oldEventName);
                    behavior.RegisterEvent(newEventName);
                });

        /// <summary>
        /// イベント名称
        /// </summary>
        public string EventName
        {
            get
            {
                return (string)GetValue(EventNameProperty);
            }
            set
            {
                SetValue(EventNameProperty, value);
            }
        }

        /// <summary>
        /// コマンドプロパティ
        /// </summary>
        public static readonly BindableProperty CommandProperty =
            BindableProperty.Create(
                nameof(Command),
                typeof(ICommand),
                typeof(EventToCommandBehavior));

        /// <summary>
        /// コマンド
        /// </summary>
        public ICommand Command
        {
            get
            {
                return (ICommand)GetValue(CommandProperty);
            }
            set
            {
                SetValue(CommandProperty, value);
            }
        }

        /// <summary>
        /// コンバータープロパティ
        /// </summary>
        public static readonly BindableProperty ConverterProperty =
            BindableProperty.Create(
                nameof(Converter),
                typeof(IValueConverter),
                typeof(EventToCommandBehavior));

        /// <summary>
        /// コンバーター
        /// </summary>
        public IValueConverter Converter
        {
            get
            {
                return (IValueConverter)GetValue(ConverterProperty);
            }
            set
            {
                SetValue(ConverterProperty, value);
            }
        }

        #endregion

        #region メソッド

        /// <summary>
        /// イベントのアタッチ
        /// </summary>
        /// <param name="bindable">VisualElement</param>
        protected override void OnAttachedTo(VisualElement bindable)
        {
            base.OnAttachedTo(bindable);

            _AssociatedObject = bindable;

            if (bindable.BindingContext != null)
            {
                base.BindingContext = bindable.BindingContext;
            }

            bindable.BindingContextChanged += OnBindingContextChanged;

            RegisterEvent(EventName);
        }

        /// <summary>
        /// イベントのデタッチ
        /// </summary>
        /// <param name="bindable">VisualElement</param>
        protected override void OnDetachingFrom(VisualElement bindable)
        {
            DeregisterEvent(EventName);

            bindable.BindingContextChanged -= OnBindingContextChanged;

            _AssociatedObject = null;

            base.OnDetachingFrom(bindable);
        }

        /// <summary>
        /// バインディングコンテキストの変更処理
        /// </summary>
        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            base.BindingContext = _AssociatedObject.BindingContext;
        }

        /// <summary>
        /// バインディングコンテキストの変更処理
        /// </summary>
        /// <param name="sender">イベント元情報</param>
        /// <param name="e">イベント引数</param>
        private void OnBindingContextChanged(object sender, EventArgs e)
        {
            OnBindingContextChanged();
        }

        /// <summary>
        /// イベントの登録
        /// </summary>
        /// <param name="eventName">イベント名称</param>
        private void RegisterEvent(string eventName)
        {
            var eventInfo = _AssociatedObject.GetType().GetRuntimeEvent(eventName);
            if (eventInfo == null)
            {
                return;
            }

            var methodInfo = typeof(EventToCommandBehavior).GetTypeInfo().GetDeclaredMethod(nameof(OnEvent));
            _EventHandler = methodInfo.CreateDelegate(eventInfo.EventHandlerType, this);
            eventInfo.AddEventHandler(_AssociatedObject, _EventHandler);
        }

        /// <summary>
        /// イベントの削除
        /// </summary>
        /// <param name="eventName">イベント名称</param>
        private void DeregisterEvent(string eventName)
        {
            if (_EventHandler == null)
            {
                return;
            }

            var eventInfo = _AssociatedObject.GetType().GetRuntimeEvent(eventName);
            if (eventInfo == null)
            {
                return;
            }

            eventInfo.RemoveEventHandler(_AssociatedObject, _EventHandler);
            _EventHandler = null;
        }

        /// <summary>
        /// イベント処理
        /// </summary>
        /// <param name="sender">イベント元情報</param>
        /// <param name="eventArgs">イベント引数</param>
        private void OnEvent(object sender, object eventArgs)
        {
            if (Command != null)
            {
                object param = eventArgs;

                if (Converter != null)
                {
                    param = Converter.Convert(eventArgs, typeof(object), null, null);
                }

                if (Command.CanExecute(param))
                {
                    Command.Execute(param);
                }
            }
        }

        #endregion
    }
}
