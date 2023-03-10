using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundMain : BaseSound
{
    [SerializeField] MainManager mainManager;

    public enum SE
    {
        Touch,
    }

    // Start is called before the first frame update
    void Start()
    {
        LoadBGM(mainManager.songName);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space) && !mainManager.isStart)
        {
            mainManager.isStart = true;
            mainManager.SetStartTime(Time.time);
            Debug.Log(mainManager.startTime);
            PlayBGM();
        }

    }
}
