using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VO1BAB_HFT_202231.Logic;
using static VO1BAB_HFT_202231.Logic.CarsLogic;
using static VO1BAB_HFT_202231.Logic.RentsLogic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VO1BAB_HFT_20231.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class CrudMethodController : ControllerBase
    {
        ICarLogic carlogic;
        IRentsLogic rentlogic;

        public CrudMethodController(ICarLogic carlogic, IRentsLogic rentlogic)
        {
            this.carlogic = carlogic;
            this.rentlogic = rentlogic;
        }

        [HttpGet]
        public IEnumerable<string> TheRentsCarBrand()
        {
            return this.rentlogic.TheRentsCarBrand();
        }

        [HttpGet]
        public IEnumerable<BrandperRentsCount> BrandperRentsCountsMethod()   
        {
            return this.rentlogic.BrandperRentsCountsMethod();
        }

        [HttpGet]
        public TheMostFamous TheMostFamousBrand()
        {
            return carlogic.TheMostFamousBrand();
        }

        [HttpGet]
        public IEnumerable<AvarageCarHP> AvarageHPperCar()
        {
            return this.carlogic.AvarageHPperCar();
        }

    }
    }
