namespace Patterns.MediatorPattern.ChatRoom
{
    public class ChatMediator : IChatMediator
    {
        private ChatBox _chatBox;
        private MessageInput _messageInput;
        private SendButton _sendButton;
        private UserList _userList;

        public ChatMediator(ChatBox chatBox, MessageInput messageInput, SendButton sendButton, UserList userList)
        {
            _chatBox = chatBox;
            _messageInput = messageInput;
            _sendButton = sendButton;
            _userList = userList;
        }

        public void Notify(object sender, string message)
        {
            if (sender is UserList)
            {
                _chatBox.LoadMessages();
                _messageInput.Clear();
                _sendButton.Enable();
            }
        }
    }
}