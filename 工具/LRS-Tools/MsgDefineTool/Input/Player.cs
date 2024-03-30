namespace Msg {
    public class Player {
        public PlayerInfo playerInfo = new PlayerInfo();        //玩家的基础信息
        public PlayerModuleActor actorModule = new PlayerModuleActor(); //玩家的角色模块数据
        public PlayerModuleTeam teamModule = new PlayerModuleTeam();    //玩家的队伍模块数据
        public PlayerModuleTask taskModule = new PlayerModuleTask();    //玩家的任务模块数据
        public PlayerModuleBag bagModule = new PlayerModuleBag();       //玩家的背包模块数据
    }
}