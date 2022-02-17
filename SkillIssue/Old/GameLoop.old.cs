using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Timers;

namespace SkillIssue
{
    class GameLoop
    {
        private Game _SkillIssue;

        /// <summary>
        /// Whether or not the gameloop is running.
        /// </summary>
        public bool Running { get; private set; }

        /// <summary>
        /// Timer to reset the FPS counter.
        /// </summary>
        public Timer FPStimer = new Timer(1000);

        /// <summary>
        /// Load game into the gameloop.
        /// </summary>
        public void Load(Game gameObj)
        {
            _SkillIssue = gameObj;
        }

        /// <summary>
        /// Start the gameloop.
        /// </summary>
        public async void Start()
        {
            if (_SkillIssue == null) throw new ArgumentException("Game not loaded!");

            // Load game content
            _SkillIssue.Load();

            // Set gameloop state
            Running = true;

            // Start FPS timer
            FPStimer.Elapsed += ResetFPS;
            FPStimer.AutoReset = true;
            FPStimer.Enabled = true;

            // Set previous game time
            DateTime _previousGameTime = DateTime.Now;

            while (Running)
            {
                // Calculate the time elapsed since the last game loop cycle
                TimeSpan GameTime = DateTime.Now - _previousGameTime;
                // Update the current previous game time
                _previousGameTime = _previousGameTime + GameTime;
                // Update the game
                _SkillIssue.Update(GameTime);
                _SkillIssue.GameTime = GameTime.ToString();
                // Update Game at 60fps
                await Task.Delay(1);
            }
        }

        /// <summary>
        /// Stop the gameloop.
        /// </summary>
        public void Stop()
        {
            Running = false;
            FPStimer.Stop();
            _SkillIssue?.Unload();
        }

        /// <summary>
        /// Update the FPS counter and reset FPS step every second.
        /// </summary>
        public void ResetFPS(Object source, ElapsedEventArgs e)
        {
            _SkillIssue.FPS = _SkillIssue.FPSstep;
            _SkillIssue.FPSstep = 0;
        }


        /// <summary>
        /// Render the graphic buffer and increment the FPS counter.
        /// </summary>
        public void Draw(Graphics gfx)
        {
            _SkillIssue.Draw(gfx);
            _SkillIssue.FPSstep++;
        }
    }
}
