# ZombieDice
# game explanation: https://boardgamegeek.com/boardgame/62871/zombie-dice
# expansion rules: https://boardgamegeek.com/boardgame/110279/zombie-dice-2-double-feature

The base game and it's expansion are implemented as a .NET application, in one package. Expansion can be turned on/off dynamically. It relies on the base solution and non-invasively enriches the behavior of the base solution, to include the new functionalities that the extension brings.

Implementation also uses the method of extracting the SDK (software development kit), which is needed to enable the interoperability of the software and its parts.
