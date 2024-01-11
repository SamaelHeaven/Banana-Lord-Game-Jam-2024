using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Rigidbody2D _rigidbody;

    private Vector3 _lastPosition;
    
    private void Update()
    {
        if (_lastPosition != null)
        {
            var diff = (_lastPosition - transform.position);
            
            // Stupid logic not really working. Committing for other, will need to fix.
            if (diff.x != 0 || diff.y != 0) 
            {
                var x = 0;
                var y = 0;
                if (diff.x > diff.y)
                {
                    x = (diff.x > 0 ? -1 : 1);
                    y = 0;
                }
                else
                {
                    y = (diff.y > 0 ? -1 : 1);
                    x = 0;
                }
                _animator.SetFloat("X", x);
                _animator.SetFloat("Y", y);
            }
        }
        
        _lastPosition = transform.position;
    }
}
