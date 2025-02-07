using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainManager : MonoBehaviour
{

    [SerializeField] SoundMain soundMain;

    public string songName;

    public int MAX_RAITO_POINT = 5;
    public int MAX_DIGIT_POINT = 1000000;
    public int PERFECT_POINT   = 5;

    public bool isStart      = false;
    public bool isEnd        = false;
    public float startTime   = 0;   // スタートボタンを押すまでの秒数を保存
    public float playerScore = 0;
    public float maxScore    = 0;
    public int point = 0;
    
    int combo = 0;

    int perfect  = 0;
    int great    = 0;
    int bad      = 0;
    int miss     = 0;

    public void SetStartTime(float startTime)
    {
        this.startTime = startTime;
    }

    public void Start()
    {
        songName = GameManager.Instance.songName;
    }

    public void Update()
    {
        if (soundMain == null && isStart && isEnd) return;  // AudioSourceが消えた状態でも参照してしまうためNull判定を追加
        if (soundMain.IsCheckEndBGM() && isStart && isEnd)
        {
            SetGameManagerScore();
            SceneManager.LoadScene("ResultScene");
        }
    }

    public void SetGameManagerScore()
    {
        GameManager.Instance.point  = point;
        GameManager.Instance.combo  = combo;
        GameManager.Instance.perfect= perfect;
        GameManager.Instance.great  = great;
        GameManager.Instance.bad    = bad;
        GameManager.Instance.miss   = miss;
    }

    public void ResetCombo()
    {
        combo = 0;
    }
    public void AddCombo()
    {
        combo++;
    }
    public int GetCombo()
    {
        return combo;
    }

    public int GetPoint()
    {
        return point;
    }

    
    // 0:perfect 1:great 2:bad 3:miss
    public void AddJudgeCount(int num)
    {
        switch (num)
        {
            case 0:
                perfect++;
                point += 5;
                break;
            case 1:
                great++;
                point += 3;
                break;
            case 2:
                bad++;
                point += 1;
                break;
            case 3:
                miss++;
                break;
        }
    }

    private void OnDestroy()
    {
        
    }

}
