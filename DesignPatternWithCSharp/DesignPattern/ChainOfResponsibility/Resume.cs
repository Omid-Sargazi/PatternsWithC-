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
    public delegate ResumeStatus? ResumeCheck(Resume resume);

    public class ResumeProcessor
    {
        private readonly List<ResumeCheck> _checks = new();

        public ResumeProcessor AddCheck(ResumeCheck check)
        {
            _checks.Add(check);
            return this;
        }

        public ResumeStatus Process(Resume resume)
        {
            foreach (var check in _checks)
            {
                var result = check(resume);
                if (result.HasValue && result.Value != ResumeStatus.Accepted)
                {
                    return result.Value;
                }
            }

            return ResumeStatus.Accepted;
        }
    }
}