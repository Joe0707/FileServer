namespace Msg{
    /** 攻击消息定义 */
    public class BattleMsgList{
        /**消息类型*/
        public int msgType = 0;
        /**消息值*/
        public int msgValue = 0;
        /**攻击者唯一ID*/
        public string attackId = "";
        /**被攻击者唯一ID*/
        public string hiterId = "";
        /**是否偏移*/
        public int isDev = 0;
        /**是否暴击*/
        public int isRit = 0;
        /** 是否死亡默认0未死亡, 1死亡 */
        public int isDead = 0;
        /**技能ID */
        public int skillId = 0;
    }
}