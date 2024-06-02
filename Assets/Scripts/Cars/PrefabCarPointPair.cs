
using System;
using UnityEngine;

[Serializable]
public class PrefabCarPointPair
{
    [SerializeField] private Transform placementPoints;
    public Vector2 PlacementPoints => placementPoints.TransformDirection(placementPoints.position);
    public GameObject PrefCar;
}
