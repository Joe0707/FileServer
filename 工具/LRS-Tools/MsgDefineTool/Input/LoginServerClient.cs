using System.Collections.Generic;
namespace Msg {
    
    /**
    * [登录服]所有协议发送和接受消息参数定义
    * 说明： 发送到服务器的参数定义首字母大写的驼峰格式,客户端接收服务器返回参数的首字符小写(驼峰格式定义), 
    * 特殊说明：发送和接受协议中，某个服务器的参数名首字母都大写。例如连接服变量为ConnId， 客户端发送给服务器和服务器返回给客户端的参数名都是ConnId。
    * 另外，所有服务器参数名在 GlobalDefine.cs中有定义。
    * xxxRequest代表是客户端发送到服务器参数定义，xxxResponse代表是客户端收到服务器返回参数定义
    */
    
    /** 登录(客户端发送参数) */
    public class LoginRequest : MsgBase{
        //登录输入的账号
        public string accountId = "";
        //登录输入的密码
        public string passWord = "";
        //连接服ID
        public string connId = "";
    }
    /** 登录(服务器返回参数) */
    public class LoginResponse : MsgBase{
        //账号唯一ID
        public string gId = "";
        //账号ID
        public string accountId = "";
        //账号状态,默认0手动填写账号和密码，1游客登陆（或快速登陆），2通行证（接第三方SDK），3起初为游客登陆（或快速登陆）后期不全信息
        public int loginStatus = 0;
        //player对象
        public Player player = new Player();
    }

    /** 注册(客户端发送参数) */
    public class RegisterRequest : MsgBase{
        //登录输入的账号
        public string accountId = "";
        //登录输入的密码
        public string passWord = "";
        //连接服ID
        public string connId = "";
    }
    /** 注册(服务器返回参数) */
    public class RegisterResponse : MsgBase{
        //账号唯一ID
        public string gId = "";
        //账号ID
        public string accountId = "";
        //账号状态,默认0手动填写账号和密码，1游客登陆（或快速登陆），2通行证（接第三方SDK），3起初为游客登陆（或快速登陆）后期不全信息
        public int loginStatus = 0;
        //实名认证状态， 默认0没认证, 1认证了
        public int realStatus = 0;
    }

    /** 快速登录(客户端发送参数) */
    public class quickLoginRequest : MsgBase{
        //账号唯一ID
        public string accountId = "";
        //连接服ID
        public string connId = "";
    }
    /** 快速登录(服务器返回参数) */
    public class quickLoginResponse : MsgBase{
        //账号唯一ID
        public string gId = "";
        //账号ID
        public string accountId = "";
        //账号状态,默认0手动填写账号和密码，1游客登陆（或快速登陆），2通行证（接第三方SDK），3起初为游客登陆（或快速登陆）后期不全信息
        public int loginStatus = 0;
        //实名认证状态， 默认0没认证, 1认证了
        public int realStatus = 0;
        //player
        public Player player = new Player();
    }

    /** 创建角色(客户端发送参数) */
    public class createPlayerRequest : MsgBase{
        //账号唯一ID
        public string accountId = "";
        //账号名称
        public string name = "";
        //连接服ID
        public string connId = "";
    }
    /** 创建角色(服务器返回参数) */
    public class createPlayerResponse : MsgBase{
        //账号唯一ID
        public string accountId = "";
        //账号状态,默认0手动填写账号和密码，1游客登陆（或快速登陆），2通行证（接第三方SDK），3起初为游客登陆（或快速登陆）后期不全信息
        public int loginStatus = 0;
        //player对象
        public Player player = new Player();
        //卡牌对象
        public List<Actor> actors = new List<Actor>();
    }

    /** 补全游客账号信息(客户端发送) */
    public class repairAccountRequest : MsgBase{
        //账号唯一ID
        public string accountId = "";
        //登录输入的密码
        public string passWord = "";
        //连接服ID
        public string connId = "";
        //游客登录时随机的账号ID, 设备ID
        public string oldAccountId = "";
    }
    /** 补全游客账号信息(服务器返回) */
    public class repairAccountResponse : MsgBase{
        //账号唯一ID
        public string accountId = "";
        //账号状态
        public int loginStatus = 0;
        //player对象
        public Player player = new Player();
    }
}