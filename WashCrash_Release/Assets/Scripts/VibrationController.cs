/*  
*	TickLuck team
*	All rights reserved
*/

using UnityEngine;

public class VibrationController : MonoBehaviour
{
    #region Variables
    public static bool is_vibrating = false;
    public static bool is_on = true;
    #endregion



    #region UnityMethods

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        if (is_vibrating && is_on)
        {
            
            Handheld.Vibrate();
            is_vibrating = false;
        }
    }
	
	#endregion
}
