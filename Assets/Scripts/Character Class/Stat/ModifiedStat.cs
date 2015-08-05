/// <summary>
/// ModifiedStat.cs
/// Derrick Ma
/// 2 Aug, 2015
/// 
/// This is the base class for stats that will be modified by attributes 
/// </summary>

using System.Collections.Generic;						//to use List<>

public class ModifiedStat : BaseStat
{
    private List<ModifyingAttribute> mods;				//A list of attributes that modifies this stat

	/// <summary>
	/// Gets the ModValue.
	/// </summary>
	/// <value>The ModValue.</value>
    public int ModValue { get; private set; }

	/// <summary>
	/// Gets the adjusted value.
	/// </summary>
	/// <value>The adjusted value.</value>
	public override int AdjustedValue
	{
		get
		{
			return base.AdjustedValue + ModValue;
		}
	}

	/// <summary>
	/// Initializes a new instance of the <see cref="ModifiedStat"/> class.
	/// </summary>
    public ModifiedStat()
    {
        mods = new List<ModifyingAttribute>();
        ModValue = 0;
    }

	/// <summary>
	/// Adds the modifier to the list
	/// registered to the StatChanged event of the attribute
	/// </summary>
	/// <param name="mod">Modifying Attribute.</param>
    public void AddModifier(ModifyingAttribute mod)
    {
        mods.Add(mod);
        mod.Attribute.StatChanged += Update;
    }

	/// <summary>
	/// Calculates the ModValue.
	/// </summary>
    private void CalculateModValue()
    {
        ModValue = 0;
        if (mods.Count > 0)
        {
            foreach (var att in mods)
            {
                ModValue += (int)(att.Attribute.AdjustedValue * att.Ratio);
            }

            OnStatChanged(AdjustedValue);
        }
    }

	/// <summary>
	/// Update the ModValue.
	/// </summary>
	/// <param name="a">Useless a</param>
    public void Update(int a = 0)
    {
        CalculateModValue();
    }
}

/// <summary>
/// A Struct holds the modifying attribute and ratio will be added to ModifiedStat
/// </summary>
public struct ModifyingAttribute
{
	public Attribute Attribute;							//Attribute modifies the ModifiedStat
    public float Ratio;									//the percentage of attribute affacts the ModifiedStat

	/// <summary>
	/// Initializes a new instance of the <see cref="ModifyingAttribute"/> struct.
	/// </summary>
	/// <param name="attribute">Attribute.</param>
	/// <param name="ratio">Ratio.</param>
    public ModifyingAttribute(Attribute attribute, float ratio)
    {
        Attribute = attribute;
        Ratio = ratio;
    }
}
