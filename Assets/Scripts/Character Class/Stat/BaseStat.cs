/// <summary>
/// BaseStat.cs
/// Derrick Ma
/// 2 Aug, 2015
/// 
/// This is the base class of stat in game
/// </summary>

public class BaseStat
{
	public delegate void StatChangedEventHandler(int changedValue);			//delegate to StatChanged event
	public event StatChangedEventHandler StatChanged;   					//StatChanged event handler

	/// <summary>
	/// Raises the stat changed event.
	/// </summary>
	/// <param name="changedValue">Changed value.</param>
	protected void OnStatChanged(int changedValue)
	{
		if(StatChanged != null)
		{
			StatChanged(changedValue);
		}
	}

	/// <summary>
	/// Gets or sets the baseValue.
	/// </summary>
	/// <value>The baseValue.</value>
    public int BaseValue
    {
        get
        {
            return baseValue;
        }
        protected set
        {
            baseValue = value;
            OnStatChanged(AdjustedValue);
        }
    }
	private int baseValue;

	/// <summary>
	/// Gets or sets the buffValue.
	/// </summary>
	/// <value>The buffValue.</value>
    public int BuffValue 
    { 
        get
        {
            return buffValue;
        }
        set
        {
            buffValue = value;
            OnStatChanged(AdjustedValue);
        }
    }
	private int buffValue;

	
	/// <summary>
	/// Gets the adjusted value.
	/// </summary>
	/// <value>The adjusted value.</value>
	public virtual int AdjustedValue
	{
		get { return BaseValue + BuffValue; }
	}

	/// <summary>
	/// Initializes a new instance of the <see cref="BaseStat"/> class.
	/// </summary>
    public BaseStat()
    {
        BaseValue = 0;
        BuffValue = 0;
    }
}