using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public void SetTimeScale(float scale)
    {
        Time.timeScale = scale;
    }
}
