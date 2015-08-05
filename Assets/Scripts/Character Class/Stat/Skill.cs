public class Skill : BaseStat
{
    public bool Known { get; set; }
    public int ExpToLevel { get; set; }
    public float LevelModifier { get; set; }

    public Skill()
    {
        Known = false;
        ExpToLevel = 100;
        LevelModifier = 1.2f;
    }

    private int CalculateExpToLevel()
    {
        return (int)(ExpToLevel * LevelModifier);
    }

    public void LevelUp()
    {
        ExpToLevel = CalculateExpToLevel();
        BaseValue++;
    }

    public void Add(int num)
    {
        BaseValue += num;
    }

    public void Sub(int num)
    {
        BaseValue -= num;
    }

    public void Set(int num)
    {
        BaseValue = num;
    }
}

public enum SkillName
{
    //Main
    MeleeWeaponMastery,
    MetalArmorMastery,
    RangedWeaponMastery,
    LeatherArmorMastery,
    MagicSpellMastery,
    ClothArmorMastery,
    //Melee
    SwordMastery,
    MaceMastery,
    AxeMastery,
    //Ranged
    BowMastery,
    CrossBowMastery,
    ThrowingMastery,
    //Magic
    ElementMastery,
    SummonMastery,
    IllusionMastery
}


