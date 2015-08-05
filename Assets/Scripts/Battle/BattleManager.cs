using UnityEngine;
using System.Collections.Generic;

public class BattleManager : MonoBehaviour
{
    public static BattleManager Instance;

    //Total Battle Time
    public float BattleTime;

    //BattleUnitPrefabs
    [SerializeField]
    GameObject BattleUnitPrefab;

    //Each Side
    public List<BattleUnit> LeftSideTeam;
    public List<BattleUnit> RightSideTeam;

    //TeamSize
    private const int TEAM_SIZE = 1;
    void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Calculate Battle Time
        BattleTime += Time.deltaTime;
    }

    public void InitiateTeams()
    {
        //Initiate Both Side
        LeftSideTeam = new List<BattleUnit>(TEAM_SIZE);
        for (int i = 0; i < TEAM_SIZE; i++)
        {
            var battleUnit = (Instantiate(BattleUnitPrefab, Vector3.left * (i * 10 + 10), Quaternion.identity) as GameObject).GetComponent<BattleUnit>();
            battleUnit.SetBattleUnitSide(0);
            LeftSideTeam.Add(battleUnit);
        }

        RightSideTeam = new List<BattleUnit>(TEAM_SIZE);
        for (int i = 0; i < TEAM_SIZE; i++)
        {
            var battleUnit = (Instantiate(BattleUnitPrefab, Vector3.right * (i * 10 + 10), Quaternion.identity) as GameObject).GetComponent<BattleUnit>();
            battleUnit.SetBattleUnitSide(1);
            RightSideTeam.Add(battleUnit);
        }
    }
}
