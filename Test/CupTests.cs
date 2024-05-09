﻿namespace Test
{
    [TestFixture]
    public class CupTests
    {
        [Test]
        public void PickDie_CupNotEmpty_ReturnsDie()
        {
            List<Die> dice = new List<Die>();
            for (int i = 0; i < 6; i++)
            {
                dice.Add(new Die(DIE_COLOR.GREEN));
            }

            for (int i = 0; i < 4; i++)
            {
                dice.Add(new Die(DIE_COLOR.YELLOW));
            }

            for (int i = 0; i < 3; i++)
            {
                dice.Add(new Die(DIE_COLOR.RED));
            }

            Cup cup = new Cup(dice);

            Die die = cup.PickDie();

            Assert.IsNotNull(die);
            Assert.IsTrue(Enum.IsDefined(typeof(DIE_COLOR), die.Color));
        }

        [Test]
        public void PickDie_CupEmpty_ThrowsInvalidOperationException()
        {
            List<Die> dice = new List<Die>();
            Cup cup = new Cup(dice);

            Assert.Throws<InvalidOperationException>(() => cup.PickDie());
        }

        [Test]
        public void ReturnDiceToCup_AddsDieToCup()
        {
            List<Die> dice = new List<Die>();
            Cup cup = new Cup(dice);
            Die die = new Die(DIE_COLOR.GREEN);

            cup.ReturnDiceToCup(die);

            Assert.Contains(die, cup.dice);
        }
    }
}
