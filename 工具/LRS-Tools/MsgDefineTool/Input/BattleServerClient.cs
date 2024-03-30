using System.Collections.Generic;
namespace Msg {
    
    /**
    * [battle服]客户端获取连接信息
    * 返回消息的data参数定义，总消息为msg:{code: 0, data:{}}
    */

    /**战前调整队员到空格子上 */
    public class battlePrePareSetActorPosition : MsgBase
    {
        /**账号唯一ID */
        public string accountGid = "";
        /**战斗唯一ID */
        public string battleGid = "";
        /** 卡牌唯一ID */
        public string actorGid = "";
        /** 要换位置index下标 */
        public int index = 0;
    }

    /** 战斗中服务器主动给客户端消息 */
    public class notifyBattleInfo : MsgBase{
        /**返回错误码 */
        public int code = 0;
        /** 消息类型*/
        public string msgType = "";
        /**子消息类型 */
        public string subMsgType = "";
        /**战斗回合数 */
        public int battleRound = 0;
        /** 战斗回合状态,None不切换状态,BattleInit战斗初始化,BattleStart战斗开始,TeamAdjustment队伍调整,MyTurn我的回合,OthersTurn别人的回合,Dialog剧情,BattleResult战斗结算,BattleEnd战斗结束*/
        public string battleState = "";
        /** 战斗结果状态, -1战前, 0战斗中, 1战斗失败, 2战斗胜利 */
        public int battleResultState = 0;
        /**战斗奖励数据 */
        public BattleReward battleReward = new BattleReward();
        /**战斗消息列表 */
        public List<BattleMsgList> battleMsgList = new List<BattleMsgList>();
    }
    /** 回合结束（客户端发送） */
    public class battleRoundEndState : MsgBase{
        //账号唯一ID
        public string accountGid = "";
    }
    /** 进入关卡后调整队员战位 (客户端发送) */
    public class battlePrePareRequest : MsgBase{
        //账号唯一ID
        public string accountGid = "";
        //战斗唯一ID
        public string battleGid = "";
        //换位置队员唯一ID
        public string actorGid = "";
        //换位置队员2唯一ID
        public string actorGid2 = "";
    }
    /** 进入关卡 (客户端发送) */
    public class battleEnterRequest : MsgBase{
        //关卡ID
        public int levelId = 0;
        //账号唯一ID
        public string accountGid = "";
    }
    /** 进入关卡 (服务器返回) */
    public class battleEnterResponse : MsgBase{
        //账号唯一ID
        public string accountGid = "";
        //战斗唯一ID
        public string battleGid = "";
        //怪物布局信息
        public List<Team> monsters = new List<Team>();
        //队伍布局信息
        public List<Team> teams = new List<Team>();
    }

    /** 战斗开始切换状态 (客户端发送) */
    public class battleStartRequest : MsgBase{
        //账号唯一ID
        public string accountGid = "";
    }

    /** 战斗开始，手动操作队员移动战位 (客户端发送)*/
    public class battlePlayStateRequest : MsgBase{
        //账号唯一ID
        public string accountGid = "";
        //卡牌唯一id
        public string actorGid = "";
        //目标格子下标index
        public int positionIndex = 0;
    }

    /** 战斗开始，手动操作队员移动战位 (服务器返回)*/
    public class battlePlayStateResponse : MsgBase{
        //返回战斗消息类型，包括战位移动
        public List<BattleMsgList> msgList = new List<BattleMsgList>();
    }

    /** 战斗开始,手动操作队员与怪物战斗 (客户端发送) */
    public class battlePlayRequest : MsgBase{
        //账号唯一ID
        public string accountGid = "";
        //卡牌唯一ID
        public string actorGid = "";
        //怪物唯一ID
        public string monsterGid = "";
        /**攻击者落脚点 */
        public int positionIndex = -1;
    }
    /** 战斗开始后,手动操作队员与怪物战斗 (服务器返回) */
    public class battlePlayResponse : MsgBase{
        //战斗消息列表
        public List<BattleMsgList> msgList = new List<BattleMsgList>(); 
    }

    /** 战斗开始后,自己回合结束, 怪物回合返回 (服务器返回) */
    public class onAttackResponse : MsgBase{
        //消息类型
        public string msgType = "";
        //战斗状态
        public string battleState = "";
        //战斗消息列表
        public List<BattleMsgList> msgList = new List<BattleMsgList>();
    }

    /** 战斗结束 (客户端发送)*/
    public class battleEndRequest : MsgBase{
        //账号唯一ID
        public string accountGid = "";
    }
    /** 战斗结束 (服务器返回) */
    public class battleEndResponse : MsgBase{
        //账号唯一ID
        public string accountGid = "";
        //战斗奖励数据
        public List<BattleReward> reward = new List<BattleReward>();
    }
    /** 退出关卡（客户端发送） */
    public class battleOutRequest : MsgBase{
        //账号唯一ID
        public string accountGid = "";
    }



}