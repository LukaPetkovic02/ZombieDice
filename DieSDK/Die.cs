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
    }
}
