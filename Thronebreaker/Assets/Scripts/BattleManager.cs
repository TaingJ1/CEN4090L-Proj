using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using System;

public class BattleManager : MonoBehaviour
{
     
    public GameObject[] playerUnitPrefabs;
    public GameObject[] enemyUnitPrefabs;

    public UnitSO[] playerUnitData;
    public UnitSO[] enemyUnitData;

    public Transform party1, party2, party3;

    [SerializeField] private List<PartyMemberUnit> playerUnits = new List<PartyMemberUnit>();

    [NonSerialized]
    public List<EnemyUnit> enemyUnits = new List<EnemyUnit>();

    public BattleDataContainer battleData;
    
    private bool isPlayerTurn = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        battleData = FindAnyObjectByType<BattleDataContainer>();
        StartBattle();
    }

    void StartBattle()
    {
        SpawnUnit(playerUnitData[0], playerUnitPrefabs[0], party1.position, true);
        SpawnUnit(playerUnitData[1], playerUnitPrefabs[1], party2.position, true);
        SpawnUnit(playerUnitData[2], playerUnitPrefabs[2], party3.position, true);

        // Spawn enemy units depending on how many enemies are in the battle (2 for basic testing)
        for (int i = 0; i < 2; i++)
        {   
            SpawnUnit(enemyUnitData[i], enemyUnitPrefabs[i], new Vector3(4, 2 + (i * -3), 0), false);
        }

        // Start the battle Coroutine here
        StartCoroutine(ManageTurns());
    }

    void SpawnUnit(UnitSO unitData, GameObject unitPrefab, Vector3 position, bool isPlayer)
    {
        GameObject unitObject = Instantiate(unitPrefab, position, Quaternion.identity);

        if (isPlayer)
        {
            var unitScript = unitObject.GetComponent<PartyMemberUnit>();
            unitScript.unitData = unitData;
            unitScript.manager = this;
            playerUnits.Add(unitScript);
        }
        else
        {
            var unitScript = unitObject.GetComponent<EnemyUnit>();
            unitScript.unitData = unitData;
            unitScript.manager = this;
            enemyUnits.Add(unitScript);
        }

        unitObject.name = unitPrefab.name;
    }

    public EnemyUnit currentUnitAttacking;

    IEnumerator ManageTurns()
    {
        while (playerUnits.Count > 0 && enemyUnits.Count > 0)
        {
            if (isPlayerTurn)
            {
                yield return StartCoroutine(PlayerTurn());
            }
            else
            {
                //var rand = UnityEngine.Random.Range(0, enemyUnits.Count);
                //currentUnitAttacking = enemyUnits[rand];
                yield return StartCoroutine(EnemyTurn());
            }

            isPlayerTurn = !isPlayerTurn;
        }

        EndBattle();
    }
    
    IEnumerator PlayerTurn()
    {
        // Shows options for attacks and performing options here

        Debug.Log("Player Turn");
        yield return new WaitForSeconds(2f);
    }

    IEnumerator EnemyTurn()
    {
        Debug.Log("Enemy Turn");
        yield return new WaitForSeconds(2f);
        DoEnemyTurn();
    }

    public void DoEnemyTurn()
    {
        foreach (var e in enemyUnits.ToArray())
        {
            if (!e)
            {
                continue;
            }
            e.DoTurn();
        }
    }

    void EndBattle()        
    {
        if (playerUnits.Count == 0)
        {
            Debug.Log("Loss");
        }
        else if (enemyUnits.Count == 0)
        {
            Debug.Log("Win");
        }
    }

}
