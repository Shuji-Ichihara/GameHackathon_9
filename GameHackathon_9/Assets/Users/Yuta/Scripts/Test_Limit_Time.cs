using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Test_Limit_Time : MonoBehaviour
{
    private float up_time = 0.0f;
    private int time_limit = 0;

    public float Max_Up_Time = 1f;
    public int Max_Time_Limit = 90;

    // Update is called once per frame
    void Update()
    {
        up_time += Time.deltaTime;

        //Debug.Log(time_limit);

        if(up_time >= Max_Up_Time)
        {
            time_limit++;
            up_time = 0;
        }

        if(time_limit >= Max_Time_Limit)
        {
            SceneManager.LoadScene("Test_END");
        }
    }
}
