using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;
using System.Linq;

namespace LiveTddTotalAmount
{
    [TestClass]
    public class TotalAmountTests
    {
        private IRepository<Budget> _repository = Substitute.For<IRepository<Budget>>();
        private Accouting _accouting;

        [TestInitialize]
        public void TestInit()
        {
            _accouting = new Accouting(_repository);
        }

        [TestMethod]
        public void no_budgets()
        {
            GivenBudgets();
            TotalAmountShouldBe(0, new DateTime(2018, 4, 1), new DateTime(2018, 4, 1));
        }

        private void GivenBudgets(params Budget[] budgets)
        {
            _repository.GetAll().Returns(budgets.ToList());
        }

        private void TotalAmountShouldBe(int expected, DateTime startDate, DateTime endDate)
        {
            Assert.AreEqual(expected, _accouting.TotalAmount(startDate, endDate));
        }
    }
}