using System;
namespace Library;

/// <summary>
/// Данный класс - наследник EventArgs из условия для реализации события Updated.
/// </summary>
public class ChangeStateEvent : EventArgs
{
	private DateTime _timeOfUpdate;

	public DateTime TimeOfUpdate
	{
		get
		{
			return _timeOfUpdate;
		}
	}

	private double _state;

	public double state
	{
		get
		{
			return _state;
		}
	}

	public ChangeStateEvent(double state = 0)
	{
		this._timeOfUpdate = DateTime.Now;
		this._state = state;
	}
}