
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace Hitlab.Animations
{
    public class HandController : MonoBehaviour
    {
        [SerializeField] private Hand _hand;
        [SerializeField] private ActionBasedController _controller;

        // Update is called once per frame
        void Update()
        {
            
            _hand.SetGrip(_controller.selectAction.action.ReadValue<float>());
            _hand.SetPoint(_controller.activateAction.action.ReadValue<Vector2>());
        }

        public void SetPointer(bool inactive)
        {
            _hand.SetHandStateEnabled(HandStates.Point, !inactive);
        }

        public void SetGrip(bool inactive)
        {
            _hand.SetHandStateEnabled(HandStates.Grip, !inactive);
        }

        public void SetUI(bool inactive)
        {
            _hand.SetHandStateEnabled(HandStates.UI, !inactive);
        }

        public void SetPointerOverride(bool over)
        {
            _hand.SetHandStateOverride(HandStates.Point, over);
        }

        public void SetGripOverride(bool over)
        {
            _hand.SetHandStateOverride(HandStates.Grip, over);
        }

        public void SetUIOverride(bool over)
        {
            _hand.SetHandStateOverride(HandStates.UI, over);
        }
    }

}