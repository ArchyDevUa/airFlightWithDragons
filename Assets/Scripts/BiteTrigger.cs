using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BiteTrigger : MonoBehaviour
{
    [SerializeField] public Animator _dragon;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _dragon.SetTrigger("BiteTrigger");
        }
        
    }
}
