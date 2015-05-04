using System;

namespace IoCContainer
{
    public class HardDisk : IOutput
    {
        public void Write(string output)
        {
            Console.WriteLine("Writing {0} to HardDisk", output);
        }
    }
}
