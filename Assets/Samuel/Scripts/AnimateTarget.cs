using System;
using UnityEngine;

public class AnimateTarget : MonoBehaviour
{
    [SerializeField] private float delay;
    [SerializeField] private float animateSpeed;
    private float _clock;
    private float _targetScale;
    private bool _animate;
    private bool _destroy;

    private void Start()
    {
        var objTransform = transform;
        _targetScale = objTransform.localScale.x;
        objTransform.localScale = new Vector3(0.0001f, 0.0001f, 0f);
        _animate = true;
    }

    private void Update()
    {
        var objTransform = transform;
        var localScale = objTransform.localScale;
        if (_animate && transform.localScale.x < _targetScale)
        {
            var scaleIncrease = animateSpeed * Time.deltaTime;
            transform.localScale = new Vector3(localScale.x + scaleIncrease, localScale.y + scaleIncrease, 0);
        }

        if (transform.localScale.x > _targetScale)
        {
            transform.localScale = new Vector3(_targetScale, _targetScale, 0);
        }
        _clock += Time.deltaTime;
        if (_clock > delay)
        {
            _destroy = true;
        }
        if (!_destroy)
        {
            return;
        }
        var scaleDecrease = animateSpeed * Time.deltaTime;
        objTransform.localScale = new Vector3(localScale.x - scaleDecrease, localScale.y - scaleDecrease, 0);
        if (transform.localScale.x <= 0)
        {
            Destroy(gameObject);
        }
    }
}