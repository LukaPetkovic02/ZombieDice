namespace DieSDK
{
    public class RollResult : IColor, IValue
    {
        public IColor Color { get; private set; }
        public IValue Value { get; private set; }

        public RollResult(IColor color, IValue value)
        {
            Color = color;
            Value = value;
        }

        public string DisplayDie()
        {
            string color = GetColorName();
            string value = GetValueName();

            return $"../../../images/{color}_{value}.png";
        }
        private string GetColorName()
        {
            string typeName = Color.GetType().Name;
            return typeName[..^5].ToLower();
        }

        private string GetValueName()
        {
            string typeName = Value.GetType().Name;
            return typeName[..^5].ToLower();
        }
    }
}
