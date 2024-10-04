using RpgRougeliketest.TurnBasedSystem;
using RpgRougeliketest.TurnBasedSystem.Units.Enemys;
using RpgRougeliketest.TurnBasedSystem.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.Devices;
using System.Drawing;
using RpgRougeliketest.TurnBasedSystem.Item;
using System.Numerics;

namespace RpgRougeliketest
{
    internal class DrawEngine
    {
        private Size WindowSize;

        private List<HUD.Label> labels = new List<HUD.Label>();
        public DrawEngine(Size size)
        {
            this.WindowSize = size;
        }

        internal void Update()
        {
            foreach (var item in labels)
            {
                item.position += item.velo;
                item.Life++;
                if (item.Life > item.MaxLife)
                    item.shouldRemove = true;
            }

            labels.RemoveAll(x => x.shouldRemove);
        }

        internal void Draw(Graphics g, TBSClass tbs)
        {
            Font font = new Font("Arial", 14);
            g.Clear(Color.White);

            g.DrawImageUnscaled(Image.FromFile(@"image\bg.jpg"), new Point(0,0));
            var Boarder = 32;
            var FloorPos = 150;
            var playerPos = 128;
            var enemyPos = WindowSize.Width- Boarder;
            var enemySpacing = Boarder;
            var enemySpacingMin = 128;
            DrawUnit(g, font, playerPos, FloorPos, tbs.Player);

            for (int i = tbs.EnemyCounts - 1; i >= 0; i--)
            {
                Enemy currEnemy = tbs.EnemyList[i];

                enemyPos -= Math.Max(currEnemy.ImageSize.Width, enemySpacingMin);
                DrawUnit(g, font, enemyPos, FloorPos, currEnemy);
                enemyPos -= enemySpacing;
            }

            if(tbs.ChoosingItem && tbs.itemPickSlots[0] > -1)
            {
                var ItemCollection = BaseItem.GetDerivedInstances<BaseItem>();
                for (int i = 0; i < tbs.itemPickSlots.Length; i++)
                {
                    if (tbs.itemPickSlots[i] < 0)
                        continue;

                    var item = ItemCollection[tbs.itemPickSlots[i]];
                    var pos = new Vector2(playerPos + i * (enemySpacing * 3), FloorPos * 2 + 64);
                    
                    //label.position.X -= label.getSize(g, font).Width / 2;

                    var marked = new BlockPosition();
                    marked.SetById((ushort)(i + 3)); // offset by 3 to get the middle row with the index 3 .. 5 

                    DrawItem(g, tbs, font, item, pos, tbs.Player.nextBlockPos.Value.Equals(marked));

                }
            }

            //HUD

            foreach (var label in labels)
            {
                DrawLabel(g, font, label);
            }
            
            var xOffSet = Boarder; 
            var yOffSet = Boarder;
            foreach (var item in tbs.currentItems)
            {
                g.DrawImageUnscaled(item.Image, xOffSet, yOffSet);
                xOffSet += Boarder;
            }

            //// Draw a blue ellipse
            //Pen bluePen = new Pen(Color.Blue, 2);
            //Rectangle ellipseRectangle = new Rectangle(250, 150, 150, 100);
            //g.DrawEllipse(bluePen, ellipseRectangle);

            //// Draw text
            //
            //string text = "Hello, C# Drawing!";
            //SolidBrush brush = new SolidBrush(Color.Green);
            //g.DrawString(text, font, brush, 50, 300);
        }

        private void DrawItem(Graphics g, TBSClass tbs, Font font, BaseItem? item, Vector2 pos, bool marked)
        {
            var namePos = new Vector2(pos.X, pos.Y);
            HUD.Label itemNameLabel = new HUD.Label($"{item.Name}", namePos);
            HUD.Label labelBackGround = new HUD.Label(new String(' ', item.Name.Length+5), pos);
            if (marked)
            {
                //DrawBlockPositionMarked(g, (int)pos.X, (int)pos.Y, marked, null, Brushes.Yellow);
                DrawLabel(g, font, labelBackGround, Brushes.Yellow); // Empty label = missformed label
                DrawLabel(g, font, new HUD.Label($"{item.Desc}", new Vector2(pos.X-64, pos.Y+64)), Brushes.DarkGray);
            }
            else
            { DrawLabel(g, font, labelBackGround, Brushes.DarkGray); }
            
            g.DrawImageUnscaled(item.Image, (int)pos.X-32, (int)pos.Y);
            DrawLabel(g, font, itemNameLabel, null);
        }

        private void DrawLabel(Graphics g, Font font, HUD.Label label, Brush bg = null)
        {
            if (bg != null)
            {
                var size = g.MeasureString(label.Text, font);
                g.FillRectangle(bg, new RectangleF(label.Position.X, label.Position.Y, size.Width, size.Height));
            }
            g.DrawString(label.Text, font, Brushes.Black, label.Position.X, label.Position.Y);
        }
        public void AddLabel(HUD.Label label)
        {
            labels.Add(label);
        }

