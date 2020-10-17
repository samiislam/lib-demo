using System;
using System.Text;

namespace mylib
{
    public class ClassLib
    {
        public string Call(string caller)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{caller}: I love you!");
            sb.AppendLine("Jill: I love you too!");
            //sb.AppendLine("Amy: I love you too!");
            return sb.ToString();
        }
    }
}
