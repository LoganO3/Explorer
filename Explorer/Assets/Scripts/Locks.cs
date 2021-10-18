using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Locks : MonoBehaviour
{

    [SerializeField] int lockLevel = 0;
    Player player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(player.accessLevel >= lockLevel)
        {
            Destroy(gameObject);
        }
    }
}
