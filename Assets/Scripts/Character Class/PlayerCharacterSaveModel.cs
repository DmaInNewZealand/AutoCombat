using System;

[Serializable]
public class PlayerCharacterSaveModel
{
    public string Name { get; set; }
    public int Level { get; set; }

    public uint FreePoints { get; set; }
    public uint FreeExp { get; set; }

    public int[] Attributes;
    public int[] Skills;

    public void GetFromPlayerCharacter()
    {
        Name = PlayerCharacter.Player.Name;
        Level = PlayerCharacter.Player.Level;

        FreePoints = PlayerCharacter.Player.FreePoints;
        FreeExp = PlayerCharacter.Player.FreeExp;

        Attributes = new int[Enum.GetValues(typeof(AttributeName)).Length];
        for (int i = 0; i < Attributes.Length; i++)
        {
            Attributes[i] = PlayerCharacter.Player.GetAttribute(i).BaseValue;
        }

        Skills = new int[Enum.GetValues(typeof(SkillName)).Length];
        for (int i = 0; i < Skills.Length; i++)
        {
            Skills[i] = PlayerCharacter.Player.GetSkill(i).BaseValue;
        }
    }

    public void SetToPlayerCharacter()
    {
        PlayerCharacter.Player.Name = Name;
        PlayerCharacter.Player.Level = Level;

        PlayerCharacter.Player.FreePoints = FreePoints;
        PlayerCharacter.Player.FreeExp = FreeExp;

        for (int i = 0; i < Attributes.Length; i++)
        {
            PlayerCharacter.Player.GetAttribute(i).Set(Attributes[i]);
        }

        for (int i = 0; i < Skills.Length; i++)
        {
            PlayerCharacter.Player.GetSkill(i).Set(Skills[i]);
        }
    }
}