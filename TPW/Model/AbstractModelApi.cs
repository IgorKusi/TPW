using System.Collections.ObjectModel;
using Logika;

namespace Model; 

public abstract class AbstractModelApi {
    public virtual bool Enabled { get; set; }
    public virtual ObservableCollection<Circle> Circles { get; }
    public abstract void Start();
    public abstract void Stop();

    public static AbstractModelApi CreateApi(AbstractLogikaApi api) {
        return new ConcreteModelApi(api);
    }

    public static AbstractModelApi CreateApi(int xSize, int ySize, int numBalls, int circRadius) {
        return new ConcreteModelApi(xSize, ySize, numBalls, circRadius);
    }


    private sealed class ConcreteModelApi : AbstractModelApi {
        private readonly AbstractLogikaApi _lApi;

        public override bool Enabled {
            get => _lApi.Enabled;
            set => _lApi.Enabled = value;
        }

        public override ObservableCollection<Circle> Circles { get; } = new();

        public ConcreteModelApi(AbstractLogikaApi lApi) {
            _lApi = lApi;

            foreach (var ball in _lApi.GetBalls()) {
                Circles.Add(new Circle(ball));
            }
        }

        public ConcreteModelApi(int xSize, int ySize, int numBalls, int ballRadius) {
            _lApi = AbstractLogikaApi.CreateApi(xSize, ySize, numBalls, ballRadius);

            foreach (var ball in _lApi.GetBalls()) {
                Circles.Add(new Circle(ball));
            }
        }


        public override void Start() {
            _lApi.Start();
        }

        public override void Stop() {
            _lApi.Stop();
        }
    }
}