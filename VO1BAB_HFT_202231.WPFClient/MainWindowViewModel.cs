using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VO1BAB_HFT_202231.Models;

namespace VO1BAB_HFT_202231.WPFClient
{
    public  class MainWindowViewModel:ObservableRecipient
    {
        public RestCollection<CarBrand> Carbrand { get; set; }

        public RestCollection<Cars> cars { get; set; }

        public ICommand CreateCarBrandCommand { get; set; }

        public ICommand DeleteCarBrandCommand { get; set; }

        public ICommand UpdateCrandBrandCommand { get; set; }


        public ICommand CreateCarCommand { get; set; }

        public ICommand DeleteCarCommand { get; set; }

        public ICommand UpdateCrandCommand { get; set; }


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





        public MainWindowViewModel()
        {
            
            Carbrand = new RestCollection<CarBrand>("http://localhost:50437/", "carbrand");
            cars = new RestCollection<Cars>("http://localhost:50437/", "cars");
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


            selectedCar = new Cars();
            SelectedCarBrand = new CarBrand();







        }
    }
}
