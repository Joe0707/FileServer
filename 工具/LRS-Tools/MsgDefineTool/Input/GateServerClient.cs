namespace Msg {
    
    /**
    * [gate服]客户端获取连接信息
    * 返回消息的data参数定义，总消息为msg:{code: 0, data:{}}
    */
    
    /** 客户端获取连接服信息 */
    public class getConnectorRequest : MsgBase{
        //账号ID
        public string accountId = "";
    }
    
    /** 服务器返回连接信息 */
    public class getConnectorResponse : MsgBase{
        //连接服IP地址
        public string host = "";
        //连接服port
        public int port = 0;
        //连接服ID
        public string connId = "";
    }
}