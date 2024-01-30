using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class EmissionRate : MonoBehaviour
{
    public ParticleSystem ps;
    public TextMeshProUGUI liveText;
    public float initRate = 5.0f;
    public float rateStep = 0.1f;


    void Start()
    {
        liveText = GetComponent<TextMeshProUGUI>();
        ps.emissionRate = initRate;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow) && ps.emissionRate < 10)
        {
            var emission = ps.emission;
            emission.rateOverTime = new ParticleSystem.MinMaxCurve(emission.rateOverTime.constantMax + rateStep);
        }

        else if (Input.GetKey(KeyCode.DownArrow) && ps.emissionRate > 0)
        {
            var emission = ps.emission;
            emission.rateOverTime = new ParticleSystem.MinMaxCurve(Mathf.Max(0, emission.rateOverTime.constantMax - rateStep));
        }

        liveText.text = "Emission Rate: " + Math.Round(ps.emissionRate, 1).ToString();

    }
}
