using System.Collections.Generic;
namespace Msg {
    // 战斗队伍信息
    public class BattleTeamInfo {
        public string name = "";    //队伍名称
        public string leader = "";  //队长角色GID
        public int memberNum = 0;   //队伍成员数量
        public List<string> team = new List<string>();  //队伍队员的GID信息和位置对应 ["false", "actorGid_1", "false", "actorGid_2", "false", "false"]
    }
}