namespace CleanCode.Domain.Models
{
    public class Speaker
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int? Exp { get; set; }
        public bool HasBlog { get; set; }
        public string BlogURL { get; set; }
        public WebBrowser Browser { get; set; }
        public List<string> Certifications { get; set; }
        public string Employer { get; set; }
        public int RegistrationFee { get; set; }
        public List<Session> Sessions { get; set; }

        //public int? Register(IRepository repository)
        //{
        //    ValidateSpeaker();
        //    RegistrationFee = CalculateRegistrationFee();

        //    try
        //    {
        //        return repository.SaveSpeaker(this);
        //    }
        //    catch (Exception)
        //    {
        //        // Log exception
        //        throw; // Rethrow the exception
        //    }
        //}

        //public int CalculateRegistrationFee() => Exp switch
        //{
        //    <= 1 => 500,
        //    <= 3 => 250,
        //    <= 5 => 100,
        //    <= 9 => 50,
        //    _ => 0
        //};
    }

    #region Custom Exceptions

    public class SpeakerDoesntMeetRequirementsException : Exception
    {
        public SpeakerDoesntMeetRequirementsException(string message) : base(message)
        {
        }
    }

    public class NoSessionsApprovedException : Exception
    {
        public NoSessionsApprovedException(string message) : base(message)
        {
        }
    }

    #endregion Custom Exceptions
}