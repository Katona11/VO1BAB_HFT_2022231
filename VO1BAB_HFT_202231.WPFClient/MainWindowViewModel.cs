using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using VO1BAB_HFT_202231.Logic;
using VO1BAB_HFT_202231.Models;

namespace VO1BAB_HFT_202231.WPFClient
{
    
    public  class MainWindowViewModel:ObservableRecipient
    {
       
        public RestCollection<CarBrand> Carbrand { get; set; }

        public RestCollection<Cars> cars { get; set; }

        public RestCollection<Rents> rents { get; set; }


        public  List<TheMostFamous> themostfamous { get; set; }

        public List<string> therentscarbrand { get; set; }

        public List<BrandperRentsCount> brandperRentsCounts { get; set; }

        public List<AvarageCarHP> avarageCarHPs { get; set; }   


        public List<YearInfo> yearInfos { get; set; }





        public ICommand CreateCarBrandCommand { get; set; }

        public ICommand DeleteCarBrandCommand { get; set; }

        public ICommand UpdateCrandBrandCommand { get; set; }


        public ICommand CreateCarCommand { get; set; }

        public ICommand DeleteCarCommand { get; set; }

        public ICommand UpdateCrandCommand { get; set; }


        public ICommand CreateRentCarCommand { get; set; }

        public ICommand DeleteRentCarCommand { get; set; }

        public ICommand UpdateRentCarCommand { get; set; }


        private CarBrand selectedCarBrand;

        public CarBrand SelectedCarBrand
        {
            get { return selectedCarBrand; }
            set 
            {

                if (value != null)
                {
                    selectedCarBrand = new CarBrand()
                    {
                        Name = value.Name,
                        CarBrandID = value.CarBrandID
                    };
                    OnPropertyChanged();
                    (DeleteCarBrandCommand as RelayCommand).NotifyCanExecuteChanged();
                }
                

                
            }
        }

        private Cars selectedCar;

        public Cars SelectedCar
        {
            get { return selectedCar; }

            set

            {
                if (value != null)
                {
                    selectedCar = new Cars()
                    {
                        LicensePlateNumber = value.LicensePlateNumber,
                        PerformanceInHP = value.PerformanceInHP,
                        CarBrandID= value.CarBrandID,
                        Type = value.Type,
                        Year = value.Year,
                        CarsID= value.CarBrandID,
                        
                    };
                    OnPropertyChanged();
                    (DeleteCarCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }

        private Rents selectedRentitem;

        public Rents SelectedRentitem
        {
            get { return selectedRentitem; }
            set
            {
                if (value != null)
                {
                    selectedRentitem = new Rents()
                    {
                        RentId = value.RentId,
                        RentTime = value.RentTime,
                        CarsID = value.CarsID,
                        OwnerName = value.OwnerName,

                    };
                    OnPropertyChanged();
                    (DeleteRentCarCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }






        public MainWindowViewModel()
        {
            
            Carbrand = new RestCollection<CarBrand>("http://localhost:50437/", "carbrand");
            cars = new RestCollection<Cars>("http://localhost:50437/", "cars");
            rents = new RestCollection<Rents>("http://localhost:50437/", "rents");
            //themostfamous = new RestCollection<TheMostFamous>("http://localhost:50437/", "CrudMethod/TheMostFamousBrand");
            themostfamous = new RestService("http://localhost:50437/").Get<TheMostFamous>("CrudMethod/TheMostFamousBrand");
            therentscarbrand = new RestService("http://localhost:50437/").Get<string>("CrudMethod/TheRentsCarBrand");
            brandperRentsCounts = new RestService("http://localhost:50437/").Get<BrandperRentsCount>("CrudMethod/BrandperRentsCountsMethod");
            avarageCarHPs = new RestService("http://localhost:50437/").Get<AvarageCarHP>("CrudMethod/AvarageHPperCar");
            yearInfos = new RestService("http://localhost:50437/").Get<YearInfo>("CrudMethod/YearStatistics");
            



            CreateCarBrandCommand = new RelayCommand(() =>
            {
                Carbrand.Add(new CarBrand()
                {
                    Name = SelectedCarBrand.Name
                });
            });

            UpdateCrandBrandCommand = new RelayCommand(() =>
            {
                Carbrand.Update(SelectedCarBrand);
            });

            DeleteCarBrandCommand = new RelayCommand(() =>
            {
                Carbrand.Delete(SelectedCarBrand.CarBrandID);
            },
            () =>
            {
                return SelectedCarBrand != null;
            });

            //-----------------------------------------------------------

            CreateCarCommand = new RelayCommand(() =>
            {
                cars.Add(new Cars()
                {
                    LicensePlateNumber = SelectedCar.LicensePlateNumber,
                    PerformanceInHP = SelectedCar.PerformanceInHP,
                    CarBrandID = SelectedCar.CarBrandID,
                    Type = SelectedCar.Type,
                    Year = SelectedCar.Year
                });
            });


            UpdateCrandCommand = new RelayCommand(() =>
            {
                cars.Update(SelectedCar);
            });

            DeleteCarCommand = new RelayCommand(() =>
            {
                cars.Delete(SelectedCar.CarsID);
            },
            () =>
            {
                return SelectedCar != null;
            });

            //---------------------------------------------------------



            CreateRentCarCommand = new RelayCommand(() =>
            {
                rents.Add(new Rents()
                {
                   CarsID = SelectedRentitem.CarsID,
                   OwnerName = SelectedRentitem.OwnerName,
                   RentTime = SelectedRentitem.RentTime,
                   //RentId = SelectedRentitem.RentId,
                });
            });


            UpdateRentCarCommand = new RelayCommand(() =>
            {
                rents.Update(SelectedRentitem);
            });

            DeleteRentCarCommand = new RelayCommand(() =>
            {
                rents.Delete(SelectedRentitem.RentId);
            },
            () =>
            {
                return selectedRentitem != null;
            });



            selectedRentitem = new Rents();
            selectedCar = new Cars();
            SelectedCarBrand = new CarBrand();







        }
    }

    public class Therentscarbrand
    {
        public string Name { get; set; }
    }
}
