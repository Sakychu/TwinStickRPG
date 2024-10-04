using Microsoft.Extensions.Configuration;
using RpgRougeliketest.TurnBasedSystem;
using RpgRougeliketest.TurnBasedSystem.Units;
using RpgRougeliketest.TurnBasedSystem.Units.Enemys;
using XInput.Wrapper;
using static XInput.Wrapper.X;

namespace RpgRougeliketest
{
    public partial class DrawFrom : Form
    {
        private const int deadzone = 128 * 8;//(32767 / 2);
        DrawEngine de = null;
        IConfigurationRoot configuration = null;
        X.Gamepad gamepad = null;

        public DrawFrom()
        {
            InitializeComponent();
            de = new DrawEngine(Size);
            TBS.gTBS.Init();
            configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            if (X.IsAvailable)
            {
                gamepad = X.Gamepad_1;
            }
        }
        bool w, a, s, d = false;
        bool i, j, k, l = false;
        bool next = false;
        private void timer1_Tick(object sender, EventArgs e)
        {
            
            if (gamepad != null)
            {
                if (gamepad.Update())
                {
                    // something happened: button pressed, stick turned or trigger was triggered
                    if (gamepad.A_up || gamepad.LBumper_up || gamepad.RBumper_up)
                        next = true;
                    if(true)
                    {
                        var moveItend = stickToBlockPos(gamepad.LStick, deadzone + gamepad.LStick_DeadZone);
                        TBS.gTBS.IntentMovePlayer(moveItend);
                        var attackItend = stickToBlockPos(gamepad.RStick, deadzone + gamepad.RStick_DeadZone);
                        TBS.gTBS.IntentChangeTarget(attackItend);
                    }
                }
                X.Gamepad.Capability caps = gamepad.Capabilities;
                //if (gamepad.FFB_Supported)
                //{
                //    // can play with ~~vibrations~~ FFB
                //}
            }

            // Example: Read left thumbstick values
            //float deadband = 0.1f; // Adjust as needed
            //float leftThumbX = (Math.Abs((float)gamepad.LeftThumbX) < deadband) ? 0 : (float)gamepad.LeftThumbX / short.MinValue * -100;
            //float leftThumbY = (Math.Abs((float)gamepad.LeftThumbY) < deadband) ? 0 : (float)gamepad.LeftThumbY / short.MaxValue * 100;

            //if (w)
            //{
            //    if (a)
            //        TBS.gTBS.IntentMovePlayer(BlockPosition.BlockPositionsExp.TopLeft);
            //    else if (d)
            //        TBS.gTBS.IntentMovePlayer(BlockPosition.BlockPositionsExp.TopRight);
            //    else
            //        TBS.gTBS.IntentMovePlayer(BlockPosition.BlockPositionsExp.Top);
            //}
            //else if (s)
            //{
            //    if (a)
            //        TBS.gTBS.IntentMovePlayer(BlockPosition.BlockPositionsExp.BottomLeft);
            //    else if (d)
            //        TBS.gTBS.IntentMovePlayer(BlockPosition.BlockPositionsExp.BottomRight);
            //    else
            //        TBS.gTBS.IntentMovePlayer(BlockPosition.BlockPositionsExp.Bottom);
            //}
            //else
            //{
            //    if (a)
            //        TBS.gTBS.IntentMovePlayer(BlockPosition.BlockPositionsExp.Left);
            //    else if (d)
            //        TBS.gTBS.IntentMovePlayer(BlockPosition.BlockPositionsExp.Right);
            //    else
            //        TBS.gTBS.IntentMovePlayer(BlockPosition.BlockPositionsExp.Middle);
            //}

            

            //if (i)
            //{
            //    if (j)
            //        TBS.gTBS.IntentChangeTarget(BlockPosition.BlockPositionsExp.TopLeft);
            //    else if (l)
            //        TBS.gTBS.IntentChangeTarget(BlockPosition.BlockPositionsExp.TopRight);
            //    else
            //        TBS.gTBS.IntentChangeTarget(BlockPosition.BlockPositionsExp.Top);
            //}
            //else if (k)
            //{
            //    if (j)
            //        TBS.gTBS.IntentChangeTarget(BlockPosition.BlockPositionsExp.BottomLeft);
            //    else if (l)
            //        TBS.gTBS.IntentChangeTarget(BlockPosition.BlockPositionsExp.BottomRight);
            //    else
            //        TBS.gTBS.IntentChangeTarget(BlockPosition.BlockPositionsExp.Bottom);
            //}
            //else
            //{
            //    if (j)
            //        TBS.gTBS.IntentChangeTarget(BlockPosition.BlockPositionsExp.Left);
            //    else if (l)
            //        TBS.gTBS.IntentChangeTarget(BlockPosition.BlockPositionsExp.Right);
            //    else
            //        TBS.gTBS.IntentChangeTarget(BlockPosition.BlockPositionsExp.Middle);
            //}

            if (next)
            {
                TBS.gTBS.NextStep(); //NextBtn_Click(sender, e);
                next = false;
            }

            BufferedGraphicsContext currentContext;
            BufferedGraphics myBuffer;
            currentContext = BufferedGraphicsManager.Current;
            myBuffer = currentContext.Allocate(this.CreateGraphics(), this.DisplayRectangle);

            de.Draw(myBuffer.Graphics, TBS.gTBS);
            myBuffer.Render();
            //Invalidate();
        }

