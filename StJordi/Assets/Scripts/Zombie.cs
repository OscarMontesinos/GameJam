using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : Unit
{
    Animator animator;

    private void Start()
    {
        animator = transform.GetChild(0).GetComponent<Animator>();
    }
    public override void Update()
    {
        base.Update();
        transform.LookAt(player.transform.position);
    }
    public override void TakeDmg(int dmg)
    {
        base.TakeDmg(dmg);
        animator.SetTrigger("Hit");
    }
    public override IEnumerator Golpear()
    {

        animator.SetTrigger("Attack");
        return base.Golpear();
    }
}
