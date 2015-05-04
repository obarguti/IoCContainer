using System;

namespace IoCContainer
{
    public class Printer : IOutput
    {
        public void Write(string output)
        {
            Console.WriteLine("Writing {0} to Printer", output);
        }
    }
}
