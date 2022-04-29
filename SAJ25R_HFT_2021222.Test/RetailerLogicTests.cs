using Moq;
using NUnit.Framework;
using SAJ25R_HFT_2021222.Logic;
using SAJ25R_HFT_2021222.Models.Others;
using SAJ25R_HFT_2021222.Models.Tables;
using SAJ25R_HFT_2021222.Repository.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAJ25R_HFT_2021222.Test
{
    [TestFixture]
    public class RetailerLogicTests
    {
        [Test]
        public void TestAddRetailer()
        {
            Mock<IRetailerRepository> retrepo = new Mock<IRetailerRepository>(MockBehavior.Loose);

            retrepo.Setup(repo => repo.InsertElement(It.IsAny<Retailer>()));
            Retailer ret = new Retailer() { SellerId = 20, DeskId = 6, Name = "Aron" };
            RetailerLogic logic = new RetailerLogic(retrepo.Object);

            logic.AddRetailer(ret);

            Assert.That(ret.DeskId, Is.EqualTo(6));
            retrepo.Verify(repo => repo.InsertElement(ret), Times.Once);
        }

        [Test]
        public void TestGetRetailerById()
        {
            Mock<IRetailerRepository> retrepo = new Mock<IRetailerRepository>(MockBehavior.Loose);

            List<Retailer> rets = new List<Retailer>()
            {
                new Retailer() { SellerId = 10, Position = "Boss" },
                new Retailer() { SellerId = 11, Position = "Seller" },
                new Retailer() { SellerId = 12, Position = "Cashier" },
            };
            retrepo.Setup(repo => repo.GetById(12)).Returns(rets[2]);

            RetailerLogic logic = new RetailerLogic(retrepo.Object);
            Retailer result = logic.GetRetailerById(12);
            Assert.That(result.Position, Is.EqualTo(rets[2].Position));
            retrepo.Verify(repo => repo.GetById(12), Times.Once);
        }

        [Test]
        public void RetailerOwners()
        {
            Mock<IRetailerRepository> retrepo = new Mock<IRetailerRepository>(MockBehavior.Loose);
            Mock<IOwnerRepository> ownrepo = new Mock<IOwnerRepository>(MockBehavior.Loose);

            List<Owner> owners = new List<Owner>()
            {
                new Owner() { OwnerId = 10, Job = "Butcher", Age = 40, Name = "Joe Riley", SellerId = 10 },
                new Owner() { OwnerId = 23, Job = "Manager", Age = 53, Name = "Adam Smith", SellerId = 11 },
                new Owner() { OwnerId = 31, Job = "Vet", Age = 31, Name = "Jack Ryan", SellerId = 12 },
                new Owner() { OwnerId = 42, Job = "Nurse", Age = 23, Name = "Elisabeth Smirlov", SellerId = 13 },
                new Owner() { OwnerId = 43, Job = "Nurse", Age = 23, Name = "Julia Smirlov", SellerId = 13 },
                new Owner() { OwnerId = 47, Job = "Serialkiller", Age = 21, Name = "Big Balias", SellerId = 10 },
            };

            List<Retailer> retailers = new List<Retailer>()
            {
                new Retailer() { Name = "Andrew Hill", SellerId = 10, Salary = 1800 },
                new Retailer() { Name = "Big Joe", SellerId = 11, Salary = 1200 },
                new Retailer() { Name = "Tom Bryan", SellerId = 12, Salary = 1450 },
                new Retailer() { Name = "Oliver Jones", SellerId = 13, Salary = 2000 },
            };

            List<RetailersOwners> expected = new List<RetailersOwners>()
            {
                new RetailersOwners() { RetName = "Andrew Hill", Owners = new List<string>() { "Joe Riley", "Big Balias" } },
                new RetailersOwners() { RetName = "Big Joe", Owners = new List<string>() { "Adam Smith" } },
                new RetailersOwners() { RetName = "Tom Bryan", Owners = new List<string>() { "Jack Ryan" } },
                new RetailersOwners() { RetName = "Oliver Jones", Owners = new List<string>() { "Elisabeth Smirlov", "Julia Smirlov" } },
            };

            ownrepo.Setup(repo => repo.GetAll()).Returns(owners.AsQueryable());
            retrepo.Setup(repo => repo.GetAll()).Returns(retailers.AsQueryable());

            RetailerLogic managerLogic = new RetailerLogic(retrepo.Object);

            var result = managerLogic.RetOwns();

            Assert.That(result, Is.EquivalentTo(expected));
        }
    }
}
