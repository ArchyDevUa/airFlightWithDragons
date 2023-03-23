using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    private float _leftRight;
    private float _upDown;
    private float _kren;
    [SerializeField] private AudioSource _sound;
    [SerializeField] private AudioClip _acseleration;
    [SerializeField] private GameObject _amoPrefab;
    [SerializeField] private GameObject _proppeler;
    [SerializeField] private GameManager _gm;

    private void Start()
    {
        Cursor.visible = false;
    }

    void Update()
    {
        if (_gm.isGameOver == false)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                _sound.PlayOneShot(_acseleration, 1.0f);
            }
        
            if (Input.GetKey(KeyCode.LeftShift))
            {
            
                transform.Translate(new Vector3(0,0,1) * Time.deltaTime * _speed * 3);
            }
            else
            {
                transform.Translate(new Vector3(0,0,1) * Time.deltaTime * _speed);
            }

            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
            {
                Instantiate(_amoPrefab,_proppeler.transform.position   ,transform.rotation * _amoPrefab.transform.rotation );
            
            }
        
        
            _leftRight = Input.GetAxis("Mouse X");
            _upDown = Input.GetAxis("Mouse Y");
            _kren = Input.GetAxis("Horizontal");
            transform.Rotate(new Vector3(-_upDown ,_leftRight,-_kren/2));
        }
       

    }
    
    
}
