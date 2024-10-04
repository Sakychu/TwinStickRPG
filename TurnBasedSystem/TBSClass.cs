using RpgRougeliketest.TurnBasedSystem;
using RpgRougeliketest.TurnBasedSystem.Item;
using RpgRougeliketest.TurnBasedSystem.Skills;
using RpgRougeliketest.TurnBasedSystem.Units;
using RpgRougeliketest.TurnBasedSystem.Units.Enemys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace RpgRougeliketest
{
    public static class TBS
    {
        public static TBSClass gTBS = new TBSClass();
    }
}

namespace RpgRougeliketest.TurnBasedSystem
{
    public class TBSClass
    {
        int wave = -1;

        bool choosingItem = false;
        internal int[] itemPickSlots = new int[3];
        internal List<BaseItem> currentItems = new List<BaseItem> { };

        Units.Player player = null;
        public Units.Player Player { get { return player; } }
        //private BlockPosition? nextPlayerPos = null;
        //public BlockPosition? NextPlayerPos { get { return nextPlayerPos; } }

        List<Enemy> enemys = null;
        internal Random mRand;

        public Enemy Enemy { get { return enemys[0]; } }
        public List<Enemy> EnemyList { get { return enemys; } }
        public int EnemyCounts { get { return enemys.Count; } }

        public bool ChoosingItem { get => choosingItem; internal set => choosingItem = value; }

        public enum GameState 
        {
            MainMenu,
            Playing,
            Map,
            ItemReward
        }
        
        internal GameState currenState = GameState.Playing;

        internal void Init()
        {
            mRand = new Random();
            player = new Units.Player();
            enemys = new List<Enemy>
            {

            };
            itemPickSlots[0] = -1;
            choosingItem = false;
        }

        internal void NextStep()
        {
            //playersTurn();

            switch (currenState)
            {
                case GameState.MainMenu:
                    break;
                case GameState.Playing:
                     TakeTurns();
                    break;
                case GameState.Map:
                    break;
                case GameState.ItemReward:
                    SpawnItems();
                    break;
                default:
                    break;
            }
        }

        private void SpawnItems()
        {
            if (choosingItem)
            {
                var ItemCollection = BaseItem.GetDerivedInstances<BaseItem>();
                if (itemPickSlots[0] < 0)
                {
                    RemoveOwnedItems(ItemCollection);
                    GenerateRandomItemsAndPopulateItemChoices(ItemCollection);
                }
                else if (player.nextBlockPos.HasValue)
                {
                    if (player.nextBlockPos.Value.Left)
                    {
                        currentItems.Add(ItemCollection[itemPickSlots[0]]);
                        choosingItem = false;
                    }
                    else if (player.nextBlockPos.Value.Middle)
                    {
                        currentItems.Add(ItemCollection[itemPickSlots[1]]);
                        choosingItem = false;
                    }
                    else if (player.nextBlockPos.Value.Right)
                    {
                        currentItems.Add(ItemCollection[itemPickSlots[2]]);
                        choosingItem = false;
                    }

                    if (!choosingItem)
                    {
                        itemPickSlots[0] = -1;
                        currentItems[^1].onGet(player);
                    }
                }
            }
            else
            {
                if (EnemyCounts == 0)
                {
                    SpawnNextWave();
                    currenState = GameState.Playing;
                }
            }
        }

        private void RemoveOwnedItems(List<BaseItem?> itemCollection)
        {
            for (int i = 0; i < itemCollection.Count; i++)
            {
                bool found = false;
                var item = itemCollection[i];
                for (int k = 0; k < currentItems.Count; k++)
                {
                    found = found || item.Name == currentItems[k].Name;
                }
                if(found)
                    itemCollection[i] = null;
            }
            itemCollection.RemoveAll(x => x == null);
        }

        private void TakeTurns()
        {
            for (int i = 0; i < EnemyCounts; i++)
            {
                takeTurn(player, EnemyList[i], out bool hit, i);
                if (!player.mPiercingAttacks || hit)
                    break;
            }
            //takeTurn(player, Enemy);
            foreach (var enemy in enemys)
            {
                if (enemy.mDead)
                    continue;
                takeTurn(enemy, player, out bool hit);
            }

            EnemyList.RemoveAll(enemy => enemy.mDead);

            player.currentStates.ResetMod();
            foreach (var enemy in enemys)
            {
                enemy.currentStates.ResetMod();
                enemy.IntentNextTurn();
            }

            if (EnemyCounts < 1)
            {
                SpawnNextWave();
            }
        }

        private void GenerateRandomItemsAndPopulateItemChoices(List<BaseItem?> ItemCollection)
        {
            if (ItemCollection.Count == 0)
                return;

            var localList = new List<int>();
            for (int i = 0; i < ItemCollection.Count; i++)
            {
                localList.Add(i);
            }
            for (int slotIndex = 0; slotIndex < itemPickSlots.Length; slotIndex++)
            {
                int listIndex = mRand.Next(0, localList.Count);//Math.Min(0, localList.Count - 1);
                int itemIndex = localList[listIndex];
                itemPickSlots[slotIndex] = itemIndex;
                localList.RemoveAt(listIndex);
                if (localList.Count == 0)
                    itemPickSlots[slotIndex] = -1;
            }
        }

