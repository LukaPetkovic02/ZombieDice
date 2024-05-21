namespace DieSDK
{
    public sealed class Die
    {
        public IColor Color { get; }
        //public IValue Value { get; }
        public Die(IColor color, IValue[] values)
        {
            Color = color;
            this.values = values;
        }
        private const int NumberOfSides = 6;

        private readonly IValue[] values;
        

        public RollResult Roll()
        {
            IValue rolledValue = GetRandomDieValue();
            return new RollResult(Color, rolledValue, this);
        }
        private IValue GetRandomDieValue()
        {
            return values[RandomGenerator.Instance.Next(NumberOfSides)];
        }
    }
}
