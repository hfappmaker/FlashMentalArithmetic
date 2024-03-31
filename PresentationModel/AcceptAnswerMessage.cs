using CommunityToolkit.Mvvm.Messaging.Messages;
using System.Collections;

namespace PresentationModel
{
    public class AcceptAnswerMessage : ValueChangedMessage<bool>
    {
        public AcceptAnswerMessage(bool value) : base(value)
        {
        }
    }
}