using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Teleport : MonoBehaviour
{
    public GameObject teleportAnchor;
        public GameObject teleportAnchor2;
    public InputActionReference button;
    public InputActionReference buttonb;
    private EnemySpawner enemySpawner;
    void Start()
    {
        enemySpawner = FindObjectOfType<EnemySpawner>();
    }

    void Update()
    {
        if (button.action.triggered)
        {
            this.transform.position = teleportAnchor.transform.position;
            enemySpawner.SpawnEnemies();
        }
        else if (buttonb.action.triggered)
        {
            this.transform.position = teleportAnchor2.transform.position;
        }
    }
}
