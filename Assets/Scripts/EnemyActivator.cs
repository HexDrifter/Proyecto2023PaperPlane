using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyActivator : MonoBehaviour
{
    [SerializeField] public Camera cam;
    [SerializeField] public float cameraOffset;
    public GameObject[] enemies;

    private void Awake()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
    }
    private void Start()
    {
        cam = Camera.main;
        

    }

    private void Update()
    {
        foreach (GameObject enemy in enemies)
        {
            //Debug.Log("Cam Position: "+cam.transform.position.x+"Enemy Position: "+enemy.transform.position.x + "Enemy Name" + enemy.name);
            
            if((cam.transform.position.x + cameraOffset)> enemy.transform.position.x)
            {
                //Debug.Log(Camera.);
                enemy.SetActive(true);
            }
        }

    }

}
