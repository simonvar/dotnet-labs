using System.Collections.Generic;
using Domain.Gateway;
using Domain.Interactor;
using Domain.Models;
using Moq;
using Xunit;

namespace DomainTest {
    public class AddProductsInStockInteractorTest {
        private readonly Mock<IProductsGateway> _gateway = new Mock<IProductsGateway>();

        public AddProductsInStockInteractorTest() {
            _gateway
                .Setup(it => it.AddInStock(It.IsAny<Product>(), 0))
                .Returns(100);
        }


        [Fact]
        public void IdEqualsResult() {
            var interactor = new AddProductInStockInteractor(_gateway.Object);
            var product = new Product {Id = 100, Price = 100.0};
            var result = interactor.Execute(product, 0);
            Assert.Equal(result, product.Id);
        }
    }
}