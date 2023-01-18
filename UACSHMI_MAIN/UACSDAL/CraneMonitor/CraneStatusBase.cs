﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UACSDAL
{
    /// <summary>
    /// 行车状态基类
    /// </summary>
    public class CraneStatusBase : ICloneable
    {
        object ICloneable.Clone()
        {
            return this.Clone();
        }
        public CraneStatusBase Clone()
        {
            return (CraneStatusBase)this.MemberwiseClone();
        }

        private string craneNO = string.Empty;
        /// <summary>
        /// 行车号
        /// </summary>
        public string CraneNO
        {
            get { return craneNO; }
            set { craneNO = value; }
        }

        private long ready = 0;
        /// <summary>
        /// 准备好
        /// </summary>
        public long Ready
        {
            get { return ready; }
            set { ready = value; }
        }

        private long controlMode = 0;
        /// <summary>
        /// 控制模式
        /// </summary>
        public long ControlMode
        {
            get { return controlMode; }
            set { controlMode = value; }
        }

        private long askPlan = 0;
        /// <summary>
        /// 请求指令
        /// </summary>
        public long AskPlan
        {
            get { return askPlan; }
            set { askPlan = value; }
        }


        private long xAct = 0;
        /// <summary>
        /// X
        /// </summary>
        public long XAct
        {
            get { return xAct; }
            set { xAct = value; }
        }

        private long yAct = 0;
        /// <summary>
        /// Y
        /// </summary>
        public long YAct
        {
            get { return yAct; }
            set { yAct = value; }
        }


        private long zAct = 0;
        /// <summary>
        /// Z
        /// </summary>
        public long ZAct
        {
            get { return zAct; }
            set { zAct = value; }
        }

        private long craneStatus = 0;
        /// <summary>
        /// 行车状态
        /// </summary>
        public long CraneStatus
        {
            get { return craneStatus; }
            set { craneStatus = value; }
        }

        private long hasCoil = 0;
        /// <summary>
        /// 有卷
        /// </summary>
        public long HasCoil
        {
            get { return hasCoil; }
            set { hasCoil = value; }
        }
        
        private string receiveTime = string.Empty;
        /// <summary>
        /// 心跳
        /// </summary>
        public string ReceiveTime
        {
            get { return receiveTime; }
            set { receiveTime = value; }
        }

        private long xSpeed = 0;

        public long XSpeed
        {
            get { return xSpeed; }
            set { xSpeed = value; }
        }

        private long ySpeed = 0;

        public long YSpeed
        {
            get { return ySpeed; }
            set { ySpeed = value; }
        }

        private long zSpeed = 0;

        public long ZSpeed
        {
            get { return zSpeed; }
            set { zSpeed = value; }
        }

        private long planUpX = 0;

        public long PlanUpX
        {
            get { return planUpX; }
            set { planUpX = value; }
        }

        private long planUpY = 0;

        public long PlanUpY
        {
            get { return planUpY; }
            set { planUpY = value; }
        }

        private long planUpZ = 0;

        public long PlanUpZ
        {
            get { return planUpZ; }
            set { planUpZ = value; }
        }

        private long planDownX = 0;

        public long PlanDownX
        {
            get { return planDownX; }
            set { planDownX = value; }
        }

        private long planDownY = 0;

        public long PlanDownY
        {
            get { return planDownY; }
            set { planDownY = value; }
        }

        private long planDownZ = 0;

        public long PlanDownZ
        {
            get { return planDownZ; }
            set { planDownZ = value; }
        }

        private long rotateAngleAct = 0;

        public long RotateAngleAct
        {
            get { return rotateAngleAct; }
            set { rotateAngleAct = value; }
        }

        private long clampWidthAct = 0;

        public long ClampWidthAct
        {
            get { return clampWidthAct; }
            set { clampWidthAct = value; }
        }

        private long weightLoaded;

        public long WeightLoaded
        {
            get { return weightLoaded; }
            set { weightLoaded = value; }
        }
        


        /// <summary>
        /// 行车状态描述
        /// </summary>
        /// <returns></returns>
        public string CraneStatusDesc()
        {
            //空钩起升过程= 000;
            if (craneStatus == STATUS_NEED_TO_READY)
            {
                return STATUS_NEED_TO_READY_Desc;
            }
            //空钩等待状态= 010
            else if (craneStatus == STATUS_WAITING_ORDER_WITH_OUT_COIL)
            {
                return STATUS_WAITING_ORDER_WITH_OUT_COIL_Desc;
            }
            //空钩走行状态= 020
            else if (craneStatus == STATUS_MOVING_WITH_OUT_COIL)
            {
                return STATUS_MOVING_WITH_OUT_COIL_Desc;
            }
            //空钩走行到位状态= 030
            else if (craneStatus == STATUS_ARRIVED_POS_WITH_OUT_COIL)
            {
                return STATUS_ARRIVED_POS_WITH_OUT_COIL_Desc;
            }
            //空钩下降去取卷= 040
            else if (craneStatus == STATUS_LIFT_COIL_DOWN_PHASE)
            {
                return STATUS_LIFT_COIL_DOWN_PHASE_Desc;
            }
            //钢卷起吊= 050
            else if (craneStatus == STATUS_COIL_LIFTED)
            {
                return STATUS_COIL_LIFTED_Desc;
            }
            //重钩起升过程= 060
            else if (craneStatus == STATUS_LIFT_COIL_UP_PHASE)
            {
                return STATUS_LIFT_COIL_UP_PHASE_Desc;
            }
            //重钩等待状态= 070
            else if (craneStatus == STATUS_WAITING_ORDER_WITH_COIL)
            {
                return STATUS_WAITING_ORDER_WITH_COIL_Desc;
            }
            //重钩走行状态= 080
            else if (craneStatus == STATUS_MOVING_WITH_COIL)
            {
                return STATUS_MOVING_WITH_COIL_Desc;
            }
            //重钩走行到位= 090
            else if (craneStatus == STATUS_ARRIVED_POS_WITH_COIL)
            {
                return STATUS_ARRIVED_POS_WITH_COIL_Desc;
            }
            //重钩下降去落卷= 100
            else if (craneStatus == STATUS_DOWN_COIL_DOWN_PHASE)
            {
                return STATUS_DOWN_COIL_DOWN_PHASE_Desc;
            }
            //钢卷落关= 110
            else if (craneStatus == STATUS_COIL_DOWN)
            {
                return STATUS_COIL_DOWN_Desc;
            }
            else
            {
                return STATUS_UNKNOWN;
            }
        }

        /// <summary>
        /// 行车模式描述
        /// </summary>
        /// <returns></returns>
        public string CraneModeDesc()
        {
            if (controlMode == CRANE_MODE_REMOTE)
            {
                return CRANE_MODE_REMOTE_DESC;
            }
            else if (controlMode == CRANE_MODE_MANPOWER)
            {
                return CRANE_MODE_MANPOWER_DESC;
            }
            else if (controlMode == CRANE_MODE_AUTO)
            {
                return CRANE_MODE_AUTO_DESC;
            }
            else if (controlMode == CRANE_MODE_AWAIT)
            {
                return CRANE_MODE_AWAIT_DESC;
            }
            else if (controlMode == CRANE_MODE_Recondition)
            {
                return CRANE_MODE_Recondition_DESC;
            }
            else
            {
                return CRANE_MODE_UNKNOWN;
            }
        }




        //--------------------------------------------------行车当前模式定义----------------------------------------------------------------

        //遥控 = 1
        public const long CRANE_MODE_REMOTE = 1;
        //人工 = 2
        public const long CRANE_MODE_MANPOWER = 2;
        //自动 = 4
        public const long CRANE_MODE_AUTO = 4;
        //等待 = 5
        public const long CRANE_MODE_AWAIT = 5;
        /// <summary>
        /// 检修 = 6
        /// </summary>
        public const long CRANE_MODE_Recondition = 6;


        //遥控 = 1
        public const string CRANE_MODE_REMOTE_DESC = "遥控";
        //人工 = 2
        public const string CRANE_MODE_MANPOWER_DESC = "人工";
        //自动 = 4
        public const string CRANE_MODE_AUTO_DESC = "自动";
        //等待 = 5
        public const string CRANE_MODE_AWAIT_DESC = "等待";
        /// <summary>
        /// 检修 = 6
        /// </summary>
        public const string CRANE_MODE_Recondition_DESC = "检修";
        /// <summary>
        /// 未知
        /// </summary>
        public const string CRANE_MODE_UNKNOWN = "未知";


        //--------------------------------------------------行车设备状态定义----------------------------------------------------------------
        //空钩起升过程= 000;
        public const long STATUS_NEED_TO_READY = 0;
        //空钩等待状态= 010
        public const long STATUS_WAITING_ORDER_WITH_OUT_COIL = 10;
        //空钩走行状态= 020
        public const long STATUS_MOVING_WITH_OUT_COIL = 20;
        //空钩走行到位状态= 030
        public const long STATUS_ARRIVED_POS_WITH_OUT_COIL = 30;
        //空钩下降去取卷= 040
        public const long STATUS_LIFT_COIL_DOWN_PHASE = 40;
        //钢卷起吊= 050
        public const long STATUS_COIL_LIFTED = 50;
        //重钩起升过程= 060
        public const long STATUS_LIFT_COIL_UP_PHASE = 60;
        //重钩等待状态= 070
        public const long STATUS_WAITING_ORDER_WITH_COIL = 70;
        //重钩走行状态= 080
        public const long STATUS_MOVING_WITH_COIL = 80;
        //重钩走行到位= 090
        public const long STATUS_ARRIVED_POS_WITH_COIL = 90;
        //重钩下降去落卷= 100
        public const long STATUS_DOWN_COIL_DOWN_PHASE = 100;
        //钢卷落关= 110
        public const long STATUS_COIL_DOWN = 110;


        //空钩起升过程= 000;
        public const string STATUS_NEED_TO_READY_Desc = "空钩起升";
        //空钩等待状态= 010
        public const string STATUS_WAITING_ORDER_WITH_OUT_COIL_Desc = "空钩等待";
        //空钩走行状态= 020
        public const string STATUS_MOVING_WITH_OUT_COIL_Desc = "空钩走行";
        //空钩走行到位状态= 030
        public const string STATUS_ARRIVED_POS_WITH_OUT_COIL_Desc = "空钩到位";
        //空钩下降去取卷= 040
        public const string STATUS_LIFT_COIL_DOWN_PHASE_Desc = "空钩下降";
        //钢卷起吊= 050
        public const string STATUS_COIL_LIFTED_Desc = "钢卷起吊";
        //重钩起升过程= 060
        public const string STATUS_LIFT_COIL_UP_PHASE_Desc = "起卷上升";
        //重钩等待状态= 070
        public const string STATUS_WAITING_ORDER_WITH_COIL_Desc = "重钩等待";
        //重钩走行状态= 080
        public const string STATUS_MOVING_WITH_COIL_Desc = "重钩走行";
        //重钩走行到位= 090
        public const string STATUS_ARRIVED_POS_WITH_COIL_Desc = "重钩到位";
        //重钩下降去落卷= 100
        public const string STATUS_DOWN_COIL_DOWN_PHASE_Desc = "落卷下降";
        //钢卷落关= 110
        public const string STATUS_COIL_DOWN_Desc = "钢卷落关";

        public const string STATUS_UNKNOWN = "999";


        //--------------------------------------------------行车状态信号对应的系统内部tag点定义-------------------------------------
        //--------------------------------------------------系统内部tag点主要供给画面使用，行车后台程序不使用------------
        /// <summary>
        /// 准备好
        /// </summary>
        public const string ADRESS_READY = "ready";
        /// <summary>
        /// 控制模式
        /// </summary>
        public const string ADRESS_CONTROL_MODE = "autoMode";
        /// <summary>
        /// 请求计划
        /// </summary>
        public const string ADRESS_ASK_PLAN = "askPlan";
        /// <summary>
        /// 大车位置
        /// </summary>
        public const string ADRESS_XACT = "xAct";
        /// <summary>
        /// 小车位置
        /// </summary>
        public const string ADRESS_YACT = "yAct";
        /// <summary>
        /// 夹钳高度
        /// </summary>
        public const string ADRESS_ZACT = "zAct";
        /// <summary>
        /// 有卷标志
        /// </summary>
        public const string ADRESS_HAS_COIL = "hasCoil";
        /// <summary>
        /// 行车状态
        /// </summary>
        public const string ADRESS_CRANE_STATUS = "status";
        /// <summary>
        /// 心跳
        /// </summary>
        public const string ADRESS_CRANE_PLC_HEART_BEAT = "heartBeat";
        /// <summary>
        /// 大车方向实际速度
        /// </summary>
        public const string ADRESS_XSPEED = "xSpeed";
        /// <summary>
        /// 小车方向实际速度
        /// </summary>
        public const string ADRESS_YSPEED = "ySpeed";
        /// <summary>
        /// 升降实际速度
        /// </summary>
        public const string ADRESS_ZSPEED = "zSpeed";
        /// <summary>
        /// 称重信号
        /// </summary>
        public const string ADRESS_WEIGHT_LOADED = "weightLoaded";
        /// <summary>
        /// 夹钳旋转角度
        /// </summary>
        public const string ADRESS_ROTATE_ANGLE_ACT = "rotateAngleAct";
        /// <summary>
        /// 夹钳开度
        /// </summary>
        public const string ADRESS_CLAMP_WIDTH_ACT = "pawActWidth";
        /// <summary>
        /// 计划起卷X
        /// </summary>
        public const string ADRESS_PLAN_UP_X = "planUpX";
        /// <summary>
        /// 计划起卷Y
        /// </summary>
        public const string ADRESS_PLAN_UP_Y = "planUpY";
        /// <summary>
        /// 计划起卷Z
        /// </summary>
        public const string ADRESS_PLAN_UP_Z = "planUpZ";
        /// <summary>
        /// 计划落卷X
        /// </summary>
        public const string ADRESS_PLAN_DOWN_X = "planDownX";
        /// <summary>
        /// 计划落卷Y
        /// </summary>
        public const string ADRESS_PLAN_DOWN_Y = "planDownY";
        /// <summary>
        /// 计划落卷Z
        /// </summary>
        public const string ADRESS_PLAN_DOWN_Z = "planDownZ";


        //--------------------------------------------------行车控制模式----------------------------------------------------------------
        /// <summary>
        /// 要求停车 = 100
        /// </summary>
        public const long SHORT_CMD_NORMAL_STOP = 100;
        /// <summary>
        /// 紧急停止 = 200
        /// </summary>
        public const long SHORT_CMD_EMG_STOP = 200;
        /// <summary>
        /// 复位 = 300
        /// </summary>
        public const long SHORT_CMD_RESET = 300;
        /// <summary>
        /// 自动 = 400
        /// </summary>
        public const long SHORT_CMD_ASK_COMPUTER_AUTO = 400;
        /// <summary>
        /// 手动 = 500
        /// </summary>
        public const long SHORT_CMD_CANCEL_COMPUTER_AUTO = 500;
    }
}
