using System.Collections.Generic;
namespace Msg {
    public class PlayerModuleTeam {
        public List<BattleTeamInfo> teams = new List<BattleTeamInfo>(); //玩家的所有队伍配置
        public List<string> inBattleTeamList = new List<string>();      //已经进入战斗的队伍的名称，小阿姨说以后会多队伍，可能还有出征自动战斗之类的东西。。。预留的
    }
}