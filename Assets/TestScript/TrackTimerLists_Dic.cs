using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="newTrackTimer",menuName ="CreateData/Create New TrackTimerData")]
public class TrackTimerLists_Dic : ScriptableObject
{
    public List<PointGameObject> trackTimerLists;
}
public class PointData
{
    public float timer;
    public int trackId;
    public PointData()
    {

    }
    public PointData(int timer,int trackId)
    {
        this.timer=timer;
        this.trackId=trackId;
    }
}
[System.Serializable]
public class PointGameObject:PointData
{
    public GameObject gameObject;
}
