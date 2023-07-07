using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControler : MonoBehaviour
{
    [SerializeField] public float velocidad; 
    [SerializeField] public CinemachineBrain brain;
    public Rigidbody2D rbody;
    public Vector2 inputMove; //Hice la variable pública para ver el input



    public void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        //brain = GetComponent<CinemachineBrain>();
    }
    void Update()
    {
        

        if (Input.GetKeyDown(KeyCode.Space))
        {
            shotBullet();
        }
    }

    private void FixedUpdate()
    {
        ProcesarMovimiento();
        brain.ManualUpdate();
        
    }

    private void shotBullet()
    {
        Debug.Log("Bang");
        //throw new NotImplementedException();
    }

    // Update is called once per frame
    void ProcesarMovimiento()
    {
        inputMove.x = Input.GetAxis("Horizontal");
        inputMove.y = Input.GetAxis("Vertical");

        rbody.velocity = inputMove * velocidad;

        //rbody.velocity = new Vector2(inputHorizontal * velocidad, inputVertical * velocidad);
    }
}