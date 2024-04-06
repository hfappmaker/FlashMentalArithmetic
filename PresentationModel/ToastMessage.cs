using CommunityToolkit.Mvvm.Messaging.Messages;
using System.Collections;

namespace PresentationModel
{
    public class ToastMessage : ValueChangedMessage<ToastMessageType>
    {
        public ToastMessage(ToastMessageType value) : base(value)
        {
        }
    }
}