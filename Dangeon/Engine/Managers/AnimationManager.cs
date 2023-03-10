using DangeonMaster.Engine.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnimationState = DangeonMaster.Engine.Enums.GameActions;
namespace DangeonMaster.Engine.Managers
{
    internal class AnimationManager
    {
        private AnimationState _key = AnimationState.NONE;
        private bool _flipState;
        private readonly Dictionary<AnimationState, Animation> _animations;
        private Texture2D _texture;
        private Vector2 _position;
        private float _frameTime = 0;
        private int _frameHeight = 0, _frameWidth = 0;

        public AnimationManager()
        {
            _animations = new Dictionary<AnimationState, Animation>();
        }

        public void AddAnimation(AnimationState key, Animation animation)
        {
            _animations.Add(key, animation);
        }
        public void AddAnimation(AnimationState key, int frameCount, int frameRow, bool continuous)
        {
            if (_texture == null || _frameTime == 0 || _frameWidth == 0 || _frameHeight == 0)
            {
                throw new Exception("Animation manager is not set");
            }

            _animations.Add(key, new Animation(ref _texture, frameCount, _frameTime, _frameWidth, _frameHeight, frameRow, continuous));
            _key = key;
        }

        public void SetDefault(ref Texture2D texture, float frameTime, int frameWidth, int frameHeight)
        {
            _texture = texture;
            _frameTime = frameTime;
            _frameHeight = frameHeight;
            _frameWidth = frameWidth;
        }

        public void Update(AnimationState key, Vector2 direction, Vector2 position)
        {
            if (_animations[_key].IsContinuous() && _animations[_key].FramesLeft() > 0)
            {
                _animations[_key].Start();
                _animations[_key].Update(_flipState);
                return;
            }

            if (!_animations.ContainsKey(key))
            {
                _animations[_key].Stop();
                _animations[_key].Reset();
                return;
            }

            _position = position;
            _animations[key].Start();
            _animations[key].Update(CheckFaceingDirection(direction));

            _key = key;
        }
        public void Draw()
        {
            _animations[_key].Draw(_position);
        }

        public bool IsContinuous()
        {
            return (_animations[_key].IsContinuous() && _animations[_key].FramesLeft() > 0) ? true : false;
        }

        private bool CheckFaceingDirection(Vector2 direction)
        {
            if (direction.X == 1) _flipState = false;
            if (direction.X == -1) _flipState = true;
            return _flipState;
        }
    }
}
