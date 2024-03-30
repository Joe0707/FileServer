using System.Collections.Generic;
namespace Msg {
    
    /**
    * [game服]客户端获取连接信息
    * 返回消息的data参数定义，总消息为msg:{code: 0, data:{}}
    */

    /**设置队员上阵、下阵（客户端发送） */
    public class setActorIsGoBattleRequest : MsgBase
    {
        //账号唯一ID
        public string accountGid = "";
        //卡牌唯一ID
        public string actorGid = "";
        //是上阵, 0 下阵, 1 上阵
        public int isGoBattle = 0;
    }
    /**设置队员上阵、下阵（服务器返回） */
    public class setActorIsGoBattleResponse : MsgBase
    {
        //卡牌唯一ID
        public string actorGid = "";
        //在队伍中的位置
        public int postionIndex = 0;
        //是否上阵,0下阵,1上阵
        public int isGoBattle = 0;
    }

    /** 招募队员 （客户端发送）*/
    public class getNewActorRequest : MsgBase{
        //账号唯一ID
        public string accountGid = "";
        //连接服ID
        public string connId = "";
    }
    /** 招募队员 （服务器返回）*/
    public class getNewActorResponse : MsgBase{
        public List<Actor> actors = new List<Actor>();
    }

    
    /** 战斗结束，玩家领取关卡奖励 (客户端发送) */
    public class getBattleRewardRequest : MsgBase{
        //账号唯一ID
        public string accountGid = "";
        //关卡唯一ID
        public string levelGid = "";
    }
    /** 战斗结束，玩家领取关卡奖励 (服务器返回) */
    public class getBattleRewardResponse : MsgBase{
        //账号唯一ID
        public string accountGid = "";
        //战斗奖励数据
        public List<BattleReward> reward = new List<BattleReward>();
    }

    /** 进入游戏 (客户端发送) */
    public class enterGameRequest : MsgBase{
        //账号ID
        public string accountId = "";
    }
    /** 进入游戏 (服务器返回) */
    public class enterGameResponse : MsgBase{
        //player
        public Player player = new Player();
        //actors
        public List<Actor> actors = new List<Actor>();
    }

}