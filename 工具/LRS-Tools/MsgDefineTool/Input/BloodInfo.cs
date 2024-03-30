using System.Collections.Generic;
namespace Msg {
    //角色血脉信息
    public class BloodInfo {
        public int birthTime = 0;       //出生时间
        public int title = 0;           //先天爵位
        public string spouse = "";      //配偶角色GID？ 配偶血脉信息GID？ 父母、子女等同配置方式
        public List<string> children = new List<string>();    //[子女GID1, 子女GID2....]
        public List<string> parent = new List<string>();    //[父GID,母GID]
        public List<ActorBloodlineInfo> bloodlines = new List<ActorBloodlineInfo>();    //血脉信息
    }
}