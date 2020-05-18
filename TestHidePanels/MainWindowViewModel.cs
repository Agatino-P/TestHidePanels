using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;

namespace TestHidePanels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private ObservableCollection<string> _oc1 = new ObservableCollection<string>();
        public ObservableCollection<string> OC1 { get => _oc1; set => Set(() => OC1, ref _oc1, value); }
        public bool OC1Visible => OC1.Count() > 0;


        private ObservableCollection<string> _oc2 = new ObservableCollection<string>();
        public ObservableCollection<string> OC2 { get => _oc2; set { Set(() => OC2, ref _oc2, value); RaisePropertyChanged("OC2Visible"); } }
        public bool OC2Visible => OC2.Count() > 0;

        public bool RighPanelVisible => OC1Visible && OC2Visible;

        private RelayCommand _empty1Cmd;
        public RelayCommand Empty1Cmd => _empty1Cmd ?? (_empty1Cmd = new RelayCommand(
            () => { OC1.Clear(); RaisePropertyChanged("OC1Visible"); },
            () => { return 1 == 1; },
            keepTargetAlive: true
            ));


        private RelayCommand _empty2Cmd;
        public RelayCommand Empty2Cmd => _empty2Cmd ?? (_empty2Cmd = new RelayCommand(
                () => { OC2.Clear(); RaisePropertyChanged("OC2Visible"); },
            () => { return 1 == 1; },
            keepTargetAlive: true
            ));


        private RelayCommand _populate1Cmd;
        public RelayCommand Populate1Cmd => _populate1Cmd ?? (_populate1Cmd = new RelayCommand(
                () => { OC1.Add("str1"); RaisePropertyChanged("OC1Visible"); },
            () => { return 1 == 1; },
            keepTargetAlive: true
            ));


        private RelayCommand _populate2Cmd;
        public RelayCommand Populate2Cmd => _populate2Cmd ?? (_populate2Cmd = new RelayCommand(
                () => { OC2.Add("str2"); RaisePropertyChanged("OC2Visible"); },
            () => { return 1 == 1; },
            keepTargetAlive: true
            ));


        private RelayCommand _testCmd;
        public RelayCommand TestCmd => _testCmd ?? (_testCmd = new RelayCommand(
            () =>
            {
                Debug.WriteLine($"OC1Visible {OC1Visible} OC2Visible {OC2Visible}");
            },
            () => { return 1 == 1; },
            keepTargetAlive: true
            ));

        public MainWindowViewModel()
        {
            //OC1.Add("1");
        }
    }
}
