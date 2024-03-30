using System.Collections.Generic;
// 玩家操作的消息定义
namespace Msg {
    // 攻击消息
    public class BattleActiveAttack {
        public string activeType = "attack";    //操作类型：攻击
        public string self = "";        //攻击方GID
        public string target = "";      //受击方GID
        public int isResist = 0;        //是否是反击
        public int isDev = 0;       //是否偏斜
        public int isCri = 0;       //是否暴击
        public int isDead = 0;      //是否击杀
        public int skillId = 0;     //使用的技能ID
        public int damage = 0;      //伤害数值
    }

    // 移动消息
    public class BattleActiveMove {
        public string activeType = "move";  //操作类型：移动
        public string self = "";            //移动者的GID
        public int index = 0;               //移动的目标位置
    }

    public class BattleActiveMsgList {
        public string notifyType = "active";    //通知类型
        public List<ActiveMsg> msgList = new List<ActiveMsg>(); //一系列顺序的消息通知
    }

    public class ActiveMsg {
        public string activeType = "";  //操作类型
        public List<string> strArgs = new List<string>();   //字符串类型的参数
        public List<int> intAgrs = new List<int>();         //数值类型参数
    }

    public class ActiveAttackMsg {
        public string activeType = "attack";  //操作类型
        public List<string> strArgs = new List<string>();   //字符串类型的参数 [攻击方GID, 受击方GID]
        public List<int> intAgrs = new List<int>();         //数值类型参数 [使用的技能ID, 伤害数值, 是否暴击, 是否是反击, 是否偏斜，是否击杀]
    }
    public class ActiveMoveMsg {
        public string activeType = "move";  //操作类型
        public List<string> strArgs = new List<string>();   //字符串类型的参数 [移动者GID]
        public List<int> intAgrs = new List<int>();         //数值类型参数 [目标位置]
    }
}