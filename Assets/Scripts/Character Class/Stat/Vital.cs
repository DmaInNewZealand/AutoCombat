public class Vital : ModifiedStat
{
    private int curValue;
    public int CurValue
    {
        get
        {
            if(curValue > AdjustedValue)
            {
                curValue = AdjustedValue;
            }
            return curValue;
        }
        set
        {
            curValue = value;
        }
    }

    public Vital()
    {
        CurValue = 0;
    }
}

public enum VitalName
{
    Health,
    Fury,
    Energy,
    Mana
}


