namespace GlobalDefine{
	/**
 * 后端路由说明
 */
	public class ERoutePath{
		/**
         * 根据accountId获取链接服信息
         * request
         *      accountId: 设备ID或用户账号
         * response
         *     host: ip
         *     port: 端口号
         *     connId: 连接服ID
         *
         */
		public const string gate_gateHandler_getConnector = "gate.gateHandler.getConnector";
		/**
         * 账号注册
         * request
         *     accountId: 用户账号
         *     passWord: 用户密码
         *     connId: 连接服ID
         *
         * response
         *     gid: 玩家GID
         *     accountId: 用户账号
         *     loginStatus: 账号状态, 0手动填写账号和密码，1游客登陆（或快速登陆），2通行证（接第三方SDK），3起初为游客登陆（或快速登陆）后期补全信息
         *     realStatus: 实名认证状态 0没认证, 1认证了
         *
         */
		public const string connector_connHandler_register = "connector.connHandler.register";
		/**
         * 账号登陆
         * request
         *     accountId: 用户账号
         *     passWord: 用户密码
         *     connId: 连接服ID
         *
         * response
         *      gId: 账号唯一ID,
         *      accountId: 账号ID,
         *      loginStatus: 账号状态,默认0手动填写账号和密码，1游客登陆（或快速登陆），2通行证（接第三方SDK），3起初为游客登陆（或快速登陆）后期不全信息
         *      isCreatePlayer: 账号是否已经创建玩家信息
         *      token: 验证同设备用的唯一字符串
         *
         */
		public const string connector_connHandler_login = "connector.connHandler.login";
		/**
         * 账号快速登陆
         * request
         *     accountId: 用户账号
         *     connId: 连接服ID
         *
         * response
         *      gId: 账号唯一ID //string
         *      accountId: 账号ID //string
         *      loginStatus: 账号状态,默认0手动填写账号和密码，1游客登陆（或快速登陆），2通行证（接第三方SDK），3起初为游客登陆（或快速登陆）后期不全信息 //int
         *      realStatus: 实名认证状态， 默认0没认证, 1认证了 //int
         *      isCreatePlayer: 账号是否已经创建玩家信息 //int
         *      token: 验证同设备用的唯一字符串 //string
         *
         */
		public const string connector_connHandler_quickLogin = "connector.connHandler.quickLogin";
		/**
         * 创建玩家实体
         * request
         *     accountId: 用户账号
         *     connId: 连接服ID
         *     name: 角色/玩家名称
         *
         * response {
         *      accountId: 账号唯一ID //string
         *      loginStatus: 账号状态,默认0手动填写账号和密码，1游客登陆（或快速登陆），2通行证（接第三方SDK），3起初为游客登陆（或快速登陆）后期不全信息 //int
         *      isCreatePlayer: 账号是否已经创建玩家信息 //int
         * 
         */
		public const string connector_connHandler_createPlayer = "connector.connHandler.createPlayer";
		/**
         * 补全账号信息
         * request
         *     accountId: 新用户账号
         *     connId: 连接服ID
         *     passWord: 新密码
         *     oldAccountId: 旧的账号/设备号
         *
         * response {
         *      accountId: 账号唯一ID //string
         *      loginStatus: 账号状态 //int
         *      isCreatePlayer: 账号是否已经创建玩家信息 //int
         *      playerInfo: 经过修改的玩家信息 //PlayerInfo
         * 
         */
		public const string connector_connHandler_repairAccount = "connector.connHandler.repairAccount";
		/**
         * 进入游戏
         * request
         *     accountId: 用户账号
         *
         * response {
         *      player: 玩家数据 //Player
         * 
         */
		public const string connector_gameHandler_enterGame = "connector.gameHandler.enterGame";
		/**
         * 招募新队员
         * request
         *     accountGid: 玩家GID
         *     connId: 连接服ID
         *
         * response {
         *      newActor: 角色数据 //Actor
         * 
         */
		public const string connector_gameHandler_getNewActor = "connector.gameHandler.getNewActor";
		/**
         * 设置队员上阵、下阵
         * request
         *     accountGid: 玩家GID
         *     actorGid: 角色GID
         *     isGoBattle: 操作类型 0 下阵 1上阵
         *
         * response {
         *      actorGid: 角色唯一ID //string
         *      oldTeamName: 旧队伍名称 //string
         *      oldIndex: 在旧队伍中的位置 //int
         *      newTeamName: 新队伍名称 //string
         *      newIndex: 在新队伍中的位置 //int
         *      isGoBattle: 是否上阵 0下阵,1上阵 //int
         * 
         */
		public const string connector_gameHandler_setActorIsGoBattle = "connector.gameHandler.setActorIsGoBattle";
		/**
         * 获取战斗奖励
         * request
         *     accountGid: 玩家GID
         *     levelGid: 战斗场景GID
         *
         * response {
         *      accountGid: 账号唯一ID //string
         *      reward: 战斗奖励数据 //List<ItemInfo>
         * 
         */
		public const string connector_gameHandler_getBattleReward = "connector.gameHandler.getBattleReward";
		/**
         * 进入战斗场景
         * request
         *     accountGid: 玩家GID
         *     levelId: 关卡配置ID/战斗场景配置ID
         *
         * response {
         *      accountGid: 账号唯一ID //string
         *      battleGid: 战斗唯一ID //string
         *      monsters: 怪物布局信息 //List<Team>
         *      teams: 队伍布局信息 //List<Team>
         * 
         */
		public const string connector_battleHandler_battleEnter = "connector.battleHandler.battleEnter";
		/**
         * 战斗开始前准备-调整队伍战位(队员互换位置)
         * request
         *     accountGid: 玩家GID
         *     battleGid: 关卡配置ID/战斗场景配置ID
         *     actorGid: 角色GID
         *     actorGid2: 角色GID2
         *
         * response {
         * 
         */
		public const string connector_battleHandler_battlePrePare = "connector.battleHandler.battlePrePare";
		/**
         * 战前调整队员到空格子上
         * request
         *     accountGid: 玩家GID
         *     battleGid: 关卡配置ID/战斗场景配置ID
         *     actorGid: 角色GID
         *     index: 格子index
         *
         * response {
         * 
         */
		public const string connector_battleHandler_battlePrePareSetActorPosition = "connector.battleHandler.battlePrePareSetActorPosition";
		/**
         * 战斗开始
         * request
         *     accountGid: 玩家GID
         *
         * response {
         * 
         */
		public const string connector_battleHandler_battleStart = "connector.battleHandler.battleStart";
		/**
         * 战斗开始后-自己的回合操作队员移动位置
         * request
         *     accountGid: 玩家GID
         *     actorGid: 角色GID
         *     positionIndex: 格子index
         *
         * response {
         * 
         */
		public const string connector_battleHandler_battlePlayState = "connector.battleHandler.battlePlayState";
		/**
         * 战斗开始,自己的回合，手动操作队员与怪物战斗
         * request
         *     accountGid: 玩家GID
         *     monsterGid: 攻击目标GID
         *     actorGid: 进行攻击的角色GID
         *     positionIndex: 发起攻击的格子index
         *
         * response {
         * 
         */
		public const string connector_battleHandler_battlePlay = "connector.battleHandler.battlePlay";
		/**
         * 回合结束
         * request
         *     accountGid: 玩家GID
         *
         * response {
         * 
         */
		public const string connector_battleHandler_battleRoundEndState = "connector.battleHandler.battleRoundEndState";
		/**
         * 战斗结束确认
         * request
         *     accountGid: 玩家GID
         *
         * response {
         *      accountGid: 账号唯一ID //string
         *      reward: 战斗奖励数据 //List<ItemInfo>
         * 
         */
		public const string connector_battleHandler_battleEnd = "connector.battleHandler.battleEnd";
		/**
         * 退出关卡（放弃战斗）
         * request
         *     accountGid: 玩家GID
         *
         * response {
         * 
         */
		public const string connector_battleHandler_battleOut = "connector.battleHandler.battleOut";
		/**
         * 确认解锁操作
         * request
         *     accountGid: 玩家GID
         *
         * response {
         *     accountGid: 玩家GID
         */
		public const string connector_battleHandler_battleActivityConfirm = "connector.battleHandler.battleActivityConfirm";
		/**
         * 获取指定城市的商会信息
         * request
         *     accountGid: 玩家GID
         *     cityId: 城市ID
         *
         * response {
         *     code: 错误码
         *     info: 城市信息结构体
         */
		public const string connector_gameHandler_getChamberOfCommerceInfoByCity = "connector.gameHandler.getChamberOfCommerceInfoByCityRequest";
		/**
         * 购买商会物品
         * request
         *     accountGid: 玩家GID
         *     shopId: 商会/城市ID
         *     itemId: 道具ID
         *     num: 道具数量
         *
         * response {
         *     code: 错误码
         */
		public const string connector_gameHandler_buyStoryItem = "connector.gameHandler.buyStoryItem";
		/**
         * 出售物品到商会
         * request
         *     accountGid: 玩家GID
         *     shopId: 商会/城市ID
         *     itemList: [itemId, num][] 要出售的道具组
         *     equipGidList: [equipGid_1,equipGid_2,...] 要出售的装备GID组
         *
         * response {
         *     code: 错误码
         */
		public const string connector_gameHandler_sellStoryItem = "connector.gameHandler.sellStoryItem";
		/**
         * 选定接取商会任务
         * request
         *     accountGid: 玩家GID
         *     shopId: 商会/城市ID
         *     taskId: 目标任务ID
         *
         * response {
         *     code: 错误码
         */
		public const string connector_gameHandler_pickStoryTask = "connector.gameHandler.pickStoryTask";
		/**
         * 放弃商会任务
         * request
         *     accountGid: 玩家GID
         *     shopId: 商会/城市ID
         *     taskGid: 目标任务ID
         *
         * response {
         *     code: 错误码
         */
		public const string connector_gameHandler_deleteChamberOfCommerceTask = "connector.gameHandler.deleteChamberOfCommerceTask";
		/**
         * 替换技能请求
         * request
         *     accountGid: 玩家GID
         *     entityGid: 角色GID
         *     skillId: 技能ID -1时认为是拆卸槽位上的技能
         *     slotType: 槽位类型 1~6
         *
         * response {
         *     code: 错误码
         */
		public const string connector_gameHandler_skillSlotUseSkill = "connector.gameHandler.skillSlotUseSkill";
		/**
         * 获取城堡信息
         * request
         *     accountGid: 玩家GID
         *
         * response
         *     code: 错误码
         *     info: PlayerModuleCastle 城堡整体数据信息
         *
         */
		public const string connector_gameHandler_getPlayerModuleCastleInfo = "connector.gameHandler.getPlayerModuleCastleInfo";
		/**
         * 升级城堡
         * request
         *     accountGid: 玩家GID
         *
         * response
         *     code: 错误码
         *
         */
		public const string connector_gameHandler_upCastleLv = "connector.gameHandler.upCastleLv";
		/**
         * 建造建筑
         * request
         *     accountGid: 玩家GID
         *     architectureType: 建筑类型
         *     slot: int 进行建造的目标槽位
         *     slotType: int 槽位类型
         *
         * response
         *     code: 错误码
         *     info: CastleArchitectureInfo 新城堡建筑信息
         *
         */
		public const string connector_gameHandler_buildArchitecture = "connector.gameHandler.buildArchitecture";
		/**
         * 拆除建筑
         * request
         *     accountGid: 玩家GID
         *     architectureId: 建筑唯一ID
         *
         * response
         *     code: 错误码
         *
         */
		public const string connector_gameHandler_dismantleArchitecture = "connector.gameHandler.dismantleArchitecture";
		/**
         * 领取建筑产出
         * request
         *     accountGid: 玩家GID
         *     architectureId: 建筑唯一ID
         *
         * response
         *     code: 错误码
         *
         */
		public const string connector_gameHandler_gainArchitectureProduce = "connector.gameHandler.gainArchitectureProduce";
		/**
         * 领取所有建筑产出
         * request
         *     accountGid: 玩家GID
         *
         * response
         *     code: 错误码
         *
         */
		public const string connector_gameHandler_gainAllArchitectureProduce = "connector.gameHandler.gainAllArchitectureProduce";
		/**
         * 随机联姻对象
         * request
         *     accountGid: 玩家GID
         *     entityGid: 选定进行联姻的角色GID
         *     prestige: 进行联姻的目标势力类型
         *
         * response
         *     code: 错误码
         *
         */
		public const string connector_gameHandler_randomAllianceTarget = "connector.gameHandler.randomAllianceTarget";
		/**
         * 根据角色联姻对象随机获取介绍
         * request
         *     accountGid: 玩家GID
         *
         * response
         *     code: 错误码
         *     partInfo: Part 面部信息
         *     introList: List<int> 字符串简介ID组
         *
         */
		public const string connector_gameHandler_randomAllianceTargetIntro = "connector.gameHandler.randomAllianceTargetIntro";
		/**
         * 确认联姻
         * request
         *     accountGid: 玩家GID
         *
         * response
         *     code: 错误码
         *
         */
		public const string connector_gameHandler_affirmAlliance = "connector.gameHandler.affirmAlliance";
		/**
         * 退出城堡联姻
         * request
         *     accountGid: 玩家GID
         *
         * response
         *     code: 错误码
         *
         */
		public const string connector_gameHandler_exitAlliance = "connector.gameHandler.exitAlliance";
		/**
         * 任命城堡建筑守卫
         * request
         *     accountGid: 玩家GID
         *     entityGid: 目标角色GID
         *     architectureId: 目标建筑ID
         *
         * response
         *     code: 错误码
         *
         */
		public const string connector_gameHandler_appointArchitectureGuard = "connector.gameHandler.appointArchitectureGuard";
		/**
         * 撤销城堡守卫
         * request
         *     accountGid: 玩家GID
         *     architectureId: 目标建筑ID
         *
         * response
         *     code: 错误码
         *
         */
		public const string connector_gameHandler_revocationArchitectureGuard = "connector.gameHandler.revocationArchitectureGuard";
		/**
         * 城堡建筑开启额外槽位
         * request
         *     accountGid: 玩家GID
         *
         * response
         *     code: 错误码
         *
         */
		public const string connector_gameHandler_castleArchitectureOpenExtraSlot = "connector.gameHandler.castleArchitectureOpenExtraSlot";
		/**
         * 城堡历练设置教师
         * request
         *     accountGid: 玩家GID
         *     entityGid: 目标角色GID
         *     slot: 历练教师槽序号
         *     slotType: 历练教师槽类型 ECastleModuleSlotType
         *
         * response
         *     code: 错误码
         *     info: CastlePracticeRunInfo 历练信息
         *
         */
		public const string connector_gameHandler_appointPracticeInstructor = "connector.gameHandler.appointPracticeInstructor";
		/**
         * 城堡历练撤销教师
         * request
         *     accountGid: 玩家GID
         *     slot: 历练教师槽序号
         *     slotType: 历练教师槽类型 ECastleModuleSlotType
         *
         * response
         *     code: 错误码
         *
         */
		public const string connector_gameHandler_revocationPracticeInstructor = "connector.gameHandler.revocationPracticeInstructor";
		/**
         * 城堡历练设置学员
         * request
         *     accountGid: 玩家GID
         *     entityGid: 目标角色GID
         *     slot: 历练教师槽序号
         *     slotType: 历练教师槽类型 ECastleModuleSlotType
         *
         * response
         *     code: 错误码
         *     info: CastlePracticeRunInfo 历练信息
         *
         */
		public const string connector_gameHandler_appointPracticeStudent = "connector.gameHandler.appointPracticeStudent";
		/**
         * 城堡历练撤销学员
         * request
         *     accountGid: 玩家GID
         *     slot: 历练教师槽序号
         *     slotType: 历练教师槽类型 ECastleModuleSlotType
         *
         * response
         *     code: 错误码
         *
         */
		public const string connector_gameHandler_revocationPracticeStudent = "connector.gameHandler.revocationPracticeStudent";
		/**
         * 城堡历练开始历练
         * request
         *     accountGid: 玩家GID
         *     slot: 历练教师槽序号
         *     slotType: 历练教师槽类型
         *     practiceType: 历练类型 ECastlePracticeType
         *     targetPrestige: 目标势力
         *
         * response
         *     code: 错误码
         *     info: CastlePracticeRunInfo 历练信息
         *
         */
		public const string connector_gameHandler_runPractice = "connector.gameHandler.runPractice";
		/**
         * 城堡历练终止历练
         * request
         *     accountGid: 玩家GID
         *     slot: 历练教师槽序号
         *     slotType: 历练教师槽类型
         *
         * response
         *     code: 错误码
         *     studentGid: 历练学员GID
         *     oldLv: 旧等级
         *     newLv: 新等级
         *     oldExp: 旧经验
         *     newExp: 新经验
         *     rewardList: 历练中获取的全部奖励列表
         *     randomEventList: 历练中出现的全部事件ID
         *
         *
         */
		public const string connector_gameHandler_terminatePractice = "connector.gameHandler.terminatePractice";
		/**
         * 城堡历练开启额外历练位
         * request
         *     accountGid: 玩家GID
         *
         * response
         *     code: 错误码
         */
		public const string connector_gameHandler_openExtraPracticeSlot = "connector.gameHandler.openExtraPracticeSlot";
		/**
         * 城堡历练选择随机事件结果
         * request
         *     accountGid: 玩家GID
         *     slot: 历练教师槽序号
         *     slotType: 历练教师槽类型
         *     optionIndex: 选项序号 0~N
         *
         * response
         *     code: 错误码
         *     replyId: 返回的对话ID？待定
         *     rewardList: 事件结果奖励组
         */
		public const string connector_gameHandler_selectPracticeRandomEventOption = "connector.gameHandler.selectPracticeRandomEventOption";
		/**
         * 城堡历练选择随机相亲结果
         * request
         *     accountGid: 玩家GID
         *     slot: 历练教师槽序号
         *     slotType: 历练教师槽类型
         *     optionIndex: 选项序号 0~N
         *
         * response
         *     code: 错误码
         *     replyId: 返回的对话ID？待定
         */
		public const string connector_gameHandler_selectPracticeRandomMarriageOption = "connector.gameHandler.selectPracticeRandomMarriageOption";
		/**
         * 城堡学校传授技能
         * request
         *     accountGid: 玩家GID
         *     studentGid: 学生GID
         *     instructorGid: 导师GID
         *     skillId: 目标技能
         *
         * response
         *     code: 错误码
         *     isAddSkill: 是否成功学习
         */
		public const string connector_gameHandler_castleImpartSkill = "connector.gameHandler.castleImpartSkill";
		/**
         * 城堡商会获取商会道具列表
         * request
         *     accountGid: 玩家GID
         *
         * response
         *     code: 错误码
         *     goodsList: ChamberOfCommerceGoodsInfo[] 商会道具列表
         */
		public const string connector_gameHandler_getCastleChamberOfCommerceGoods = "connector.gameHandler.getCastleChamberOfCommerceGoods";
		/**
         * 城堡商会购买道具
         * request
         *     accountGid: 玩家GID
         *     itemId: 道具ID
         *     num: 购买数量
         *
         * response
         *     code: 错误码
         */
		public const string connector_gameHandler_buyCastleGoods = "connector.gameHandler.buyCastleGoods";
		/**
         * 城堡商会获取商会物资菜单信息
         * request
         *     accountGid: 玩家GID
         *
         * response
         *     code: 错误码
         *     menuList: CastleChamberOfCommerceGoodsMenu[]
         */
		public const string connector_gameHandler_getCastleChamberOfCommerceGoodsMenu = "connector.gameHandler.getCastleChamberOfCommerceGoodsMenu";
		/**
         * [节日系统]-进入物资兑换
         * request
         *     accountGid: 玩家GID
         *
         * response
         *     code: 错误码
         *     exchangeItems: 兑换id,数量 字典
         */
		public const string connector_gameHandler_enterTradeFestival = "connector.gameHandler.enterTradeFestival";
		/**
         * [节日系统]-节日物资兑换
         * request
         *     accountGid: 玩家GID
         *     exchangeId: 兑换ID
         *     count: 兑换数量
         *
         * response
         *     code: 错误码
         */
		public const string connector_gameHandler_tradeFestivalExchange = "connector.gameHandler.tradeFestivalExchange";
		/**
         * [节日系统]-退出节日
         * request
         *     accountGid: 玩家GID
         *
         * response
         *     code: 错误码
         */
		public const string connector_gameHandler_exitFestival = "connector.gameHandler.exitFestival";
		/**
         * 城堡学校设置教师
         * request
         *     accountGid: 玩家GID
         *     entityGid: 目标角色GID
         *     slot: 目标槽位
         *
         * response
         *     code: 错误码
         */
		public const string connector_gameHandler_appointSchoolInstructor = "connector.gameHandler.appointSchoolInstructor";
		/**
         * 城堡学校卸任教师
         * request
         *     accountGid: 玩家GID
         *     slot: 目标槽位
         *
         * response
         *     code: 错误码
         */
		public const string connector_gameHandler_revocationSchoolInstructor = "connector.gameHandler.revocationSchoolInstructor";
		/**
         * 城堡学校设置重点学生
         * request
         *     accountGid: 玩家GID
         *     entityGid: 目标角色GID
         *     slot: 目标槽位
         *
         * response
         *     code: 错误码
         */
		public const string connector_gameHandler_addSchoolEmphasisStudent = "connector.gameHandler.addSchoolEmphasisStudent";
		/**
         * 城堡学校卸下重点学生
         * request
         *     accountGid: 玩家GID
         *     slot: 目标槽位
         *
         * response
         *     code: 错误码
         */
		public const string connector_gameHandler_revocationSchoolEmphasisStudent = "connector.gameHandler.revocationSchoolEmphasisStudent";
		/**
         * [节日系统]-进入角斗日
         * request
         *     accountGid: 玩家GID
         *     level: 竞技场等级
         *
         * response
         *     code: 错误码
         *     sum: 战斗总次数
         *     battleIds: <战斗序号,战斗id>
         */
		public const string connector_gameHandler_enterWrestleFestival = "connector.gameHandler.enterWrestleFestival";
		/**
         * [节日系统]-祈祷增加角色特性
         * request
         *     accountGid: 玩家GID
         *     actorGidList: 角色唯一id数组
         *     optionId: 节日选项id
         *     optionEffect: 祈祷效果id
         *
         * response
         *     code: 错误码
         */
		public const string connector_gameHandler_prayerAddActorSpeciality = "connector.gameHandler.prayerAddActorSpeciality";
		/**
         * [节日系统]-祈祷增加全局特性
         * request
         *     accountGid: 玩家GID
         *     optionId: 节日选项id
         *     optionEffect: 祈祷效果id
         *
         * response
         *     code: 错误码
         */
		public const string connector_gameHandler_prayerAddPlayerSpeciality = "connector.gameHandler.prayerAddPlayerSpeciality";
		/**
         * 进行婚宴
         * request
         *      accountGid: 玩家GID
         *      entityGid string 目标角色
         *      level int 婚宴等级
         *      attendant List<string> 伴郎伴娘
         *      bouquet List<string> 捧花
         *      student List<string> 花童
         *
         * response
         *     code: 错误码
         *     rewardList: List<IntPair> 奖励列表
         *     bouquetGid: string 捧花中奖人
         */
		public const string connector_gameHandler_runWedding = "connector.gameHandler.runWedding";
		/**
         * 举办城堡宴会
         * request
         *      accountGid: 玩家GID
         *      entityGid string 目标角色
         *      country int 指定国家
         *      area int 指定区域
         *      isReplenishGoods int 是否从城堡市场自动购买缺少物资
         *
         * response
         *     code: 错误码
         *     infoList: List<CastleFeastTargetInfo> 相亲对象信息列表
         */
		public const string connector_gameHandler_castleFeastRun = "connector.gameHandler.castleFeastRun";
		/**
         * 城堡宴会表白
         * request
         *      accountGid: 玩家GID
         *      targetId string 目标角色
         *
         * response
         *     code: 错误码
         *     issueId: int 问题ID
         */
		public const string connector_gameHandler_castleFeastRunConfession = "connector.gameHandler.castleFeastRunConfession";
		/**
         * 城堡宴会回答问题
         * request
         *      accountGid: 玩家GID
         *
         * response
         *     code: 错误码
         *     replyId: int 回答ID
         *     issueId: int 后续场景状态可使用的物资组ID 0为直接结束宴会 否则进入使用物资挽回阶段
         */
		public const string connector_gameHandler_castleFeastReplyIssue = "connector.gameHandler.castleFeastReplyIssue";
		/**
         * 城堡宴会使用物资挽回对象
         * request
         *      accountGid: 玩家GID
         *      useType: int 使用的类型 0为取消 1为物资 2为钻石
         *      goodsGroupIndex: int 使用物资时使用的物资组
         *      goodsList: IntPairList 物资数量信息
         *
         * response
         *     code: 错误码
         */
		public const string connector_gameHandler_castleFeastUseGoodsRetrieve = "connector.gameHandler.castleFeastUseGoodsRetrieve";
		/**
         * 城堡宴会退出
         * request
         *      accountGid: 玩家GID
         *
         * response
         *     code: 错误码
         */
		public const string connector_gameHandler_castleFeastExit = "connector.gameHandler.castleFeastExit";
		/**
         * [道具使用]-使用道具扫荡券
         * request
         *     accountGid: 玩家GID
         *     taskGid: 任务Gid
         *     teamName: 编队Gid
         *
         * response
         *     code: 错误码
         *     data: 奖励信息
         *          itemList: 道具奖励,
         *          equipList: 装备奖励,
         *          actorList: 角色奖励
         *
         */
		public const string connector_gameHandler_useItemSweeping = "connector.gameHandler.useItemSweeping";
		/**
         * [成就目标]-领取成就目标奖励
         * request
         *      accountGid 账号唯一ID
         *      isAll 0不全部领取奖励, id 目标数据ID
         *      isAll 1全部领取奖励, id = 0
         * response
         *      code: 错误码
         *      data:
         */
		public const string connector_gameHandler_getPlayerTargetAttainmentReward = "connector.gameHandler.getPlayerTargetAttainmentReward";
		/*
        * [军团系统]-创建军团信息
         * request
         *      accountGid 账号唯一ID
         *      corpsName 军团名称
         *      flagInfo 军团旗帜
         * response
         *      code: 错误码
         *      data: 
         *          corpsInfo: 军团信息
         */
		public const string connector_gameHandler_createNewCorps = "connector.gameHandler.createNewCorps";
		/**
         * [军团系统]-修改军团名
         * request
         *      accountGid 账号唯一ID
         *      corpsName 军团名称
         */
		public const string connector_gameHandler_modifyCorpsName = "connector.gameHandler.modifyCorpsName";
		/**
         * [军团系统]-修改军团旗帜
         * request
         *      accountGid 账号唯一ID
         *      flagInfo 军团旗帜
         */
		public const string connector_gameHandler_modifyCorpsFlag = "connector.gameHandler.modifyCorpsFlag";
		/**
         * [军团系统]-升级军团职位
         * request
         *      accountGid 账号唯一ID
         *      index 解锁槽位坐标
         * response
         *      code: 错误码
         *      data: 军团职位槽位信息
         */
		public const string connector_gameHandler_upCorpsPosition = "connector.gameHandler.upCorpsPosition";
		/**
         * [军团系统]-给角色任命军团职位
         * request
         *      accountGid 账号唯一ID
         *      index 解锁槽位坐标
         *      entityGid 任命的角色 ""卸下
         * response
         *      code: 错误码
         *      data: 军团职位槽位信息
         */
		public const string connector_gameHandler_appointmentCorpsPosition = "connector.gameHandler.appointmentCorpsPosition";
		/**
         * 保存编队预设
         * request
         *      accountGid 账号唯一ID
         *      name 队伍名称
         * response
         *      info 编队预设信息
         */
		public const string connector_gameHandler_saveTeamPreset = "connector.gameHandler.saveTeamPreset";
		/**
         * 使用编队预设
         * request
         *      accountGid 账号唯一ID
         *      name 队伍名称
         * response
         *      showCode 编队内角色应用预设时的出现的错误码列表
         */
		public const string connector_gameHandler_useTeamPreset = "connector.gameHandler.useTeamPreset";
		/**
         * [军团圣物]-打造军团圣物
         * request
         *      accountGid 账号唯一ID
         *      equipGid 装备唯一ID
         */
		public const string connector_gameHandler_createCorpsSacred = "connector.gameHandler.createCorpsSacred";
		/**
         * [军团圣物]-军团圣物突破
         * request
         *      accountGid 账号唯一ID
         *      equipGid 装备唯一ID
         */
		public const string connector_gameHandler_corpsSacredBreak = "connector.gameHandler.corpsSacredBreak";
		/**
         * [军团圣物]-圣物人物解绑
         * request
         *      accountGid 账号唯一ID
         *      equipGid 装备唯一ID
         */
		public const string connector_gameHandler_corpsSacredUnbundling = "connector.gameHandler.corpsSacredUnbundling";
		/**
         * [军团圣物]-刷新军团圣物效果
         * request
         *      accountGid 账号唯一ID
         *      equipGid 装备唯一ID
         * response
         *      effectIdList 效果id数组
         */
		public const string connector_gameHandler_refreshCorpsSacredEffect = "connector.gameHandler.refreshCorpsSacredEffect";
		/**
         * [军团圣物]-开始打造军团圣物
         * request
         *      accountGid 账号唯一ID
         *      equipGid 装备唯一ID
         * response
         *      effectIdList 效果id数组
         */
		public const string connector_gameHandler_startCreateCorpsSacred = "connector.gameHandler.startCreateCorpsSacred";
		/**
         * 设置角色转向角度
         * request
         *      accountGid 账号唯一ID
         *      orientationHash 角色及对应角度的字典
         * response
         *      code
         */
		public const string connector_battleHandler_battleSetActorOrientation = "connector.battleHandler.battleSetActorOrientation";
		/**
         * [军团圣物] 开始突破军团圣物
         * request
         *      accountGid 账号唯一ID
         *      equipGid 装备唯一ID
         * response
         *      effectIdList 效果id数组
         */
		public const string connector_gameHandler_startCorpsSacredBreak = "connector.gameHandler.startCorpsSacredBreak";
		/**
         * [军团技能] 激活军团技能
         * request
         *      accountGid 账号唯一ID
         *      corpSkillId 军团技能id
         */
		public const string connector_gameHandler_activatedCorpSkill = "connector.gameHandler.activatedCorpSkill";
		/**
         * [军团技能] 升级解锁军团技能
         * request
         *      accountGid 账号唯一ID
         *      corpSkillId 军团技能id
         * response
         *      corpSkill 军团技能
         */
		public const string connector_gameHandler_upUnlockedCorpSkill = "connector.gameHandler.upUnlockedCorpSkill";
		/**
         * [广场]点击某城市点广场中NPC
         *  accountGid 账号唯一ID
         *  npcId
         */
		public const string connector_gameHandler_clickMapPointFunctionNpc = "connector.gameHandler.clickMapPointFunctionNpc";
		/**
         * [广场]对话结束
         * accountGid 账号唯一ID
         * dialogId 对话ID
         */
		public const string connector_gameHandler_closeNpcDialogGetReward = "connector.gameHandler.closeNpcDialogGetReward";
		/**
         * [广场]领取对话中奖励协议
         * accountGid 账号唯一ID
         * dialogId 对话ID
         * index 奖励下标
         */
		public const string connector_gameHandler_getDialogReward = "connector.gameHandler.getDialogReward";
		/**
         * 理发店进行理发
         * accountGid 账号唯一ID
         * actorGid 需要更变造型的角色GID
         * partIdList 目标部件数组
         */
		public const string connector_gameHandler_runBarber = "connector.gameHandler.runBarber";
		/**
         * 处理角色要求
         * accountGid 账号唯一ID
         * entityGid 处理的角色GID
         * status 需求状态 0拒绝 1接受
         */
		public const string connector_gameHandler_processingActorDemand = "connector.gameHandler.processingActorDemand";
		/**
         * 伤病进行治疗
         * accountGid 账号唯一ID
         * actorGid 需要更变造型的角色GID
         * injuryId 目标伤病ID
         * useItemNum 使用的道具数量
         */
		public const string connector_gameHandler_cureInjury = "connector.gameHandler.cureInjury";
		/**
         * 全员伤病治疗
         * accountGid 账号唯一ID
         * injuryType 目标伤病类型
         */
		public const string connector_gameHandler_allActorCureInjury = "connector.gameHandler.allActorCureInjury";
		/**
         * 测试命令
         * accountGid 账号唯一ID
         * data 参数字典 "functionName":"方法名(必填)","方法参数1":"方法参数(按方法需要选填)","方法参数2":"方法参数(按方法需要选填)"
         */
		public const string connector_gameHandler_testCommand = "connector.gameHandler.testCommand";
		/**
         * [角色] 添加自定义标签
         * accountGid 账号唯一ID
         * entityGid 角色唯一id
         * customTag 自定义标签
         */
		public const string connector_gameHandler_addActorCustomTag = "connector.gameHandler.addActorCustomTag";
		/**
         * 确认解锁剧情步骤
         * accountGid 账号唯一ID
         * paramList 下一个触发器需要的额外临时参数字典
         */
		public const string connector_battleHandler_unlockSceneScenario = "connector.battleHandler.unlockSceneScenario";
		/**
         * 根据木桩ID获取一个team数据
         * accountGid 账号唯一ID
         * stumpId 木桩ID
         */
		public const string connector_battleHandler_getTeamInfoByStumpId = "connector.battleHandler.getTeamInfoByStumpId";
		/**
         * [征兵] 角色参与征兵
         * accountGid 账号唯一ID
         * entityGids 角色唯一id数组
         * countryId 加入国家
         */
		public const string connector_gameHandler_actorJoinConscription = "connector.gameHandler.actorJoinConscription";
		/**
         * [城堡委托派遣]获取委托任务列表协议
         * accountGid 账号唯一ID
         */
		public const string connector_gameHandler_getEntrustTaskList = "connector.gameHandler.getEntrustTaskList";
		/**
         * [城堡委托派遣]选择一个委托任务派遣六名角色去执行
         * accountGid 账号唯一ID
         * entrustGid 委托任务唯一ID
         * actorGids 选择的角色唯一ID列表
         */
		public const string connector_gameHandler_entrustActorCompleteTask = "connector.gameHandler.entrustActorCompleteTask";
		/**
         * [城堡委托派遣]刷新未接取的委托任务列表
         * accountGid 账号唯一ID
         */
		public const string connector_gameHandler_refreshEntrustTaskList = "connector.gameHandler.refreshEntrustTaskList";
		/**
         * [城堡委托派遣]领取完成委托任务奖励
         * accountGid 账号唯一ID
         * actorGids 选择的角色唯一ID列表
         */
		public const string connector_gameHandler_getCompleteEntrustTaskReward = "connector.gameHandler.getCompleteEntrustTaskReward";
		/**
         * 前端通知后端战斗场景完成加载
         * accountGid 账号唯一ID
         */
		public const string connector_battleHandler_notifyServerBattleSceneLoadEnd = "connector.battleHandler.notifyServerBattleSceneLoadEnd";
		/**
         * [钻石商店]获取钻石商店数据
         * accountGid 账号唯一ID
         */
		public const string connector_gameHandler_getDiamondShopInfo = "connector.gameHandler.getDiamondShopInfo";
		/**
         * [钻石商店]钻石商店购买商品
         * accountGid 账号唯一ID
         * randomGoodsList List<IntPair> 需要购买的随机商品
         * shopCycleGoodsList List<IntPair> 需要购买的周期商品
         */
		public const string connector_gameHandler_buyGoodsOfDiamondShop = "connector.gameHandler.buyGoodsOfDiamondShop";
		/**
         * [排行榜] 获取通用排行榜信息
         * accountGid 账号唯一ID
         * rankId int 排行榜id
         */
		public const string connector_gameHandler_getGeneralRankListInfo = "connector.gameHandler.getGeneralRankListInfo";
		/**
         * [排行榜] 获取活动排行榜
         * accountGid 账号唯一ID
         */
		public const string connector_gameHandler_getOpenActiveRankInfo = "connector.gameHandler.getOpenActiveRankInfo";
		/**
         * [主线、支线任务] 结束上一个剧情
         * accountGid 账号唯一ID
         */
		public const string connector_gameHandler_stopLastStory = "connector.gameHandler.stopLastStory";
		/**
         * [排行榜] 获取角色排行榜信息
         * accountGid 账号唯一ID
         * rankId int 排行榜id
         */
		public const string connector_gameHandler_getActorRankListInfo = "connector.gameHandler.getActorRankListInfo";
		/**
         * [排行榜] 排行榜获取角色详情
         * accountGid 账号唯一ID
         * rankId int 排行榜id
         * entityGid string 角色实体唯一ID
         */
		public const string connector_gameHandler_getRankListActorInfo = "connector.gameHandler.getRankListActorInfo";
		/**
         * [每日签到] 获取签到信息
         * accountGid 账号唯一ID
         */
		public const string connector_gameHandler_getSignInfo = "connector.gameHandler.getSignInfo";
		/**
         * [每日签到] 点击签到
         * accountGid 账号唯一ID
         */
		public const string connector_gameHandler_clickTheSignIn = "connector.gameHandler.clickTheSignIn";
		/**
         * [每日签到] 获取连续签到信息
         * accountGid 账号唯一ID
         */
		public const string connector_gameHandler_getContinuousSignInfo = "connector.gameHandler.getContinuousSignInfo";
		/**
         * [每日签到] 领取连续签到奖励
         * accountGid 账号唯一ID
         */
		public const string connector_gameHandler_receiveContinuousSignReward = "connector.gameHandler.receiveContinuousSignReward";
		/**
         * [竞技场] 获取玩家竞技场数据
         * accountGid 账号唯一ID
         */
		public const string connector_gameHandler_getPlayerArenaInfo = "connector.gameHandler.getPlayerArenaInfo";
		/**
         * [竞技场] 获取玩家战报
         * accountGid 账号唯一ID
         * start 检索起始位置
         * num 检索数量
         */
		public const string connector_gameHandler_getPlayerArenaBattleRecord = "connector.gameHandler.getPlayerArenaBattleRecord";
		/**
         * [竞技场] 获取前三席位数据
         * accountGid 账号唯一ID
         */
		public const string connector_gameHandler_getArenaSeatListInfo = "connector.gameHandler.getArenaSeatListInfo";
		/**
         * [竞技场] 领取晋级奖励
         * accountGid 账号唯一ID
         */
		public const string connector_gameHandler_gainArenaRankLvPrize = "connector.gameHandler.gainArenaRankLvPrize";
		/**
         * [竞技场] 进行竞技场匹配
         * accountGid 账号唯一ID
         * seatNum 挑战的目标席位 为0时进行随机匹配
         */
		public const string connector_gameHandler_arenaRunMatch = "connector.gameHandler.arenaRunMatch";
		/**
         * [竞技场] 购买竞技场战斗次数
         * accountGid 账号唯一ID
         */
		public const string connector_gameHandler_buyArenaBattleNum = "connector.gameHandler.buyArenaBattleNum";
		/**
         * [竞技场] 竞技场进行挑战
         * accountGid 账号唯一ID
         */
		public const string connector_battleHandler_runArenaChallenge = "connector.battleHandler.runArenaChallenge";
		/**
         * [竞技场] 领取赛季战斗总次数奖励
         * accountGid 账号唯一ID
         */
		public const string connector_gameHandler_gainArenaSeasonBattleNumPrize = "connector.gameHandler.gainArenaSeasonBattleNumPrize";
		/**
         * [军团] 将成年角色加入军团
         * accountGid 账号唯一ID
         */
		public const string connector_gameHandler_adultActorJoinCorps = "connector.gameHandler.adultActorJoinCorps";
		/**
         * [任务] 修改追踪任务
         * accountGid 账号唯一ID
         * taskGid 任务唯一id
         */
		public const string connector_gameHandler_modifyTrackingTask = "connector.gameHandler.modifyTrackingTask";
		/**
         * [装备附魔] 获取附魔冷却时间
         * accountGid 账号唯一ID
         * equipGid 装备唯一id
         */
		public const string connector_gameHandler_getEnchantingCoolingTime = "connector.gameHandler.getEnchantingCoolingTime";
		/**
         * [系统设置] 账号登出
         * accountGid 账号唯一ID
         */
		public const string connector_connHandler_logout = "connector.connHandler.logout";
		/**
         * [组队副本]获取玩家组队副本模式数据
         * accountGid 账号唯一ID
         */
		public const string connector_gameHandler_getTeamBattleInfo = "connector.gameHandler.getTeamBattleInfo";
		/**
         * [组队副本]获取玩家组队副本指定副本队伍数据
         * accountGid 账号唯一ID
         * levelId 组队副本主线关卡ID
         */
		public const string connector_gameHandler_getTeamBattleCopyInfo = "connector.gameHandler.getTeamBattleCopyInfo";
		/**
         * [组队副本]购买组队副本进入次数
         * accountGid 账号唯一ID
         */
		public const string connector_gameHandler_BuyTeamBattleEntryNum = "connector.gameHandler.BuyTeamBattleEntryNum";
		/**
         * [组队副本]创建副本组队伍
         * accountGid 账号唯一ID
         * country 国家ID
         * level 难度
         */
		public const string connector_gameHandler_CreateTeamBattleGroup = "connector.gameHandler.CreateTeamBattleGroup";
		/**
         * [组队副本]匹配进入队伍
         * accountGid 账号唯一ID
         * country 国家ID
         * level 难度
         */
		public const string connector_gameHandler_MatchTeamBattleGroup = "connector.gameHandler.MatchTeamBattleGroup";
		/**
         * [组队副本]进入指定队伍
         * accountGid 账号唯一ID
         * groupId 组队副本队伍ID
         */
		public const string connector_gameHandler_EntryTargetTeamBattleGroup = "connector.gameHandler.EntryTargetTeamBattleGroup";
		/**
         * [主线、支线] 接默认主线任务
         */
		public const string connector_gameHandler_acceptDefaultTaskMain = "connector.gameHandler.acceptDefaultTaskMain";
		/**
         * [系统设置] 使用兑换码
         * accountGid 账号唯一ID
         * exchangeCode 兑换码
         */
		public const string connector_gameHandler_useExchangeCode = "connector.gameHandler.useExchangeCode";
		/**
         * [爬塔功能] 获取全部塔信息
         * accountGid 账号唯一ID
         */
		public const string connector_gameHandler_getAllTowerInfo = "connector.gameHandler.getAllTowerInfo";
		/**
         * [爬塔功能] 进入塔内
         * accountGid 账号唯一ID
         * towerId  塔ID
         */
		public const string connector_gameHandler_enterTheTower = "connector.gameHandler.enterTheTower";
		/**
         * [爬塔功能] 进入答题
         * accountGid 账号唯一ID
         */
		public const string connector_gameHandler_enterTheTowerAnswer = "connector.gameHandler.enterTheTowerAnswer";
		/**
         * [爬塔功能] 回答问题
         * accountGid 账号唯一ID
         * answerId 答案ID
         */
		public const string connector_gameHandler_towerAnswerTheQuestions = "connector.gameHandler.towerAnswerTheQuestions";
		/**
         * [爬塔功能] 进入塔内商店
         * accountGid 账号唯一ID
         */
		public const string connector_gameHandler_enterTheTowerShop = "connector.gameHandler.enterTheTowerShop";
		/**
         * [爬塔功能] 兑换塔内商店商品
         * accountGid 账号唯一ID
         * shopId 商品id
         */
		public const string connector_gameHandler_exchangeTowerShop = "connector.gameHandler.exchangeTowerShop";
		/**
         * [组队副本]组队副本进行挑战
         * accountGid 账号唯一ID
         * country 国家
         * level 难度
         */
		public const string connector_battleHandler_runTeamBattleChallenge = "connector.battleHandler.runTeamBattleChallenge";
		/**
         * [组队副本]根据队伍ID获取队伍信息
         * accountGid 账号唯一ID
         * groupId 队伍ID
         */
		public const string connector_gameHandler_getTeamBattleCopyGroupInfo = "connector.gameHandler.getTeamBattleCopyGroupInfo";
		/**
         * [爬塔功能] 爬塔挑战
         * accountGid 账号唯一ID
         */
		public const string connector_battleHandler_climbTowerChallenge = "connector.battleHandler.climbTowerChallenge";
		/**
         * [每日任务]领取每日任务奖励
         * accountGid 账号唯一ID
         * taskId 任务id
         */
		public const string connector_gameHandler_receiveTaskDailyReward = "connector.gameHandler.receiveTaskDailyReward";
		/**
         * [每日任务]领取每日活跃奖励
         * accountGid 账号唯一ID
         * rewardId 奖励id
         */
		public const string connector_gameHandler_receiveActiveDailyReward = "connector.gameHandler.receiveActiveDailyReward";
		/**
         * [每日任务]领取周活跃奖励
         * accountGid 账号唯一ID
         */
		public const string connector_gameHandler_receiveActiveWeekReward = "connector.gameHandler.receiveActiveWeekReward";
		/**
         * [图书馆图鉴]领取单图鉴奖励
         * accountGid 账号唯一ID
         * type1 图鉴一级类型
         * type2 图鉴二级类型
         * tmpId 激活图鉴的物品ID
         */
		public const string connector_gameHandler_getOneAtlasReward = "connector.gameHandler.getOneAtlasReward";
		/**
         * [图书馆图鉴]领取阶段图鉴奖励
         * accountGid 账号唯一ID
         * type1 图鉴一级类型
         * type2 图鉴二级类型
         */
		public const string connector_gameHandler_getAtlasStageReward = "connector.gameHandler.getAtlasStageReward";
		/**
         * [穿脱装备]脱下角色全部装备
         * accountGid 账号唯一ID
         * entityGid 角色唯一id
         */
		public const string connector_gameHandler_takeOffAllEquipByEntityGid = "connector.gameHandler.takeOffAllEquipByEntityGid";
		/**
         * [技能学习] 刷新学习角色待学技能列表
         * accountGid 账号唯一ID
         * entityGid 角色唯一id
         */
		public const string connector_gameHandler_refreshActorSkillChoose = "connector.gameHandler.refreshActorSkillChoose";
		/**
         * [技能学习] 确认学习角色待学技能
         * accountGid 账号唯一ID
         * entityGid 角色唯一id
         * index 目标技能序
         */
		public const string connector_gameHandler_confirmActorSkillChoose = "connector.gameHandler.confirmActorSkillChoose";
	}

}
