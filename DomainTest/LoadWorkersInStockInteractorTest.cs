﻿using System.Collections.Generic;
using Domain.Gateway;
using Domain.Interactor;
using Domain.Models;
using Moq;
using Xunit;

namespace DomainTest {
    public class LoadWorkersInStockInteractorTest {
        private readonly Mock<IWorkersGateway> _emptyGateway = new Mock<IWorkersGateway>();

        private readonly List<Worker> _list = new List<Worker> {
            new Worker {Id = 0, Salary = 10.0},
            new Worker {Id = 1, Salary = 15.0},
        };

        private readonly Mock<IWorkersGateway> _listGateway = new Mock<IWorkersGateway>();


        public LoadWorkersInStockInteractorTest() {
            _emptyGateway
                .Setup(it => it.GetInStock(0))
                .Returns(new List<Worker>());

            _listGateway
                .Setup(it => it.GetInStock(1))
                .Returns(_list);
        }


        [Fact]
        public void EmptyResult() {
            var interactor = new LoadWorkersInStockInteractor(_emptyGateway.Object);
            var result = interactor.Execute(0);
            Assert.Empty(result);
        }

        [Fact]
        public void ListResult() {
            var interactor = new LoadWorkersInStockInteractor(_listGateway.Object);
            var result = interactor.Execute(1);
            Assert.Equal(_list, result);
        }
    }
}