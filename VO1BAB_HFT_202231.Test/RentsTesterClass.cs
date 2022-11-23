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
    class RentsTesterClass
    {
        RentsLogic logic;
        Mock<IRepository<Rents>> mockRentsRepo;
        List<Rents> rentslist;

        [SetUp]
        public void Init()
        {
            rentslist = new List<Rents>()
            {
                new Rents()
                {
                    RentId = 1,
                    OwnerName = "Kiss Attila",
                    RentTime = "2001-06-22",
                    CarsID = 1,
                    cars = new Cars()
                    {
                        CarBrandID = 1,
                        CarsID = 1,
                        LicensePlateNumber = "ABC-123",
                        PerformanceInHP = 400,
                        Type = "AMG",
                        Year = 2010,
                        CarBrand = new CarBrand()
                        {
                            CarBrandID = 1,
                            Name = "Mercedes-Benz"
                        }
                    }
                }
            };
            mockRentsRepo = new Mock<IRepository<Rents>>();
            mockRentsRepo.Setup(x => x.ReadAll()).Returns(() => rentslist.AsQueryable());
            logic = new RentsLogic(mockRentsRepo.Object);
        }

        [Test]
        public void TheRentsCarBrandTest()
        {
            var actual = logic.TheRentsCarBrand().ToList();
            var excepted = new List<string>
            {
                "Mercedes-Benz"
            };
            Assert.AreEqual(excepted, actual);
        }

        [Test]
        public void BrandperRentsCountsMethod()
        {
            var actual = logic.BrandperRentsCountsMethod().ToList();
            var excepted = new List<BrandperRentsCount>
            {
                new BrandperRentsCount()
                {
                    brand = "Mercedes-Benz",
                    count = 1
                }
            };
            Assert.AreEqual(excepted, actual);
        }

        [Test]
        public void NotEqualsTest()
        {
            var actual = logic.ReadAll().ToList();
            var excepted = new List<Rents>
            {
                 new Rents()
                {
                    RentId = 3,
                    OwnerName = "Kiss Attila",
                    RentTime = "2001-06-22",
                    CarsID = 1,
                    cars = new Cars()
                    {
                        CarBrandID = 1,
                        CarsID = 1,
                        LicensePlateNumber = "ABC-123",
                        PerformanceInHP = 400,
                        Type = "AMG",
                        Year = 2010,
                        CarBrand = new CarBrand()
                        {
                            CarBrandID = 1,
                            Name = "Mercedes-Benz"
                        }
                    }
                }
            };
            Assert.AreNotEqual(excepted, actual);
        }
    }
}
