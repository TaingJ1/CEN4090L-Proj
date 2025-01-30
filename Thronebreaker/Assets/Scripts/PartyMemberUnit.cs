using UnityEngine;
using TMPro;
using System;
using Unity.VisualScripting;

public class PartyMemberUnit : MonoBehaviour
{
    public UnitSO unitData;

    [NonSerialized]
    public BattleManager manager;

    [SerializeField] private int currentHealth;
    [SerializeField] private int physAttack;
    [SerializeField] private int magicAttack;
    [SerializeField] private int currentMana;

    [SerializeField] private int defense;

    public HealthBar healthBar;
    public ManaBar manaBar;
    public PlayerSelectionMenu selectionMenu;

    void Awake()                // Sets the unit's stats at beginning of battle
    {
        currentHealth = unitData.maxHealth;
        physAttack = unitData.physAttack;
        magicAttack = unitData.magicAttack;
        defense = unitData.defense;
        currentMana = unitData.maxMana;

        healthBar.SetMaxHealth(currentHealth);
        manaBar.SetMaxMana(currentMana);

        //manager = GameObject.FindAnyObjectByType<BattleManager>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log($"{manager.gameObject.name}", manager.gameObject);
        Debug.Log($"{unitData.unitName} has {unitData.maxHealth} health");
    }

    public void DoTurn()
    {
        if (currentHealth == 0)
        {
            Debug.Log("Party Member died");
            //manager.enemyUnits.Remove(this);
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("Taking Damage");
            takeDamage(3);
        }
    }

    public void SetHealth()
    {
        healthBar.SetHealth(currentHealth);
    }

    public void takeDamage(int damage)
    {
        currentHealth -= damage;
        SetHealth();
    }
}
