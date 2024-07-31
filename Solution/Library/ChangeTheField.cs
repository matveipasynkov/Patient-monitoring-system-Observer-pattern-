using System;
namespace Library;

/// <summary>
/// Класс, который содержит методы, связанные с изменением полей объекта.
/// </summary>
public static class ChangeTheField
{
	/// <summary>
	/// Данный метод реализует изменение информации об объекте.
	/// </summary>
	/// <param name="patients"></param>
	/// <returns></returns>
	public static List<Patient> ChangeInfo(List<Patient> patients)
	{
		PrintPatients(patients);

		int patientIndex = Checks.CheckPatientNumber(patients);
		Patient selectedPatient = patients[patientIndex];

		Console.Clear();

		PrintPatientFields(selectedPatient);

		string field = Checks.CheckPatientField(patients, false);
		bool isSensorField = false;

		Console.Clear();

		if (field == "sensors")
		{
			isSensorField = true;

			PrintSensors(selectedPatient);

			int sensorIndex = Checks.CheckSensorNumber(selectedPatient);
			Sensor selectedSensor = selectedPatient.Sensors[sensorIndex];

			Console.Clear();

			PrintSensorsFields(selectedSensor);

			field = Checks.CheckSensorField(selectedSensor);

			Console.Clear();

			string value = Checks.CheckSensorValue(selectedSensor, field);

			patients[patientIndex].ChangePatientInfo(field, value, isSensorField, sensorIndex);
		}
		else
		{
			string value = Checks.CheckPatientValue(selectedPatient, field);

			patients[patientIndex].ChangePatientInfo(field, value, isSensorField);
		}

		return patients;
	}

	/// <summary>
	/// Данный метод выводит список пациентов для пользователя.
	/// </summary>
	/// <param name="patients"></param>
	public static void PrintPatients(List<Patient> patients)
	{
        Console.WriteLine("Список пациентов:");

        for (int i = 0; i < patients.Count; ++i)
		{
			Console.WriteLine($"{i + 1}-ый пациент: {patients[i].Name}");
		}
	}

	/// <summary>
	/// Данный метод выводит информацию о конкретном пациенте.
	/// </summary>
	/// <param name="patient"></param>
	public static void PrintPatientFields(Patient patient)
	{
		Console.WriteLine("Доступная к изменению информация о пациенте.");
		Console.WriteLine($"Имя (name): {patient.Name}");
		Console.WriteLine($"Возраст (age): {patient.Age}");
		Console.WriteLine($"Гендер (gender): {patient.Gender}");
		Console.WriteLine($"Диагноз (diagnosis): {patient.Diagnosis}");
		Console.WriteLine($"Состояние (state): {patient.State}");
		Console.WriteLine($"Также для изменения доступны {patient.Sensors.Count} сенсоров (sensors).");
	}
	
	/// <summary>
	/// Данный метод выводит список сенсоров для соотвествующего пациента.
	/// </summary>
	/// <param name="patient"></param>
	public static void PrintSensors(Patient patient)
	{
		Console.WriteLine($"Список сенсоров пациента {patient.Name}:");

		for (int i = 0; i < patient.Sensors.Count; ++i)
		{
			Console.WriteLine($"{i + 1}-ый сенсор: {patient.Sensors[i].SensorName}");
		}
	}

	/// <summary>
	/// Данный метод выводит информацию о выбранном сенсоре.
	/// </summary>
	/// <param name="sensor"></param>
	public static void PrintSensorsFields(Sensor sensor)
	{
        Console.WriteLine("Доступная к изменению информация о сенсоре.");
		Console.WriteLine($"Имя (sensor_name): {sensor.SensorName}");
		Console.WriteLine($"Тяжесть (severity): {sensor.Severity}");
		Console.WriteLine($"Нижний порог (lower_threshold): {sensor.LowerThreshold}");
		Console.WriteLine($"Верхний порог (upper_threshold): {sensor.UpperThreshold}");
    }
}

