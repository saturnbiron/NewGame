using GameEngine;
using SFML.Audio;
using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    class Explosion : AnimatedSprite
    {

        private readonly Sound _boom = new Sound();
        public Explosion(Vector2f pos) : base(pos)
        {
            Texture = Game.GetTexture("Resources/explosion-spritesheet.png");
            SetUpExplosionAnimation();
            PlayAnimation("explosion", AnimationMode.OnceForwards);

            _boom.SoundBuffer = Game.GetSoundBuffer("Resources/boom.wav");
            _boom.Play();
        }

        public override void Update(Time elapsed)
        {
            base.Update(elapsed);
            
            if (!IsPlaying())
            {
                MakeDead();
            }

        }

        private void SetUpExplosionAnimation()
        {
            var frames = new List<IntRect>
            {
                new IntRect(  0, 0, 64, 64),
                new IntRect( 64, 0, 64, 64),
                new IntRect(128, 0, 64, 64),
                new IntRect(192, 0, 64, 64),
                new IntRect(256, 0, 64, 64),
                new IntRect(320, 0, 64, 64),
                new IntRect(384, 0, 64, 64),
                new IntRect(448, 0, 64, 64),
                new IntRect(512, 0, 64, 64 )
            };
            AddAnimation("explosion", frames);
        }
    }
}
