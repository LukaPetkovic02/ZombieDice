namespace Test
{
    [TestFixture]
    public class RollTests
    {
        [Test]
        public void DrawDiceFromCup_ReturnsCorrectNumberOfDice()
        {
            // Arrange
            var roll = new Roll();
            int numberOfDiceToDraw = 3;

            // Act
            var drawnDice = roll.DrawDiceFromCup(numberOfDiceToDraw);

            // Assert
            Assert.AreEqual(numberOfDiceToDraw, drawnDice.Count);
            Assert.IsTrue(drawnDice.All(die => die.Color == DIE_COLOR.GREEN || die.Color == DIE_COLOR.YELLOW || die.Color == DIE_COLOR.RED));
        }

        [Test]
        public void RollDice_PopulatesResults()
        {
            // Arrange
            var roll = new Roll();
            var diceToRoll = roll.DrawDiceFromCup(3);

            // Act
            var diceResults = roll.RollDice(diceToRoll);

            // Assert
            Assert.AreEqual(3, roll.Brains.Count + roll.Runners.Count + roll.Shotguns.Count);
            Assert.AreEqual(diceToRoll.Count, diceResults.Count);
        }

        [Test]
        public void ReturnAllBrainsToCup_ReturnsBrainsToCup()
        {
            // Arrange
            var roll = new Roll();
            var diceToRoll = roll.DrawDiceFromCup(3);
            roll.RollDice(diceToRoll);

            // Act
            roll.returnAllBrainsToCup();

            // Assert
            Assert.AreEqual(0, roll.Brains.Count); // Check if Brains list is cleared
        }
    }
}
