using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class Attacker : MonoBehaviour
{
    [SerializeField] private float _timeBetweenAttack = 1.5f;
    [SerializeField] private Hitbox _hitbox;

    private bool _isReady = true;

    public void Attack()
    {
        if(_isReady)
        {
            _isReady = false;
            _hitbox.gameObject.SetActive(true);
            StartCoroutine(Cooldown());
        }
    }

    private IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(_timeBetweenAttack);
        _isReady = true;
    }
}
