using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealsBar : MonoBehaviour
{
    [SerializeField] private float _duration;
    [SerializeField] private float _stepChangeHeals;

    private UnityEngine.UI.Slider _healsBar;
    private float _speed;

    private void OnEnable()
    {
        _healsBar =GetComponent<UnityEngine.UI.Slider>();
        _speed = _stepChangeHeals /_duration ;
    }

    public  void Increase()
    {
        float heals;

        if (_healsBar.value < _healsBar.maxValue)
        {
            heals = _healsBar.value + _stepChangeHeals;
            StartCoroutine( ChangeHeals(heals)); 
        }
    }

    public void Decrease()
    {
        float heals;

        if (_healsBar.value > _healsBar.minValue)
        {
            heals = _healsBar.value - _stepChangeHeals;
            StartCoroutine(ChangeHeals(heals));
        }
    }

    private IEnumerator ChangeHeals(float heals)
    {
        while (_healsBar.value!=heals)
        { 
            _healsBar.value = Mathf.MoveTowards(_healsBar.value, heals, _speed *Time.deltaTime);
            yield return null;
        }
    }
}