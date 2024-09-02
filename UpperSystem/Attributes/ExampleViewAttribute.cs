using System;

namespace UpperSystem
{
    [AttributeUsage(AttributeTargets.Class)]
    public class ExampleViewAttribute : Attribute
    {
        public int Index { get; set; }

        public string DisplayName { get; set; }
    }
}
