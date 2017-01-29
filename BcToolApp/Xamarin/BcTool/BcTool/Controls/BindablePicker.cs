using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace BcTool.Controls
{
    /// <summary>
    /// Binding可能なPickerクラス
    /// </summary>
    public class BindablePicker : Picker
    {
        public BindablePicker()
        {
        }

        /// <summary>
        /// ItemsSource の BindableProperty
        /// </summary>
        public readonly static BindableProperty ItemSourceProperty =
            BindableProperty.Create(
                    nameof(ItemsSource),
                    typeof(IEnumerable),
                    typeof(BindablePicker),
                    default(IEnumerable),
                    propertyChanged: (bindable, oldValue, newValue) =>
                    {
                        var picker = bindable as BindablePicker;
                        picker.Items.Clear();

                        if (newValue == null)
                        {
                            return;
                        }

                        foreach (var item in (IEnumerable)newValue)
                        {
                            picker.Items.Add(item.ToString());
                        }
                    },
                    defaultBindingMode: BindingMode.Default
                );

        /// <summary>
        /// ItemsSource の CLR プロパティ
        /// </summary>
        public IEnumerable ItemsSource
        {
            get
            {
                return (IEnumerable)this.GetValue(ItemSourceProperty);
            }
            set
            {
                this.SetValue(ItemSourceProperty, value);
            }
        }
    }
}
