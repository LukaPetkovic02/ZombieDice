namespace Test
{
    [TestFixture]
    public class DieTests
    {
        [Test]
        public void Roll_GreenDie_ShouldSetValidValue()
        {
            Die die = new Die(DIE_COLOR.GREEN);

            die.Roll();

            Assert.That(die.Value, Is.EqualTo(DIE_VALUE.BRAIN)
                .Or.EqualTo(DIE_VALUE.STEP)
                .Or.EqualTo(DIE_VALUE.SHOTGUN));
        }

        [Test]
        public void Roll_YellowDie_ShouldSetValidValue()
        {
            Die die = new Die(DIE_COLOR.YELLOW);

            die.Roll();

            Assert.That(die.Value, Is.EqualTo(DIE_VALUE.BRAIN)
                .Or.EqualTo(DIE_VALUE.STEP)
                .Or.EqualTo(DIE_VALUE.SHOTGUN));
        }

        [Test]
        public void Roll_RedDie_ShouldSetValidValue()
        {
            Die die = new Die(DIE_COLOR.RED);

            die.Roll();

            Assert.That(die.Value, Is.EqualTo(DIE_VALUE.BRAIN)
                .Or.EqualTo(DIE_VALUE.STEP)
                .Or.EqualTo(DIE_VALUE.SHOTGUN));
        }
    }
}