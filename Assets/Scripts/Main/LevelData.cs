using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelData", menuName = "Level Data")]
public class LevelData : ScriptableObject
{
    public int levelNumber;
    public int numOfTargets;
    public int numOfBarriers;
    public int viewingTime;
    public Vector3[] targetPos;
    public Vector3[] barrierPos;
}
