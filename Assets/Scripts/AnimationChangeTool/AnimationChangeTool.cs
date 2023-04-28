using Spine;
using UnityEngine;
using Spine.Unity;
using Animation = Spine.Animation;

namespace AnimationChangeTool
{
    public class AnimationChangeTool : MonoBehaviour
    {
        [SerializeField] SkeletonAnimation _skeletonAnimation;
        private ExposedList<Animation> _animations;private bool toggleTxt = false;

        public void OnGUI()
        {
            _animations = _skeletonAnimation.AnimationState.Data.SkeletonData.Animations;
            
            GUI.Box(new Rect(10,10,150,60 + _animations.Count*30), "Change Animation");

            var y = 10;
            foreach (var animation in _animations)
            {
                y += 30;
                if (GUI.Button(new Rect(20, y, 130, 20), animation.Name))
                    _skeletonAnimation.AnimationState.SetAnimation(0, animation.Name, _skeletonAnimation.loop);
            }
            
            y += 30;

            _skeletonAnimation.loop = GUI.Toggle(new Rect(20, y, 130, 20), _skeletonAnimation.loop, "Loop");
            
            if (GUI.changed) 
                _skeletonAnimation.AnimationState.SetAnimation(0, _skeletonAnimation.AnimationName, _skeletonAnimation.loop);
        }
    }
}