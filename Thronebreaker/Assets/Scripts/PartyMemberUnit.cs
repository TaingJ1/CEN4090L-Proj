using UnityEngine;
using TMPro;
using System;
using Unity.VisualScripting;
using System.Collections;

public abstract class PartyMemberUnit : MonoBehaviour
{
    public UnitSO unitData;

    [NonSerialized]
    public BattleManager manager;

    [SerializeField] protected int currentHealth;
    [SerializeField] protected int physAttack;
    [SerializeField] protected int magicAttack;
    [SerializeField] protected int currentMana;

    [SerializeField] protected int defense;

    public HealthBar healthBar;
    public ManaBar manaBar;
    public PlayerSelectionMenu selectionMenu;

    protected virtual void Awake()                // Sets the unit's stats at beginning of battle
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
    protected virtual void Start()
    {
        Debug.Log($"{unitData.unitName} has {unitData.maxHealth} health");
    }

    public virtual IEnumerator DoTurn()
    {
        Debug.Log($"{unitData.unitName} is taking a turn");

        selectionMenu.gameObject.SetActive(true);
        selectionMenu.SetCurrentUnit(this);
        
        yield return selectionMenu.StartCoroutine(selectionMenu.SelectAction());
    }

    public void SetHealth()
    {
        healthBar.SetHealth(currentHealth);
    }

    public virtual void TakeDamage(int damage)
    {
        currentHealth -= damage;
        SetHealth();
    }
}