        private BlockPosition.BlockPositionsExp stickToBlockPos(X.Point stick, int deadzone)
        {
            bool top = false, middle = false, bottom = false;
            bool left = false, vmiddle = false, right = false;

            //Console.WriteLine($"{stick.X:000},{stick.Y:000}");

            if (stick.Y > deadzone)
            {
                //Console.WriteLine($"TOP");
                top = true;
            }
            else if (stick.Y < -deadzone)
            {
                //Console.WriteLine($"BOTTOM");
                bottom = true;
            }
            else
            {
                //Console.WriteLine($"MIDDLE");
                middle = true;
            }

            if (stick.X > deadzone)
            {
                //Console.WriteLine($"RIGHT");
                right = true;
            }
            else if (stick.X < -deadzone)
            {
                //Console.WriteLine($"LEFT");
                left = true;
            }
            else
            {
                //Console.WriteLine($"vMIDDLE");
                vmiddle = true;
            }

            if (top)
            {
                if (left)
                    return BlockPosition.BlockPositionsExp.TopLeft;
                else if (right)
                    return BlockPosition.BlockPositionsExp.TopRight;
                else
                    return BlockPosition.BlockPositionsExp.Top;
            }
            else if (bottom)
            {
                if (left)
                    return BlockPosition.BlockPositionsExp.BottomLeft;
                else if (right)
                    return BlockPosition.BlockPositionsExp.BottomRight;
                else
                    return BlockPosition.BlockPositionsExp.Bottom;
            }
            else if (middle)
            {
                if (left)
                    return BlockPosition.BlockPositionsExp.Left;
                else if (right)
                    return BlockPosition.BlockPositionsExp.Right;
                else
                    return BlockPosition.BlockPositionsExp.Middle;
            }
            return BlockPosition.BlockPositionsExp.Middle;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void NextBtn_Click(object sender, EventArgs e)
        {
            TBS.gTBS.NextStep();
            //Invalidate();
        }

        private void MovePlayer0_Click(object sender, EventArgs e)
        {
            TBS.gTBS.IntentChangeTarget(BlockPosition.BlockPositionsExp.TopLeft);
            //Invalidate();
        }

        private void MovePlayer1_Click(object sender, EventArgs e)
        {
            TBS.gTBS.IntentChangeTarget(BlockPosition.BlockPositionsExp.Top);
            Invalidate();
        }

        private void MovePlayer2_Click(object sender, EventArgs e)
        {
            TBS.gTBS.IntentChangeTarget(BlockPosition.BlockPositionsExp.TopRight);
            Invalidate();
        }

        private void MovePlayer3_Click(object sender, EventArgs e)
        {
            TBS.gTBS.IntentChangeTarget(BlockPosition.BlockPositionsExp.Left);
            Invalidate();
        }

        private void MovePlayer4_Click(object sender, EventArgs e)
        {
            TBS.gTBS.IntentChangeTarget(BlockPosition.BlockPositionsExp.Middle);
            Invalidate();
        }

        private void MovePlayer5_Click(object sender, EventArgs e)
        {
            TBS.gTBS.IntentChangeTarget(BlockPosition.BlockPositionsExp.Right);
            Invalidate();
        }

        private void MovePlayer6_Click(object sender, EventArgs e)
        {
            TBS.gTBS.IntentChangeTarget(BlockPosition.BlockPositionsExp.BottomLeft);
            Invalidate();
        }

        private void MovePlayer7_Click(object sender, EventArgs e)
        {
            TBS.gTBS.IntentChangeTarget(BlockPosition.BlockPositionsExp.Bottom);
            Invalidate();
        }

        private void MovePlayer8_Click(object sender, EventArgs e)
        {
            TBS.gTBS.IntentChangeTarget(BlockPosition.BlockPositionsExp.BottomRight);
            Invalidate();
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        { }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (((char)e.KeyValue))
            {
                case 'W':
                    w = true;
                    break;
                case 'A':
                    a = true;
                    break;
                case 'S':
                    s = true;
                    break;
                case 'D':
                    d = true;
                    break;
                case 'I':
                    i = true;
                    break;
                case 'J':
                    j = true;
                    break;
                case 'K':
                    k = true;
                    break;
                case 'L':
                    l = true;
                    break;
                case ' ':
                    next = true;
                    break;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            switch ((char)e.KeyValue)
            {
                case 'W':
                    w = false;
                    break;
                case 'A':
                    a = false;
                    break;
                case 'S':
                    s = false;
                    break;
                case 'D':
                    d = false;
                    break;

                case 'I':
                    i = false;
                    break;
                case 'J':
                    j = false;
                    break;
                case 'K':
                    k = false;
                    break;
                case 'L':
                    l = false;
                    break;
                case ' ':
                    next = false;
                    break;
            }
        }
    }
}