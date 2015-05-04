using System;

namespace IoCContainer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //var printer = new Printer();
            //var stringWriter = new StringWriter(printer);
            //stringWriter.WriteString("Hello World");
            
            //var hardDisk = new HardDisk();
            //stringWriter = new StringWriter(hardDisk);
            //stringWriter.WriteString("Hello World");

            //var dependencyResolver = new DependencyResolver();
            //var output = dependencyResolver.ResolveOutput();
            //var stringWriter = new StringWriter(output);
            //stringWriter.WriteString("Hello World");

            var dependencyResolver = new DependencyResolver();
            dependencyResolver.Register<StringWriter, StringWriter>();
            dependencyResolver.Register<IOutput, HardDisk>();
       
            var stringWriter = dependencyResolver.Resolve<StringWriter>();
            stringWriter.WriteString("Hello World");

            Console.ReadKey();
        }
    }
}
