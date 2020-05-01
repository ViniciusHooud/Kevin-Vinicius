using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MobileCamoes.Behavior
{
    public class MaiuculoBehavior : Behavior<Entry>
    {
        protected override void OnAttachedTo(Entry bindable)
        {
            base.OnAttachedTo(bindable);
            bindable.TextChanged += Bindable_TextChanged;
        }

        private void Bindable_TextChanged(object sender, TextChangedEventArgs e)
        {
            Entry entry = sender as Entry;

            if(!string.IsNullOrEmpty(e.NewTextValue))
                entry.Text = e.NewTextValue.ToUpper();
        }

        protected override void OnDetachingFrom(Entry bindable)
        {
            base.OnDetachingFrom(bindable);
            bindable.TextChanged -= Bindable_TextChanged;
        }
    }
}
