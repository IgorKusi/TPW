using System.ComponentModel;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Nodes;
using Dane;
using Timer = System.Timers.Timer;

namespace Logika;

public class Logger {
    private const string LOG_PATH = "D:\\TPW\\TPW\\log.json";
    private readonly object _lock = new();
    private Timer _timer = new();

    private string _logContent = "";

    //WriteIndented -> readable formatting
    //Encoder -> don't replace + with \u002B
    private readonly JsonSerializerOptions _serializerOptions = new JsonSerializerOptions
        {WriteIndented = true, Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping};

    public Logger() {
        //try to save any not-logged data before shutdown
        AppDomain.CurrentDomain.ProcessExit += delegate { Log(); };
        _timer.Interval = 1000; //ms
        _timer.Elapsed += delegate { Log(); };
        _timer.Start();
    }

    public void OnBallUpdate(object? source, PropertyChangedEventArgs args) {
        if ( args.PropertyName != "pos" ) return;
        if ( source == null ) return;

        Ball ball = (Ball) source;
        
        JsonNode node = JsonNode.Parse(JsonSerializer.Serialize(ball, _serializerOptions))!;
        node[ "Time" ] = DateTime.Now.ToString("HH:mm:ss.ffff zz");

        _logContent += node.ToJsonString(_serializerOptions);
    }

    public void Log() {
        lock (_lock) {
            File.AppendAllText(LOG_PATH, _logContent);
        }

        _logContent = "";
    }
}