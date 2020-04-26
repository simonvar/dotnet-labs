using System.Collections.Generic;
using Domain.Gateway;
using Domain.Interactor;
using Domain.Models;
using Moq;
using Xunit;

namespace DomainTest {
    public class LoadProductsInStockInteractorTest {
        private readonly Mock<IProductsGateway> _emptyGateway = new Mock<IProductsGateway>();

        private readonly List<Product> _list = new List<Product> {
            new Product {Id = 0, Price = 10.0},
            new Product {Id = 1, Price = 15.0},
        };

        private readonly Mock<IProductsGateway> _listGateway = new Mock<IProductsGateway>();


        public LoadProductsInStockInteractorTest() {
            _emptyGateway
                .Setup(it => it.GetInStock(0))
                .Returns(new List<Product>());

            _listGateway
                .Setup(it => it.GetInStock(1))
                .Returns(_list);
        }


        [Fact]
        public void EmptyResult() {
            var interactor = new LoadProductsInStockInteractor(_emptyGateway.Object);
            var result = interactor.Execute(0);
            Assert.Empty(result);
        }

        [Fact]
        public void ListResult() {
            var interactor = new LoadProductsInStockInteractor(_listGateway.Object);
            var result = interactor.Execute(1);
            Assert.Equal(_list, result);
        }
    }
}