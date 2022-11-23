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
    class CarBrandTesterClass
    {
        CarBrandLogic logic;
        Mock<IRepository<CarBrand>> mockCarBrandrepo;
        List<CarBrand> carbrandlist;

        [SetUp]
        public void Init()
        {

            carbrandlist = new List<CarBrand>
            {
                new CarBrand()
                {
                    Name = "Audi",
                    CarBrandID = 1,
                    Cars = new List<Cars>()
                    {
                       new Cars()
                       {
                       CarBrandID = 1,
                       CarsID = 1,
                       Type = "S8",
                       LicensePlateNumber = "ABC-123",
                       PerformanceInHP = 500,
                       Year = 2011,
                       AllRents = new List<Rents>()
                       {
                           new Rents()
                           {
                               CarsID = 1,
                               RentId = 1,
                               RentTime = "2006-11-21",
                               OwnerName = "Nagy Attila"
                               
                           }
                       }
                       
                       }
                    }

                }
            };
            mockCarBrandrepo = new Mock<IRepository<CarBrand>>();
            mockCarBrandrepo.Setup(t => t.ReadAll()).Returns(() => carbrandlist.AsQueryable());
            logic = new CarBrandLogic(mockCarBrandrepo.Object);


        }

        [Test]
        public void NotEqualTest()
        {
            var actual = logic.ReadAll().ToList();
            var excepted = new List<CarBrand>
            {
                new CarBrand()
                {
                    Name = "Opel",
                    CarBrandID = 2,
                    Cars = new List<Cars>()
                    {
                       new Cars()
                       {
                       CarBrandID = 1,
                       CarsID = 1,
                       Type = "S8",
                       LicensePlateNumber = "ABC-123",
                       PerformanceInHP = 500,
                       Year = 2011,
                       AllRents = new List<Rents>()
                       {
                           new Rents()
                           {
                               CarsID = 1,
                               RentId = 1,
                               RentTime = "2006-11-21",
                               OwnerName = "Nagy Attila"

                           }
                       }

                       }
                    }

                }
            };
            Assert.AreNotEqual(excepted, actual);
        }


    }
}
