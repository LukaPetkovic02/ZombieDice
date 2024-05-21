namespace DieSDK
{
    public class RollResult : IColor, IValue
    {
        public IColor Color { get; private set; }
        public IValue Value { get; private set; }
        public Die Die { get; }

        public RollResult(IColor color, IValue value, Die die)
        {
            Color = color;
            Value = value;
            Die = die;
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
