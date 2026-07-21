using System;
using NUnit.Framework;
using Moq;
using PlayersManagerLib;

namespace PlayerManager.Tests
{
    [TestFixture]
    public class PlayerManagerTests
    {
        private Mock<IPlayerMapper> _mockPlayerMapper;

        [SetUp]
        public void Init()
        {
            _mockPlayerMapper = new Mock<IPlayerMapper>();
        }

        [Test]
        [TestCase] // Using TestCase attribute as requested in Task 2
        public void RegisterNewPlayer_NameDoesNotExist_ReturnsPlayerWithCorrectAttributes()
        {
            // Arrange
            string newPlayerName = "Koushal";
            _mockPlayerMapper
                .Setup(m => m.IsPlayerNameExistsInDb(newPlayerName))
                .Returns(false);
            
            // Act
            Player player = Player.RegisterNewPlayer(newPlayerName, _mockPlayerMapper.Object);

            // Assert
            Assert.That(player, Is.Not.Null);
            Assert.That(player.Name, Is.EqualTo(newPlayerName));
            Assert.That(player.Age, Is.EqualTo(23));
            Assert.That(player.Country, Is.EqualTo("India"));
            Assert.That(player.NoOfMatches, Is.EqualTo(30));

            // Verify mapper was invoked correctly
            _mockPlayerMapper.Verify(m => m.IsPlayerNameExistsInDb(newPlayerName), Times.Once);
            _mockPlayerMapper.Verify(m => m.AddNewPlayerIntoDb(newPlayerName), Times.Once);
        }

        [Test]
        [TestCase]
        public void RegisterNewPlayer_NameAlreadyExists_ThrowsArgumentException()
        {
            // Arrange
            string existingPlayerName = "John";
            _mockPlayerMapper
                .Setup(m => m.IsPlayerNameExistsInDb(existingPlayerName))
                .Returns(true);

            // Act & Assert
            // Note: Modern NUnit 3+ and NUnit 4 do not support the legacy [ExpectedException] attribute.
            // Assert.Throws is the modern, compile-safe, and standard way to assert exceptions.
            var ex = Assert.Throws<ArgumentException>(() => 
                Player.RegisterNewPlayer(existingPlayerName, _mockPlayerMapper.Object)
            );

            Assert.That(ex.Message, Is.EqualTo("Player name already exists."));
            _mockPlayerMapper.Verify(m => m.IsPlayerNameExistsInDb(existingPlayerName), Times.Once);
            _mockPlayerMapper.Verify(m => m.AddNewPlayerIntoDb(It.IsAny<string>()), Times.Never);
        }

        [Test]
        [TestCase]
        public void RegisterNewPlayer_EmptyName_ThrowsArgumentException()
        {
            // Act & Assert
            var ex = Assert.Throws<ArgumentException>(() => 
                Player.RegisterNewPlayer("", _mockPlayerMapper.Object)
            );

            Assert.That(ex.Message, Is.EqualTo("Player name can't be empty."));
            _mockPlayerMapper.Verify(m => m.IsPlayerNameExistsInDb(It.IsAny<string>()), Times.Never);
        }
    }
}
