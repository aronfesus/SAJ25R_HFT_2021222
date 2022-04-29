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
    public class GunLogicTests
    {

        [Test]
        [TestCase(null)]
        public void TestAddGunWithNullName(string input)
        {
            Mock<IGunRepository> gunrepo = new Mock<IGunRepository>(MockBehavior.Loose);
            Mock<IOwnerRepository> ownrepo = new Mock<IOwnerRepository>(MockBehavior.Loose);

            gunrepo.Setup(repo => repo.InsertElement(It.IsAny<Gun>()));
            Gun gun = new Gun() { GunName = input, Caliber = "7.62", OwnerId = 2 };
            GunLogic logic = new GunLogic(gunrepo.Object, ownrepo.Object);

            Assert.That(() => logic.AddGun(gun), Throws.TypeOf<NullReferenceException>());
        }

        [Test]
        [TestCase("AK47")]
        public void TestAddGunWithCorrectName(string input)
        {
            Mock<IGunRepository> gunrepo = new Mock<IGunRepository>(MockBehavior.Loose);
            Mock<IOwnerRepository> ownrepo = new Mock<IOwnerRepository>(MockBehavior.Loose);

            gunrepo.Setup(repo => repo.InsertElement(It.IsAny<Gun>()));
            Gun gun = new Gun() { GunName = input, Caliber = "7.62", OwnerId = 2 };
            GunLogic logic = new GunLogic(gunrepo.Object, ownrepo.Object);

            Assert.That(() => logic.AddGun(gun), Throws.Nothing);
        }


      

        [Test]
        public void TestRemoveGun()
        {

            Mock<IOwnerRepository> ownrepo = new Mock<IOwnerRepository>(MockBehavior.Loose);
            Mock<IGunRepository> gunrepo = new Mock<IGunRepository>(MockBehavior.Loose);

            List<Gun> guns = new List<Gun>()
            {
                new Gun() { SerialNumber = 184284, Caliber = ".56 NATO" },
                new Gun() { SerialNumber = 184285, Caliber = ".45 ACP" },
                new Gun() { SerialNumber = 184286, Caliber = "223 REM" },
            };
            gunrepo.Setup(rep => rep.GetById(184286)).Returns(guns[2]);
            GunLogic logic = new GunLogic(gunrepo.Object, ownrepo.Object);

            logic.RemoveGunById(184286);
            gunrepo.Verify(repo => repo.RemoveById(184286), Times.Once);
        }


        [Test]
        public void GunsOwners()
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

            List<GunsOwners> expected = new List<GunsOwners>()
            {
                new GunsOwners() { SerialNumber = 123456, OwnName = "Joe Riley" },
                new GunsOwners() { SerialNumber = 123457, OwnName = "Adam Smith" },
                new GunsOwners() { SerialNumber = 123458,  OwnName = "Jack Ryan" },
                new GunsOwners() { SerialNumber = 123459, OwnName = "Joe Riley" },
                new GunsOwners() { SerialNumber = 123410, OwnName = "Adam Smith" },
            };

            ownrepo.Setup(repo => repo.GetAll()).Returns(owners.AsQueryable());
            gunrepo.Setup(repo => repo.GetAll()).Returns(guns.AsQueryable());

            GunLogic gunLogic = new GunLogic(gunrepo.Object, ownrepo.Object);

            var result = gunLogic.GunsOwns();

            Assert.That(result, Is.EqualTo(expected));


        }

    }
}
