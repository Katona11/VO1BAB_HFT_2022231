using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO1BAB_HFT_202231.Logic;
using VO1BAB_HFT_202231.Models;
using VO1BAB_HFT_202231.Repository;

namespace VO1BAB_HFT_202231.Test
{
    [TestFixture]
    class CarTesterClass
    {
        CarsLogic logic;
        Mock<IRepository<Cars>> mockCarRepo;
        List<Cars> carlist;

        [SetUp]
        public void Init()
        {
            carlist = new List<Cars>()
            {
                new Cars()
                {
                    CarsID = 1,
                    CarBrandID = 1,
                    Year = 2001,
                    Type = "Amg",
                    LicensePlateNumber = "ABC-121",
                    PerformanceInHP = 450,
                    CarBrand = new CarBrand()
                    {
                        CarBrandID = 1,
                        Name = "Mercedes-Benz"
                    },
                    AllRents = new List<Rents>()
                    {
                        new Rents()
                        {
                            RentId = 1,
                            CarsID = 1,
                            OwnerName = "Kiss Attila",
                            RentTime = "2001-06-22"
                        }
                    }
                }
            };
            mockCarRepo = new Mock<IRepository<Cars>>();
            mockCarRepo.Setup(x => x.ReadAll()).Returns(() => carlist.AsQueryable());
            logic = new CarsLogic(mockCarRepo.Object);
        }

        [Test]
        public void AvarageHPperCarTest()
        {
            var actual = logic.AvarageHPperCar().ToList();
            var excepted = new List<AvarageCarHP>
            {
                new AvarageCarHP("Mercedes-Benz",450)
            };
            Assert.AreEqual(excepted, actual);
        }

        [Test]
        public void TheMostFamousBrand()
        {
            var actual = logic.TheMostFamousBrand().ToList();
            var excepted = new List<TheMostFamous>
            {
                new TheMostFamous("Mercedes-Benz",1)
            };
            Assert.AreEqual(excepted, actual);

        }
        
        [Test]
        public void NotEqualTest()
        {
            var actual = logic.ReadAll().ToList();
            var excepted = new List<Cars>()
            {
               new Cars()
               {
                CarsID = 2,
                CarBrandID = 1,
                Year = 2001,
                Type = "Amg",
                LicensePlateNumber = "ABC-121",
                PerformanceInHP = 450,
                CarBrand = new CarBrand()
                {
                    CarBrandID = 1,
                    Name = "Mercedes-Benz"
                },
                AllRents = new List<Rents>()
                    {
                        new Rents()
                        {
                            RentId = 1,
                            CarsID = 1,
                            OwnerName = "Kiss Attila",
                            RentTime = "2001-06-22"
                        }
                    }
               }
            };

            Assert.AreNotEqual(excepted, actual);
        }


    }
}
