namespace GlobalDefine{
	/**错误码说明 */
	public enum EErrorCode{
		/** 通讯成功 */
		SUCCESS = 0, 
		/** 未知错误 */
		UNKNOWN_ERROR = 1, 
		/** 协议参数个数错误 */
		PARAM_NUM_ERROR = 2, 
		/** 无链接conn服消息 */
		NO_CONN_LINK_INFO = 3, 
		/** 数据保存错误*/
		SAVE_ERROR = 4, 
		/**配置获取错误*/
		CFG_ERROR = 5, 
		/** 账号已注册 */
		Login_ACCOUNT_IS_REGISTER = 100, 
		/** 无登陆loginServer服消息 */
		Login_NO_LOGINSERVER_LINK_INFO = 101, 
		/** 账号未注册不能登录 */
		Login_ACCOUNT_NOT_REGISTER = 102, 
		/** 链接服无该游客链接信息 */
		Login_CONN_NOTFIND_UIDDATA = 103, 
		/** 补全游客账号错误,未找到旧账号数据 */
		Login_REPAIRE_ACCDATA_ERROR = 104, 
		/** 账号注册失败,loginServer返回null */
		Login_REGISTER_RPC_SERVER_ERROR = 105, 
		/** 新账号已被注册过 */
		Login_NEW_ACCOUNTID_IS_REGISTER = 106, 
		/** 补全信息失败, 旧账号格式错误 */
		Login_OLD_ACCOUNTID_TYPE_ERROR = 107, 
		/** 补全信息时账号状态错误 */
		Login_OLD_ACCOUNT_LOGINSTATUS_ERROR = 108, 
		/** 账号未注册不能创建player */
		Login_CREATE_PLAYERDATA_ERROR = 109, 
		/** 创建player失败,账号信息未找到 */
		Login_CREATE_PLAYERDATA_ERROR_ACCOUNT_ERROR = 110, 
		/** 进入游戏失败,未发现playerData */
		Login_CREATE_PLAYERDATA_ERROR_ISHAVE = 111, 
		/** 账号登陆失败 */
		Login_ACCOUNT_LOGIN_ERROR = 112, 
		/** 快速登陆，创建账号失败 */
		Login_QUICK_LOGIN_CREATE_ACCOUNT_ERROR = 113, 
		/** 快速登陆，创建player失败 */
		Login_QUICK_LOGIN_CREATE_PLAYER_ERROR = 114, 
		/** 快速登陆，创建actor卡牌失败 */
		Login_QUICK_LOGIN_CREATE_ACTOR_ERROR = 115, 
		/** 快速登陆, 账号状态不能在快速登陆接口登陆 */
		Login_QUICK_LOGIN_ACCOUNT_STATUS_ERROR = 116, 
		/**账号已经在另一个地方登录 */
		Login_LOGIN_ACCOUNT_LOGINED_OTHER = 117, 
		/** 登陆密码错误 */
		Login_LOGIN_PASSWORD_ERROR = 118, 
		/** 补全信息时为角色保存数据失败 */
		Login_OLD_ACCOUNTID_PLAYER_SAVE_ERROR = 119, 
		/** 重复创建角色*/
		Login_REPEAT_CREATE_PLAYER_ERROR = 120, 
		/** 获得game服信息失败 */
		Game_GET_GAMESERVER_INFO_ERROR = 501, 
		/** 账号没登录不能进入游戏 */
		Game_ACCOUNT_ISNOTLOGIN_ENTERGAME_ERROR = 502, 
		/** enterGame从redis获取player数据错误 */
		Game_GET_PLAYER_DATA_FROM_REDIS_ERROR = 503, 
		/** 招募队员时获取唯一gId错误 */
		Game_GET_NEW_ACTOR_GET_UNIQUEN_ID_ERROR = 504, 
		/** 招募队员时创建队员数据失败 */
		Game_GET_NEW_ACTOR_CREATE_NEW_DATA_ERROR = 505, 
		/**从缓存中获取player对象错误 */
		Game_GET_PLAYER_OBJECT_ERROR = 506, 
		/**缓存player中没有actors数据 */
		Game_GET_CACHE_PLAYER_ACTORS_ERROR = 507, 
		/**缓存player没有对应actorGid的actor数据 */
		Game_GET_CACHE_PLAYER_ACTORGID_ACTOR_ERROR = 508, 
		/**[设置队友上阵下阵]-队友数据错误 */
		Game_SET_ACTOR_IS_GO_BATTLE_INFO_ERROR = 509, 
		/**[设置队友上阵下阵]-获取最新队伍站位信息错误 */
		Game_SET_ACTOR_IS_GO_BATTLE_NEW_INDEX_STR_ERROR = 510, 
		/**[设置队友上阵下阵]-队友当前处于要设置的状态 */
		Game_SET_ACTOR_IS_GO_BATTLE_IS_STATUS = 511, 
		/**[设置队友上阵下阵]-账号正在战斗无法操作 */
		Game_SET_ACTOR_IS_GO_BATTLE_NOT_ACTOR = 512, 
		/**[设置队友上阵下阵]-上阵队伍最少得有一个 */
		Game_SET_ACTOR_IS_GOBATTLE_ONLY_ONE = 513, 
		/**[站前调整队员位置]-位置锁定无法调整 */
		Game_REPARE_POSITION_TILE_IS_LOCKED = 514, 
		/**[设置队友上阵下阵]-位置锁定无法调整 */
		Game_SET_ACTOR_IS_GOBATTLE_IS_LOCKED = 515, 
		/**[设置队友上阵下阵]-目标队伍没有空位 */
		Game_SET_ACTOR_IS_GOBATTLE_NOT_VACANCY = 516, 
		/**[设置队友上阵下阵]-玩家最少需要一个编队，不能将本角色下阵 */
		Game_SET_ACTOR_IS_GOBATTLE_PLAYER_LEAST_NEED_ONE_TEAM = 517, 
		/**[获取剧情角色]-获取剧情角色失败 */
		Game_GET_CACHE_PLAYER_FIXED_ACTORS_ERROR = 518, 
		/**[招募角色]-该actor已经招募过*/
		Game_GET_NEW_ACTOR_CREATE_IS_HAVE_ACTOR_ERROR = 519, 
		/**[设置队员上阵或下阵]-该队员已上阵或下阵 */
		Game_SETISGOBATTLE_ACTOR_IS_READY = 520, 
		/**[删除装备]-要删除的装备中有穿在角色身上的 */
		Game_DELETE_EQUIPS_IS_ACTOR_CHUAN = 521, 
		/**[删除道具]-删除道具失败 */
		Game_DELETE_ITEM_FAIL = 522, 
		/**[删除装备]-没有要删除的装备唯一ID信息 */
		Game_NOT_FIND_EQUIPGID_IN_PLAYER = 523, 
		/**[删除道具]-要删除的道具不存在或数量不够 */
		Game_DELETE_ITEM_IS_NOT_FIND_NOT_ENOUGH = 524, 
		/**[获得装备]-添加装备失败 */
		Game_GET_EQUIPMENT_JSON_DATA_ERROR = 525, 
		/**[获得装备]-装备没有附魔不能刷新 */
		Game_EQUIP_NOT_ENCHATING = 526, 
		/**[添加道具]-增加道具数量超过最大上限 */
		Game_ADD_ITEM_COUNT_DAYU_MAXCOUNT = 527, 
		/**[穿、替换装备] 未找到actor数据*/
		Game_USE_ACTOR_EQUIP_NOT_FIND_ACTOR = 528, 
		/**[穿、替换装备] 未找到装备数据*/
		Game_USE_ACTOR_EQUIP_NOT_FIND_EQUIP = 529, 
		/**[穿、替换装备] 要穿的装备已经被使用了*/
		Game_USE_ACTOR_EQUIP_EQUIP_IS_USE = 530, 
		/**[脱装备]-该装备未穿着 */
		Game_TAKEOFF_EQUIP_NOT_USE = 531, 
		/**[穿、替换装备]-主手槽位装备的不是单手武器 */
		Game_USE_ACTOR_EQUIP_MAIN_EQUIP_ERROR = 532, 
		/**[穿、替换装备]-没找到职业表数据 */
		Game_USE_ACTOR_EQUIP_NOT_FIND_JOB_DATA = 533, 
		/**[穿、替换装备]-要穿的装备与该角色职业不符合 */
		Game_USE_ACTOR_EQUIP_JOB_BU_FU_HE = 534, 
		/**[装备升品]-没该装备信息 */
		Game_EQUIP_UP_PROMOTE_NOT_FIND_EQUIP_DATA = 535, 
		/**[装备升品]-装备升品超出上限 */
		Game_EQUIP_UP_PROMOTE_TOP_QUALITY_LIMIT = 536, 
		/**[装备升品]-获取升品json数据错误*/
		Game_EQUIP_UP_PROMOTE_GET_JSON_ERROR = 537, 
		/**[装备升品]-杀怪数不够不能升品 */
		Game_EQUIP_UP_PROMOTE_KILL_NUM_ERROR = 538, 
		/**[脱装备]-装备未穿在角色身上不能脱下 */
		Game_TAKE_OFF_EQUIP_NOT_USED = 539, 
		/**[创建新编队]-获取vip的json数据错误 */
		Game_CREATE_NEW_TEAM_VIP_CFG_ERROR = 540, 
		/**[创建新编队]-创建新编队个数达到上限 */
		Game_CREATE_NEW_TEAM_COUNT_ERROR = 541, 
		/**[强化装备]-未找到装备 */
		Game_EQUIP_STRENGTHEN_GET_DATA_ERROR = 542, 
		/**[强化装备]-未找到强化json数据 */
		Game_EQUIP_STRENTHEN_NOT_FIND_CFG = 543, 
		/**[强化装备]-强化装备消耗道具不足 */
		Game_EQUIP_STRENGTHEN_CONSUME_ITEM_ERROR = 544, 
		/**[装备强化]-强化道具不足 */
		Game_EQUIP_STRENGTHEN_CONSUME_ITEM_COUNT_ERROR = 545, 
		/**[装备强化]-银币不足 */
		Game_EQUIP_STRENGTHEN_YINBI_ERROR = 546, 
		/**[宝石升级]-五级彩色宝石不会升级产生*/
		Game_FIVE_LEVEL_COLORED_NOT_UP_CREATE = 547, 
		/**[装备镶嵌宝石的槽位升级]-未找到槽位信息 */
		Game_SLOT_ADD_LEVEL_NOT_FIND_DATA = 548, 
		/**[装备镶嵌宝石的槽位升级]-消耗的道具(银币不足) */
		Game_SLOT_ADD_LEVEL_CONSUME_ITEM_ERROR = 549, 
		/**[装备镶嵌宝石的槽位升级]-获取槽位升级需要的json数据错误 */
		Game_SLOT_ADD_LEVEL_GET_JSON_ERROR = 550, 
		/**[彩色宝石合成]-合成宝石材料错误 */
		Game_CREATE_COLORED_GEM_MATERIAL_ERROR = 551, 
		/**[彩色宝石合成]-合成宝石失败 */
		Game_CREATE_COLORED_GEM_ERROR = 552, 
		/**[宝石升级]-宝石升级失败 */
		Game_UPGRADE_GEM_ERROR = 553, 
		/**[装备强化]-装备品质不够不能强化 */
		Game_EQUIP_STRENGTHEN_QUALITY_ERROR = 554, 
		/**[宝石镶嵌]- 装备宝石镶嵌失败 */
		Game_EQUIP_INLAY_GEM_ERROR = 555, 
		/**[装备附魔]-该品质装备不能附魔 */
		Game_ENCHANTING_QUALITY_ERROR = 556, 
		/**[装备附魔]-附魔消耗道具数据错误 */
		Game_ENCHANTING_GET_JSON_ERROR = 557, 
		/**[添加宝石]-彩色宝石等级不足 */
		Game_BAG_GEM_LEVEL_ERROR = 558, 
		/**[装备附魔]-没有临时附魔信息 */
		Game_ENCHANTING_TEMPORARY_INFO_ERROR = 559, 
		/**[装备附魔]-装备品质限制的等级到极限了 */
		Game_ENCHANTING_PROMETO_MAXLEVEL_ERROR = 560, 
		/**[装备附魔]-钻石不够 */
		Game_ENCHATING_RANDOM_ARR_ZUANSHI_ERROR = 561, 
		/**[装备洗炼]-洗炼消耗银币错误 */
		Game_REFINEMENT_CONSUME_ERROR = 562, 
		/**[装备洗炼]-洗炼属性重随错误 */
		Game_REFINEMENT_NATURE_CREATE_ERROR = 563, 
		/**[装备附魔]-银币数据错误 */
		Game_ENCHANTING_SLIVER_ERROR = 564, 
		/**[装备附魔]-银币数量不足 */
		Game_ENCHANTING_SLIVER_COUNT_ERROR = 565, 
		/**[装备附魔]-没有保护道具数据 */
		Game_ENCHANTING_PROTECT_ITEM_ERROR = 566, 
		/**[装备附魔]-没有提升成功率道具数据 */
		Game_ENCHANTING_ADD_PRO_ITEM_ERRRO = 567, 
		/**[装备附魔]-提升成功率道具json数据错误 */
		Game_ENCHANTING_ADD_PRO_ITEM_JSON_ERROR = 568, 
		/**[装备洗炼]-洗炼属性保存错误 */
		Game_REFINEMENT_NATURE_SAVE_ERROR = 569, 
		/**[装备附魔]-附魔json数据错误 */
		Game_ENCHATING_JSON_DATA_ERROR = 570, 
		/**[装备附魔]-装备已经附魔确定不用清除刷新cd时间 */
		Game_ENCHATING_YIFUMO_NOT_REFRESH_CD_TIME = 571, 
		/**[装备附魔]-装备已经附魔了不能随机属性了 */
		Game_ENCHATING_EQUIP_IS_FUMO = 572, 
		/**[装备附魔]-确定装备附魔失败 */
		Game_ENCHATING_IS_FUMO_ERROR = 573, 
		/**[装备附魔]-装备未确定附魔无需刷新附魔cd时间 */
		Game_ENCHATING_NOT_FUMO_NOT_SHUAXIN = 574, 
		/**[宝石槽位]-宝石槽位重置错误 */
		Game_GEM_SLOT_RESERT_ERROR = 575, 
		/**[装备强化]-概率提升超过上限 */
		Game_EQUIP_STRENGTHEN_BEYOND_UP_LIMIT = 576, 
		/**[强化装备]-装备升品消耗道具不足 */
		Game_EQUIP_UP_PROMOTE_CONSUME_ITEM_ERROR = 577, 
		/**[装备附魔]-刷新附魔CD时间的json数据错误 */
		Game_ENCHATING_SHUAXIN_CDTIME_JSON_ERROR = 578, 
		/**[道具合成]-装备强化道具合成错误 */
		Game_STRENGTHEN_ITEM_UP_ERROR = 579, 
		/**[装备附魔]-刷新随机附魔cd时间钻石总数不够 */
		Game_ENCHANTING_DIAMAND_ERROR = 580, 
		/**[装备附魔]-不能附魔还在CD时间内 */
		Game_ENCHATING_CD_TIME_ERROR = 581, 
		/**[穿、替换装备]-角色力量不足 */
		Game_USE_ACTOR_EQUIP_LACK_OF_POWER = 582, 
		/**[装备分解]-删除装备信息失败 */
		Game_EQUIP_DECOMPOSE_ERROR = 583, 
		/**[装备镶嵌宝石]-要镶嵌的宝石信息未找到 */
		Game_EQUIP_INLAY_GEM_ERROR2 = 584, 
		/**[装备镶嵌宝石]-已经有相同的宝石无需在镶嵌 */
		Game_EQUIP_INLAY_GEM_THE_SAME_ERROR = 585, 
		/**[装备附魔]-刷新确定附魔次数和花费json数据错误 */
		Game_ENCHANTING_REFRESH_COUNT_JSON_ERROR = 586, 
		/**[装备附魔]-刷新确定附魔CD时间消耗的钻石不足 */
		Game_ENCHANTING_REFRESH_ENCHAT_DIMAOND_ERROR = 587, 
		/**[邮件系统]-获取邮件没找到 */
		Game_GET_MAIL_NOT_FIND = 588, 
		/**[邮件系统]-邮件状态错误 */
		Game_MAIL_STATUS_ERROR = 589, 
		/**[装备镶嵌宝石]-宝石颜色等级错误 */
		Game_EQUIP_INLAY_GEM_SLOT_LEVEL_COLOR_LESS = 590, 
		/**[邮件系统]-邮件附件已过期 */
		Game_MAIL_APPEND_EXPIRATION = 591, 
		/**[编队]-队伍信息错误 */
		Game_TEAM_INFO_ERROR = 592, 
		/**[邮件系统]-邮件删除错误 */
		Game_MAIL_DELETE_ERROR = 593, 
		/**[邮件系统]-没有可以删除的邮件 */
		Game_MAIL_NOTHING_TO_DELETE = 594, 
		/**[装备技能提取]-装备已经装备了该技能道具 */
		Game_EQUIP_SKILL_SLOT_IS_USED = 595, 
		/**[装备技能提取]-道具信息不存在 */
		Game_NOT_FIND_ITEM_DATA = 596, 
		/**[装备技能提取]-没找到角色信息 */
		Game_EQUIP_SKILL_NOT_FIND_ACTOR = 597, 
		/**[装备技能提取]-在角色身上未找到技能信息 */
		Game_EQUIP_SKILL_ACTOR_NOT_FIND_SKILL = 598, 
		/**[装备技能提取]-未找到技能提取的json数据 */
		Game_EQUIP_SKILL_NOT_FIND_JSON_DATA = 599, 
		/**[装备技能提取]-技能提取消耗道具不足 */
		Game_EQUIP_SKILL_CONSUME_ITEM_ERROR = 600, 
		/**[装备技能提取]-使用道具不是技能封装道具 */
		Game_EQUIP_SKILL_SLOT_USE_ITEM_YTYPE_ERROR = 601, 
		/**[装备技能提取]-安装技能装备类型错误 */
		Game_EQUIP_SKILL_INSTALL_EQUIP_TYPE_ERROR = 602, 
		/**[装备技能提取]-技能JSON数据错误 */
		Game_EQUIP_SKILL_SLOT_SKILL_JSON_ERROR = 603, 
		/**[邮件系统]-邮件JSON信息没找到 */
		Game_MAIL_JSON_NOT_FIND = 604, 
		/**[装备技能提取]-给装备使用技能效果道具-装备没有槽位孔 */
		Game_EQUIP_SKILL_SLOT_NOT_SLOT = 605, 
		/**[跑马灯系统]-添加跑马灯信息异常 */
		Game_MARQUEE_ADD_ERROR = 606, 
		/**[角色转职]-选择职业当前城市未开放 */
		Game_CHANGE_JOB_CITY_NO_OPEN = 607, 
		/**[角色转职]-角色属性值不够 */
		Game_CHANGE_JOB_ACTOR_ATTR_ERROR = 608, 
		/**[角色转职]-消耗道具不足 */
		Game_CHANGE_JOB_ITEM_NOT_ENOUGH = 609, 
		/**[角色转职]-职业没有变化 */
		Game_CHANGE_JOB_NOT_CHANGE = 610, 
		/**[角色转职]-选择职业未解锁 */
		Game_CHANGE_JOB_NOT_OPEN_JOB = 611, 
		/**[购买商店物品]-物品可购买数量不足*/
		Game_BUY_ITEM_LACK_SURPLUS_NUM = 612, 
		/**银币不足*/
		Game_LACK_SILVER = 613, 
		/**声望不足*/
		Game_LACK_PRESTIGE = 614, 
		/**道具不足*/
		Game_LACK_ITEM = 615, 
		/**不能出售装备*/
		Game_CANT_SELL_EQUIP = 616, 
		/**[接取商会任务]-目标任务不存在*/
		Game_PICK_CHAMBER_OF_COMMERCE_TASK_IS_NULL = 617, 
		/**[购买爵位]-目标爵位未解锁*/
		Game_BUY_NOBILITY_IS_UNLOCK = 618, 
		/**[购买爵位]-目标爵位低于角色爵位*/
		Game_BUY_NOBILITY_ACTOR_NOBILITY_IS_HIGH = 619, 
		/**[购买爵位]-目标城市该爵位还在购买CD*/
		Game_BUY_NOBILITY_IN_COLD_TIME = 620, 
		/**[购买商店物品]-城镇错误*/
		Game_BUY_ITEM_LACK_CUR_MAP_POINT_ERR = 621, 
		/**[城堡升级]-已经达到最大等级*/
		Game_UP_CASTLE_LV_LV_IS_MAX = 622, 
		/**[城堡升级]-声望等级不足*/
		Game_UP_CASTLE_LV_LACK_PRESTIGE_LEVEL = 623, 
		/**[城堡建造新建筑]-建筑数量达到上限*/
		Game_BUILD_ARCHITECTURE_MAX_NUM_LIMIT = 624, 
		/**[城堡建筑]-不存在目标建筑*/
		Game_GAIN_ARCHITECTURE_TARGET_IS_NULL = 625, 
		/**[城堡建筑资源领取]-已经领取资源*/
		Game_GAIN_ARCHITECTURE_PRODUCE_IS_GAINED = 626, 
		/**[创建账号]-创建默认地图和默认开启点错误 */
		Game_CREATE_MAP_AND_POINTS_ERROR = 627, 
		/**[创建大地图]-重复创建大地图*/
		Game_CREATE_MAP_ERROR = 628, 
		/**[大地图]-城市点未开放 */
		Game_MAP_POINT_ID_NOT_OPEN = 629, 
		/**[相亲]-角色不符合相亲要求*/
		Game_MATCH_ACTOR_UNQUALIFIED = 630, 
		/**[城堡联姻]-声望等级不符合联姻要求*/
		Game_CASTLE_ALLIANCE_PRESTIGE_LV_UNQUALIFIED = 631, 
		/**[城堡联姻]-未随机联姻对象*/
		Game_CASTLE_ALLIANCE_RANDOM_TARGET_IS_NULL = 632, 
		/**[技能替换]-技能已经被装备*/
		Game_USE_SKILL_IS_USE = 633, 
		/**[技能替换]-技能槽不能使用*/
		Game_USE_SKILL_SLOT_IS_CAN_NOT_USE = 634, 
		/**[技能替换]-当前职业不符合技能使用要求*/
		Game_USE_SKILL_JOB_IS_CAN_NOT_USE = 635, 
		/**[添加道具] 道具JSON数据错误 */
		Game_BAG_ITEM_JSON_DATA_ERROR = 636, 
		/**[使用道具] 道具JSON数据错误 */
		Game_USE_ITEM_TYPE_ERROR = 637, 
		/**装备不存在*/
		Game_EQUIPMENT_IS_NULL = 638, 
		/**[装备分解]-选择装备不可分解 */
		Game_EQUIP_NOT_CAN_DECOMPOSE = 639, 
		/**[任务]-创建任务数据失败 */
		Game_CREATE_TASK_DATA_ERROR = 640, 
		/**[任务]-获取任务JSON数据错误 */
		Game_GET_TASK_DATA_JSON_ERROR = 641, 
		/**[任务]-该种类型的任务已接取 */
		Game_TASK_IS_ACCEPT = 642, 
		/**[任务]-任务未接取不能提交任务 */
		Game_TASK_NOT_ACCEPTE_NOT_SUBMIT = 643, 
		/**[任务]-任务未完成不能提交 */
		Game_TASK_NOT_COMPLETE_NOT_SUBMIT = 644, 
		/** [角色解雇]-固定角色不可解雇*/
		Game_FIRED_ACTOR_IS_FIXED_ACTOR = 645, 
		/**[城堡宴会表白]-表白目标不存在*/
		Game_CASTLE_FEAST_RUN_CONFESSION_TARGET_IS_NULL = 646, 
		/**[城堡宴会开启]-还在宴会冷却时间*/
		Game_CASTLE_FEAST_RUN_IS_IN_COLD_TIME = 647, 
		/**[城堡宴会开启]-宴会所需道具补足*/
		Game_CASTLE_FEAST_RUN_LACK_ITEM = 648, 
		/**[城堡学校任命教师]-已经被任命*/
		Game_CASTLE_SCHOOL_APPOINT_INSTRUCTOR_ALREADY_IS_INSTRUCTOR = 649, 
		/**[城堡训练指定教学教师]-教师不存在*/
		Game_CASTLE_TRAIN_ASSIGN_INSTRUCTOR_TARGET_IS_NULL = 650, 
		/**角色不存在*/
		Game_ACTOR_IS_NULL = 651, 
		/**[城堡训练进行重点培养]-角色已经是重点培养*/
		Game_CASTLE_SCHOOL_ADD_EMPHASIS_STUDENT_IS_EMPHASIS = 652, 
		/**[城堡训练进行历练]-该教师队正进行历练*/
		Game_CASTLE_TRAIN_RUN_PRACTICE_INSTRUCTOR_ALREADY_RUN = 653, 
		/**[城堡训练技能传授]-该技能不能传授*/
		Game_CASTLE_TRAIN_IMPART_SKILL_NOT_IMPART = 654, 
		/**角色在战斗队伍中*/
		Game_ACTOR_AWAIT_POSITION_BATTLE_TEAM = 655, 
		/**角色在城堡历练担任教师*/
		Game_ACTOR_AWAIT_POSITION_CASTLE_PRACTICE_INSTRUCTOR = 656, 
		/**角色在城堡历练学习*/
		Game_ACTOR_AWAIT_POSITION_CASTLE_PRACTICE_STUDENT = 657, 
		/**角色在城堡建筑担任守卫*/
		Game_ACTOR_AWAIT_POSITION_CASTLE_ARCHITECTURE_GUARD = 658, 
		/**[城堡建筑任命守卫]-已经存在建筑守卫*/
		Game_CASTLE_ARCHITECTURE_APPOINT_GUARD_IS_HAS_GUARD = 659, 
		/**[任务]-获取城市点任务列表失败 */
		Game_TASK_GET_POINT_FUNCTIONtYPE_TASKINFO_ERROR = 660, 
		/**[任务]-不能重复创建账号主线任务数据 */
		Game_TASK_CREATE_MAINTASK_ERROR = 661, 
		/**[城堡建筑建造]-该建筑槽已存在建筑*/
		Game_CASTLE_ARCHITECTURE_SLOT_IS_HAS_ARCHITECTURE = 662, 
		/**[任务]-此任务不属于该城市点*/
		Game_TASK_ACCEPT_TASK_NOT_IN_POINTS = 663, 
		/**[城堡建筑额外槽位开启]-全部槽位都已经开启*/
		Game_CASTLE_ARCHITECTURE_OPEN_EXTRA_SLOT_IS_OPEN_ALL = 664, 
		/**[城堡建筑建造]-该建筑槽未开启*/
		Game_CASTLE_ARCHITECTURE_SLOT_NOT_IS_OPEN = 665, 
		/**[任务]-未达到条件不能完成任务 */
		Game_TASK_CONDITION_ERROR_NOT_COMPLETE = 666, 
		/**[酒馆招募]-酒馆银币刷新次数不足*/
		Game_TAVERN_REFRESH_COUNT_ERROR = 667, 
		/**[酒馆招募]-当前城市点获取错误*/
		Game_TAVERN_MAP_POINT_ERROR = 668, 
		/**[酒馆招募]-酒馆配置信息获取错误*/
		Game_TAVERN_TAVERN_CFG_ERROR = 669, 
		/**[城堡历练]-该历练槽未开启*/
		Game_CASTLE_TRAIN_PRACTICE_SLOT_NOT_IS_OPEN = 670, 
		/**[城堡历练]-正在进行历练*/
		Game_CASTLE_TRAIN_PRACTICE_IS_RUN = 671, 
		/**[任务]-该城市没有接过任务 */
		Game_TASK_THE_CITY_NOT_FIND_TASK_INFO = 672, 
		/**[城堡历练]-没有导师*/
		Game_CASTLE_TRAIN_PRACTICE_NO_TEACHER = 673, 
		/**[城堡历练]-所有槽位都已经开启*/
		Game_CASTLE_TRAIN_PRACTICE_OPEN_EXTRA_SLOT_IS_OPEN_ALL = 674, 
		/**[经验池]-添加经验超出经验池上限 */
		Game_EXP_POND_ADD_EXP_BEYOND_LIMIT = 675, 
		/**[城堡历练]-历练随机事件结果已经确定*/
		Game_CASTLE_TRAIN_PRACTICE_RANDOM_EVENT_RESULT_IS_COMFIRM = 676, 
		/**[城堡历练]-没有随机相亲对象或相亲结果已经选择*/
		Game_CASTLE_TRAIN_PRACTICE_RANDOM_MARRIAGE_OPTION_IS_SELECT = 677, 
		/** 方法参数值错误 */
		Game_FUNCTION_PARAM_VALUE_ERROR = 678, 
		/**[任务]-不存在该唯一ID对应的任务信息*/
		Game_TASK_NOT_FIND_TASK_BY_TASKGID = 679, 
		/**道具配置获取错误 */
		Game_GET_ITEM_JSON_ERROR = 680, 
		/**角色在城堡训练学习*/
		Game_ACTOR_AWAIT_POSITION_CASTLE_SCHOOL_STUDENT = 681, 
		/**角色在城堡建筑担任守卫*/
		Game_ACTOR_AWAIT_POSITION_CASTLE_SCHOOL_INSTRUCTOR = 682, 
		/**角色当前已经被安排待命位置*/
		Game_ACTOR_AWAIT_POSITION_ERR = 683, 
		/**友好度不足 */
		Game_FRIENDLY_NOT_ENOUGH = 684, 
		/**捐授爵位不高于当前爵位 */
		Game_HALLHONOR_CHANGE_NOBILITY_ERROR = 685, 
		/**未开启该势力*/
		Game_NOT_OPEN_PRASTIGE = 686, 
		/**[酒馆招募]-英雄配置信息获取错误*/
		Game_TAVERN_HEROS_CFG_ERROR = 687, 
		/**[城堡学校传授]-该教师等级不足*/
		Game_CASTLE_SCHOOL_IMPART_SKILL_INSTRUCTOR_LEVEL_DEFICIENCY = 688, 
		/**[城堡学校传授]-该技能不可传授*/
		Game_CASTLE_SCHOOL_IMPART_SKILL_SKILL_CAN_NOT_LEARN = 689, 
		/**[城堡学校传授]-该教师不存在该技能*/
		Game_CASTLE_SCHOOL_IMPART_SKILL_INSTRUCTOR_NOT_HAVE_SKILL = 690, 
		/**[城堡学校传授]-该学生不满足学习技能所需的属性*/
		Game_CASTLE_SCHOOL_IMPART_SKILL_STUDENT_LACK_ATTR = 691, 
		/**[城堡学校传授]-该学生已经学习该技能*/
		Game_CASTLE_SCHOOL_IMPART_SKILL_STUDENT_HAVE_SKILL = 692, 
		/**[城堡学校传授]-该教师职业无法进行技能传授*/
		Game_CASTLE_SCHOOL_IMPART_SKILL_INSTRUCTOR_JOB_ERR = 693, 
		/**[大地图]-切换城市点失败 */
		Game_MAP_CHANGE_MAP_POINT_ERROR = 694, 
		/**[节日系统]-节日配置信息获取错误*/
		Game_FESTIVAL_CFG_ERROR = 695, 
		/**[节日系统]-参加节日不存在*/
		Game_JOIN_FESTIVAL_ERROR = 696, 
		/**[节日系统]-其他节日正在进行中*/
		Game_OTHER_FESTIVAL_IS_ONGOING = 697, 
		/**[节日系统]-节日兑换配置信息获取错误*/
		Game_FESTIVAL_EXCHANGE_CFG_ERROR = 698, 
		/**[节日系统]-节日兑换次数不足*/
		Game_FESTIVAL_EXCHANGE_COUNT_ERROR = 699, 
		/**[节日系统]-参加节日已状态错误*/
		Game_JOIN_FESTIVAL_STRTUS_ERROR = 700, 
		/**[节日系统]-当前节日未解锁*/
		Game_FESTIVAL_IS_LOCK = 701, 
		/**[城堡学校任命教师]-教师年龄未满足条件*/
		Game_CASTLE_SCHOOL_APPOINT_INSTRUCTOR_AGE_DEFICIENCY = 702, 
		/**[城堡学校任命教师]-教师槽位不足*/
		Game_CASTLE_SCHOOL_APPOINT_INSTRUCTOR_LACK_INSTRUCTOR_SLOT = 703, 
		/**[城堡学校重点培养]-重点培养槽位不足*/
		Game_CASTLE_SCHOOL_ADD_EMPHASIS_STUDENT_LACK_EMPHASIS_SLOT = 704, 
		/**[城堡学校重点培养]-学生年龄未满足条件*/
		Game_CASTLE_SCHOOL_ADD_EMPHASIS_STUDENT_AGE_DEFICIENCY = 705, 
		/**[城堡历练任命教师]-该教师等级不足*/
		Game_CASTLE_TRAIN_PRACTICE_APPOINT_PRACTICE_INSTRUCTOR_LEVEL_DEFICIENCY = 706, 
		/**[节日系统]-角斗日配置信息获取错误*/
		Game_FESTIVAL_WRESTLE_CFG_ERROR = 707, 
		/**[节日系统]-节日选项配置信息获取错误*/
		Game_FESTIVAL_OPTION_CFG_ERROR = 708, 
		/**[节日系统]-节日祈祷次数不足*/
		Game_FESTIVAL_PARYER_COUNT_NULL = 709, 
		/**[节日系统]-节日选项不是当前节日*/
		Game_FESTIVAL_OPTION_NOT_CURRENT_FESTIVAL = 710, 
		/**[节日系统]-节日选项效果错误*/
		Game_FESTIVAL_OPTION_EFFECT_ERROR = 711, 
		/**特性配置信息获取错误*/
		Game_SPECIALITY_CFG_ERROR = 712, 
		/**[节日系统]-节日效果人数超出上限*/
		Game_FESTIVAL_EFFECT_ACTOR_COUNT_BEYOND_LIMIT = 713, 
		/**[节日系统]-角色已经成年*/
		Game_ACTOR_IS_ADULT = 714, 
		/**[节日系统]-角色是未成年*/
		Game_ACTOR_IS_NONAGE = 715, 
		/**[节日系统]-祈祷角色职业不符*/
		Game_FESTIVAL_ACTOR_JOB_TYPE_ERROR = 716, 
		/**[节日系统]-祈祷角色重复祈祷*/
		Game_FESTIVAL_ACTOR_REPEAT_PRAYER = 717, 
		/**角色爵位等级不足*/
		Game_ACTOR_NOBILITY_LEVEL_DEFICIENCY = 718, 
		/**[城堡联姻]-联姻随机相亲对象次数不足*/
		Game_CASTLE_ALLIANCE_RANDOM_TARGET_NUM_DEFICIENCY = 719, 
		/**[城堡联姻]-联姻随机相亲对象描述词条已经达到获取上限*/
		Game_CASTLE_ALLIANCE_RANDOM_INTRO_MAX_LIMIT = 720, 
		/**[城堡历练设置学员]-学员年纪不足*/
		Game_CASTLE_TRAIN_PRACTICE_APPOINT_PRACTICE_STUDENT_AGE_DEFICIENCY = 721, 
		/**[城堡历练设置学员]-教师等级不足*/
		Game_CASTLE_TRAIN_PRACTICE_APPOINT_PRACTICE_STUDENT_INSTRUCTOR_LEVEL_DEFICIENCY = 722, 
		/**角色年龄不足*/
		Game_ACTOR_AGE_DEFICIENCY = 723, 
		/**[节日系统]-祈祷全局特性重复祈祷*/
		Game_FESTIVAL_PLAYER_REPEAT_PRAYER = 724, 
		/**[城堡宴会]-玩家未满足地区友好度要求*/
		Game_CASTLE_FEAST_RUN_AREA_PRESTIGE_LV_DEFICIENCY = 725, 
		/**[城堡宴会]-玩家未回答问题*/
		Game_CASTLE_FEAST_USE_GOODS_RETRIEVE_RESULT_IS_UNDEFINED = 726, 
		/**[城堡宴会]-玩家使用的物资与选择物资组不匹配*/
		Game_CASTLE_FEAST_USE_GOODS_RETRIEVE_GOODSLIST_MISMATCH = 727, 
		/**[城堡建筑设置守卫]-育鹰厅无法设置守卫*/
		Game_CASTLE_APPOINT_ARCHITECTURE_GUARD_YUYING_NOT_SET_GUARD = 728, 
		/**[节日系统]-祈祷角色增加寿命重复 */
		Game_FESTIVAL_PRAYER_ACTOR_ADD_LIFE_REPEAT = 729, 
		/**[节日系统]-祈祷角色未入队 */
		Game_FESTIVAL_PRARYER_ACTOR_STATUS_ERROR = 730, 
		/**[节日系统]-香桃节没有相亲对象 */
		Game_PEACH_FESTIVAL_NOT_FIND_TARGET = 731, 
		/**[节日系统]-香桃节相亲者不是未婚 */
		Game_ACTOR_MARRIED_STATE_ERROR = 732, 
		/**[婚宴]-未找到对应婚宴信息*/
		Game_WEDDING_WAIT_INFO_IS_NULL = 733, 
		/**[婚宴]-角色已经担任过伴郎伴娘*/
		Game_WEDDING_ATTENDANT_IS_USED = 734, 
		/**[婚宴]-伴郎伴娘性别错误*/
		Game_WEDDING_ATTENDANT_SEX_ERR = 735, 
		/**[婚宴]-捧花人员数量错误*/
		Game_WEDDING_BOUQUEST_NUM_ERR = 736, 
		/**[婚宴]-花童人员数量错误*/
		Game_WEDDING_STUDENT_NUM_ERR = 737, 
		/**[婚宴]-花童人员年龄错误*/
		Game_WEDDING_STUDENT_AGE_ERR = 738, 
		/**[婚宴]-婚宴等级不符合结婚对象爵位*/
		Game_WEDDING_LEVEL_INCONFORMITY_NOBILITY = 739, 
		/**[道具使用]-使用次数不足 */
		Game_ITEM_USE_COUNT_ERROR = 740, 
		/**[道具使用]-任务不可扫荡 */
		Game_USE_ITEM_TASK_NOT_SWEEPING = 741, 
		/**[军团功能]-军团信息重复创建 */
		Game_REPEAT_CREATE_CORPS_ERROR = 742, 
		/**[军团功能]-军团名违规 */
		Game_CORPS_NAME_RULES_ERROR = 743, 
		/**[军团功能]-军团旗帜配置错误 */
		Game_CORPS_FLAG_CFG_ERROR = 744, 
		/**[军团功能]-没有找到军团信息 */
		Game_CORPS_INFO_NOT_FIND = 745, 
		/**[军团功能]-军团名重复 */
		Game_CORPS_NAME_REPEAT_ERROR = 746, 
		/**[军团功能]-军团旗帜没有变化 */
		Game_CORPS_FLAGE_NO_CHANGE = 747, 
		/**[军团功能]-军团职位槽未找到 */
		Game_CORPS_POSITION_SLOT_NOT_FIND = 748, 
		/**[军团功能]-军团职位槽位配置错误 */
		Game_CORPS_POSITION_CFG_ERROR = 749, 
		/**[军团功能]--军团职位槽位没有任职角色 */
		Game_CORPS_POSITION_SLOT_NO_ACTOR = 750, 
		/**[军团功能]--军团职位槽位任职角色没变 */
		Game_CORPS_POSITION_SLOT_ACTOR_NO_CHANGE = 751, 
		/**[军团功能]--军团职位任职角色已经有职位 */
		Game_CORPS_POSITION_ACTOR_IS_POSITION = 752, 
		/**[军团功能]--军团职位槽位未解锁 */
		Game_CORPS_POSITION_SLOT_IS_LOCK = 753, 
		/** [角色解雇]-选中角色不可操作 */
		Game_CHOOSE_ACTOR_NOT_OPERABLE = 754, 
		/**[成就目标奖励]-领取奖励失败 */
		Game_ATTAINMENT_GET_REWARD_ERROR = 755, 
		/**[军团功能]--打造装备已经存在军团圣物属性 */
		Game_CORPS_SACRED_IS_EXIST = 756, 
		/**[军团功能]--圣物效果获取错误 */
		Game_CORPS_SACRED_GET_EFFECT_ERROR = 757, 
		/**[军团功能]--打造装备类型错误 */
		Game_CORPS_SACRED_EQUIPTYPE_ERROR = 758, 
		/**[军团功能]--其他圣物正在打造或突破 */
		Game_CORPS_SACRED_OTHER_EQUIP_IS_MAKE = 759, 
		/**[军团功能]--打造圣物选择效果错误 */
		Game_CORPS_SACRED_CHOOSE_EFFECT_ERROR = 760, 
		/**[城堡学校重点培养]-重点培养槽位已经被使用*/
		Game_CASTLE_SCHOOL_ADD_EMPHASIS_STUDENT_EMPHASIS_SLOT_IS_USE = 761, 
		/**[城堡学校任命教师]-教师槽位已经被使用*/
		Game_CASTLE_SCHOOL_APPOINT_INSTRUCTOR_INSTRUCTOR_SLOT_IS_USE = 762, 
		/**[军团功能]--穿戴圣物已绑定其他角色 */
		Game_USE_SACRED_EQUIP_BINDING_OTHER_ENTITY = 763, 
		/**[军团功能]--当前职位不可穿戴圣物 */
		Game_USE_SACRED_EQUIP_CORPS_POSITION_ERROR = 764, 
		/**[军团功能]--圣物没有进行绑定 */
		Game_CORPS_SACRED_EQUIP_NO_BINDING = 765, 
		/**[军团功能]--圣物没有开始打造 */
		Game_CORPS_SACRED_EQUIP_NO_START_MAKE = 766, 
		/**[军团功能]--圣物不满足突破条件 */
		Game_CORPS_SACRED_AWAIT_BREAK_ERROR = 767, 
		/**[军团技能]--选择技能没找到 */
		Game_CORPS_SKILL_CHOOSE_IS_NOT_FIND = 768, 
		/**[军团技能]--选择技能等级达到上限 */
		Game_CORPS_SKILL_CHOOSE_LEVEL_IS_MAX = 769, 
		/**[军团技能]--选择技能状态错误 */
		Game_CORPS_SKILL_CHOOSE_STATUS_ERROE = 770, 
		/**[治疗伤病]--角色不存在该伤病*/
		Game_CURE_INJURY_ACTOR_NOT_HAVE_INJURY = 771, 
		/**[对话奖励]--对话json数据错误 */
		Game_GET_DIALOG_REWARD_JSON_ERROR = 772, 
		/**[对话奖励]--对话json中配置的奖励值错误 */
		Game_GET_DIALOG_REWARD_JSON_OPTION_ERROR = 773, 
		/**[对话奖励]--获取奖励组json错误 */
		Game_GET_DIALOG_REWARD_GET_REWARDGROUP_JSON_ERROR = 774, 
		/**[军团需求]--角色没有提出需求 */
		Game_CORPS_ACTOR_NO_HAVE_DEMAND = 775, 
		/**[治疗全员伤病]该道具无法治疗伤病*/
		Game_All_ACTOR_CURE_INJURY_CURE_ITEM_ERR = 776, 
		/**[测试命令]--测试方法没找到 */
		Game_TEST_COMMAND_FUNCTION_NOT_FIND = 777, 
		/**[测试命令]--测试功能未开启 */
		Game_TEST_COMMAND_NOT_OPTEN_TEST = 778, 
		/**[自定义标签]--不满足设置条件 */
		Game_ACOTR_CUSTOM_TAG_DISSATISFY_CONDITION = 779, 
		/**[自定义标签]--标签格式错误 */
		Game_ACOTR_CUSTOM_TAG_FOEMAT_ERROR = 780, 
		/**[角色征兵]--征兵功能未解锁 */
		Game_ACOTR_CONSCTRIPTION_IS_LOCK = 781, 
		/**[角色征兵]--选择角色错误 角色位置或状态不可参加征兵 */
		Game_ACOTR_CONSCTRIPTION_ACTOR_ERROR = 782, 
		/**[角色征兵]--所选国家的友好度不足 */
		Game_ACOTR_CONSCTRIPTION_COUNTRY_FRIEND_ERROR = 783, 
		/**[角色征兵]--所选角色没有当前国家规定血脉 */
		Game_ACOTR_CONSCTRIPTION_ACTOR_BLOOD_ERROR = 784, 
		/**[城堡委托派遣]-城堡未开启委托派遣 */
		Game_CASTLE_NOT_OPEN_WEITUO_PAIQIAN = 785, 
		/**[城堡委托派遣]-上阵角色数量不正确 */
		Game_CASTLE_PAIQIAN_ACTOR_COMPLETE_ACTOR_NUM_ERROR = 786, 
		/**[城堡委托派遣]-未找到委托任务信息 */
		Game_CASTLE_NOT_FIND_WEITUO_TASK = 787, 
		/**[城堡委托派遣]-派遣执行任务的角色中有未找到角色信息 */
		Game_CASTLE_WEI_TUO_NOT_FIND_ACTORINFO = 788, 
		/**[城堡委托派遣]-该委托任务已经派角色执行了 */
		Game_CASTLE_WEITUO_THE_TASK_IS_PAIQIAN_ACTOR = 789, 
		/**[城堡委托派遣]-刷新委托任务列表次数上限 */
		Game_CASTLE_WEITUO_REFRESH_TASKLIST_COUNT_ERROR = 790, 
		/**[城堡委托派遣]-接任务次数到达上限 */
		Game_CASTLE_WEITUO_ACCEPT_COUNT_ERROR = 791, 
		/**[城堡委托派遣]-未找到vip的cfg数据 */
		Game_CASTLE_WEITUO_BUY_COUNT_NOT_FIND_VIP_JSON = 792, 
		/**[城堡委托派遣]-购买次数达到上限 */
		Game_CASTLE_WEITUO_BUY_COUNT_BUZU_ERROR = 793, 
		/**[城堡委托派遣]-钻石不足 */
		Game_CASTLE_WEITUO_BUY_COUNT_ZUANSHI_BUZU = 794, 
		/**[城堡委托派遣]-任务未完成不能领取奖励 */
		Game_CASTLE_WEITUO_TASK_NOT_COMPLETE_REWARD_ERROR = 795, 
		/**[城堡委托派遣]-未找到委托任务json数据 */
		Game_CASTLE_WEITUO_NOT_FIND_ENTRUST_JSON = 796, 
		/**[城堡委托派遣]-获取委托任务的基础奖励数据错误 */
		Game_CASTLE_WEITUO_GET_ENTRUST_TASK_BASE_REWARD_ERROR = 797, 
		/**[编队上阵]-角色不可使用 */
		Game_TEAM_ENTER_UNAVAILABLE_ACTOR = 798, 
		/**[城堡委托派遣]-队长不符合条件 */
		Game_CASTLE_WEITUO_PAIQIAN_CAPTOR_IS_ERROR = 799, 
		/**角色在进行城堡委托*/
		Game_ACTOR_AWAIT_POSITION_CASTLE_ENTRUST_WEITUO = 800, 
		/**[任务]-该任务不能放弃 */
		Game_CASTLE_SUIJI_TASK_NOT_GIVE_UP = 801, 
		/**[任务]-主线-上一个任务未完成不能接新任务 */
		Game_MAIN_TASK_LAST_TASK_NOT_COMPLETE = 802, 
		/**[任务]-主线-未找到下一个主线任务ID */
		Game_MAIN_TASK_NOT_FIND_NEXT_TASK_ID = 803, 
		/**管理员开启活动榜单配置错误*/
		GmAdmin_OPEN_ACTIVE_RANK_CFG_ERROR = 804, 
		/**管理员开启活动榜单时间设置错误*/
		GmAdmin_OPEN_ACTIVE_RANK_TIME_ERROR = 805, 
		/**玩家VIP等级不足*/
		Game_PLAYER_LACK_VIP_LEVEL = 806, 
		/**玩家竞技场挑战次数不足*/
		Game_PLAYER_LACK_ARENA_BATTLE_NUM = 807, 
		/**[排行榜-获取榜单角色详情-榜单id错误]*/
		Game_GET_RANK_ACTOR_INFO_RANKID_ERROR = 808, 
		/**[排行榜-获取榜单角色详情-角色id错误]*/
		Game_GET_RANK_ACTOR_INFO_ENTITYGID_ERROR = 809, 
		/**[每日签到]-功能未开启*/
		Game_SIGN_DAILY_NOT_OPEN = 810, 
		/**[每日签到]-签到次数不足*/
		Game_SIGN_DAILY_SIGN_COUNT_ERROR = 811, 
		/**[每日签到]-没有可以领取的连续签到奖励*/
		Game_SIGN_DAILY_CONTINUOUS_REWARD_ERROR = 812, 
		/**玩家剩余竞技场挑战购买次数不足*/
		Game_PLAYER_LACK_BUY_ARENA_BATTLE_NUM = 813, 
		/**[GM兑换码]-兑换码设置奖励组配置错误 */
		GmAdmin_EXCHANGE_CODE_REWARDGROUP_JSON_ERROR = 814, 
		/**[GM兑换码]-兑换码名称错误 */
		GmAdmin_EXCHANGE_CODE_NAME_ERROR = 815, 
		/**[GM兑换码]-兑换码起止时间错误 */
		GmAdmin_EXCHANGE_CODE_TIME_ERROR = 816, 
		/**[GM兑换码]-单日生成次数超出限制 */
		GmAdmin_EXCHANGE_CODE_TODAY_COUNT_ERROR = 817, 
		/**[GM兑换码]-单日单次生成数量超出限制 */
		GmAdmin_EXCHANGE_CODE_SINGLE_COUNT_ERROR = 818, 
		/**[GM兑换码]-通用兑换码GID错误 */
		GmAdmin_EXCHANGE_CODE_GENERAL_GID_ERROR = 819, 
		/**[GM兑换码]-通用兑换码GID重复 */
		GmAdmin_EXCHANGE_CODE_GENERAL_GID_REPEAT = 820, 
		/**[系统设置]-使用兑换码兑换信息不存在 */
		Game_EXCHANGE_CODE_EXCHANGEL_INFO_IS_NULL = 821, 
		/**[系统设置]-使用兑换码未开始 */
		Game_EXCHANGE_CODE_NOT_START = 822, 
		/**[系统设置]-使用兑换码已结束 */
		Game_EXCHANGE_CODE_IS_OVER = 823, 
		/**[系统设置]-使用兑换码重复 */
		Game_EXCHANGE_CODE_REPEAT_USE = 824, 
		/**[组队副本]参与次数不足*/
		Game_TEAM_BATTLE_LACK_TEAM_BATTLE_ENTER_NUM = 825, 
		/**[组队副本]不存在目标副本组*/
		Game_TEAM_BATTLE_TARGET_GROUP_IS_NULL = 826, 
		/**[组队副本]可购买挑战次数不足*/
		Game_PLAYER_LACK_BUY_TEAM_BATTLE_CHALLENGE_NUM = 827, 
		/**[组队副本]挑战次数不足*/
		Game_TEAM_BATTLE_LACK_TEAM_BATTLE_CHALLENGE_NUM = 828, 
		/**[组队副本]副本已通关*/
		Game_TEAM_BATTLE_IS_WIN = 829, 
		/**[组队副本]目标副本组无可用位置*/
		Game_TEAM_BATTLE_TARGET_GROUP_LACK_POSITION = 830, 
		/**[爬塔功能]-功能没解锁 */
		Game_CLIMB_TOWER_FUNCTION_NOT_UNLOCK = 831, 
		/**[爬塔功能]-塔未开启 */
		Game_CLIMB_TOWER_TOWER_NOT_OPEN = 832, 
		/**[爬塔功能]-没有进入塔内 */
		Game_CLIMB_TOWER_OUTSIDE_THE_TOWER = 833, 
		/**[爬塔功能]-答题塔类型错误 */
		Game_CLIMB_TOWER_ANSWER_TOWER_TYPE_ERROR = 834, 
		/**[爬塔功能]-选择答案不存在 */
		Game_CLIMB_TOWER_CHOOSE_ANSWER_NOT_HAVE = 835, 
		/**[爬塔功能]-答案配置不存在 */
		Game_CLIMB_TOWER_ANSWER_CFG_NOT_HAVE = 836, 
		/**[爬塔功能]-答题状态错误 */
		Game_CLIMB_TOWER_ANSWER_STATUS_ERROR = 837, 
		/**[爬塔功能]-商店商品不存在 */
		Game_CLIMB_TOWER_SHOP_GOODS_NOT_HAVE = 838, 
		/**[爬塔功能]-挑战配置不存在 */
		Game_CLIMB_TOWER_CHALLENGE_CFG_ERROR = 839, 
		/**[爬塔功能]-挑战到最高层 */
		Game_CLIMB_TOWER_CHALLENGE_LEVEL_MAX = 840, 
		/**[爬塔功能]-挑战次数不足 */
		Game_CLIMB_TOWER_CHALLENGE_COUNT_ERROR = 841, 
		/**[爬塔功能]-功能未开启 */
		Game_CLIMB_TOWER_FUNCTION_NOT_OPEN = 842, 
		/**[每日任务]-功能未开启 */
		Game_TASK_DAILY_FUNCTION_NOT_OPEN = 843, 
		/**[每日任务]-任务配置不存在 */
		Game_TASK_DAILY_TASK_CFG_ERROR = 844, 
		/**[每日任务]-领取任务状态错误 */
		Game_TASK_DAILY_TASK_STATUS_ERROR = 845, 
		/**[每日任务]-活跃奖励配置不存在 */
		Game_TASK_DAILY_ACTIVE_DAILY_CFG_ERROR = 846, 
		/**[每日任务]-领取奖励状态错误 */
		Game_TASK_DAILY_REWARD_STATUS_ERROR = 847, 
		/**[每日任务]-周活跃值不足 */
		Game_TASK_DAILY_WEEK_ACTIVE_COUNT_ERROR = 848, 
		/**[技能替换]-技能槽不能使用*/
		Game_USE_SKILL_ACTOR_LACK_TARGET_SKILL = 849, 
		/**[主线任务]-获取战斗路点信息失败 */
		Game_TASK_MAIN_GET_MAP_POINT_INFO_ERROR = 850, 
		/**[主线任务]-Allcontrol表中未配置默认主线任务ID */
		Game_ALLCONTROL_XML_NOT_FIND_DEFAULT_MAIN_TASKID = 851, 
		/**[主线任务]-创建默认主线任务数据失败 */
		Game_CREATE_DEFAULT_TASK_MAIN_DATA_ERROR = 852, 
		/**[主线任务]-根据任务唯一ID从缓存未找到数据 */
		Game_GET_DEFAULT_MAIN_TASK_BY_HASH_ERROR = 853, 
		/**[主线任务]-同一个主线任务不能多次接取 */
		Game_TASK_MAIN_SAME_NOT_ACCEPT = 854, 
		/**[主线任务]-当前主线任务的步骤还未结束不能接下一任务 */
		Game_TASK_MAIN_STORY_INDEX_IS_NOT_LAST = 855, 
		/**[图书馆图鉴]未找到激活的单个图鉴信息 */
		Game_ATLAS_NOT_FIND_ATLASINFO = 856, 
		/**[图书馆图鉴]未找到一级类型二级类型下阶段奖励数据 */
		Game_ATLAS_STAGE_NOT_FIND_STAGE_INFO = 857, 
		/**[图书馆图鉴]奖励已经领取过了 */
		Game_ATLAS_ISGET_ONE_REWARD = 858, 
		/**[图书馆事件]创建事件数据失败 */
		Game_LIBRARY_EVENT_CREATE_DATA_ERROR = 859, 
		/**[技能学习] 刷新角色待学技能列表没有可用等级 */
		Game_ACTOR_REFRESH_SKILL_CHOOSE_DISABLED_LV = 860, 
		/**[技能学习] 学习角色待学技能列表为空 */
		Game_ACTOR_SKILL_CHOOSE_LIST_IS_EMPTY = 861, 
		/**[技能学习] 学习角色待学技能目标技能序错误 */
		Game_ACTOR_SKILL_CHOOSE_LIST_CONFIRM_INDEX_ERR = 862, 
		/** 获取战斗服连接信息错误 */
		Battle_GET_BATTLE_CONNECT_INFO_ERROR = 1000, 
		/** 获取关卡JSON数据错误 */
		Battle_GET_LEVEL_JSON_DATA_LEVEL = 1001, 
		/** 账号未登录未创建关卡对象 */
		Battle_ACCOUNT_NOT_CREATE_LEVEL_OBJ = 1002, 
		/** 进入关卡失败,获取关卡唯一ID错误 */
		Battle_GET_LEVEL_WEIYI_ID_ERROR = 1003, 
		/** 获取关卡房间对象错误 */
		Battle_GET_LEVEL_ROOM_OBJ_ERROR = 1004, 
		/** player主卡片ID错误 */
		Battle_PLAYER_MAIN_ACTOR_GID_ERROR = 1005, 
		/** 获取Actor数据错误 */
		Battle_ACTOR_DATA_GET_NULL_ERROR = 1006, 
		/** 获取技能json数据失败 */
		Battle_SKILL_GET_JOSN_DATA_ERROR = 1007, 
		/** 退出关卡,连接已断开 */
		Battle_OUT_LEVEL_DISCONNECTR = 1008, 
		/**创建战斗对象失败 */
		Battle_CREATE_BATTLE_OBJECT_ERROR = 1009, 
		/**删除战斗对象失败 */
		Battle_DELETE_BATTLE_OBJECT_ERROR = 1010, 
		/**[战前调整两个队员位置]-从缓存获取战斗对象失败 */
		Battle_BATTLE_PREPARE_GET_BATTLE_CACHE_DATA_ERROR = 1011, 
		/**[战前调整两个队员位置]-战斗对象中的关卡对象为空 */
		Battle_BATTLE_PREPARE_GET_LEVELOBJ_ERROR = 1012, 
		/**[战前调整两个队员位置]-战斗对象中的队伍对象为空 */
		Battle_BATTLE_PREPARE_GET_TEAMS_ERROR = 1013, 
		/**[战前调整两个队员位置]-战斗对象中没有自己队伍信息 */
		Battle_BATTLE_PREPARE_GET_SELF_TEAMS_ERROR = 1014, 
		/**[战前调整两个队员位置]-换位置的队员不在战斗中 */
		Battle_BATTLE_PREPARE_ACTORS_NOT_IN_BATTLE = 1015, 
		/**[战前调整两个队员位置]-关卡对象中格子对象数据错误 */
		Battle_BATTLE_PREPARE_TILES_NOT_IN_BATTLE = 1016, 
		/**[战前调整队员位置]-战斗状态错误 */
		Battle_BATTLE_PREPARE_BATTLE_STATUS_ERROR = 1017, 
		/**[战前调整队员到空格子上]-格子不能使用或被占用*/
		Battle_BATTLE_PREPARE_TILE_STATUS_IS_ERROR = 1018, 
		/**[战斗开始后-操作队员移动] 玩家战斗唯一ID错误*/
		Battle_BATTLE_START_ACTOR_BATTLEGID_ERROR = 1019, 
		/**[战斗开始后-操作队员移动位置] 战斗结果状态错误*/
		Battle_BATTLE_RESULT_STATUES_IS_ERROR = 1020, 
		/**[战斗开始后-操作队员移动位置] 格子被占用 */
		Battle_BATTLE_MOVE_POSITION_TILE_ISUSE = 1021, 
		/**[战斗开始后-操作队员移动位置] 队员无法移动 */
		Battle_BATTLE_MOVE_MEMBER_IS_NOT_MOVE = 1022, 
		/**[战斗中-结束自己回合]-没有找到账号的战斗唯一ID */
		Battle_BATTLE_ZHONG_NOT_FIND_ACCTOUNT_BATTLEGID = 1023, 
		/**[战斗中-结束自己回合]-没找到账号的战斗数据 */
		Battle_BATTLE_ZHONG_NOT_FIND_BATTLE_INFO = 1024, 
		/**[战斗中-队员与怪战斗]-有生物状态不对 */
		Battle_BATTLE_ZHONG_ENTITY_STATUS_ERROR = 1025, 
		/**[战斗中-队员与怪战斗]-攻击方死亡无法攻击 */
		Battle_BATTLE_ZHONG_ATTACK_IS_DEAD = 1026, 
		/**[战斗中-队员与怪战斗]-受击攻击方死亡无法攻击 */
		Battle_BATTLE_ZHONG_TARGET_IS_DEAD = 1027, 
		/**[战斗结束]-该账号战斗已经结束 */
		Battle_BATTLE_END_ACCOUNT_END_BATTLE = 1028, 
		/**[战斗模块]-获取battleManager错误 */
		Battle_BATTLE_GET_BATTLEMANAGER_ERROR = 1029, 
		/**[战斗场景]-战斗场景生命周期阶段错误*/
		Battle_BATTLE_CYCLE_STATE_ERROR = 1030, 
		/**[战斗场景]-操作者操作类型错误*/
		Battle_PLAYER_ACTIVE_TYPE_ERROR = 1031, 
		/**[战斗场景]-不是当前主操作者*/
		Battle_PLAYER_NOT_IS_MAIN_ERROR = 1032, 
		/**[战斗场景]-主动操作角色不存在*/
		Battle_USE_ACTOR_IS_NULL_ERROR = 1033, 
		/**[战斗场景]-非主动目标角色不存在 例如被攻击方，调换位置时第二对象等*/
		Battle_TARGET_ACTOR_IS_NULL_ERROR = 1033, 
		/**[战斗场景]-主动操作角色已经行动过*/
		Battle_USE_ACTOR_IS_ACTIONED_ERROR = 1034, 
		/**[战斗场景]-目标格子不存在*/
		Battle_TILE_IS_NULL_ERROR = 1035, 
		/**[玩家操作-attackActor]-攻击时使用的技能错误*/
		Battle_ACTIVE_ATTACKACTOR_USE_SKILLID_ERROR = 1036, 
		/**[玩家操作-attackActor]-超出技能攻击距离*/
		Battle_ACTIVE_ATTACKACTOR_EXCEED_SKILL_ATKRANGE_ERROR = 1037, 
		/**[AI操作-attackAi]-未寻找到可以进行攻击的位置*/
		Battle_AI_ATTACK_SEEK_TILE_IS_NULL_ERROR = 1038, 
		/**[AI操作-moveAi]-未检索到可移动点*/
		Battle_AI_MOVE_SEEK_TILE_IS_NULL_ERROR = 1039, 
		/**[玩家操作]-moveActor-角色移动力不足*/
		Battle_USE_ACTOR_LACK_MOV_POWER_ERROR = 1040, 
		/**[玩家操作]-escapeActor-该格子不能撤离*/
		Battle_ACTIVE_ESCAPEACTOR_TILE_NOT_CAN_ESCAPE_ERROR = 1041, 
		/**[玩家操作]-attackActor-AP不足*/
		Battle_ACTIVE_ATTACKACTOR_LACK_AP_ERROR = 1042, 
		/**[玩家操作]-操作锁定*/
		Battle_ACTIVE_ACTIVITY_IS_LOCK = 1043, 
		/**[玩家操作]-角色禁止攻击*/
		Battle_ACTIVE_ACTOR_IS_FORBID_ATTACK = 1044, 
		/**[玩家操作]-角色禁止移动*/
		Battle_ACTIVE_ACTOR_IS_FORBID_MOVE = 1045, 
		/**[玩家操作]-角色缺少行动次数*/
		Battle_ACTIVE_ACTOR_LACK_ACTIVE_NUM = 1046, 
		/**[发送奖励]-玩家属于机器人 */
		Battle_PLAYER_IS_ROBOT = 1047, 
		/**[玩家操作]-技能主目标不可选择*/
		Battle_ACTIVE_ATTACKACTOR_USE_SKILL_MAIN_TAERGET_ERROR = 1048, 
		/**[玩家操作]-目标格子上不存在可攻击角色*/
		Battle_USE_SKILL_TARGET_TILE_ACTOR_ABSENCE = 1049, 
		/** token验证失败 */
		Auth_FA_TOKEN_ILLEGAL = 1500, 
		/** token过期了 */
		Auth_FA_TOKEN_EXPIRE = 1501, 
	}

}