        private void DrawUnit(Graphics g, Font font, int x, int y, BaseUnit bu)
        {
            //x += bu.ImageSize.Width / 2;
            //g.DrawImageUnscaled(bu.getImage(), x + (int)bu.ScreenOffset.X + (bu.ImageSize.Width / 2), WindowSize.Height - (y + bu.ImageSize.Height + (int)bu.ScreenOffset.Y));
            g.DrawImageUnscaled(bu.getImage(), x - (bu.ImageSize.Width /2) + ( (26 * 3)/2), WindowSize.Height - (y + bu.ImageSize.Height + (int)bu.ScreenOffset.Y));
            DrawHealthBar(g, x, y, bu);
            g.DrawString($"HP: {bu.currentStates.CurrentHealth:000}", font, Brushes.Black, x, y+4);
            

            //DrawBlockPosition(g, x, WindowSize.Height - y + 8, (bu.CurrentBlockPos.GetIndex()));
            DrawBlockPosition(g, x, WindowSize.Height - y + 8, Brushes.Pink);
            if (bu.NextBlockPos.HasValue && bu.ShowNextMove)
                DrawBlockPositionMarked(g, x, WindowSize.Height - y + 8, bu.NextBlockPos.Value, null, Brushes.Yellow); //WindowSize.Height - y + 8
            DrawBlockPositionMarked(g, x, WindowSize.Height - y + 8, bu.CurrentBlockPos, null, Brushes.Green);

            DrawBlockPosition(g, x, y + 48, Brushes.Pink);
            
            if (bu.NextTargetPos.HasValue && bu.ShowTarget)
                DrawBlockPositionMarked(g, x, y + 48, bu.NextTargetPos.Value, null, Brushes.Yellow);
            
            DrawBlockPositionMarked(g, x, y + 48, bu.GetSkill().GetHitBox(), null, Brushes.Red);
        }

        private void DrawHealthBar(Graphics g, int x, int y, BaseUnit bu)
        {
            var rec = new Rectangle(x-3, y-3, 26*3+6, 32);
            g.FillRectangle(Brushes.Black, rec);
            //rec.Offset(4, 2);
            rec.Inflate(-4, -4);
            g.FillRectangle(Brushes.Gray, rec);
            rec.Width = (int)(rec.Width * (bu.currentStates.CurrentHealth / bu.baseStates.CurrentHealth));
            g.FillRectangle(Brushes.Red, rec);
        }
        private void DrawBlockPositionMarked(Graphics g, int x, int y, Brush? nonMarkedColor = null, Brush? markedColor = null, params BlockPosition[] marked)
        {
            DrawBlockPositionMarked(g, x, y, null, Brushes.Pink);

            foreach (var item in marked)
            {
                DrawBlockPositionMarked(g, x, y, item);
            }

        }
        private void DrawBlockPositionMarked(Graphics g, int x, int y, Brush? nonMarkedColor = null, Brush? markedColor = null)
        {
            DrawBlockPositionMarked(g, x, y, nonMarkedColor, markedColor);
        }
        private void DrawBlockPositionMarked(Graphics g, int x, int y, BlockPosition marked, Brush? nonMarkedColor = null, Brush? markedColor = null)
        {
            int RectSize = 26;
            int gapSize = 3;
            RectangleF[] rects = new RectangleF[9];
            List<RectangleF> markedRects = new List<RectangleF>();
            int i = 0;
            //for (int blockX = 0; blockX < 3; blockX++)
            //{
            //    for (int blockY = 0; blockY < 3; blockY++)
            //    {
            for (int blockX = 0; blockX < 3; blockX++)
            {
                for (int blockY = 0; blockY < 3; blockY++)
                {
                    i = 3 * blockY + blockX;
                    rects[i] = new RectangleF(x + (blockX * RectSize), y + (blockY * RectSize), RectSize - gapSize, RectSize - gapSize);

                    if (marked.GetByIndex(i))
                    {
                        markedRects.Add(rects[i]);
                    }
                }
            }

            if (nonMarkedColor != null)
            { 
                g.FillRectangles(nonMarkedColor, rects); 
            }

            if (markedColor != null && markedRects.Count > 0)
                g.FillRectangles(markedColor, markedRects.ToArray());


        }

        private void DrawBlockPosition(Graphics g, int x, int y, Brush color, bool bg = true)
        {
            int RectSize = 26;
            int gapSize = 3;
            RectangleF[] rects = new RectangleF[9];
            RectangleF[] rectsbg = new RectangleF[9];
            int i = 0;
            for (int blockX = 0; blockX < 3; blockX++)
            {
                for (int blockY = 0; blockY < 3; blockY++)
                {
                    rects[i] = new RectangleF(x + (blockX * RectSize), y + (blockY * RectSize), RectSize - gapSize, RectSize - gapSize);
                    rectsbg[i] = new RectangleF(x- gapSize + (blockX * RectSize), y- gapSize + (blockY * RectSize), RectSize+ gapSize, RectSize + gapSize);
                    i++;
                }
            }
            if(bg)
                g.FillRectangles(Brushes.Black, rectsbg);
            g.FillRectangles(color, rects);
            
            //switch(bu.CurrentBlockPos)
            //{
            //    case BlockPosition.BlockPositions.Top:
            //        g.FillRectangle(Brushes.Red, rects[1]);
            //        break;
            //    case BlockPosition.BlockPositions.Middle:
            //        g.FillRectangle(Brushes.Red, rects[4]);
            //        break;
            //    case BlockPosition.BlockPositions.Bottom:
            //        g.FillRectangle(Brushes.Red, rects[7]);
            //        break;

            //    case BlockPosition.BlockPositions.TopLeft:
            //        g.FillRectangle(Brushes.Red, rects[0]);
            //        break;
            //    case BlockPosition.BlockPositions.Left:
            //        g.FillRectangle(Brushes.Red, rects[3]);
            //        break;
            //    case BlockPosition.BlockPositions.BottomLeft:
            //        g.FillRectangle(Brushes.Red, rects[6]);
            //        break;

            //    case BlockPosition.BlockPositions.TopRight:
            //        g.FillRectangle(Brushes.Red, rects[2]);
            //        break;
            //    case BlockPosition.BlockPositions.Right:
            //        g.FillRectangle(Brushes.Red, rects[5]);
            //        break;
            //    case BlockPosition.BlockPositions.BottomRight:
            //        g.FillRectangle(Brushes.Red, rects[8]);
            //        break;
            //}
        }
    }
}
