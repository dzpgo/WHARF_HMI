using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UACSDAL
{
    public class constData
    {
        /// <summary>
        /// 平台名称
        /// </summary>
        public const string tagServiceName = "iplature";

        /// <summary>
        /// 机组入口定义
        /// </summary>
        public const int EntrySaddleDefine = 0;

        /// <summary>
        /// 机组出口定义
        /// </summary>
        public const int ExitSaddleDefine = 1;

        /// <summary>
        /// 机组号
        /// </summary>
        public const string UnitNo = "D401";
        public const string UnitNo_1 = "D102";
        public const string UnitNo_2 = "D112";
        public const string UnitNo_3 = "D108";
        public const string UnitNo_4 = "D208";

        public const string bayNo = "Z11-Z12";
        public const string bayNo_A = "FIA";
        public const string bayNo_B = "FIB";

        public const long Z11_Z12BaySpaceX = 318000;
        public const long Z11_Z12BaySpaceY = 40000;
        public const long B_BaySpaceX = 168000;
        public const long B_BaySpaceY = 42000;

        public const bool xAxisRight = false;
        public const bool xBxisRight = true;
        public const bool yAxisDown = false;
        public const bool yBxisDown = true;
    }
}
