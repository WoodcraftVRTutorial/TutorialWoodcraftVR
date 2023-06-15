using System;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace Hitlab.Animations
{
    public enum HandStates
    {
        Rest,
        Point,
        Grip,
        UI
    }

    public class HandStateEnabled
    {
        public HandStateEnabled(HandStates state, bool enabled)
        {
            State = state;
            Enabled = enabled;
        }
        public HandStates State;
        public bool Enabled;
    }

    public class HandStateOverride
    {
        public HandStateOverride(HandStates state, bool over)
        {
            State = state;
            Override = over;
        }

    public HandStates State;
    public bool Override;
}

    [RequireComponent(typeof(Animator))]
    public class Hand : MonoBehaviour
    {

        [SerializeField] private float _speed;
        [SerializeField] private float _rayDeadZone;
        [SerializeField] private GameObject _rayInteractor;
        [SerializeField] private XRDirectInteractor _directInteractor;
        [SerializeField] private GameObject _uirayInteractor;
        [SerializeField] private GameObject _uirayAttachTransform;
        [SerializeField] private float _uirayRange = 5.0f;
        [SerializeField] private LayerMask _uiLayerMask;

        private Animator _animator;

        private float _gripTarget;
        private float _gripCurrent;
        private float _pointTarget;
        private float _pointCurrent;
        private float _uiTarget;
        private float _uiCurrent;
        private List<HandStateEnabled> _handStateEnabledPool = new List<HandStateEnabled>();
        private List<HandStateOverride> _handStateOverridePool = new List<HandStateOverride>();

        private const string POINT_LAYER_PARAM = "Point";
        private const string TRIGGER_LAYER_PARAM = "Grip";


        private HandStates _state;


        // Start is called before the first frame update
        void Start()
        {
            _handStateEnabledPool.Add(new HandStateEnabled(HandStates.Grip, true));
            _handStateEnabledPool.Add(new HandStateEnabled(HandStates.UI, true));
            _handStateEnabledPool.Add(new HandStateEnabled(HandStates.Point, true));

            _handStateOverridePool.Add(new HandStateOverride(HandStates.Grip, false));
            _handStateOverridePool.Add(new HandStateOverride(HandStates.UI, false));
            _handStateOverridePool.Add(new HandStateOverride(HandStates.Point, false));

            _animator = GetComponent<Animator>();
        }

        // Update is called once per frame
        private void Update()
        {
            if (_animator == null) return;
            AnimateHand();
        }
        private void FixedUpdate()
        {
            foreach (var handStateOverride in _handStateOverridePool)
            {
                if (handStateOverride.State == HandStates.UI && handStateOverride.Override)
                {
                    _uiTarget = 1;
                    _uirayInteractor.SetActive(true);
                    _state = HandStates.Rest;
                    return;
                }
            };

            foreach (var handStateEnabled in _handStateEnabledPool)
            {
                if (handStateEnabled.State == HandStates.UI && !handStateEnabled.Enabled)
                    return;
            };

            if (!(_state == HandStates.Rest || _state == HandStates.UI) || _animator == null) return;


            Ray ray = new Ray();
            ray.origin = _uirayAttachTransform.transform.position;
            ray.direction = _uirayAttachTransform.transform.forward;

            var didRayCastHit = Physics.Raycast(ray, _uirayRange, _uiLayerMask);

            _uiTarget = Convert.ToInt32(didRayCastHit);
            _state = didRayCastHit ? HandStates.UI : HandStates.Rest;
            _uirayInteractor.SetActive(didRayCastHit);
        }

        internal void SetPoint(Vector2 readValue)
        {
            foreach (var handStateOverride in _handStateOverridePool)
            {
                if (handStateOverride.State == HandStates.Point && handStateOverride.Override)
                {
                    _pointTarget = 1;
                    _rayInteractor.SetActive(true);
                    _state = HandStates.Rest;
                    return;
                }
            };

            foreach (var handStateEnabled in _handStateEnabledPool)
            {
                if (handStateEnabled.State == HandStates.Point && !handStateEnabled.Enabled)
                    return;
            };

            if (!(_state == HandStates.Rest || _state == HandStates.Point)) return;

            _pointTarget = readValue.y;
            var isPointing = _pointTarget > _rayDeadZone;

            _state = isPointing ? HandStates.Point : HandStates.Rest;
            _rayInteractor.SetActive(isPointing);
        }

        internal void SetGrip(float readValue)
        {
            foreach (var handStateOverride in _handStateOverridePool)
            {
                if (handStateOverride.State == HandStates.Grip && handStateOverride.Override)
                {
                    _gripTarget = 1;
                    _directInteractor.enabled = true;
                    _state = HandStates.Rest;
                    return;
                }
            };

            foreach (var handStateEnabled in _handStateEnabledPool)
            {
                if (handStateEnabled.State == HandStates.Grip && !handStateEnabled.Enabled)
                    return;
            };

            if (!(_state == HandStates.Rest || _state == HandStates.Grip)) return;

            _gripTarget = readValue;
            var isGripping = readValue > 0;

            _state = isGripping ? HandStates.Grip : HandStates.Rest;
            _directInteractor.enabled = isGripping;

        }

        private void AnimateHand()
        {
            if (_pointCurrent != _pointTarget)
            {
                _pointCurrent = Mathf.MoveTowards(_pointCurrent, _pointTarget, Time.deltaTime * _speed);
                _animator.SetFloat(POINT_LAYER_PARAM, _pointCurrent);
            }

            if (_uiCurrent != _uiTarget)
            {
                _uiCurrent = Mathf.MoveTowards(_uiCurrent, _uiTarget, Time.deltaTime * _speed);
                _animator.SetFloat(POINT_LAYER_PARAM, _uiCurrent);
            }

            if (_gripCurrent != _gripTarget)
            {
                _gripCurrent = Mathf.MoveTowards(_gripCurrent, _gripTarget, Time.deltaTime * _speed);
                _animator.SetFloat(TRIGGER_LAYER_PARAM, _gripCurrent);
            }
        }

        public void SetHandStateEnabled(HandStates state, bool enabled)
        {
            _handStateEnabledPool.ForEach(handStateEnabled =>
            {
                if (handStateEnabled.State == state)
                {
                    handStateEnabled.Enabled = enabled;
                }
            });
        }

        public void SetHandStateOverride(HandStates state, bool over)
        {
            _handStateOverridePool.ForEach(handStateOverride =>
            {
                if (handStateOverride.State == state)
                {
                    handStateOverride.Override = over;
                }
            });
        }


    }

}