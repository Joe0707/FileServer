using System.Collections.Generic;
namespace Msg {
    //背包信息
    public class BagInfo {
        public int maxCount = 0;    //背包格子数量， -1时为无限
        public int bagType = 0;     //背包类型 0.虚拟道具 1.消耗品 2.装备 3.材料
        public List<BagSlotInfo> slots = new List<BagSlotInfo>();   //背包内所有格子的信息
    }
}