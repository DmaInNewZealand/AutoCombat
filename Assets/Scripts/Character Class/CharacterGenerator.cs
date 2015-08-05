using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class CharacterGenerator : MonoBehaviour
{
    //Points Left
    public int LeftPoints;

    private const int STARTING_POINTS = 50;
    private const int MIN_STARTING_ATTRUBUTE_VALUE = 10;
    private const int STARTING_ATTRUBUTE_VALUE = 30;

    void Awake()
    {
        for (int i = 0; i < Enum.GetValues(typeof(AttributeName)).Length; i++)
        {
            PlayerCharacter.Player.GetAttribute(i).Add(STARTING_ATTRUBUTE_VALUE);
        }

        LeftPoints = STARTING_POINTS;
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Add(int attrId)
    {
        if (attrId >= 0 && attrId < Enum.GetValues(typeof(AttributeName)).Length)
        {
            if (LeftPoints > 0)
            {
                LeftPoints--;
                PlayerCharacter.Player.GetAttribute(attrId).Add(1);
            }
        }
    }

    public void Sub(int attrId)
    {
        if (attrId >= 0 && attrId < Enum.GetValues(typeof(AttributeName)).Length)
        {
            if (PlayerCharacter.Player.GetAttribute(attrId).BaseValue > MIN_STARTING_ATTRUBUTE_VALUE)
            {
                LeftPoints++;
                PlayerCharacter.Player.GetAttribute(attrId).Sub(1);
            }
        }
    }

    public void SaveCharacterData()
    {
        BinaryFormatter bf = new BinaryFormatter();
        using (FileStream file = File.Create(Application.persistentDataPath + "/PlayerInfo.dat"))
        {
            PlayerCharacterSaveModel data = new PlayerCharacterSaveModel();
            data.GetFromPlayerCharacter();
            bf.Serialize(file, data);
        }
    }

    public void LoadCharacterDate()
    {
        if(File.Exists(Application.persistentDataPath + "/PlayerInfo.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            using (FileStream file = File.Open(Application.persistentDataPath + "/PlayerInfo.dat",FileMode.Open))
            {
                PlayerCharacterSaveModel data = bf.Deserialize(file) as PlayerCharacterSaveModel;
                data.SetToPlayerCharacter();
            }
        }
    }
}