namespace PIS
{
    public static class Rules
    {
        public static IRule[] GetRules()
        {
            return new IRule[] { new Rule1(), new Rule2() };
        }
    }
}
