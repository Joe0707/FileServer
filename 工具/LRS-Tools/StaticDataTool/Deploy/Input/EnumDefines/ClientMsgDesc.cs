namespace GlobalDefine{
	/**战斗协议-子协议 */
	public class SubMsgType{
		/**战斗开始 */
		public const string BattleStart = "battleStart";
		/**战斗开始后-移动队员到空格子上 */
		public const string BattlePlayState = "battlePlayState";
		/**战斗开始后-队员与怪物战斗 */
		public const string BattlePlay = "battlePlay";
		/**战斗开始后-结束自己回合 */
		public const string BattleRoundEndState = "battleRoundEndState";
		/**战斗开始后-切换战斗回合状态 */
		public const string ChangeBattleStatus = "changeBattleStatus";
		/**战斗成功/失败-结算 */
		public const string BattleResult = "BattleResult";
		/**战斗开始前改变角色位置*/
		public const string changeActorPosition = "changeActorPosition";
	}

	public class NotifyMainType{
		/** 战斗场景生命周期通知*/
		public const string NotifySceneCycleChange = "NotifySceneCycleChange";
		/** 战斗场景角色属性更新通知*/
		public const string NotifyActorAttrUpdate = "NotifyActorAttrUpdate";
		/** 回合操作者更变通知*/
		public const string NotifyChangeActivityPlayer = "NotifyChangeActivityPlayer";
		/** 结算通知*/
		public const string NotifyBattleSettle = "NotifyBattleSettle";
		/** 战斗时操作通知 [operateType: string, operateParam: Dictionary[string, string]]*/
		public const string NotifyBattleOperate = "NotifyBattleOperate";
		/** 事件触发通知 [eventType: this.triggerType, eventParam: Dictionary[string, string], eventId: 0]*/
		public const string NotifyBattleEvent = "NotifyBattleEvent";
		/** 通知常规道具修改 [list:  ItemInfo]*/
		public const string notifyCommonItemEdit = "notifyCommonItemEdit";
		/** 通知新增装备信息 [list:EquipmentInfo] */
		public const string notifyAddNewEquip = "notifyAddNewEquip";
		/** 通知删除装备信息 [list:string] */
		public const string notifyDeleteEquip = "notifyDeleteEquip";
		/** 通知装备杀敌数修改 [changeEquips: Dictionary[string, number]] */
		public const string notifyEquipKillNumChange = "notifyEquipKillNumChange";
		/** 通知装备圣物信息修改 [equipGid: string, corpsSacred: CorpsSacredInfo] */
		public const string notifyEquipCorpsSacredChange = "notifyEquipCorpsSacredChange";
		/** 通知角色技能槽修改 [entityGid: string, slotUpdate: Dictionary[string, number]]*/
		public const string notifyActorSkillSlotUpdate = "notifyActorSkillSlotUpdate";
		/** 通知角色技能池修改 [entityGid: string, delList: number[], updateList: skillInfo[]]*/
		public const string notifyActorSkillPoolUpdate = "notifyActorSkillPoolUpdate";
		/** 通知角色等级数据修改 [entityGid: string, lvInfos: lvInfo[], exp: number, level: number]*/
		public const string notifyActorLevelUpdate = "notifyActorLevelUpdate";
		/** 通知玩家当前所在商会数据更新 [info: ChamberOfCommerceInfo]*/
		public const string notifyPlayerCurChamberOfCommerceUpdate = "notifyPlayerCurChamberOfCommerceUpdate";
		/** 通知玩家城堡每日更新 [surplusRandomNum: number, surplusSendNum: number]*/
		public const string notifyPlayerCastleEveryDayUpdate = "notifyPlayerCastleEveryDayUpdate";
		/** 通知玩家城堡联姻结果 [resultList: CastleAllianceResult[], type: ECastleAllianceType]*/
		public const string notifyPlayerCastleAllianceResult = "notifyPlayerCastleAllianceResult";
		/** 通知添加角色 [actor:ActorAgent] */
		public const string notifyAddNewActor = "notifyAddNewActor";
		/** 通知删除角色 [actorGid:string]*/
		public const string notifyDeleteActor = "notifyDeleteActor";
		/** 通知玩家声望等级更新 [info: PlayerModulePrestige]*/
		public const string notifyPlayerPrestigeLvUpdate = "notifyPlayerPrestigeLvUpdate";
		/** 通知玩家城市点随机任务更新[mapGid: string, pointGid: string, mapPointInfo: MapPointInfo]*/
		public const string notifyPlayerMapPointTaskIdUpdate = "notifyPlayerMapPointTaskIdUpdate";
		/** 通知玩家城堡历练随机事件[info: CastlePracticeRunInfo, eventId: number]*/
		public const string notifyCastleTrainPracticeEvent = "notifyCastleTrainPracticeEvent";
		/** 通知玩家城堡历练随机相亲[info: CastlePracticeRunInfo, partInfo: Part, nobilityInfo: NobilityInfo, birthTime: number]*/
		public const string notifyCastleTrainPracticeMarriage = "notifyCastleTrainPracticeMarriage";
		/**通知玩家任务信息更新[info: TaskInfo] */
		public const string notifyTaskInfoUpdate = "notifyTaskInfoUpdate";
		/**通知玩家主线、支线任务更新[info: taskMainInfo] */
		public const string notifyMainTaskInfoUpdate = "notifyMainTaskInfoUpdate";
		/**通知玩家过期任务删除[taskGids: List<string>],任务唯一ID列表 */
		public const string notifyDeleteOverdueTaskInfo = "notifyDeleteOverdueTaskInfo";
		/**通知玩家角色爵位修改 */
		public const string notifyActorChangeNobility = "notifyActorChangeNobility";
		/**通知玩家修改世界时间*/
		public const string notifyPlayerChangeTime = "notifyPlayerChangeTime";
		/**通知玩家开启新城市点[mapGid, mapId, pointGid, pointId, mapPointInfo] */
		public const string notifyOpenNewMapPointInfo = "notifyOpenNewMapPointInfo";
		/**通知玩家角色待命位置信息更新[entityGid: string, awaitPosition: int]*/
		public const string notifyPlayerUpdateActorAwaitPosition = "notifyPlayerUpdateActorAwaitPosition";
		/**通知玩家任务触发器信息 [TaskTriggerInfo]*/
		public const string notifyTaskTriggerInfo = "notifyTaskTriggerInfo";
		/**通知玩家城堡学校信息更新[info: CastleSchoolInfo]*/
		public const string notifyPlayerCastleSchoolInfoUpdate = "notifyPlayerCastleSchoolInfoUpdate";
		/**通知玩家解锁节日 [festivalId: number]*/
		public const string notifyUnlockFestival = "notifyUnlockFestival";
		/**通知玩家某城市点任务完成删除任务ID [mapGid, pointId, taskId] */
		public const string notifyPlayerMapPointDeleteTaskId = "notifyPlayerMapPointDeleteTaskId";
		/**通知玩家更改全局特性 */
		public const string notifyPlayerChangePlayerSpecial = "notifyPlayerChangePlayerSpecial";
		/**通知玩家城堡市场商品更新*/
		public const string notifyPlayerCastleChamberOfCommerceGoods = "notifyPlayerCastleChamberOfCommerceGoods";
		/**通知玩家角色婚姻状态修改 */
		public const string notifyActorChangeMarryState = "notifyActorChangeMarryState";
		/**通知玩家初次完成随机战斗任务 */
		public const string notifyFirstCompleteRandomBattleTask = "notifyFirstCompleteRandomBattleTask";
		/**通知在线玩家每日刷新 */
		public const string notifyOnlinePlayerDailyRefresh = "notifyOnlinePlayerDailyRefresh";
		/**通知玩家进行婚宴*/
		public const string notifyPlayerRunWedding = "notifyPlayerRunWedding";
		/**通知玩家某个目标数据状态变化info[id,count,status] */
		public const string notifyPlayerTargetAttainment = "notifyPlayerTargetAttainment";
		/**通知玩家角色特性列表更新*/
		public const string notifyActorSpecialityUpdate = "notifyActorSpecialityUpdate";
		/**通知玩家离线 [code: ErrorCode]*/
		public const string notifyPlayerOffLine = "notifyPlayerOffLine";
		/**通知玩家角色伤病列表更新*/
		public const string notifyActorInjuryUpdate = "notifyActorInjuryUpdate";
		/**通知玩家角色升级信息改变*/
		public const string notifyPlayerActorUpLvInfo = "notifyPlayerActorUpLvInfo";
		/**通知玩家开启节日 [festivalIds: [number]]*/
		public const string notifyOpenFestival = "notifyOpenFestival";
		/**通知玩家更改全局属性 */
		public const string notifyPlayerChangePlayerAttrs = "notifyPlayerChangePlayerAttrs";
		/**通知玩家角色状态修改 */
		public const string notifyActorChangeStatus = "notifyActorChangeStatus";
		/**通知玩家处理角色要求 */
		public const string notifyPlayerProcessingActorDemand = "notifyPlayerProcessingActorDemand";
		/**通知玩家改变角色要求状态 */
		public const string notifyChangeActorDemandStatus = "notifyChangeActorDemandStatus";
		/**通知玩家角色伤病信息*/
		public const string notifyActorAddInjuryInfo = "notifyActorAddInjuryInfo";
		/**通知玩家确认剧情进度*/
		public const string notifyPlayerUnlockSceneScenario = "notifyPlayerUnlockSceneScenario";
		/**通知玩家结算军团工资*/
		public const string notifyPlayerWageSettlement = "notifyPlayerWageSettlement";
		/**[城堡委托派遣]-主动通知城堡等级解锁委托任务列表 */
		public const string notifyStartEntrustTaskList = "notifyStartEntrustTaskList";
		/**[城堡委托派遣]-主动通知委托任务状态变化*/
		public const string notifyPlayerEntrustInfoChange = "notifyPlayerEntrustInfoChange";
		/**[城堡委托派遣]-主动通知接委托任务次数变化 */
		public const string notifyPlayerChangeEntrustCount = "notifyPlayerChangeEntrustCount";
		/**[城堡委托派遣]-主动通知删除过期或者领取奖励的委托任务 */
		public const string notifyDeleteEntrustTaskInfo = "notifyDeleteEntrustTaskInfo";
		/**[城堡委托派遣]-主动通知角色派遣任务的状态变化 */
		public const string notifyActorEntrustStatusChange = "notifyActorEntrustStatusChange";
		/**通知角色依照剧情召唤*/
		public const string notifyScenarioSummonActor = "notifyScenarioSummonActor";
		/**通知角色依照剧情从场外入场*/
		public const string notifyScenarioActorEntryScene = "notifyScenarioActorEntryScene";
		/**通知角色依照剧情移动*/
		public const string notifyScenarioActorMove = "notifyScenarioActorMove";
		/**通知角色依照剧情使用技能*/
		public const string notifyScenarioActorUseSkill = "notifyScenarioActorUseSkill";
		/**通知同步执行的剧情列表*/
		public const string notifySyncScenarioList = "notifySyncScenarioList";
		/**通知开始剧情*/
		public const string notifyStartScenarioTrigger = "notifyStartScenarioTrigger";
		/**通知玩家接收新邮件 */
		public const string notifyPlayerReceiveNewMail = "notifyPlayerReceiveNewMail";
		/**通知玩家接收跑马灯消息 */
		public const string notifyPlayerReceiveMarquee = "notifyPlayerReceiveMarquee";
		/**通知玩家更新钻石商店数据 */
		public const string notifyUpdatePlayerDiamondShopInfo = "notifyUpdatePlayerDiamondShopInfo";
		/**通知玩家更新角色血脉相关数据 */
		public const string notifyUpdateActorBloodInfo = "notifyUpdateActorBloodInfo";
		/**通知玩家更新编队预设数据 */
		public const string notifyUpdateBattleTeamInfo = "notifyUpdateBattleTeamInfo";
		/**通知玩家BUFF效果触发 */
		public const string notifyBattleActorBuffTriggered = "notifyBattleActorBuffTriggered";
		/**通知客户端主线剧情播放 */
		public const string notifyPlayerTaskNextStoryInfo = "notifyPlayerTaskNextStoryInfo";
		/**通知玩家角色夭折 */
		public const string notifyActorJuvenilesDeath = "notifyActorJuvenilesDeath";
		/**通知玩家角色成年 */
		public const string notifyActorAdult = "notifyActorAdult";
		/**通知玩家角色退休 */
		public const string notifyActorRetired = "notifyActorRetired";
		/**通知玩家角色衰老死亡 */
		public const string notifyActorLifeSpanEnd = "notifyActorLifeSpanEnd";
		/**通知玩家竞技场数据更新*/
		public const string notifyUpdatePlayerArenaInfo = "notifyUpdatePlayerArenaInfo";
		/**通知玩家竞技场匹配成功*/
		public const string notifyUpdateArenaRandomMatch = "notifyUpdateArenaRandomMatch";
		/**通知玩家竞技场席位挑战结算更新*/
		public const string notifyUpdateArenaSeatSettle = "notifyUpdateArenaSeatSettle";
		/**通知玩家修改追踪任务*/
		public const string notifyPlayerTrackingTask = "notifyPlayerTrackingTask";
		/**通知客户端某路点上进入战斗的任务列表刷新 */
		public const string notifyPointRefreshTaskGids = "notifyPointRefreshTaskGids";
		/**通知玩家完成每日任务 */
		public const string notifyPlayerCompleteTaskDaily = "notifyPlayerCompleteTaskDaily";
		/**通知玩家刷新每日任务 */
		public const string notifyPlayerRefreshTaskDaily = "notifyPlayerRefreshTaskDaily";
		/**通知玩家修改日活状态 */
		public const string notifyPlayerActiveDailyStatus = "notifyPlayerActiveDailyStatus";
		/**通知玩家修改战斗场景角色主动技能*/
		public const string notifyBattleActorChangeUseSkill = "notifyBattleActorChangeUseSkill";
		/**通知玩家修改角色战力*/
		public const string notifyPlayerActorPowerValue = "notifyPlayerActorPowerValue";
		/**通知玩家修改军团战力*/
		public const string notifyPlayerCorpsPowerValue = "notifyPlayerCorpsPowerValue";
		/**通知战斗公式数据列表*/
		public const string notifyBattleAtkRecordInfoList = "notifyBattleAtkRecordInfoList";
		/**通知通知场上创建新角色*/
		public const string notifyNewBattleActorEntryScene = "notifyNewBattleActorEntryScene";
		/**通知角色追加圣物属性 */
		public const string notifyActorAddSacredEffect = "notifyActorAddSacredEffect";
		/** 通知脱下装备 [takeOffGidList: [string] */
		public const string notifyTakeOffEquip = "notifyTakeOffEquip";
		/** 通知角色行动属性信息更新 */
		public const string notifyBattleActorActAttrUpdate = "notifyBattleActorActAttrUpdate";
		/**通知玩家地形BUFF更新 */
		public const string notifyBattleTileBuffUpdate = "notifyBattleTileBuffUpdate";
		/**通知玩家图鉴信息变化*/
		public const string notifyPlayerAtlasInfoChange = "notifyPlayerAtlasInfoChange";
		/**通知客户端阶段奖励信息变更 */
		public const string notifyPlayerAtlasStageInfoChange = "notifyPlayerAtlasStageInfoChange";
		/**通知客户端图书馆事件激活的记录数据更新 */
		public const string notifyPlayerLibraryEventInfo = "notifyPlayerLibraryEventInfo";
		/**通知玩家删除邮件 */
		public const string notifyPlayerDeleteMail = "notifyPlayerDeleteMail";
		/**通知玩家修改战斗场景角色状态*/
		public const string notifyBattleActorChangeStatus = "notifyBattleActorChangeStatus";
		/**图书馆主动通知完成支线任务数据 */
		public const string notifyLibraryCompleteBranchTask = "notifyLibraryCompleteBranchTask";
		/** 世界场景角色属性更新通知*/
		public const string NotifyWorldActorAttrUpdate = "NotifyWorldActorAttrUpdate";
		/**主动通知客户端今日刷新城堡委托任务的次数 */
		public const string notifyPlayerCastleRefreshCount = "notifyPlayerCastleRefreshCount";
	}

	public class NotifyBattleOperateType{
		/** operateParam: [srcGid: string, tileIndex: string, skillMId: string] 技能使用通知*/
		public const string skill = "skill";
		/** operateParam: [atkGid: string, targetGid: string, isCri: "0""1", isDev: "0""1", isKill: "0""1", dHitNum: string] 伤害计算通知*/
		public const string damage = "damage";
		/** operateParam: [srcGid: string, targetTileIndex: string] 移动通知*/
		public const string move = "move";
		/** operateParam: [srcGid: string, targetTileIndex: string] 角色进场通知*/
		public const string enter = "enter";
		/** operateParam: [srcGid: string, targetTileIndex: string] 角色撤离通知*/
		public const string escape = "escape";
		/** operateParam: [srcGid: string, buffMId: string, keep: number, changeType: "0""1"] buff更新/移除通知*/
		public const string buff = "buff";
		/** operateParam: [srcGid: string, addNum: string] ap值更变通知*/
		public const string addAp = "addAp";
		/** operateParam: [srcGid: string, statusId: string, changeType: "0""1"] 特殊状态挂载/移除通知*/
		public const string status = "status";
		/** operateParam: [srcGid: string, skillMId: string] 主动技能ID更变通知*/
		public const string changeUseSkill = "changeUseSkill";
		/** operateParam: [tileIndex1: string, tileIndex2: string]交换两个位置上的角色通知*/
		public const string exchangeTile = "exchangeTile";
		/**  operateParam: [srcGid: string, specialityId: number, endTime: number, changeType: "0""1"] 特性挂载/移除通知*/
		public const string speciality = "speciality";
		/**  operateParam: [srcGid: string, targetTileIndex: string] 击退通知*/
		public const string repel = "repel";
		/**  operateParam: [targetTileIndex: string, buffGId: string, buffMId: string, keep: number, changeType: "0""1"] 格子BUFF更新/移除通知*/
		public const string tileBuff = "tileBuff";
		/** operateParam: [entityGid: string, tileIndex: string]交换两个位置上的角色通知*/
		public const string transferEntity = "transferEntity";
	}

	public enum NotifyBattleEventType{
		/** eventParam: [dialogId: string]*/
		dialog = 0, 
		/** eventParam: [tileIndex: string, tileType: string]*/
		tileChange = 1, 
	}

}
