/*  
*	TickLuck team
*	All rights reserved
*/

using UnityEngine;

public class TimeController : MonoBehaviour
{
    public void TimeScale_freeze(float scale)
    {
        Time.timeScale = scale;
    }

    public void TimeScale_normal()
    {
        Time.timeScale = 1f;
    }
}
