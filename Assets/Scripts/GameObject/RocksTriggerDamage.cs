using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocksTriggerDamage : MonoBehaviour {
    public bool isDamaging;
    public float damage = 10;
    public float dTime = 10;

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            other.SendMessage((isDamaging)?"TakeDamage":"HealDamage",   damage);
        }
    }
}
