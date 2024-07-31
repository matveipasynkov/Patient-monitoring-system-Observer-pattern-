using System.Text.Json;
using System.Text.Json.Serialization;
namespace Library;

/// <summary>
/// Класс MyType из условия.
/// </summary>
[Serializable]
public class Patient
{
    public event EventHandler<ChangeStateEvent> Updated;
    public void OnUpdated(object sender, ChangeStateEvent e)
    {
        Updated?.Invoke(sender, e);
    }

    private string _patientId;
    [JsonPropertyName("patient_id")]
    public string PatientId
    {
        private set
        {
            _patientId = value;
        }
        get
        {
            return _patientId;
        }
    }

    private string _name;
    [JsonPropertyName("name")]
    public string Name
    {
        private set
        {
            _name = value;
        }
        get
        {
            return _name;
        }
    }

    private int _age;
    [JsonPropertyName("age")]
    public int Age
    {
        private set
        {
            _age = value;
        }
        get
        {
            return _age;
        }
    }

    private string _gender;
    [JsonPropertyName("gender")]
    public string Gender
    {
        private set
        {
            _gender = value;
        }
        get
        {
            return _gender;
        }
    }

    private string _diagnosis;
    [JsonPropertyName("diagnosis")]
    public string Diagnosis
    {
        private set
        {
            _diagnosis = value;
        }
        get
        {
            return _diagnosis;
        }
    }

    private double _state;
    [JsonPropertyName("state")]
    public double State
    {
        private set
        {
            _state = value;
        }
        get
        {
            return _state;
        }
    }

    private List<Sensor> _sensors;
    [JsonPropertyName("sensors")]
    public List<Sensor> Sensors
    {
        private set
        {
            _sensors = value;
        }
        get
        {
            return _sensors;
        }
    }

    public Patient(JsonElement jsonElement = new JsonElement())
    {
        this.PatientId = jsonElement.GetProperty("patient_id").GetString();
        this.Name = jsonElement.GetProperty("name").GetString();
        this.Age = jsonElement.GetProperty("age").GetInt32();
        this.Gender = jsonElement.GetProperty("gender").GetString();
        this.Diagnosis = jsonElement.GetProperty("diagnosis").GetString();
        this.State = jsonElement.GetProperty("state").GetDouble();

        List<Sensor> newSensors = new List<Sensor> { };

        JsonElement.ArrayEnumerator jsonSensors = jsonElement.GetProperty("sensors").EnumerateArray();

        foreach (JsonElement jsonSensor in jsonSensors)
        {
            Sensor sensor = new Sensor(jsonSensor);
            this.Updated += sensor.OnChangeStateEventHandler;
            newSensors.Add(sensor);
        }

        this.Sensors = newSensors;
    }

    /// <summary>
    /// Метод для изменения информации о пациентах.
    /// </summary>
    /// <param name="field"></param>
    /// <param name="value"></param>
    /// <param name="sensorsInfo"></param>
    /// <param name="sensorId"></param>
    public void ChangePatientInfo(string field, string value, bool sensorsInfo, int sensorId = -1)
    {
        if (sensorsInfo)
        {
            this.Sensors[sensorId].ChangeSensorInfo(field, value);
        }
        else
        {
            if (field == "name")
            {
                this.Name = value;
            }
            else if (field == "age")
            {
                this.Age = int.Parse(value);
            }
            else if (field == "gender")
            {
                this.Gender = value;
            }
            else if (field == "diagnosis")
            {
                this.Diagnosis = value;
            }
            else
            {
                this.State = double.Parse(value);
            }
        }

        OnUpdated(this, new(_state));
    }

    public string ToJson()
    {
        JsonSerializerOptions options = new(JsonSerializerDefaults.Web)
        {
            WriteIndented = true
        };

        return JsonSerializer.Serialize(this, options);
    }
}