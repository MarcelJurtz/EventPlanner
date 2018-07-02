namespace ClubGrid.Config
{
    public class AuthMessageSenderOptions
    {
        public int NewsCount { get; set; }

        public string SendGridUser { get; set; }
        public string SendGridKey { get; set; }

        public string SenderMail { get; set; }
        public string SenderName { get; set; }

        public string WelcomeText { get; set; }
        public string WelcomeSubject { get; set; }

        public string ParticipationText { get; set; }
        public string ParticipationSubject { get; set; }

        public string UserRegisteredText { get; set; }
        public string UserRegisteredSubject { get; set; }
    }
}
