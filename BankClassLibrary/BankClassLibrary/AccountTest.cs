using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace BankClassLibrary
{
    [TestFixture]
    class AccountTest
    {
        AccountClass source;
        AccountClass destination;

        [SetUp]
        public void Init()
        {
            source = new AccountClass();
            source.Deposit(200m);
            destination = new AccountClass();
            destination.Deposit(150m);
        }

        [Test]
        public void TransferFunds()
        {
            source.TransferFunds(destination, 100m);

            Assert.AreEqual(250m, destination.Balance);
            Assert.AreEqual(100m, source.Balance);
        }

        [Test]
        [ExpectedException(typeof(BankClassLibrary.AccountClass.InsufficientFundsException))]
        public void TransferWithInsufficientFunds()
        {
            source.TransferFunds(destination, 300m);
        }

        [Test]
        [Ignore("Decide how to implement transaction management")]
        public void TransferWithInsufficientFundsAtomicity()
        {
            try
            {
                source.TransferFunds(destination, 300m);
            }
            catch (BankClassLibrary.AccountClass.InsufficientFundsException expected)
            {
            }

            Assert.AreEqual(200m, source.Balance);
            Assert.AreEqual(150m, destination.Balance);
        }
    }
}
