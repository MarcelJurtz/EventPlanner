using ClubGrid.Interfaces;

namespace ClubGrid.Models
{
    public class Email : IEmail
    {
        private string _subject;
        private string _recipient;
        private string _content;

        private IEmailSender _sender;

        public Email(string recipient, string content) : this(recipient, string.Empty, content) { }

        public Email(string recipient, string subject, string content)
        {
            _recipient = recipient;
            _subject = subject;
            _content = content;
        }

        public string Subject { get { return _subject; } }
        public string Recipient { get { return _recipient; } }
        public string Content { get { return _content; } }

        public async void Send()
        {
            await _sender.SendEmail(_recipient, _subject, _content);
        }
    }
}
