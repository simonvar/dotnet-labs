using System.Collections.Generic;
using Domain.Gateway;
using Domain.Interactor;
using Domain.Models;
using Moq;
using Xunit;

namespace DomainTest {
    public class LoadStocksInteractorTest {
        private readonly Mock<IStocksGateway> _emptyGateway = new Mock<IStocksGateway>();

        private readonly List<Stock> _list = new List<Stock> {
            new Stock {City = "city1"},
            new Stock {City = "city2"},
        };

        private readonly Mock<IStocksGateway> _listGateway = new Mock<IStocksGateway>();


        public LoadStocksInteractorTest() {
            _emptyGateway
                .Setup(it => it.GetAll())
                .Returns(new List<Stock>());

            _listGateway
                .Setup(it => it.GetAll())
                .Returns(_list);
        }


        [Fact]
        public void EmptyResult() {
            var interactor = new LoadStocksInteractor(_emptyGateway.Object);
            var result = interactor.Execute();
            Assert.Empty(result);
        }

        [Fact]
        public void ListResult() {
            var interactor = new LoadStocksInteractor(_listGateway.Object);
            var result = interactor.Execute();
            Assert.Equal(_list, result);
        }
    }
}