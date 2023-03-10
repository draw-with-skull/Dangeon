using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnimationState = DangeonMaster.Engine.Enums.GameActions;

namespace DangeonMaster.Engine.Components
{
    internal class Animation
    {
        private readonly Texture2D _texture;
        private Rectangle _sourceRectangle;
        private SpriteEffects spriteEffect;

        private readonly int _frameCount;
        private int _currentFrame;
        private readonly float _frameTime;
        private float _frameTimeLeft;
        private bool _active = true;
        private readonly bool _continuous;
        private readonly int _frameWidth, _frameRow;

        public Animation(ref Texture2D texture, int frameCount, float frameTime, int frameWidth, int frameHeight, int frameRow, bool continuous)
        {
            _texture = texture;
            _frameCount = frameCount;
            _frameTime = frameTime;
            _frameTimeLeft = frameTime;
            _frameWidth = frameWidth;
            _frameRow = frameRow;
            _continuous = continuous;
            InitSourceRects(frameHeight);
        }
        public bool IsContinuous()
        {
            return _continuous;
        }
        public void Stop()
        {
            _active = false;
        }
        public float FramesLeft()
        {
            return _currentFrame;
        }
        public void Start()
        {
            _active = true;
        }
        public void Reset()
        {
            _currentFrame = 0;
            _frameTimeLeft += _frameTime;
        }

        public void Update(bool isFlipped)
        {
            if (!_active) return;

            _frameTimeLeft -= Globals.Time.ElapsedGameTime.Milliseconds;
            if (isFlipped) spriteEffect = SpriteEffects.FlipHorizontally; else spriteEffect = SpriteEffects.None;
            if (_frameTimeLeft < 0)
            {
                _frameTimeLeft += _frameTime;
                _currentFrame = ++_currentFrame % _frameCount;
                _sourceRectangle.X = _frameWidth * _currentFrame;
            }
        }

        public void Draw(Vector2 position)
        {
            if (_texture != null)
            {
               
                Globals.SpriteBatch.Draw(_texture, position, _sourceRectangle, Color.White, 0, Vector2.Zero, 1.0f, spriteEffect, 0);
                
            }
        }
        private void InitSourceRects(int frameHeight)
        {
            _sourceRectangle.Width = _frameWidth;
            _sourceRectangle.Height = frameHeight;
            _sourceRectangle.Y = frameHeight * _frameRow;
        }
    }
}
