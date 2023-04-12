using System.Collections.ObjectModel;
using System.Windows.Input;
using Model;

namespace ViewModel {
    public class Controller {
        public Controller() {
            BallNum = 1;

            OnButtonStop = new ButtonAction(() => {
                if ( _model == null ) return;

                Circles.Clear();
                _model.Stop();
            });
            OnButtonPauseResume = new ButtonAction(() => {
                if ( _model == null ) return;

                _model.Enabled = !_model.Enabled;
            });
            OnButtonStart = new ButtonAction(() => {
                if ( _model != null ) {
                    OnButtonStop.Execute(null);
                }

                _model = new Model.Model(BallNum, 680, 500);

                foreach ( var circle in _model.Circles ) {
                    Circles.Add(circle);
                }
                _model.Start();
            });


        }



        public ICommand OnButtonStart { get; set; }
        public ICommand OnButtonPauseResume { get; set; }
        public ICommand OnButtonStop { get; set; }

        public int BallNum { get; set; }
        private Model.Model? _model;

        public ObservableCollection<Circle> Circles { get; set; } = new();

    }

}
