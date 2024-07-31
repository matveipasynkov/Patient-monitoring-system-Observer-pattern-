using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Library;

/// <summary>
/// Вложенный класс для класса MyType из условия.
/// </summary>
[Serializable]
public class Sensor
{
    public event EventHandler<ChangeStateEvent> Updated;

    public void OnUpdated(object sender, ChangeStateEvent e)
    {
        Updated?.Invoke(sender, e);
    }

    private string _sensorId;
    [JsonPropertyName("sensor_id")]
    public string SensorId
	{
        private set
        {
            _sensorId = value;
        }
		get
		{
			return _sensorId;
		}
	}

    private string _sensorName;
    [JsonPropertyName("sensor_name")]
    public string SensorName
    {
        private set
        {
            _sensorName = value;
        }
        get
        {
            return _sensorName;
        }
    }

    private string _severity;
    [JsonPropertyName("severity")]
    public string Severity
    {
        private set
        {
            _severity = value;
        }
        get
        {
            return _severity;
        }
    }

    private int _lowerThreshold;
    [JsonPropertyName("lower_threshold")]
    public int LowerThreshold
    {
        private set
        {
            _lowerThreshold = value;
        }
        get
        {
            return _lowerThreshold;
        }
    }

    private int _upperThreshold;
    [JsonPropertyName("upper_threshold")]
    public int UpperThreshold
    {
        private set
        {
            _upperThreshold = value;
        }
        get
        {
            return _upperThreshold;
        }
    }

    private bool _triggered;
    [JsonPropertyName("triggered")]
    public bool Triggered
    {
        private set
        {
            _triggered = value;
        }
        get
        {
            return _triggered;
        }
    }

    public Sensor(JsonElement sensorJson = new JsonElement())
    {
        this.SensorId = sensorJson.GetProperty("sensor_id").GetString();
        this.SensorName = sensorJson.GetProperty("sensor_name").GetString();
        this.Severity = sensorJson.GetProperty("severity").GetString();
        this.LowerThreshold = sensorJson.GetProperty("lower_threshold").GetInt32();
        this.UpperThreshold = sensorJson.GetProperty("upper_threshold").GetInt32();
        this.Triggered = sensorJson.GetProperty("triggered").GetBoolean();
    }

    /// <summary>
    /// Метод для изменения информации о сенсорах.
    /// </summary>
    /// <param name="field"></param>
    /// <param name="value"></param>
    public void ChangeSensorInfo(string field, string value)
    {
        if (field == "sensor_name")
        {
            this.SensorName = value;
        }
        else if (field == "severity")
        {
            this.Severity = value;
        }
        else if (field == "lower_threshold")
        {
            this.LowerThreshold = int.Parse(value);
        }
        else
        {
            this.UpperThreshold = int.Parse(value);
        }
    }

    /// <summary>
    /// Метод, который меняет поле triggered при возникновении события Updated.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public void OnChangeStateEventHandler(object sender, ChangeStateEvent e)
    {
        double state = e.state;

        if (this.LowerThreshold <= state && this.UpperThreshold >= state)
        {
            Triggered = true;
        }
        else
        {
            Triggered = false;
        }
    }
}