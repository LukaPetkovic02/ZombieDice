namespace DieSDK
{
    public sealed class Die
    {
        public IColor Color { get; }
        public IValue Value { get; }
        public Die(IColor color, IValue value)
        {
            Color = color;
            Value = value;
        }
        private const int NumberOfSides = 6;

        private static IValue[] greenDie = { Values.Brain, Values.Brain, Values.Brain, Values.Step, Values.Step, Values.Shotgun };
        private static IValue[] yellowDie = { Values.Brain, Values.Brain, Values.Step, Values.Step, Values.Shotgun, Values.Shotgun };
        private static IValue[] redDie = { Values.Brain, Values.Step, Values.Step, Values.Shotgun, Values.Shotgun, Values.Shotgun };

        public RollResult Roll()
        {
            IValue rolledValue = GetRandomDieValue();
            return new RollResult(Color, rolledValue);
        }
        private IValue GetRandomDieValue()
        {
            switch (Color)
            {
                case GreenColor:
                    return greenDie[RandomGenerator.Instance.Next(NumberOfSides)];
                case YellowColor:
                    return yellowDie[RandomGenerator.Instance.Next(NumberOfSides)];
                case RedColor:
                    return redDie[RandomGenerator.Instance.Next(NumberOfSides)];
                default:
                    return Values.Brain;
            }
        }
    }
}
