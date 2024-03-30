using System.Collections.Generic;
namespace Msg {
    //检查器信息
    public class CheckInfo {
        public string checkGid = "";    //检查器的唯一ID，检查器有可能同时存在多个同类型的
        public string checkType = "";   //检查器的类型，用来匹配检查器的检查条件描述和检查逻辑
        public int state = 0;           //检查结果 0.成功 1.失败 
        public List<string> paramList = new List<string>();             //检查器的参数数组
        public List<string> valueList = new List<string>();             //检查器的持久化数据数组
    }
}