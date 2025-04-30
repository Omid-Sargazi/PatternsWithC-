
namespace PatternsInCSharp02.ProxyPattern
{
    public class RealDoctor : IDoctor
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
        private IDoctor _doctor;

        public MedicalApp(IDoctor doctor)
        {
            _doctor = doctor;
        }
        public void Consult(string question)
        {
           Console.WriteLine($"\nسوال کاربر: {question}");
           var answer = _doctor.AnswerMedicalQuestion(question);
           Console.WriteLine($"پاسخ سیستم: {answer}");
        }
    }

    public interface IDoctor
    {
        string AnswerMedicalQuestion(string question);
    }

    public class DoctorProxy : IDoctor
    {
        private RealDoctor _realDoctor;
        private Dictionary<string, string> _commonQuestionsCache = new()
        {
            {"سردرد", "استراحت کنید و مایعات بنوشید"},
        {"تب", "استامینوفن مصرف کنید و استراحت نمایید"}
        };

        public string AnswerMedicalQuestion(string question)
        {
            if(_commonQuestionsCache.ContainsKey(question))
            {
                Console.WriteLine("The answer is in the chache");
                return _commonQuestionsCache[question];
            }
            if(!CheckUserAccess())
            {
                return "برای مشاوره تخصصی باید اشتراک ویژه داشته باشید";
            }
            if(_realDoctor == null)
            {
                _realDoctor = new RealDoctor();
            }

            return _realDoctor.AnswerMedicalQuestion(question);
        }

        private bool CheckUserAccess()
        {
            Console.WriteLine("بررسی سطح دسترسی کاربر...");
            return new Random().Next(0, 2) == 1; // تصادفی true/false
        }
    }
}