namespace DieSDK
{
    public sealed class Colors
    {
        public static IColor Red { get; } = new RedColor();
        public static IColor Yellow { get; } = new YellowColor();
        public static IColor Green { get; } = new GreenColor();
    }
}
