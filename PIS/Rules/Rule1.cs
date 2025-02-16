using System;

namespace PIS
{
    public class Rule1 : IRule
    {
        public string purpose { get; } = "Участвую в государственной программе";
        public string[] messages { get; } = new string[] { "Вам необходимо обратиться в Управление по вопросам миграции МВД России (предварительно записаться)" };

        public bool Check(User user)
        {
            return user.visitpurpose == purpose;
        }
    }
}
