using DieSDK;

namespace Test
{
    [TestFixture]
    public class DieTests
    {
        [Test]
        public void Die_InitializesWithCorrectColor()
        {
            IColor color = Colors.Green;

            var die = new Die(color,Values.Brain);

            Assert.AreEqual(color, die.Color);
        }

        [Test]
        public void Die_Roll_ReturnsValidRollResult()
        {
            var die = new Die(Colors.Green,Values.Brain);

            var rollResult = die.Roll();

            Assert.IsNotNull(rollResult);
            Assert.AreEqual(Colors.Green, rollResult.Color);
            Assert.IsTrue(rollResult.Value is IValue);
        }
    }
}