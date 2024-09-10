using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour
{
    [SerializeField] Sprite[] gameSprites;
    [SerializeField] Sprite newSprite;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        newSprite = gameSprites[Random.Range(0, gameSprites.Length)];

        gameObject.GetComponent<SpriteRenderer>().sprite = newSprite;
    }


}
