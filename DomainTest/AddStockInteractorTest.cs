using System;
using Domain.Gateway;
using Domain.Interactor;
using Domain.Models;
using Moq;
using Xunit;

namespace DomainTest {
    public class AddStockInteractorTest {
        private readonly Mock<IStocksGateway> _gateway = new Mock<IStocksGateway>();

        public AddStockInteractorTest() {
            _gateway
                .Setup(it => it.AddStock(It.IsAny<String>()))
                .Returns(10);
        }


        [Fact]
        public void IdEqualsResult() {
            var interactor = new AddStockInteractor(_gateway.Object);
            var result = interactor.Execute("city");
            var id = 10;
            Assert.Equal(result, id);
        }
    }
}