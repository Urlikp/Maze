using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Obsolete("This class is obsolete. Use PlayerDamageMove instead.")]
public class Spikes : MonoBehaviour
{
    public float damage;

    private float _damage_cooldown = .5f;

    private bool _enabled = true;

    PlayerAttributes PlayerAttributes;

    // Set some variables
    void Start()
    {
        PlayerAttributes = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAttributes>();
    }

    // Give damage to player
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (_enabled)
            {
                PlayerAttributes.ModifyHealth(-damage);
                StartCoroutine("WaitForCooldown");
            }
        }
    }

    // Cooldown before another damage is applied
    private IEnumerator WaitForCooldown()
    {
        _enabled = false;
        yield return new WaitForSeconds(_damage_cooldown);
        _enabled = true;
    }
}
