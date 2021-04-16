using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeManager : MonoBehaviour
{

    public SpriteRenderer black;
    public SpriteRenderer white;

    private Color color;
    private WaitForSeconds waitTime = new WaitForSeconds(0.01f);

    public void FadeOut(float _speed = 0.02f) {
        StartCoroutine(FadeOutCoroutine(_speed));
    }

    public void FadeIn(float _speed = 0.01f) {
        StartCoroutine(FadeInCoroutine(_speed));
    }

    public void PlashOut(float _speed = 0.005f) {
        StartCoroutine(PlashOutCoroutine(_speed));
    }

    IEnumerator FadeOutCoroutine(float _speed) {

        color = black.color;

        while(color.a < 1f) {
            color.a += _speed;
            black.color = color;
            yield return waitTime;
        }

    }

    IEnumerator PlashOutCoroutine(float _speed) {

        color = white.color;

        while(color.a < 1f) {
            color.a += _speed;
            white.color = color;
            yield return waitTime;
        }

    }

    IEnumerator FadeInCoroutine(float _speed) {

        color = black.color;

        while(color.a > 0f) {
            color.a -= _speed;
            black.color = color;
            yield return waitTime;
        }

    }
}
