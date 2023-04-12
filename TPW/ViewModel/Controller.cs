using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Model;

namespace ViewModel {
    public class Controller : INotifyPropertyChanged {
        public Controller() {
            BallNum = 1;

            OnButtonStart = new ButtonAction(() => {
                _model = new Model.Model(BallNum, 680, 500);
                Circles = _model.Circles;
                _model.Start();
            });
            OnButtonStop = new ButtonAction(() =>
            {
                if ( _model == null ) return;
                _model.Stop();
            });
        }



        public ICommand OnButtonStart { get; set; }
        public ICommand OnButtonStop { get; set; }

        public int BallNum { get; set; }
        private Model.Model? _model;

        private ObservableCollection<Circle>? _circles;
        public ObservableCollection<Circle>? Circles
        {
            get { return _circles; }
            set
            {
                if (value.Equals(_circles)) return;
                _circles = value;
                OnPropertyChanged(new PropertyChangedEventArgs("CircList"));
            } }


        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChanged?.Invoke(this, e);
        }
    }

}
