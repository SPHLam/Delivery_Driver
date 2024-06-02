using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour  // Camera position is always the same as the Car position
{
    [SerializeField]
    private GameObject _driver;
    // Start is called before the first frame update

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = _driver.transform.position + new Vector3(0, 0, -10);
    }
}
