namespace RabbitMQ.StatePattern
{
    public class Task
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public string AssignedTo { get; set; }
        public int CompletionPercentage { get; set; }
        public string ReviewComments { get; set; }
        public string TestResults { get; set; }
        public string State { get; set; } // جدید، اختصاص داده شده، در حال انجام، در حال بررسی، نیاز به تست، انجام شده
        public List<string> Logs { get; set; } = new List<string>();

        public Task(string id, string description)
        {
            Id = id;
            Description = description;
            State = "new";
            LogChange("System", "کار در حالت جدید ساخته شد");
        }

        public void Assign(string developer, string changedBy)
        {
            if (State == "New")
            {
                State = "Assigned";
                AssignedTo = developer;
                LogChange(changedBy, $"کار به {developer} اختصاص داده شد");
                Console.WriteLine($"اعلان: کار {Id} به {developer} اختصاص داده شد");
            }
            else
            {
                throw new InvalidOperationException("فقط از حالت جدید می‌تونی اختصاص بدی");
            }
        }

        public void StartProgress(string changedBy)
        {
            if (State == "Assigned")
            {
                State = "InProgress";
                LogChange(changedBy, "کار به در حال انجام رفت");
            }
            else
            {
                throw new InvalidOperationException("فقط از حالت اختصاص داده شده می‌تونی شروع کنی");
            }
        }

        public void SubmitForReview(string changedBy)
    {
        if (State == "InProgress")
        {
            State = "UnderReview";
            LogChange(changedBy, "کار برای بررسی فرستاده شد");
            Console.WriteLine($"اعلان: بررسی‌کننده‌ها، لطفاً کار {Id} رو بررسی کنید");
        }
        else
        {
            throw new InvalidOperationException("فقط از حالت در حال انجام می‌تونی برای بررسی بفرستی");
        }
    }

    public void Review(bool passed, string comments, string changedBy)
    {
        if (State == "UnderReview")
        {
            ReviewComments = comments;
            if (passed)
            {
                State = "TestingRequired";
                LogChange(changedBy, "کار بررسی رو قبول شد، به نیاز به تست رفت");
            }
            else
            {
                State = "InProgress";
                LogChange(changedBy, "کار بررسی رو رد شد، به در حال انجام برگشت");
            }
        }
        else
        {
            throw new InvalidOperationException("فقط از حالت در حال بررسی می‌تونی بررسی کنی");
        }
    }

    public void Test(bool passed, string results, string changedBy)
    {
        if (State == "TestingRequired")
        {
            TestResults = results;
            if (passed)
            {
                State = "Done";
                LogChange(changedBy, "کار تست رو قبول شد، به انجام شده رفت");
            }
            else
            {
                State = "InProgress";
                LogChange(changedBy, "کار تست رو رد شد، به در حال انجام برگشت");
            }
        }
        else
        {
            throw new InvalidOperationException("فقط از حالت نیاز به تست می‌تونی تست کنی");
        }
    }

    public void EditDescription(string newDescription, string changedBy, bool isManager)
    {
        if (State == "New")
        {
            Description = newDescription;
            LogChange(changedBy, "توضیحات کار به‌روز شد");
        }
        else if (State == "Assigned" && (changedBy == AssignedTo || isManager))
        {
            Description = newDescription;
            LogChange(changedBy, "توضیحات کار به‌روز شد");
        }
        else
        {
            throw new InvalidOperationException("نمی‌تونی توضیحات رو توی این حالت یا با این کاربر ویرایش کنی");
        }
    }

    public void UpdateProgress(int percentage, string changedBy)
    {
        if (State == "InProgress")
        {
            CompletionPercentage = percentage;
            LogChange(changedBy, $"پیشرفت به {percentage}% به‌روز شد");
        }
        else
        {
            throw new InvalidOperationException("فقط توی حالت در حال انجام می‌تونی پیشرفت رو به‌روز کنی");
        }
    }

        private void LogChange(string user, string message)
        {
            string log = $"{DateTime.Now}: {user}: {message}";
            Logs.Add(log);
        }
    }
}