using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatFromTrackTimerData : MonoBehaviour
{
    [Header("轨道时刻表文件")]
    public TrackTimerLists_Dic trackTimerLists_Dic;
    public AudioSource bgm;
    public GameObject pointPre;
    private List<PointGameObject> tempTrackList = new List<PointGameObject>();
    private void Start()
    {
        CreatNecks();
    }
    public void CreatNecks()
    {
        if (trackTimerLists_Dic)
        {
            foreach (var item in trackTimerLists_Dic.trackTimerLists)
            {
                AddPoint(item.trackId, item.timer);
            }
        }
    }
    private void AddPoint(int trackId, float currentTime)
    {
        PointGameObject pNode = new PointGameObject();
        pNode.timer = currentTime;
        pNode.trackId = trackId;
        pNode.gameObject = Instantiate(pointPre);
        tempTrackList.Add(pNode);
    }
    private void Update()
    {
        foreach (var point in tempTrackList)
        {
            point.gameObject.transform.position = new Vector3(point.trackId, (bgm.time - point.timer) * -15, 0);
        }
    }
}
