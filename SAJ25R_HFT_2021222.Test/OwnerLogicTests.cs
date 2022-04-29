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
    public class OwnerLogicTests
    {

        [Test]
        public void TestAddOwnerWithCorrectName()
        {
            Mock<IOwnerRepository> ownrepo = new Mock<IOwnerRepository>(MockBehavior.Loose);

            ownrepo.Setup(repo => repo.InsertElement(It.IsAny<Owner>()));
            Owner own = new Owner() { Name = "Kendrick Junior", Address = "TT21", Age = 26, Job = "Architect" };
            OwnerLogic logic = new OwnerLogic(ownrepo.Object);

            logic.AddOwner(own);

            Assert.That(own.Name, Is.EqualTo("Kendrick Junior"));
            ownrepo.Verify(repo => repo.InsertElement(own), Times.Once);
        }

        [Test]
        public void TestAddOwnerWithIncorrectName()
        {
            Mock<IOwnerRepository> ownrepo = new Mock<IOwnerRepository>(MockBehavior.Loose);

            ownrepo.Setup(repo => repo.InsertElement(It.IsAny<Owner>()));
            Owner own = new Owner() { Name = null, Address = "TT21", Age = 26, Job = "Architect" };
            OwnerLogic logic = new OwnerLogic(ownrepo.Object);

            Assert.That(() => logic.AddOwner(own), Throws.TypeOf<NullReferenceException>());
        }


        [Test]
        public void TestGetAllOwner()
        {
            Mock<IOwnerRepository> ownrepo = new Mock<IOwnerRepository>(MockBehavior.Loose);

            List<Owner> owners = new List<Owner>()
            {
                new Owner() { Name = "Smith Jones", Age = 30, OwnerId = 12 },
                new Owner() { Name = "Jacob Garcia", Age = 30, OwnerId = 13 },
                new Owner() { Name = "Kendrick Junior", Age = 30, OwnerId = 14 },
            };
            List<Owner> expectedOwners = new List<Owner>() { owners[0], owners[1], owners[2] };

            ownrepo.Setup(repo => repo.GetAll()).Returns(owners.AsQueryable());
            OwnerLogic logic = new OwnerLogic(ownrepo.Object);

            var result = logic.GetAllOwners();
            Assert.That(result, Is.EquivalentTo(expectedOwners));
            ownrepo.Verify(repo => repo.GetAll(), Times.Once);
        }

        [Test]
        public void TestOwnersGuns()
        {

            Mock<IOwnerRepository> ownrepo = new Mock<IOwnerRepository>(MockBehavior.Loose);
            Mock<IGunRepository> gunrepo = new Mock<IGunRepository>(MockBehavior.Loose);


            List<Owner> owners = new List<Owner>()
            {
                new Owner() { OwnerId = 10, Job = "Butcher", Age = 40, Name = "Joe Riley", },
                new Owner() { OwnerId = 23, Job = "Manager", Age = 53, Name = "Adam Smith" },
                new Owner() { OwnerId = 31, Job = "Vet", Age = 31, Name = "Jack Ryan" },
            };

            List<Gun> guns = new List<Gun>()
            {
                new Gun() { SerialNumber = 123456, Price = 3000, GunName = "M4", OwnerId = 10 },
                new Gun() { SerialNumber = 123457, Price = 800, GunName = "Colt", OwnerId = 23 },
                new Gun() { SerialNumber = 123458, Price = 1200, GunName = "Ak47", OwnerId = 31 },
                new Gun() { SerialNumber = 123459, Price = 2500, GunName = "MP5", OwnerId = 10 },
                new Gun() { SerialNumber = 123410, Price = 950, GunName = "Magnum", OwnerId = 23 },
            };

            List<OwnersGuns> expected = new List<OwnersGuns>()
            {
                new OwnersGuns() { OwnName = "Joe Riley", Guns = new List<string>() { "M4", "MP5" } },
                new OwnersGuns() { OwnName = "Adam Smith", Guns = new List<string>() { "Colt", "Magnum" } },
                new OwnersGuns() { OwnName = "Jack Ryan", Guns = new List<string>() { "Ak47" } },
            };

            ownrepo.Setup(repo => repo.GetAll()).Returns(owners.AsQueryable());
            gunrepo.Setup(repo => repo.GetAll()).Returns(guns.AsQueryable());

            OwnerLogic ownerLogic = new OwnerLogic(ownrepo.Object);

            var result = ownerLogic.OwnsGuns();

            Assert.That(result, Is.EqualTo(expected));
        }

    }
}
