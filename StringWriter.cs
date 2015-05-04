namespace IoCContainer
{
    public class StringWriter
    {
        private readonly IOutput _output;

        public StringWriter(IOutput output)
        {
            _output = output;
        }

        public void WriteString(string value)
        {
            _output.Write(value);   
        }
    }
}
