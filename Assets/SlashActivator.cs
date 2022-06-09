using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class SlashActivator : MonoBehaviour
{
    [SerializeField]
    VisualEffect slashEffect;

    [SerializeField]
    Light slashLight;

    [SerializeField]
    private float maxLighting;
    public void playVFX()
    {
        slashEffect.Play();
        StartCoroutine(lightCorroutine());
    }

    private IEnumerator lightCorroutine()
    {
        slashLight.enabled = true;
        float targetTime = 0.15f;
        float elapsedTime = 0;
        while (elapsedTime < targetTime)
        {
            yield return new WaitForEndOfFrame();
            elapsedTime += Time.deltaTime;
            slashLight.intensity = Mathf.Lerp(0, maxLighting, (elapsedTime/targetTime));
        }
        elapsedTime = 0;

        while (elapsedTime < targetTime)
        {
            yield return new WaitForEndOfFrame();
            elapsedTime += Time.deltaTime;
            slashLight.intensity = Mathf.Lerp(maxLighting, 0, (elapsedTime / targetTime));
        }
        slashLight.enabled = true;
    }

    public void ReceiveMessage(MessageType argument)
    {
        if (argument == MessageType.TYPE3)
        {
            Debug.Log(this.name + " Received the message!");
        }
    }
}
