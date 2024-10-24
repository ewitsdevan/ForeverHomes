// Created by Devan Laczko, 03/10/2024
// Updated 04/10/2024

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsometricCamera : MonoBehaviour
{
    public float panSpeed = 6f;
    public Vector2 panLimitX;
    public Vector2 panLimitZ;
    private Vector2 _panPosition;
    private Vector3 _startPosition;
    
    public float zoomSpeed = 100f;
    public float zoomSmoothness = 5f;
    public float minZoom = 1f;
    public float maxZoom = 8f;
    private float _currentZoom = 7f;
    private float _startZoom;

    public bool bookOpen;
    
    public bool inMinigame;
    public float minigameZoom;
    public Vector3 minigamePan;
    
    private Camera _camera;
    private float _timer;
    private bool _isReset;
    
    private void Awake()
    {
        _startPosition = transform.position;
        _camera = GetComponentInChildren<Camera>();
        StartCoroutine(ResetTimer());
    }

    // Update is called once per frame
    void Update()
    {
        if (!inMinigame)
        {
            _panPosition = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            _currentZoom = Mathf.Clamp(_currentZoom - Input.mouseScrollDelta.y * zoomSpeed * Time.deltaTime, minZoom,
                maxZoom);
            _camera.orthographicSize =
                Mathf.Lerp(_camera.orthographicSize, _currentZoom, zoomSmoothness * Time.deltaTime);

            if (_isReset && !bookOpen  && !inMinigame)
            {
                transform.position += -transform.position * (panSpeed * Time.deltaTime);
                if (transform.position == _startPosition)
                    _isReset = false;
            }
            else if (!bookOpen)
            {
                transform.position += Quaternion.Euler(0, _camera.transform.eulerAngles.y, 0) *
                                      new Vector3(_panPosition.x, 0, _panPosition.y) * (panSpeed * Time.deltaTime);
                transform.position = new Vector3(Mathf.Clamp(transform.position.x, panLimitX.x, panLimitX.y),
                    transform.position.y, Mathf.Clamp(transform.position.z, panLimitZ.x, panLimitZ.y));
            }
        }
        else if (inMinigame)
        {
            _camera.orthographicSize =
                Mathf.Lerp(_camera.orthographicSize, minigameZoom, zoomSmoothness * Time.deltaTime);
        }
    }

    public void Reset()
    {
        if (!bookOpen && !inMinigame)
        {
            bookOpen = false;
            inMinigame = false;
            _currentZoom = 7f;
            transform.rotation = Quaternion.Slerp(transform.rotation, new Quaternion(0, 0, 0, 0), 2 * Time.deltaTime);
            _isReset = true;
        }
    }

    public void Book()
    {
        bookOpen = true;
        transform.position = Vector3.Lerp(transform.position, Quaternion.Euler(0, _camera.transform.eulerAngles.y, 0) * new Vector3(0, 0, 25), panSpeed * Time.deltaTime);
        transform.rotation = Quaternion.Slerp(transform.rotation, new Quaternion(-20, 0, -20, 0), 2 * Time.deltaTime);
    }

    IEnumerator ResetTimer()
    {
        WaitForSeconds delay = new WaitForSeconds(1);
        Vector3 lastPos = transform.position;
        _startZoom = _currentZoom;
        
        while (true)
        {
            _timer += 1;

            if (_timer >= 5)
            {
                if (lastPos == transform.position || _startZoom == _currentZoom)
                {
                    _timer = 0;
                    Reset();
                }
            }
            else if (lastPos != transform.position || _startZoom != _currentZoom)
            {
                _timer = 0;
                lastPos = transform.position;
                _startZoom = _currentZoom;
            }
            
            yield return delay;
        }
    }
}
