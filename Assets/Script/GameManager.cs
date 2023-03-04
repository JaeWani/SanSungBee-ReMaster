using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public enum Difficulty
    {
        Easy = 1,
        Medium,
        Hard,
        Very_Hard
    }

    [Header ("게임 내 값")]
    [Range (0,50)] public float SpawnDelay;
    public Difficulty CurrentDifficulty = Difficulty.Easy;

    [Header ("스코어")]
    public float Score;

    void Start()
    {
        TextManager.Instance.SpawnLogic(SpawnDelay);
    }

    void Update()
    {

    }
}
