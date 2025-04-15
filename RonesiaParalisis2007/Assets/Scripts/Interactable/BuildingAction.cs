using System;
using UnityEngine;

public class BuildingAction : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InteractableDoor.OnEnterBuilding += BuildingDoesSomething;
    }

    private void BuildingDoesSomething()
    {
        transform.localScale = Vector3.one;
    }

    private void OnDisable()
    {
        InteractableDoor.OnEnterBuilding -= BuildingDoesSomething;
    }
}
