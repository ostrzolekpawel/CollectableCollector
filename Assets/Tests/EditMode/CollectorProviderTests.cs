using Moq;
using NUnit.Framework;
using System;

namespace OsirisGames.CollectableHandler.Tests
{
    public class CollectorProviderTests
    {
        [Test]
        public void Collect_Invoked_Once()
        {
            // Arrange
            var collectorMock = new Mock<ICollector<string, int>>();
            var provider = new Mock<CollectorProvider<int, string, int>>();
            int type = 123;
            string reward = "Some Reward";
            int view = 456;
            provider.Object.Add(type, collectorMock.Object);

            // Act
            provider.Object.Collect(type, reward, view);

            // Assert
            collectorMock.Verify(collector => collector.Collect(reward, view), Times.Once);
        }

        [Test]
        public void Add_ExistingType_ThrowsError()
        {
            // Arrange
            var collectorMock = new Mock<ICollector<string, int>>();
            var provider = new Mock<CollectorProvider<int, string, int>>();
            int type = 123;
            provider.Object.Add(type, collectorMock.Object);

            // Act & Assert
            Assert.Throws<ArgumentException>(() => provider.Object.Add(type, collectorMock.Object));
        }

        [Test]
        public void Collect_NotExistingType_ThrowsError()
        {
            // Arrange
            var provider = new Mock<CollectorProvider<int, string, int>>();
            int type = 123;
            string reward = "Some Reward";
            int view = 456;

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => provider.Object.Collect(type, reward, view));
        }
    }
}