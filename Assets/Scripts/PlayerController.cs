using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour {
    public float duration = .5f;
    public float magnitude = .1f;
    public Rigidbody2D rigidbody2D;
    public float sensitivityX = 1;
    public float minimumX = -2.1f;
    public float maximumX = 2.1f;

    float positionX = 0f;

    void Start()
    {
        rigidbody2D.gravityScale = 0;
        mainSlider.onValueChanged.AddListener(delegate { ValueChangeCheck(); });
        m_previous = mainSlider.value;
        
    }
    // Update is called once per frame
    void Update () {
        transform.position = new Vector3(mainSlider.value, transform.position.y, transform.position.z);
    }
    public void ValueChangeCheck()
    {
        renderer.flipX = mainSlider.value < m_previous;
        m_previous = mainSlider.value;
        renderer.transform.rotation = renderer.flipX ? Quaternion.Euler(0,0,5) : Quaternion.Euler(0, 0, -5);
    }

    public void DefaultValue()
    {
        renderer.transform.rotation = renderer.flipX ? Quaternion.Euler(0, 0, 0) : Quaternion.Euler(0, 0, 0);
    }


#pragma warning disable 649
    [SerializeField] Slider mainSlider;
    [SerializeField] SpriteRenderer renderer;
#pragma warning restore 649

    float m_previous;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Obstacles")
        {
            StartCoroutine(Falling());
            StartCoroutine(Shake());
            SoundManagerScript.gameOverAudioSource.Play();
            InsterstitialAd.instance.no++;
        }
        
        GetComponent<CapsuleCollider2D>().enabled = false;
    }

    IEnumerator Falling()
    {
        GameController.instance.gameOver = true;
        yield return new WaitForSeconds(.38f);
        rigidbody2D.gravityScale = 1;
    }

    IEnumerator Shake()
    {
        float elapsed = 0.0f;
        
        Vector3 originalCamPos = Camera.main.transform.position;

        while (elapsed < duration)
        {

            elapsed += Time.deltaTime;

            float percentComplete = elapsed / duration;
            float damper = 1.0f - Mathf.Clamp(4.0f * percentComplete - 3.0f, 0.0f, 1.0f);

            // map value to [-1, 1]
            float x = Random.value * 2.0f - 1.0f;
            float y = Random.value * 2.0f - 1.0f;
            x *= magnitude * damper;
            y *= magnitude * damper;

            Camera.main.transform.position = new Vector3(x, y, originalCamPos.z);

            yield return null;
        }

        Camera.main.transform.position = originalCamPos;
    }
}
