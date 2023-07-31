using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyActivator : MonoBehaviour
{
    [SerializeField] public Camera cam;
    [SerializeField] public float cameraOffset;
    private List<GameObject> enemies = new List<GameObject>();

    private void Awake()
    {
        GameObject[] enemyObjects = GameObject.FindGameObjectsWithTag("Enemy");
        enemies.AddRange(enemyObjects);
    }
    private void Start()
    {
        cam = GetComponent<Camera>();
        

    }

    private void Update()
    {
        ActivateEnemies();

    }
    private void ActivateEnemies()
    {

        


        foreach (GameObject enemy in enemies)
        {
            if ((cam.transform.position.x + cameraOffset) > enemy.transform.position.x)
            {
                enemy.SetActive(true);
            }
        }
    }
    public void RemoveEnemy(GameObject enemyToRemove)
    {
        enemies.Remove(enemyToRemove);
    }

}
