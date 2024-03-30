namespace Msg{
    /** 账号返回参数定义 */
    public class Account{
        //账号唯一ID
        public string gId = "";
        //账号ID
        public string accountId = "";
        //账号状态,0手动注册,1游客注册,2通行证,3游客注册后补填信息
        public int loginStatus = 0;
    }
}