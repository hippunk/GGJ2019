﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "WindForce")]
public class WindForce : ScriptableObject
{
    public Vector3 force;
    public Vector3 normalized;
    public Vector3 MaxClampedTest;
}
