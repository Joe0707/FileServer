namespace Msg {
    public class ActorInfo {
        public string entityGid = "";                //角色实体唯一ID
        public uint entityId = 0;                    //角色模板ID 配合角色类型进行配置检索？
        public string accountGid = "";               //操控者唯一ID
        public uint actorType = 0;                   //角色类型 1玩家角色 2怪物
        public string userName = "";                 //角色名称
        public uint level = 0;                       //等级
        public uint exp = 0;                         //当前经验值
        public uint soldierType = 0;                 //职业
        public uint soldierLevel = 0;                //职业等级
        public uint inBattle = 0;                    //该角色是否正在战斗
    }
}