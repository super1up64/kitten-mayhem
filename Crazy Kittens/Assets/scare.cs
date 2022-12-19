using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scare : MonoBehaviour
{
    public GameObject GorillaPlayer;

    public GameObject RespawnPoint;

    public float JumpScareDuration;

    public GameObject jumpScareModel;

    private Collider col;

    public float shakeAmount = 0.3f;
    //public float decreaseFactor = 1.0f;

    Vector3 originalPos;

    void OnEnable()
    {
        originalPos = jumpScareModel.transform.localPosition;
    }

    void Update()
    {
        jumpScareModel.transform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;
    }
    private void Start()
    {
        jumpScareModel.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        col = other;
        StartCoroutine(Kill());
    }

    IEnumerator Kill()
    {
        jumpScareModel.SetActive(true);
        yield return new WaitForSeconds(JumpScareDuration);
        Respawn(col);
        jumpScareModel.SetActive(false);
    }

    void Respawn(Collider other)
    {
        if (other.gameObject.CompareTag("Body"))
        {
            GorillaPlayer.transform.position = RespawnPoint.transform.position;
        }
        if (other.gameObject.CompareTag("MainCamera"))
        {
            GorillaPlayer.transform.position = RespawnPoint.transform.position;
        }
    }
}