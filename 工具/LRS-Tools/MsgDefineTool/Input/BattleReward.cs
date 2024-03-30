using System.Collections.Generic;
namespace Msg{
    /** 战斗结束获得奖励消息字段定义 */
    public class BattleReward{
        //奖励钻石
        public int diamond = 0;
        //金币
        public int coin = 0;
        //奖励物品列表
        public List<ItemInfo> items = new List<ItemInfo>();
    }
}