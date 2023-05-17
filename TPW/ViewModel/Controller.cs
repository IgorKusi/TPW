using System.Collections.ObjectModel;
using System.Windows.Input;
using Model;

namespace ViewModel; 

public class Controller {
    public Controller() {
        BallNum = 1;

        OnButtonStop = new ButtonAction(() => {
            if ( _modelApi == null ) return;

            Circles.Clear();
            _modelApi.Stop();
        });
        OnButtonPauseResume = new ButtonAction(() => {
            if ( _modelApi == null ) return;

            _modelApi.Enabled = !_modelApi.Enabled;
        });
        OnButtonStart = new ButtonAction(() => {
            if ( _modelApi != null ) {
                OnButtonStop.Execute(null);
            }

            _modelApi = AbstractModelApi.CreateApi(680, 480, BallNum, 15);

            foreach (var circle in _modelApi.Circles) {
                Circles.Add(circle);
            }

            _modelApi.Start();
        });
    }

    public ICommand OnButtonStart { get; set; }
    public ICommand OnButtonPauseResume { get; set; }
    public ICommand OnButtonStop { get; set; }

    public int BallNum { get; set; }
    private AbstractModelApi? _modelApi;

    public ObservableCollection<Circle> Circles { get; set; } = new();
}