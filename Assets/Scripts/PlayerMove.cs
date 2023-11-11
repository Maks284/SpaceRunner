using UnityEngine;

[RequireComponent(typeof(PlayerStats))]
public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    private float _maxHeigth;
    [SerializeField]
    private float _minHeigth;
    [SerializeField]
    private float _maxWidth;
    [SerializeField]
    private float _minWidth;

    private PlayerStats _playerStats;
    private Transform _currentPosition;

    private void Awake()
    {
        _playerStats = GetComponent<PlayerStats>();
    }

    private void Start()
    {
        transform.position = Vector2.zero;
        _currentPosition = transform;
    }

    private void Update()
    {
        float horizontal = _playerStats.Speed * Input.GetAxis("Mouse X");
        float vertical = _playerStats.Speed * Input.GetAxis("Mouse Y");

        TryMove(horizontal, vertical);
    }

    private void TryMove(float horizontal, float vertical)
    {
        if (_currentPosition.position.x <= _maxWidth && horizontal > 0)
            MoveRight(horizontal);

        if (_currentPosition.position.x >= _minWidth && horizontal < 0)
            MoveLeft(horizontal);

        if (_currentPosition.position.y <= _maxHeigth && vertical > 0)
            MoveUp(vertical);

        if (_currentPosition.position.y >= _minHeigth && vertical < 0)
            MoveDown(vertical);
    }

    private void MoveRight(float horizontal)
    {
        transform.Translate(horizontal * Time.deltaTime, 0, 0);
        _currentPosition = transform;
    }

    private void MoveLeft(float horizontal)
    {
        transform.Translate(horizontal * Time.deltaTime, 0, 0);
        _currentPosition = transform;
    }

    private void MoveUp(float vertical) 
    {
        transform.Translate(0, vertical * Time.deltaTime, 0);
        _currentPosition = transform;
    }

    private void MoveDown(float vertical)
    {
        transform.Translate(0, vertical * Time.deltaTime, 0);
        _currentPosition = transform;
    }
}
