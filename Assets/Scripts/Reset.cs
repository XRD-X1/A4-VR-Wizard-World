using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset : MonoBehaviour
{
    public List<Transform> knives;
    public List<Transform> axes;
    public GameObject knife;
    public GameObject axe;
    private List<Vector3> realknivesPosition = new List<Vector3>();
    private List<Quaternion> realknivesRotation = new List<Quaternion>();
    private List<Vector3> realAxesPosition = new List<Vector3>();
    private List<Quaternion> realAxesRotation = new List<Quaternion>();

    private void Awake() {
        foreach (Transform item in knives)
        {
            realknivesPosition.Add(item.position);
            realknivesRotation.Add(item.rotation);
        }

        foreach (Transform item in axes)
        {
            realAxesPosition.Add(item.position);
            realAxesRotation.Add(item.rotation);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "ResetCube")
        {
            RespawnWeapons();
        }
    }

    public void RespawnWeapons()
    {
        for (int i = 0; i < realAxesRotation.Count; i++)
        {
            Instantiate(axe, realAxesPosition[i], realAxesRotation[i]);
        }
        for (int i = 0; i < realknivesPosition.Count; i++)
        {
            Instantiate(knife, realknivesPosition[i], realknivesRotation[i]);
        }
    }
}
