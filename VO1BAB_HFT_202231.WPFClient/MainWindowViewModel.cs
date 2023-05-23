using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
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

        public ICommand CreateCarBrandCommand { get; set; }

        public ICommand DeleteCarBrandCommand { get; set; }

        public ICommand UpdateCrandBrandCommand { get; set; }


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




        public MainWindowViewModel()
        {
            
            Carbrand = new RestCollection<CarBrand>("http://localhost:50437/", "carbrand");
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
            SelectedCarBrand = new CarBrand();


        }
    }
}
