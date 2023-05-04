using Newtonsoft.Json.Bson;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private PlayerInputs inputs;
    private InputAction movement;
    private Vector2 newPosition;
    private bool shielded;

    [SerializeField]
    private GameObject shieldedSprite;
    [SerializeField]
    [Range(1f,10f)]
    private float speed;

    public static event Action<float> OnPlayerDeath;

    private void Awake()
    {
        inputs = new PlayerInputs ();
        newPosition = new Vector2(transform.position.x, transform.position.y);
    }

    private void OnEnable()
    {
        movement = inputs.Actionmap.Dodge;
        movement.Enable();
        shielded = false;
    }

    public void ResetPlayer()
    {
        movement.Enable();
        Vector3 middleScreenPosition = new Vector3(Screen.width / 2, 20, 0);
        Vector3 middleWorldPosition = Camera.main.ScreenToWorldPoint(middleScreenPosition);
        transform.position = middleWorldPosition;
    }

    private void Update()
    {
        Vector3 pos = new Vector3(movement.ReadValue<float>(), 10f, 10f);
        var mousePos = Camera.main.ScreenToWorldPoint(pos);
        newPosition.x = transform.position.x + mousePos.x * Time.deltaTime * speed;
        if (newPosition.x < 8 && newPosition.x > -8)
        {
            transform.position = newPosition;
        }
    }

    public void ShieldedPickup()
    {
        shielded = true;
        shieldedSprite.SetActive(true);
        AudioManager.instance.PlaySFX("Shield");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        string tag = collision.gameObject.tag;

        switch (tag)
        {
            case "Obstacle":
                PlayerHit();
                break;
            case "PowerUp":
                PowerUpPickup();
                break;
            default:
                break;

        }

    }

    private void PlayerHit()
    {
        if (shielded)
        {
            shielded = false;
            shieldedSprite.SetActive(false);
            AudioManager.instance.PlaySFX("Click");
        }
        else
        {
            movement.Disable();
            float score = ScoreManager.StopTimer();
            OnPlayerDeath?.Invoke(score);
            AudioManager.instance.musicSource.Stop();
            AudioManager.instance.PlaySFX("Death");
            gameObject.SetActive(false);
        }
    }

    private void PowerUpPickup()
    {
        shielded = true;
        shieldedSprite.SetActive(true);
    }

    private void OnDisable()
    {
        movement.Disable();
    }
}
