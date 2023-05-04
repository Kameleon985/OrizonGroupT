using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundScroller : MonoBehaviour
{
    [SerializeField]
    private RawImage image;
    [SerializeField]
    private float horizontalSpeed=0,verticalSpeed =1;

    private void Start()
    {
        PlayerController.OnPlayerDeath += StopBackground;
    }

    private void StopBackground(float score)
    {
        gameObject.SetActive(false);
    }

    private void Update()
    {
        image.uvRect = new Rect(image.uvRect.position + new Vector2(horizontalSpeed,verticalSpeed) * Time.deltaTime, image.uvRect.size);
    }
}
