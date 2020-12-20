using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    public GameObject characterPrefab;

    private GameObject character;
    private PlayerMovement playerMovement;
    private PlayerCombat playerCombat;
    private PlayerHealth playerHealth;

    void Start()
    {
        SpawnCharacter();
    }

    void SpawnCharacter ()
    {
        if (character != null)
        {
            Destroy(character);
        }

        character = Instantiate(characterPrefab, transform);
        playerMovement = character.GetComponent<PlayerMovement>();
        playerCombat = character.GetComponent<PlayerCombat>();
        playerHealth = character.GetComponent<PlayerHealth>();
    }

    void OnMove (InputValue value)
    {
        if (playerMovement != null)
            playerMovement.Move(value.Get<Vector2>());
    }

    void Jump ()
    {
        if (playerMovement != null)
            playerMovement.Jump();
    }

    void OnPunch ()
    {
        if (playerCombat != null)
            playerCombat.Punch();
    }

    void OnKick ()
    {
        if (playerCombat != null)
            playerCombat.Kick();
    }

    void OnSpecial ()
    {
        if (playerCombat != null)
            playerCombat.Special();
    }

    void OnStartBlock ()
    {
        if (playerCombat != null)
            playerCombat.Block(true);
    }

    void OnEndBlock ()
    {
        if (playerCombat != null)
            playerCombat.Block(false);
    }
}
