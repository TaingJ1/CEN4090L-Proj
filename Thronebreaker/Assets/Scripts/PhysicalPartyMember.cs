using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class PhysicalPartyMember : PartyMemberUnit
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        base.Start();
    }

    public override IEnumerator DoTurn()
    {
        Debug.Log("Physical party member prepares.");

        // Attack logic here

        yield return base.DoTurn();
    }

    public void BaseAttack(EnemyUnit target)
    {
        int damage = physAttack;
        target.TakeDamage(damage);
        Debug.Log("Phys Party Member: Base Attack");
    }

    public void HeavyAttack(EnemyUnit target)
    {
        int damage = physAttack * 2;
        target.TakeDamage(damage);
        Debug.Log("Phys Party Member: Heavy Attack");
    }
}
