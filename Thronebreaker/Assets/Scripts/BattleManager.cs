using UnityEngine;
using UnityEngine.UI;
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

    public GameObject playerMarker;

    public Button testAttackButton;
    public Button testEndTurnButton;
    public Button testHealButton;
    public PartyMemberUnit currentSelectedPartyMember;

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
        // Set selection marker to first character
        // Turn marker on at beginning of battle
        int partyMemberIndex = 0;
        currentSelectedPartyMember = playerUnits[partyMemberIndex];
        playerMarker.SetActive(true);
        playerMarker.transform.position = party1.position;

        bool playerHasActed = false;

        while (!playerHasActed)
        {
            // Allow the player to move the marker between characters using -> and -<
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                Debug.Log("LEFT ARROW KEY PRESSED");

                partyMemberIndex = (partyMemberIndex + 1) % playerUnits.Count;
                currentSelectedPartyMember = playerUnits[partyMemberIndex];
                playerMarker.transform.position = currentSelectedPartyMember.transform.position;
            }

            // For each time the player is over a new party member, move the marker
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                Debug.Log("LEFT ARROW KEY PRESSED");

                if (partyMemberIndex == 0)
                {
                    partyMemberIndex = 2;
                    currentSelectedPartyMember = playerUnits[partyMemberIndex];
                    playerMarker.transform.position = currentSelectedPartyMember.transform.position;
                }

                else
                {
                    partyMemberIndex = (partyMemberIndex - 1) % playerUnits.Count;
                    currentSelectedPartyMember = playerUnits[partyMemberIndex];
                    playerMarker.transform.position = currentSelectedPartyMember.transform.position;
                }
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("ACTION CONFIRMED");
                playerHasActed = true;
                currentSelectedPartyMember.DoTurn();
            }

            yield return null;
        }
        // And spawn a menu near the marked party member and drop down their menu.

        // Allow the player to go up and down on the options using ^ and v

        // Allow the user to hit Space or Enter on whatever option they pick

        // If the player uses an attack, allow the player to choose
        // which enemy to attack

        /*Debug.Log("Player Turn");
        yield return new WaitForSeconds(2f);
        DoPartyMemberTurn();*/
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

    public void DoPartyMemberTurn()
    {
        foreach (var pM in playerUnits.ToArray())
        {
            pM.DoTurn();
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