        private void SpawnNextWave()
        {
            wave++;
            var cnt = 0;
            var advcnt = 0;
            var bosscnt = 0;
            var chasercnt = 0;// mRand.Next(1,3);
            //choosingItem = true;
            //currenState = GameState.ItemReward;
            switch (wave)
            {
                case 0:
                    choosingItem = true;
                    currenState = GameState.ItemReward; 
                    //cnt = 3;
                    break;
                case 1:
                    cnt = 2;
                    chasercnt = 1;
                    break;
                case 2:
                    cnt = 3;
                    bosscnt = 1; 
                    break;
                case 3:
                    choosingItem = true;
                    currenState = GameState.ItemReward;
                    break;
                case 4:
                    advcnt = 2; break;
                case 5:
                    cnt = 2; chasercnt = 1; bosscnt = 1; break;
                case 6:
                    choosingItem = true;
                    currenState = GameState.ItemReward;
                    break;
                case 7:
                    advcnt = 2; chasercnt = 1; break;
                default:
                    if (wave % 5 == 0)
                    {
                        choosingItem = true;
                        currenState = GameState.ItemReward;
                    }
                    else
                    {
                        advcnt = 3; chasercnt = 1; bosscnt = 1;
                    }
                    
                    break;
            }

            for (int i = 0; i < cnt; i++)
            {
                AddEnemy(new Slime());
            }

            for (int i = 0; i < advcnt; i++)
            {
                AddEnemy(new Advanced());
            }

            for (int i = 0; i < bosscnt; i++)
            {
                AddEnemy(new EnemyBoss());
            }

            for (int i = 0; i < chasercnt; i++)
            {
                AddEnemy(new Chaser());
            }
        }

        internal void AddEnemy(Enemy enemy)
        {
            enemys.Add(enemy);
        }

        private void takeTurn(BaseUnit me, BaseUnit target, out bool hit, int enemyIndex = -1)
        {
            hit = false;
            if (me.nextBlockPos.HasValue)
            {
                me.blockPos = me.nextBlockPos.Value;
                me.nextBlockPos = null;
            }
            if (me.nextTargetPos.HasValue)
            {
                me.targetPos = me.nextTargetPos.Value;
                me.nextTargetPos = null;
            }

            var skill = me.GetSkill();
            if (skill != null)
            {
                me.onAttack(target);
                var dmgBox = skill.Do(me, target);

                hit = applyDamage(dmgBox, me, target);

                if (target.currentStates.mHealth < 1 && enemyIndex >= 0)
                {
                    target.onDeath();
                    target.mDead = true;
                    defeteEnemy(enemyIndex);
                }
            }
        }

        private void playersTurn()
        {
            if (player.nextBlockPos.HasValue)
            {
                player.blockPos = player.nextBlockPos.Value;
                player.nextBlockPos = null;
            }

            var skill = player.GetSkill();
            if (skill != null)
            {
                Enemy target = Enemy;
                var dmgBox = skill.Do(player, target);

                applyDamage(dmgBox, player, target);

                if (target.currentStates.mHealth < 1)
                {
                    target.onDeath();
                    target.mDead = true;
                    defeteEnemy(0);
                }
            }
        }
        //private void enemysTurn(Enemy enemy)
        //{
        //    if (enemy.nextBlockPos.HasValue)
        //    {
        //        enemy.blockPos = enemy.nextBlockPos.Value;
        //        enemy.nextBlockPos = null;
        //    }

        //    Skill? skill = enemy.GetSkill();
        //    if (skill != null)
        //    {
        //        var target = player;
        //        var dmgBox = skill.Do(enemy, target);

        //        applyDamage(dmgBox, enemy, target);

        //        if (target.mHealth < 1)
        //        {
        //            target.onDeath();
        //            target.mDead = true;
        //            defeteEnemy(0);
        //        }
        //    }

        //    enemy.IntentNextTurn();
        //}
        //private void enemysTurn()
        //{
        //    Skill? skill = Enemy.GetSkill();
        //    if (skill != null)
        //    {
        //        var dmgBox = skill.Do(Enemy, player);

        //        var target = player;
        //        applyDamage(dmgBox, target);

        //        if (target.mHealth < 1)
        //        {
        //            target.onDeath();
        //            target.mDead = true;
        //            defeteEnemy(0);
        //        }
        //    }
        //}

        private void defeteEnemy(int index)
        {
            enemys.RemoveAt(index);
        }

        private bool applyDamage(DamageDistro dmgBox, BaseUnit me, BaseUnit bu)
        {
            int dmg = dmgBox.Get(bu.CurrentBlockPos);
            if (dmg > 0)
            {
                bu.onDamageTaken(me, dmg);
                bu.currentStates.mHealth -= dmg;
                //Console.WriteLine($"Dealt {dmg}!");
                me.onDamageDealt(bu, dmg);
                return true;
            }
            return false;
        }

        internal void IntentMovePlayer(BlockPosition.BlockPositionsExp bp)
        {
            player.nextBlockPos = new BlockPosition((ushort)bp);
        }

        internal void IntentMove(BaseUnit bu, BlockPosition.BlockPositionsExp bp)
        {
            bu.IntentMove(bp);
        }

        internal void IntentChangeTarget(BlockPosition.BlockPositionsExp bp)
        {
            player.nextTargetPos = new BlockPosition((ushort)bp);
        }

        internal void TriggerAllItems(Action<BaseItem> value)
        {
            foreach (var item in currentItems)
            {
                value.Invoke(item);
            }
        }
    }
}
