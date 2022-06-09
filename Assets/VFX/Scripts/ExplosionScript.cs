using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class ExplosionScript : MonoBehaviour
{
    [SerializeField]
    VisualEffect explosionEffect;

    [SerializeField]
    Light explosionLight;

    [SerializeField]
    private float maxLighting;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(explosionCorroutine());
    }

    
    private IEnumerator explosionCorroutine()
    {
        yield return new WaitForSeconds(1f);
        explosionEffect.Play();
        explosionLight.enabled = true;
        float targetTime = 0.15f;
        float elapsedTime = 0;
        while (elapsedTime < targetTime)
        {
            yield return new WaitForEndOfFrame();
            elapsedTime += Time.deltaTime;
            explosionLight.intensity = Mathf.Lerp(0, maxLighting, (elapsedTime / targetTime));
        }
        elapsedTime = 0;

        while (elapsedTime < targetTime)
        {
            yield return new WaitForEndOfFrame();
            elapsedTime += Time.deltaTime;
            explosionLight.intensity = Mathf.Lerp(maxLighting, 0, (elapsedTime / targetTime));
        }
        explosionLight.enabled = true;
        StartCoroutine(explosionCorroutine());
    }
}
