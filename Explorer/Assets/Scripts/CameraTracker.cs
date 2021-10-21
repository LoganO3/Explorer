using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTracker : MonoBehaviour
{
    [SerializeField] GameObject Player;
    [SerializeField] Vector3 offset;

    void Update()
    {
        float newZPosition = Player.transform.position.z - offset.z;
        transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y, -newZPosition);
    }
}