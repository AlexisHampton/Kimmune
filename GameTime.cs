using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//calculates the time used in the game as well as handles the day/night cycle
public class GameTime : Singleton<GameTime>
{
    public Clock gameTime = new Clock();
    public float timeUntilNextMinute = 3f;

    private void Start()
    {
        UIManager.Instance.UpdateTime(gameTime);
        StartCoroutine(TimeIsAConstruct());
    }

    IEnumerator TimeIsAConstruct()
    {
        yield return new WaitForSeconds(timeUntilNextMinute);
        gameTime.IncreaseTime();
        UIManager.Instance.UpdateTime(gameTime);

    }

    public void NextDay()
    {

    }
}
