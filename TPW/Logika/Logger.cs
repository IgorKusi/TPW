using System.ComponentModel;
using System.Text.Json;
using Dane;

namespace Logika; 

public class Logger {
    private string _path = "D:\\TPW\\TPW\\log.json";
    private object _lock = new();

    public void LogOnPropChanged(object? source, PropertyChangedEventArgs args) {
        if ( args.PropertyName != "pos" ) return;
        if ( source == null ) return;
        Log((Ball)source);
    }

    public void Log(Ball ball) {
        var options = new JsonSerializerOptions { WriteIndented = true };
        var jsonString = JsonSerializer.Serialize(ball, options);
        
        lock (_lock) {
            File.AppendAllText(_path, jsonString);
        }
    }
}