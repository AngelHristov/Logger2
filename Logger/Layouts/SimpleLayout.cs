namespace LoggerLibrary.Layouts
{
    using Layouts.Contracts;

    /// <summary>
    /// define the format in which messages should be appended
    /// </summary>

    public class SimpleLayout : ILayout
    {
        public string Format => "{0} - {1} - {2}";
    }
}
