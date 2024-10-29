using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DamageIndicater : MonoBehaviour
{
    public Image Image;
    public float FlashSpeed;

    private Coroutine coroutine;

    // Start is called before the first frame update
    void Start()
    {
        CharacterManager.Instance.Player.condition.onTakeDamage += Flash;
    }

    public void Flash()
    {
        if(coroutine != null)
        {
            StopCoroutine(coroutine);
        }

        Image.enabled = true;
        Image.color = new Color(1f, 100f / 255f, 100f / 155f);
        coroutine = StartCoroutine(FadeAway());
    }

    private IEnumerator FadeAway()
    {
        float startAlpha = 0.3f;
        float a = startAlpha;

        while (a > 0)
        {
            a -= (startAlpha / FlashSpeed) * Time.deltaTime;
            Image.color = new Color(1f, 100f / 255f, 100f / 155f, a);
            yield return null;
        }

        Image.enabled = false;
    }
}
