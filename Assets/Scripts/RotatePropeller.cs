using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePropeller : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float _speed;
    [SerializeField] private GameManager _gm;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_gm.isGameOver == false)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                transform.Rotate(new Vector3(0,0,-1) * Time.deltaTime * _speed * 3);
            }
            else
            {
                transform.Rotate(new Vector3(0,0,-1) * Time.deltaTime * _speed );
            }
        }
       
        
    }
}
