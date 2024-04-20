using CommunityToolkit.Mvvm.Messaging.Messages;

namespace CommonPresentationModel
{
    public class ToastMessage : ValueChangedMessage<ToastMessageType>
    {
        public ToastMessage(ToastMessageType value) : base(value)
        {
        }
    }
}