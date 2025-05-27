using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ClawHolding : MonoBehaviour
{

    [SerializeField] private List<ClawDetector> _detectors;
    [SerializeField] private Claw _clawA;
    [SerializeField] private Claw _clawB;

    public void Update()
    {
        if (_detectors.All(it => it.Contacting))
        {
            foreach (var rb in _detectors.First().Bodies)
            {
                rb.isKinematic = true;
                rb.transform.parent = transform;
            }
            _clawA.Fixed = true;
            _clawB.Fixed = true;
        }
        else
        {
            _clawA.Fixed = false;
            _clawB.Fixed = false;
        }
    }
}