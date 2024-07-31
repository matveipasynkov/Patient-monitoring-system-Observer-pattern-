using System;
using System.IO;
using System.Text.Json;

namespace Library;

/// <summary>
/// Класс AutoSaver из условия.
/// </summary>
public class AutoSaver
{
    DateTime latest = new DateTime();

	private string path = "";

    private List<Patient> patients;

    public AutoSaver(List<Patient> patients = default, string path = "")
	{
		this.patients = patients;
		this.path = path;

		for (int i = 0; i < patients.Count; ++i)
		{
			patients[i].Updated += Updated;

			foreach (Sensor sensor in patients[i].Sensors)
			{
				sensor.Updated += Updated;
			}
		}
	}

	public void Updated(object sender, ChangeStateEvent e)
	{
		DateTime now = e.TimeOfUpdate;

		TimeSpan difference = now.Subtract(latest);

		if (difference.TotalSeconds <= 15)
		{
            JsonSerializerOptions options = new(JsonSerializerDefaults.Web)
            {
                WriteIndented = true
            };

            string json = JsonSerializer.Serialize(patients, options);
			string catalog = Path.GetDirectoryName(path);
			string nameOfFile = $"{Path.GetFileNameWithoutExtension(path)}_tmp.json";
			string pathToAutosave = Path.Combine(catalog, nameOfFile);
            File.WriteAllText(pathToAutosave, json);
        }

		latest = now;
    }
}