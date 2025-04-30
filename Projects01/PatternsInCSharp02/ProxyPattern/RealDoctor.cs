
namespace PatternsInCSharp02.ProxyPattern
{
    public class RealDoctor
    {
        public string AnswerMedicalQuestion(string question)
        {
            Console.WriteLine("پزشک واقعی در حال بررسی سوال... (عملیات زمان‌بر)");
            Thread.Sleep(3000); // تأخیر شبیه‌سازی شده
            return $"پاسخ تخصصی به: {question}";
        }
    }

    public class MedicalApp
    {
        public void HandleUserRequest(string question)
        {
            var doctor = new RealDoctor();
            var answer = doctor.AnswerMedicalQuestion(question);
            Console.WriteLine(answer);
        }
    }
}