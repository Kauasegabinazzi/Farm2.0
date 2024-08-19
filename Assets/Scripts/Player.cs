using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool isPaused;

    [SerializeField] private float speed;
    [SerializeField] private float runSpeed;
    private float initialSpeed;

    private Rigidbody2D rigid;
    private bool _isRunning;
    private Vector2 _direction;
    private bool _isRolling;
    private bool _isCutting;
    private bool _isDigging;
    private bool _isWatering;
    private int handLingObj;
    private PlayerItens _playerItens;
    public Vector2 direction
    {
        get { return _direction; }
        set { _direction = value; }
    }

    public bool isRunning
    {
        get { return _isRunning; }
        set { _isRunning = value; }
    }

    public bool isRolling
    {
        get { return _isRolling; }
        set { _isRolling = value; }
    }

    public bool IsCutting
    {
        get { return _isCutting; }
        set { _isCutting = value; }
    }

    public bool IsDigging
    {
        get { return _isDigging; }
        set { _isDigging = value; }
    }

    public bool IsWatering
    {
        get { return _isWatering; }
        set { _isWatering = value; }
    }

    public int HandLingObj { get => handLingObj; set => handLingObj = value; }

    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        initialSpeed = speed;
        _playerItens = GetComponent<PlayerItens>();
    }

    private void Update()
    {
        if (!isPaused)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                handLingObj = 0;
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                handLingObj = 1;
            }

            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                handLingObj = 2;
            }

            onInput();
            onRun();
            onRolling();
            OnCutting();
            OnDigging();
            OnWatering();
        }
    }

    private void FixedUpdate()
    {
        if (!isPaused)
        {
            onMove();
        }
    }

    #region movement

    void onInput()
    {
        _direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    void onMove()
    {
        rigid.MovePosition(rigid.position + _direction * speed * Time.fixedDeltaTime);
    }

    void onRun()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = runSpeed;
            _isRunning = true;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = initialSpeed;
            _isRunning = false;
        }
    }

    void onRolling()
    {
        //botão direito do mouse
        if (Input.GetMouseButtonDown(1))
        {
            speed = runSpeed;
            _isRolling = true;
        }

        if (Input.GetMouseButtonUp(1))
        {
            speed = initialSpeed;
            _isRolling = false;
        }
    }

    void OnCutting()
    {
        if (handLingObj == 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                IsCutting = true;
                speed = 0f;
            }

            if (Input.GetMouseButtonUp(0))
            {
                IsCutting = false;
                speed = initialSpeed;
            }
        }
    }

    void OnDigging()
    {
        if (handLingObj == 1)
        {
            if (Input.GetMouseButtonDown(0))
            {
                IsDigging = true;
                speed = 0f;
            }

            if (Input.GetMouseButtonUp(0))
            {
                IsDigging = false;
                speed = initialSpeed;
            }
        }
    }

    void OnWatering()
    {
        if (handLingObj == 2)
        {
            if (Input.GetMouseButtonDown(0) && _playerItens.currentWater > 0)
            {
                _playerItens.currentWater--;
                IsWatering = true;
                speed = 0f;
            }

            if (Input.GetMouseButtonUp(0) || _playerItens.currentWater < 0)
            {
                IsWatering = false;
                speed = initialSpeed;
            }

            if (IsWatering)
            {
                _playerItens.currentWater -= 0.01f;
            }
        }
    }

    #endregion
}
