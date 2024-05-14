using DieSDK;

namespace ZombieDice.Model
{
    public enum DIE_COLOR
    {
        RED = 0,
        YELLOW,
        GREEN
    }

    public enum DIE_VALUE
    {
        BRAIN = 0,
        STEP,
        SHOTGUN
    }
    public interface IColor
    {
        DIE_COLOR Color { get; }
    }

    public interface IValue
    {
        DIE_VALUE Value { get; }
    }
    public class Die : IColor
    {
        public DIE_COLOR Color { get; private set; }
        private const int NumberOfSides = 6;

        private static DIE_VALUE[] greenDie = { DIE_VALUE.BRAIN ,DIE_VALUE.BRAIN,DIE_VALUE.BRAIN,DIE_VALUE.STEP,DIE_VALUE.STEP,DIE_VALUE.SHOTGUN};
        private static DIE_VALUE[] yellowDie = { DIE_VALUE.BRAIN, DIE_VALUE.BRAIN, DIE_VALUE.STEP, DIE_VALUE.STEP, DIE_VALUE.SHOTGUN, DIE_VALUE.SHOTGUN };
        private static DIE_VALUE[] redDie = { DIE_VALUE.BRAIN, DIE_VALUE.STEP, DIE_VALUE.STEP, DIE_VALUE.SHOTGUN, DIE_VALUE.SHOTGUN, DIE_VALUE.SHOTGUN };
        public Die(DIE_COLOR color)
        {
            Color = color;
        }

        public RollResult Roll()
        {
            DIE_VALUE rolledValue = GetRandomDieValue();
            return new RollResult(Color, rolledValue);
        }
        private DIE_VALUE GetRandomDieValue()
        {
            switch (Color)
            {
                case DIE_COLOR.GREEN:
                    return greenDie[RandomGenerator.Instance.Next(NumberOfSides)];
                case DIE_COLOR.YELLOW:
                    return yellowDie[RandomGenerator.Instance.Next(NumberOfSides)];
                case DIE_COLOR.RED:
                    return redDie[RandomGenerator.Instance.Next(NumberOfSides)];
                default:
                    return DIE_VALUE.BRAIN;
            }
        }
    }
}
