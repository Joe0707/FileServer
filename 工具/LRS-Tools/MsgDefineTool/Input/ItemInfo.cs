namespace Msg {
    public class ItemInfo {
        public int itemId = 0;  //道具ID
        public int count = 0;     //道具数量
        public int itemType = 0;//道具类型 1.虚拟道具（金币、钻石、点券等） 2.消耗品 3.装备
        public string randomAttrGid = "";   //道具的随机属性关联GID 主要是给装备用
    }
}