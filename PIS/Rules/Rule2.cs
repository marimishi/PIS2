using System;

namespace PIS
{
    public class Rule2 : IRule
    {
        public string purpose { get; } = "Отметка в качестве участника Государственной программы переселения соотечественников";
        public string[] messages { get; } = new string[] { "Вам необходимо прибыть для постановки на учет в качестве участника Государственной программы в Управление по вопросам миграции МВД России (предварительно записаться)" };
        public bool Check(User user)
        {
            return user.visitpurpose == purpose;
        }
    }
}
