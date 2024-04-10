using FCW0VU_HFT_2023241.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace FCW0VU_HFT_2023241.WPFclient
{
    public class LocationViewModel : ObservableRecipient
    {
        public RestCollection<Location> Locations { get; set; }
        private Location selectedLocation;

        public Location SelectedLocation
        {
            get { return selectedLocation; }
            set
            {
                if (value != null)
                {
                    selectedLocation = new Location()
                    {
                        Name = value.Name,
                        Address = value.Address,
                        Id = value.Id
                    };
                    OnPropertyChanged();
                    (DeleteLocationCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }


        public ICommand CreateLocationCommand { get; set; }
        public ICommand UpdateLocationCommand { get; set; }
        public ICommand DeleteLocationCommand { get; set; }

        public LocationViewModel()
        {
            if (!IsInDesignMode)
            {
                Locations = new RestCollection<Location>("http://localhost:13109/", "Location", "hub");

                CreateLocationCommand = new RelayCommand(() =>
                {
                    Locations.Add(new Location()
                    {
                        Name = selectedLocation.Name,
                        Address= selectedLocation.Address,
                    });
                });

                UpdateLocationCommand = new RelayCommand(() =>
                {
                    Locations.Update(selectedLocation);
                });

                DeleteLocationCommand = new RelayCommand(() =>
                {
                    Locations.Delete(selectedLocation.Id);
                },
                () =>
                {
                    return selectedLocation != null;
                });

                selectedLocation = new Location();
            }
        }

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }
    }
}
