using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MobileCamoes.Triggers
{
    public class EmailTrigger : TriggerAction<Entry>
    {
        protected override void Invoke(Entry sender)
        {
            if (sender.Text.Contains("@") && sender.Text.Contains("."))
                sender.TextColor = Color.Green;
            else
                sender.TextColor = Color.Red;
        }
    }
}
