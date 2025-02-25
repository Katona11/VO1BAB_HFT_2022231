﻿using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using VO1BAB_HFT_202231.Logic;
using VO1BAB_HFT_202231.Models;
using VO1BAB_HFT_202231.Repository;
using static VO1BAB_HFT_202231.Logic.CarsLogic;

namespace VO1BAB_HFT_202231.Test
{
    [TestFixture]
    public class CreateTesterClass
    {
        CarsLogic logic;
        CarBrandLogic carbrandlogic;
        RentsLogic rentlogic;
        Mock<IRepository<Cars>> mockCarRepo;
        Mock<IRepository<CarBrand>> carbrandrepo;
        Mock<IRepository<Rents>> rentsrepo;


        [SetUp]
       public void Init()
       {
            mockCarRepo = new Mock<IRepository<Cars>>();
            mockCarRepo.Setup(m => m.ReadAll()).Returns(new List<Cars>()
            {
                new Cars("1,1,E60,HFG-434,2004,310"),
                new Cars("2,2,AMG,YYY-444,2020,674"),
                new Cars("1,3,Audi,XXX-444,2022,400")
            }.AsQueryable());
            logic = new CarsLogic(mockCarRepo.Object);

            carbrandrepo = new Mock<IRepository<CarBrand>>();
            carbrandrepo.Setup(m => m.ReadAll()).Returns(new List<CarBrand>()
            {
                new CarBrand("1,Mercedes"),
                new CarBrand("2,Audi")
            }.AsQueryable());

            rentsrepo = new Mock<IRepository<Rents>>();
            rentsrepo.Setup(m => m.ReadAll()).Returns(new List<Rents>()
            {
                new Rents("1,2022-06-22,Katona István,1"),
                new Rents("2,2022-03-11,Kiss Bécy,2")
            }.AsQueryable());


            carbrandlogic = new CarBrandLogic(carbrandrepo.Object);
            rentlogic = new RentsLogic(rentsrepo.Object);

        }

        [Test]
        public void CreateCarTest()
        {
            try
            {
                var car = new Cars()
                {
                    Year = 2000,
                    CarBrandID = 1,
                    CarsID = 3,
                    PerformanceInHP = 500,
                    Type = "Amg",
                    LicensePlateNumber = "ABC-123"


                };
                logic.Create(car);
                mockCarRepo.Verify(r => r.Create(car), Times.Once);
            }
            catch (Exception)
            {

            }


}

        [Test]
        public void CreateCarBrandTest()
        {
            try
            {
                var carbrand = new CarBrand()
                {
                    Name = "Suzuki",
                    CarBrandID = 3


                };
                carbrandlogic.Create(carbrand);
                carbrandrepo.Verify(r => r.Create(carbrand), Times.Once);
            }
            catch (Exception)
            {


            }


        }

        [Test]
        public void CreateRentsTest()
        {
            try
            {
                var car = new Rents()
                {
                    OwnerName = "Kiss Attila",
                    RentId = 2,
                    CarsID = 1,
                    RentTime = "2002-05-22"


                };
                rentlogic.Create(car);
                rentsrepo.Verify(r => r.Create(car), Times.Once);
            }
            catch (Exception)
            {


            }


        }

        [Test]
        public void YearStaicsTest()
        {
            var actual = rentlogic.YearStatistics().ToList();
            var excepted = new List<YearInfo>()
            {
                new YearInfo(2022,2)
                
            };
            Assert.AreEqual(excepted, actual);
        }



    }
}
