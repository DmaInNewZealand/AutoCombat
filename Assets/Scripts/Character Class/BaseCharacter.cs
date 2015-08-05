using System;

public class BaseCharacter
{
    public string Name { get; set; }
    public int Level { get; set; }

    public uint FreePoints { get; set; } //Raise Attributes
    public uint FreeExp { get; set; } //Raise Skills

    private Attribute[] Attributes;
    private SubAttribute[] SubAttributes;
    private Vital[] Vitals;
    private Skill[] Skills;

    public BaseCharacter()
    {
        Name = String.Empty;
        Level = 0;

        FreePoints = 0;
        FreeExp = 0;

        Attributes = new Attribute[Enum.GetValues(typeof(AttributeName)).Length];
        SubAttributes = new SubAttribute[Enum.GetValues(typeof(SubAttributeName)).Length];
        Vitals = new Vital[Enum.GetValues(typeof(VitalName)).Length];
        Skills = new Skill[Enum.GetValues(typeof(SkillName)).Length];

        SetAttributes();
        SetSubAttributes();
        SetVitals();
        SetSkills();
    }

    private void SetAttributes()
    {
        for (int cnt = 0; cnt < Attributes.Length; cnt++)
        {
            Attributes[cnt] = new Attribute();
        }
    }

    private void SetSubAttributes()
    {
        for (int cnt = 0; cnt < SubAttributes.Length; cnt++)
        {
            SubAttributes[cnt] = new SubAttribute();
        }

        SetupSubAttributeModifiers();
    }

    private void SetVitals()
    {
        for (int cnt = 0; cnt < Vitals.Length; cnt++)
        {
            Vitals[cnt] = new Vital();
        }

        SetupVitalModifiers();
    }

    private void SetSkills()
    {
        for (int cnt = 0; cnt < Skills.Length; cnt++)
        {
            Skills[cnt] = new Skill();
        }
    }

    private void SetupSubAttributeModifiers()
    {
        //MeleePower
        GetSubAttribute(SubAttributeName.MeleePower).AddModifier(new ModifyingAttribute(GetAttribute(AttributeName.Strength), 1f));

        //RangedPower
        GetSubAttribute(SubAttributeName.RangedPower).AddModifier(new ModifyingAttribute(GetAttribute(AttributeName.Dexterity), 1f));

        //MagicPower
        GetSubAttribute(SubAttributeName.MagicPower).AddModifier(new ModifyingAttribute(GetAttribute(AttributeName.Intellect), 1f));

        //Armor
        GetSubAttribute(SubAttributeName.Armor).AddModifier(new ModifyingAttribute(GetAttribute(AttributeName.Constitution), 0.33f));
        GetSubAttribute(SubAttributeName.Armor).AddModifier(new ModifyingAttribute(GetAttribute(AttributeName.Strength), 0.33f));

        //Agile
        GetSubAttribute(SubAttributeName.Agile).AddModifier(new ModifyingAttribute(GetAttribute(AttributeName.Constitution), 0.33f));
        GetSubAttribute(SubAttributeName.Agile).AddModifier(new ModifyingAttribute(GetAttribute(AttributeName.Dexterity), 0.33f));

        //Resist
        GetSubAttribute(SubAttributeName.Resist).AddModifier(new ModifyingAttribute(GetAttribute(AttributeName.Constitution), 0.33f));
        GetSubAttribute(SubAttributeName.Resist).AddModifier(new ModifyingAttribute(GetAttribute(AttributeName.Intellect), 0.33f));

        //HealthRecover
        GetSubAttribute(SubAttributeName.HealthRecover).AddModifier(new ModifyingAttribute(GetAttribute(AttributeName.Constitution), 0.33f));
        GetSubAttribute(SubAttributeName.HealthRecover).AddModifier(new ModifyingAttribute(GetAttribute(AttributeName.Spirit), 0.66f));

        //FuryRecover
        GetSubAttribute(SubAttributeName.FuryRecover).AddModifier(new ModifyingAttribute(GetAttribute(AttributeName.Strength), 0.33f));
        GetSubAttribute(SubAttributeName.FuryRecover).AddModifier(new ModifyingAttribute(GetAttribute(AttributeName.Spirit), 0.66f));

        //EnergyRecover
        GetSubAttribute(SubAttributeName.EnergyRecover).AddModifier(new ModifyingAttribute(GetAttribute(AttributeName.Dexterity), 0.33f));
        GetSubAttribute(SubAttributeName.EnergyRecover).AddModifier(new ModifyingAttribute(GetAttribute(AttributeName.Spirit), 0.66f));

        //ManaRecover
        GetSubAttribute(SubAttributeName.ManaRecover).AddModifier(new ModifyingAttribute(GetAttribute(AttributeName.Intellect), 0.33f));
        GetSubAttribute(SubAttributeName.ManaRecover).AddModifier(new ModifyingAttribute(GetAttribute(AttributeName.Spirit), 0.66f));
    }

    private void SetupVitalModifiers()
    {
        //Health
        GetVital(VitalName.Health).AddModifier(new ModifyingAttribute(GetAttribute(AttributeName.Constitution), 5f));
        GetVital(VitalName.Health).AddModifier(new ModifyingAttribute(GetAttribute(AttributeName.Strength), 3f));
        GetVital(VitalName.Health).AddModifier(new ModifyingAttribute(GetAttribute(AttributeName.Dexterity), 2f));
        GetVital(VitalName.Health).AddModifier(new ModifyingAttribute(GetAttribute(AttributeName.Intellect), 1f));

        //Fury
        GetVital(VitalName.Fury).AddModifier(new ModifyingAttribute(GetAttribute(AttributeName.Spirit), 2.5f));
        GetVital(VitalName.Fury).AddModifier(new ModifyingAttribute(GetAttribute(AttributeName.Strength), 2.5f));

        //Energy
        GetVital(VitalName.Energy).AddModifier(new ModifyingAttribute(GetAttribute(AttributeName.Spirit), 2.5f));
        GetVital(VitalName.Energy).AddModifier(new ModifyingAttribute(GetAttribute(AttributeName.Dexterity), 2.5f));

        //Mana
        GetVital(VitalName.Mana).AddModifier(new ModifyingAttribute(GetAttribute(AttributeName.Spirit), 2.5f));
        GetVital(VitalName.Mana).AddModifier(new ModifyingAttribute(GetAttribute(AttributeName.Intellect), 2.5f));
    }

    public void AddExp(uint exp)
    {
        FreeExp += exp;
        CalculateLevel();
    }

    public void CalculateLevel()
    {

    }

    public Attribute GetAttribute(AttributeName index)
    {
        return GetAttribute((int)index);
    }

    public Attribute GetAttribute(int index)
    {
        return Attributes[index];
    }

    public SubAttribute GetSubAttribute(SubAttributeName index)
    {
        return GetSubAttribute((int)index);
    }

    public SubAttribute GetSubAttribute(int index)
    {
        return SubAttributes[index];
    }

    public Vital GetVital(VitalName index)
    {
        return GetVital((int)index);
    }

    public Vital GetVital(int index)
    {
        return Vitals[index];
    }

    public Skill GetSkill(SkillName index)
    {
        return GetSkill((int)index);
    }

    public Skill GetSkill(int index)
    {
        return Skills[(int)index];
    }
}
