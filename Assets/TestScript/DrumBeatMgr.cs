using System.Diagnostics;
using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrumBeatMgr : MonoBehaviour
{
    private int currentTrackId = -999;//当前的轨道
    private Image[] tracksIMgs;
    private Transform[] tracksPoses;
    private Transform line;
    public GameObject pointPre;
    public AudioSource bgm;
    public Slider bgmslider;
    private bool _dragSkider = false;
    private float _cooldown = 0.05f;
    public TrackTimerLists_Dic trackTimerLists_Dic;
    //轨道变量
    public int currentTrackCounts = 3;
    //string isonString = "";
    private void Start()
    {
        bgm.Pause();
    }
    void OnClickPlay()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (bgm.isPlaying)
            {
                bgm.Pause();

            }
            else
            {
                bgm.Play();
            }
        }
    }
    private void Update()
    {
        OnClickPlay();
        if (!_dragSkider)
        {
            bgmslider.value = bgm.time / bgm.clip.length;
        }
        else
        {
            bgm.time = bgmslider.value * bgm.clip.length;
        }

        foreach (var point in trackTimerLists_Dic.trackTimerLists)
        {
            point.gameObject.transform.position = new Vector3(point.trackId, (bgm.time - (point.timer)) * 10, 0);
        }
        _cooldown -= Time.deltaTime;
        if (_cooldown <= 0)
        {
            _cooldown = 0.05f;
            AddPointFromKeyCode(KeyCode.Q);
            AddPointFromKeyCode(KeyCode.W);
            AddPointFromKeyCode(KeyCode.E);
        }
    }
    private void AddPoint(int trackId, float currentTime)
    {
        PointGameObject pNode=new PointGameObject();
        pNode.timer=currentTime;
        pNode.trackId=trackId;
        pNode.gameObject=Instantiate(pointPre);
        trackTimerLists_Dic.trackTimerLists.Add(pNode);
    }
    public void AddPointFromKeyCode(KeyCode KeyCode)
    {
        if (Input.GetKey(KeyCode))
        {
            if (currentTrackCounts == 3)
            {
                switch (KeyCode)
                {
                    case KeyCode.Q:
                        currentTrackId = -3;
                        break;
                    case KeyCode.W:
                        currentTrackId = 0;
                        break;
                    case KeyCode.E:
                        currentTrackId = 3;
                        break;
                }
            }
            else if (currentTrackCounts == 4)
            {
                switch (KeyCode)
                {
                    case KeyCode.Q:
                        currentTrackId = -3;
                        break;
                    case KeyCode.W:
                        currentTrackId = -1;
                        break;
                    case KeyCode.E:
                        currentTrackId = 1;
                        break;
                    case KeyCode.R:
                        currentTrackId = 3;
                        break;
                }

            }
            else if (currentTrackCounts == 5)
            {
                switch (KeyCode)
                {
                    case KeyCode.Q:
                        currentTrackId = -4;
                        break;
                    case KeyCode.W:
                        currentTrackId = -2;
                        break;
                    case KeyCode.E:
                        currentTrackId = 0;
                        break;
                    case KeyCode.R:
                        currentTrackId = 2;
                        break;
                    case KeyCode.T:
                        currentTrackId = 4;
                        break;
                }

            }
            AddPoint(currentTrackId,bgm.time);
        }
    }
}
