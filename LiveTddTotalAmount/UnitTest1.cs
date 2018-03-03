using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;
using System.Collections.Generic;

namespace LiveTddTotalAmount
{
    [TestClass]
    public class TotalAmountTests
    {
        [TestMethod]
        public void no_budgets()
        {
            var repository = Substitute.For<IRepository<Budget>>();
            repository.GetAll().Returns(new List<Budget>());

            var accouting = new Accouting(repository);
            var totalAmount = accouting.TotalAmount(new DateTime(2018, 4, 1), new DateTime(2018, 4, 1));
            Assert.AreEqual(0, totalAmount);
        }
    }

    public interface IRepository<T>
    {
        List<T> GetAll();
    }

    public class Budget
    {
    }
}