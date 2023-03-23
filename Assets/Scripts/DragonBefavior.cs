using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonBefavior : MonoBehaviour
{
    
    [SerializeField] private float _speed = 1.0f;
    [SerializeField] private float _healthCount;
    [SerializeField] private GameObject _healthObj;
    [SerializeField] private Animator _dragonAnimation;
    [SerializeField] private GameObject _allHealth;
    [SerializeField] private GameManager _gm;
    [SerializeField] private AudioClip _dragonDeath;
    private AudioSource _audio;
    
    // Start is called before the first frame update
    void Start()
    {
        _audio = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_gm.isGameOver == false)
        {
            transform.LookAt(GameObject.Find("Player").transform);
            transform.Translate(Vector3.forward * Time.deltaTime * _speed);
            if (_healthCount <= 0)
            {
                _allHealth.SetActive(false);
                _dragonAnimation.SetBool("isDead",true);
                StartCoroutine(KillDragon());


            }
       
            _healthObj.transform.localScale = new Vector3(_healthCount, 1, 1);
        }
        else
        {
            _dragonAnimation.enabled = false;
        }
       
      
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ammo"))
        {
            _healthCount = _healthCount - 0.2f;
        }
        
        
        
    }

    IEnumerator KillDragon()
    {
        _audio.PlayOneShot(_dragonDeath,1f);
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
        _gm.plusOneKilledDragon();
        
    }
}
