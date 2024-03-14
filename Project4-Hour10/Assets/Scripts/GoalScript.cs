using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalScript : MonoBehaviour
{
    public bool isSolved = false;
    private void OnTriggerEnter(Collider col)
    {
        GameObject colObj = col.gameObject;
        if (colObj.tag == gameObject.tag)
        {
            isSolved = true;
            GetComponent<Light>().enabled = false;
            Destroy(colObj);
        }
    }
}
