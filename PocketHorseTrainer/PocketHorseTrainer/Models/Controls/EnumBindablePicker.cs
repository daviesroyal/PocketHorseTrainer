﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using Xamarin.Forms;

namespace PocketHorseTrainer.Models
{
    public class EnumBindablePicker<T> : Picker where T : struct
    {
        public EnumBindablePicker()
        {
            this.BindingContextChanged += EnumBindablePicker_BindingContextChanged;
            SelectedIndexChanged += OnSelectedIndexChanged;

            //Fill the Items from the enum
            foreach (var value in Enum.GetValues(typeof(T)))
            {
                Items.Add(GetEnumDescription(value));
            }
        }

        private void EnumBindablePicker_BindingContextChanged(object sender, EventArgs e)
        {
            //if the current value is the same as the default,
            //it wouldn't recognize the change. Force OnSelectedItemChanged to handle this case.
            OnSelectedItemChanged(this, SelectedItem, SelectedItem);
        }

        public static new BindableProperty SelectedItemProperty = BindableProperty.Create(nameof(SelectedItem), typeof(T), typeof(EnumBindablePicker<T>), default(T), propertyChanged: OnSelectedItemChanged, defaultBindingMode: BindingMode.TwoWay);

        public new T SelectedItem
        {
            get
            {
                return (T)GetValue(SelectedItemProperty);
            }
            set
            {
                SetValue(SelectedItemProperty, value);
            }
        }
        private void OnSelectedIndexChanged(object sender, EventArgs eventArgs)
        {
            if (SelectedIndex < 0 || SelectedIndex > Items.Count - 1)
            {
                SelectedItem = default;
            }
            else
            {
                //try parsing, if using description this will fail
                if (!Enum.TryParse<T>(Items[SelectedIndex], out T match))
                {
                    //find enum by Description
                    match = GetEnumByDescription(Items[SelectedIndex]);
                }
                SelectedItem = (T)Enum.Parse(typeof(T), match.ToString());
            }
        }
        private static void OnSelectedItemChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            var picker = bindable as EnumBindablePicker<T>;
            if (newvalue != null)
            {
                picker.SelectedIndex = picker.Items.IndexOf(GetEnumDescription(newvalue));
            }
        }

        private static string GetEnumDescription(object value)
        {
            string result = value.ToString();
            DisplayAttribute attribute = typeof(T).GetRuntimeField(value.ToString()).GetCustomAttributes<DisplayAttribute>(false).SingleOrDefault();
            if (attribute != null)
                result = attribute.Description;
            //else
            //{
            //    //is there a resource entry?
            //    var match = Resource1.ResourceManager.GetString($"{typeof(T).Name}_{((int)value).ToString(CultureInfo.InvariantCulture)}");
            //    if (!string.IsNullOrWhiteSpace(match))
            //        result = match;
            //}

            return result;
        }

        private T GetEnumByDescription(string description)
        {
            return Enum.GetValues(typeof(T)).Cast<T>().FirstOrDefault(x => string.Equals(GetEnumDescription(x), description));
        }
    }
}
