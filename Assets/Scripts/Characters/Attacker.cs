using UnityEngine;
using System;

public class Attacker : MonoBehaviour
{
    [SerializeField] private float _timeBetweenAttack = 1.5f;
    [SerializeField] private float _range = 0.2f;
    [SerializeField] private Attack _attack;

    private float _timer = 0;

    private void Update()
    {
        _timer -= Time.deltaTime;
    }

    public void Attack()
    {
        if(_timer <= 0)
        {
            _timer = _timeBetweenAttack;
            _attack.gameObject.SetActive(true);
        }
    }
}
