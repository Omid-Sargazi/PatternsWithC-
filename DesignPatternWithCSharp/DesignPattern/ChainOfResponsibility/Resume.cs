namespace DesignPattern.ChainOfResponsibility
{
    public class Resume
    {
        public string CandidateName { get; set; }
        public int YearsOfExperience { get; set; }
        public string EnglishLevel { get; set; } // مثلاً: A2, B1, B2, C1
        public int ExpectedSalary { get; set; }
    }

    public enum ResumeStatus
    {
        Accepted,
        RejectedByExperience,
        RejectedByEnglishLevel,
        RequiresManagerApproval
    }
}