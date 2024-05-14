namespace DieSDK
{
    public sealed class Values
    {
        public static IValue Shotgun { get; } = new ShotgunValue();
        public static IValue Step { get; } = new StepValue();
        public static IValue Brain { get; } = new BrainValue();
    }
}
