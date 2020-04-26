using Domain.Gateway;
using Domain.Interactor;
using Domain.Models;
using Moq;
using Xunit;

namespace DomainTest {
    public class AddWorkerInStockInteractorTest {
        private readonly Mock<IWorkersGateway> _gateway = new Mock<IWorkersGateway>();

        public AddWorkerInStockInteractorTest() {
            _gateway
                .Setup(it => it.AddInStock(It.IsAny<Worker>(), 0))
                .Returns(100);
        }


        [Fact]
        public void IdEqualsResult() {
            var interactor = new AddWorkerInStockInteractor(_gateway.Object);
            var worker = new Worker() {Id = 100, Salary = 100.0};
            var result = interactor.Execute(worker, 0);
            Assert.Equal(result, worker.Id);
        }
    }
}