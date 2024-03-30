using System.Collections.Generic;
namespace Msg {
    //任务信息
    public class TaskInfo {
        public string taskGid = ""; //任务GID
        public int taskType = 0;    //任务的类型 1.主线 2.支线 3.日常
        public int taskCfgId = 0;   //任务的配置ID
        public int taskCheckType = 0;   //任务的完成条件检查方式 0.达成单一条件即算完成 1.达成全部条件才算完成
        public int state = 0;           //任务的状态 0.完成 1.执行中 2.已经领取奖励 3.超时
        public int timeout = 0;         //任务超时时间点的时间戳
        public List<CheckInfo> checkList = new List<CheckInfo>();   //任务的所有完成条件信息
        public List<TriggerInfo> triggerList = new List<TriggerInfo>(); //任务完成，主动领取奖励后将会调起的所有数据修改操作
    }
}