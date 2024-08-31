namespace DieSDK
{
    public sealed class Colors
    {
        public static IColor Red { get; } = new RedColor();
        public static IColor Yellow { get; } = new YellowColor();
        public static IColor Green { get; } = new GreenColor();
        public static IColor Santa { get; } = new SantaColor();
        public static IColor Hottie { get; } = new HottieColor();
        public static IColor Hunk { get; } = new HunkColor();
    }
}
