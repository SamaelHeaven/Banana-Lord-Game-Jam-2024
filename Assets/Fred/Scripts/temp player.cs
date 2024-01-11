using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tempplayer : MonoBehaviour
{
    [SerializeField] private LayerMask platefromeLayerMask;
        public float Speed;
        private float Move;
    
        private Rigidbody2D rb;
    
        // Start is called before the first frame update
        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
        }
    
        // Update is called once per frame
        void Update()
        {
    
            if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
            {
                rb.AddForce(transform.up * 10, ForceMode2D.Impulse);
            }
    
    
    
            Move = Input.GetAxis("Horizontal");
    
            rb.velocity = new Vector2(Move * Speed, rb.velocity.y);
            
        }
    
        private void FixedUpdate()
        {
        }
    
        private bool IsGrounded()
        {
            float ExtraHeight = 0.1f;
            BoxCollider2D boxCollider = GetComponent<BoxCollider2D>();
            RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center,boxCollider.size,0f, Vector2.down,
                ExtraHeight, platefromeLayerMask);
            Color rayColor;
            if (raycastHit.collider != null)
            {
                rayColor = Color.green;
            }
            else
            {
                rayColor = Color.red;
            }
            Debug.DrawRay(boxCollider.bounds.center + new Vector3(boxCollider.bounds.extents.x,0),Vector2.down * (boxCollider.bounds.extents.y + ExtraHeight),rayColor);
            Debug.DrawRay(boxCollider.bounds.center - new Vector3(boxCollider.bounds.extents.x,0),Vector2.down * (boxCollider.bounds.extents.y + ExtraHeight),rayColor);
            Debug.DrawRay(boxCollider.bounds.center + new Vector3(0,boxCollider.bounds.extents.y),Vector2.down * (boxCollider.bounds.extents.x),rayColor);
            
            return raycastHit.collider != null;
        }
}
