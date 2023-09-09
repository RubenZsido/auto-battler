
using System;
using Unity.VisualScripting;

public enum StatModType
{
	Flat,
	PercentAdd ,
	PercentMult,
}

[Serializable]
public class StatModifier
{
	public float Value;
	public StatModType Type;
	public object Source;

	public StatModifier(float value, StatModType type, object source)
	{
		Value = value;
		Type = type;
		Source = source;
	}
}

