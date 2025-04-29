namespace PatternsInCSharp02.BridgePattern
{
    public interface IRemoteControl
    {
        string Excecute();
    }

    public class SimpleRemote : IRemoteControl
    {
        public string Excecute()
        {
            return "اجرای دستور با ریموت ساده (روشن/خاموش)";
        }
    }

    public class SmartRemote : IRemoteControl
    {
        public string Excecute()
        {
            return "اجرای دستور با ریموت هوشمند (تنظیمات پیشرفته)";
        }
    }

    public class VoiceRemote : IRemoteControl
    {
        public string Excecute()
        {
            return "اجرای دستور با ریموت صوتی (دستور صوتی)";
        }
    }

    public abstract class Gadget
    {
        protected IRemoteControl _remoteControl;
        public Gadget(IRemoteControl remoteControl)
        {
            _remoteControl = remoteControl;
        }

        public abstract string Operate();
        public string Control()
        {
            return _remoteControl.Excecute();
        }
    }

    public class Lamp : Gadget
    {
        public Lamp(IRemoteControl remoteControl) : base(remoteControl)
        {
        }

        public override string Operate()
        {
            return "لامپ روشن یا خاموش شد";
        }
    }
}