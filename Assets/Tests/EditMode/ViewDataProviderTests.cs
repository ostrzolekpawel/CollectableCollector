using Moq;
using NUnit.Framework;
using System;

namespace OsirisGames.CollectableCollector.Tests
{
    public class ViewDataProviderTests
    {
        [Test]
        public void GetViewData_Invoked_Once()
        {
            // Arrange
            var viewDataMock = new Mock<IViewData<string, int>>();
            var provider = new Mock<ViewDataProvider<int, string, int>>();
            int type = 123;
            string data = "Some Reward";
            provider.Object.Add(type, viewDataMock.Object);

            // Act
            provider.Object.GetViewData(type, data);

            // Assert
            viewDataMock.Verify(collector => collector.GetViewData(data), Times.Once);
        }

        [Test]
        public void Add_ExistingType_ThrowsError()
        {
            // Arrange
            var viewDataMock = new Mock<IViewData<string, int>>();
            var provider = new Mock<ViewDataProvider<int, string, int>>();
            int type = 123;
            provider.Object.Add(type, viewDataMock.Object);

            // Act & Assert
            Assert.Throws<ArgumentException>(() => provider.Object.Add(type, viewDataMock.Object));
        }

        [Test]
        public void GetViewData_NotExistingType_ThrowsError()
        {
            // Arrange
            var provider = new Mock<ViewDataProvider<int, string, int>>();
            int type = 123;
            string data = "Some Reward";

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => provider.Object.GetViewData(type, data));
        }
    }
}