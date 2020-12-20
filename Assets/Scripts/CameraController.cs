using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float lerpSpeed;
    public float distanceTillLerp;

    private PlayerMovement player;

    private bool isLerpingToPlayer;

    void Start()
    {
        player = FindObjectOfType<PlayerMovement>();
    }

    void Update()
    {
        if (player != null)
        {
            if (isLerpingToPlayer)
            {
                float newX = Mathf.Lerp(transform.position.x, player.transform.position.x, lerpSpeed * Time.deltaTime);
                transform.position = new Vector3(newX, transform.position.y, transform.position.z);
                if (Mathf.Abs(player.transform.position.x - transform.position.x) < 1f)
                {
                    isLerpingToPlayer = false;
                }
            }
            else
            {
                if (Mathf.Abs(player.transform.position.x - transform.position.x) > distanceTillLerp)
                {
                    isLerpingToPlayer = true;
                }
            }
        }
    }
}
