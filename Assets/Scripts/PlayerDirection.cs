using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDirection : MonoBehaviour
{
    public GameObject player;
    PlayerManager playerManager;

    // Start is called before the first frame update
    void Start()
    {
        playerManager = player.GetComponent<PlayerManager>();
    }

    void FixedUpdate()
    {
        Vector3 direction = playerManager.transform.position + new Vector3(playerManager.xPos, 0, playerManager.zPos) * playerManager.moveSpeed;
        transform.LookAt(direction);
    }
}
