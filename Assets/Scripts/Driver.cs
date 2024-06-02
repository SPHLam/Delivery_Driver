using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField]
    private float _steerSpeed = 300f;
    [SerializeField]
    private float _moveSpeed = 20f;

    private bool _hasPackage = false;
    private bool _isSpeedBuff = false;

    [SerializeField]
    private Color _packageColor = new Color(1,1,0,1);

    private SpriteRenderer _spriteRenderer;

    private float _speedBuff = 2f;


    // Start is called before the first frame update
    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(0, verticalInput, 0) * _moveSpeed * Time.deltaTime);
        transform.Rotate(new Vector3(0, 0, -horizontalInput) * _steerSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "World objects")
        {
            _moveSpeed = 20f;
            _isSpeedBuff = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Package")
        {
            if (!_hasPackage)
            {
                _hasPackage = true;
                SpriteRenderer package = collision.GetComponent<SpriteRenderer>();
                _spriteRenderer.color = package.color;
                Destroy(collision.gameObject);
            }
        }
        else if (collision.tag == "Customer")
        {
            if (_hasPackage)
            {
                _hasPackage = false;
                _spriteRenderer.color = _packageColor;
                Debug.Log("Package delivered");
            }
        }
        else if (collision.tag == "Speed pad")
        {
            if (!_isSpeedBuff)
            {
                _moveSpeed *= _speedBuff;
                _isSpeedBuff = true;
            }
        }
    }
}
