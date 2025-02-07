using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;


    public string songName = "GurennoYumiya";


    public int MAX_RAITO_POINT = 5;
    public int MAX_DIGIT_POINT = 1000000;
    public int PERFECT_POINT = 5;

    public int MAX_COMBO = 0;

    public int point = 0;
    public int combo = 0;

    public int perfect = 0;
    public int great = 0;
    public int bad = 0;
    public int miss = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;//このインスタンスをstatic な instanceに登録
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);//２回目以降重複して作成してしまったgameObjectを削除
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(songName);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            Debug.Log(perfect);
        }
    }
}
