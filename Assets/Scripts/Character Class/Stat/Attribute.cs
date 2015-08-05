/// <summary>
/// Attribute.cs
/// Derrick Ma
/// 2 Aug, 2015
/// 
/// This is the attribute of player in game
/// </summary>

public class Attribute : BaseStat
{
	/// <summary>
	/// Add num to BaseValue.
	/// </summary>
	/// <param name="num">Number adds to BaseValue</param>
    public void Add(int num)
    {
        BaseValue += num;
    }

	/// <summary>
	/// Sub num from BaseValue.
	/// </summary>
	/// <param name="num">Number subs from BaseValue</param>
    public void Sub(int num)
    {
		BaseValue -= num;
	}

	/// <summary>
	/// Set BaseValue to num.
	/// </summary>
	/// <param name="num">Number sets to BaseValue</param>
    public void Set(int num)
    {
        BaseValue = num;
    }
}

/// <summary>
/// List of character attribute names.
/// </summary>
public enum AttributeName
{
    Strength,
    Dexterity,
    Intellect,
    Constitution,
    Spirit
}