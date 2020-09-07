/*  
*	TickLuck team
*	All rights reserved
*/

using UnityEngine;

public class BlockDestroy : MonoBehaviour
{
    #region Variables
    [SerializeField]
    private float minChaseDistance = 10f;
    public GameObject destroy_effect;
    #endregion

    #region UnityMethods
   
    void Update()
    {
        if(Vector2.Distance(gameObject.transform.position, PlayerMovement.Position) >= minChaseDistance)
        {
            Destroy(gameObject);
        }
    }
	
	#endregion
}
