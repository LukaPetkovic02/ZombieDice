namespace Test
{
    [TestFixture]
    public class DieTests
    {
        [Test]
        public void Die_InitializesWithCorrectColor()
        {
            DIE_COLOR color = DIE_COLOR.GREEN;

            var die = new Die(color);

            Assert.AreEqual(color, die.Color);
        }

        [Test]
        public void Die_Roll_ReturnsValidRollResult()
        {
            var die = new Die(DIE_COLOR.GREEN);

            var rollResult = die.Roll();

            Assert.IsNotNull(rollResult);
            Assert.AreEqual(DIE_COLOR.GREEN, rollResult.Color);
            Assert.IsTrue(Enum.IsDefined(typeof(DIE_VALUE), rollResult.Value));
        }
    }
}