namespace DieSDK
{
    public sealed class Values
    {
        public static IValue Shotgun { get; } = new ShotgunValue();
        public static IValue Step { get; } = new StepValue();
        public static IValue Brain { get; } = new BrainValue();
        public static IValue DoubleBrain { get; } = new DoubleBrainValue();
        public static IValue DoubleShotgun { get; } = new DoubleShotgunValue();
        public static IValue EnergyDrink { get; } = new EnergyDrinkValue();
        public static IValue Helmet { get; } = new HelmetValue();
    }
}
