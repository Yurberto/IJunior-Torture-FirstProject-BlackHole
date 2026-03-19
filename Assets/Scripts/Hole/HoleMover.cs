using UnityEngine;

namespace Assets.Scripts.Hole
{
    public class HoleMover : MonoBehaviour
    {
        [SerializeField] private Transform _transfrom;
        [SerializeField] private bl_Joystick _joystick;

        [SerializeField] private float _speed;

        private MoverService _moverService;

        private void Start()
        {
            _moverService = new MoverService(_transfrom);
        }

        private void Update()
        {
            if (_joystick.Horizontal == 0 && _joystick.Vertical == 0)
                return;

            _moverService.MoveOnSurface(new Vector3(_joystick.Horizontal, 0, _joystick.Vertical), _speed * Time.deltaTime);
        }
    }
}
