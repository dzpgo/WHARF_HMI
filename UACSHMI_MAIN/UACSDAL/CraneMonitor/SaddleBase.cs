﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UACSDAL
{
    /// <summary>
    /// 鞍座基类
    /// </summary>
    public class SaddleBase : ICloneable
    {

        object ICloneable.Clone()
        {
            return this.Clone();
        }

        public SaddleBase Clone()
        {
            return (SaddleBase)this.MemberwiseClone();
        }

        private string saddleNo;
        /// <summary>
        /// 鞍座号
        /// </summary>
        public string SaddleNo
        {
            get { return saddleNo; }
            set { saddleNo = value; }
        }

        private string saddleName;
        /// <summary>
        /// 鞍座名称
        /// </summary>
        public string SaddleName
        {
            get { return saddleName; }
            set { saddleName = value; }
        }

        private int saddle_Seq;
        /// <summary>
        /// 鞍座序号
        /// </summary>
        public int Saddle_Seq
        {
            get { return saddle_Seq; }
            set { saddle_Seq = value; }
        }

        private int row_No;
        /// <summary>
        /// 行号
        /// </summary>
        public int Row_No
        {
            get { return row_No; }
            set { row_No = value; }
        }

        private int col_No;
        /// <summary>
        /// 列号
        /// </summary>
        public int Col_No
        {
            get { return col_No; }
            set { col_No = value; }
        }

        private int layer_Num;
        /// <summary>
        /// 层号
        /// </summary>
        public int Layer_Num
        {
            get { return layer_Num; }
            set { layer_Num = value; }
        }

        private long saddleWidth;
        /// <summary>
        /// 鞍座宽度
        /// </summary>
        public long SaddleWidth
        {
            get { return saddleWidth; }
            set { saddleWidth = value; }
        }

        private long saddleLength;
        /// <summary>
        /// 鞍座长度
        /// </summary>
        public long SaddleLength
        {
            get { return saddleLength; }
            set { saddleLength = value; }
        }


        private long x_Center;
        /// <summary>
        /// X中心点
        /// </summary>
        public long X_Center
        {
            get { return x_Center; }
            set { x_Center = value; }
        }

        private long y_Center;
        /// <summary>
        /// Y中心点
        /// </summary>
        public long Y_Center
        {
            get { return y_Center; }
            set { y_Center = value; }
        }

        private long z_Center;
        /// <summary>
        /// Z中心点
        /// </summary>
        public long Z_Center
        {
            get { return z_Center; }
            set { z_Center = value; }
        }

        private int stock_Status;
        /// <summary>
        /// 库位状态
        /// </summary>
        public int Stock_Status
        {
            get { return stock_Status; }
            set { stock_Status = value; }
        }

        private int lock_Flag;
        /// <summary>
        /// 封锁标记
        /// </summary>
        public int Lock_Flag
        {
            get { return lock_Flag; }
            set { lock_Flag = value; }
        }


        private string mat_No;
        /// <summary>
        /// 材料号
        /// </summary>
        public string Mat_No
        {
            get { return mat_No; }
            set
            {
                mat_No = value;
            }
        }

        private string next_Unit_No;
        /// <summary>
        /// 下道机组
        /// </summary>
        public string Next_Unit_No
        {
            get { return next_Unit_No; }
            set
            {
                next_Unit_No = value;
            }
        }

        private string tagAdd_IsOccupied;
        /// <summary>
        /// 鞍座占位信号点地址
        /// </summary>
        public string TagAdd_IsOccupied
        {
            get
            {
                return tagAdd_IsOccupied;
            }
            set
            {
                tagAdd_IsOccupied = value;
            }
        }

        private long tagVal_IsOccupied;
        /// <summary>
        /// 鞍座占位信号点值
        /// </summary>
        public long TagVal_IsOccupied
        {
            get
            {
                return tagVal_IsOccupied;
            }
            set
            {
                tagVal_IsOccupied = value;
            }
        }

        private string tag_Lock_Request;
        /// <summary>
        /// 鞍座锁定请求地址
        /// </summary>
        public string Tag_Lock_Request
        {
            get { return tag_Lock_Request; }
            set { tag_Lock_Request = value; }
        }

        private long tag_Lock_Request_Value;
        /// <summary>
        /// 鞍座锁定请求值
        /// </summary>
        public long Tag_Lock_Request_Value
        {
            get { return tag_Lock_Request_Value; }
            set { tag_Lock_Request_Value = value; }
        }

        private string tag_IsLocked;
        /// <summary>
        /// 鞍座锁定反馈地址
        /// </summary>
        public string Tag_IsLocked
        {
            get { return tag_IsLocked; }
            set { tag_IsLocked = value; }
        }



        private long tag_IsLocked_Value;
        /// <summary>
        /// 鞍座锁定反馈值
        /// </summary>
        public long Tag_IsLocked_Value
        {
            get { return tag_IsLocked_Value; }
            set { tag_IsLocked_Value = value; }
        }
        

        private string coilNO;
        /// <summary>
        /// 钢卷号
        /// </summary>
        public string CoilNO
        {
            get
            {
                return coilNO;
            }
            set
            {
                coilNO = value;
            }
        }


        private int plastic_Flag;
        /// <summary>
        /// 钢卷套袋
        /// </summary>
        public int Plastic_Flag
        {
            get
            {
                return plastic_Flag;
            }
            set
            {
                plastic_Flag = value;
            }
        }

        private string thick;
        /// <summary>
        /// 厚度
        /// </summary>
        public string Thick
        {
            get { return thick; }
            set
            {
                thick = value;
            }
        }

        private string addres;
        /// <summary>
        /// 港口
        /// </summary>
        public string Addres
        {
            get { return addres; }
            set
            {
                addres = value;
            }
        }

        private string strap;
        /// <summary>
        /// 带子颜色
        /// </summary>
        public string Strap
        {
            get { return strap; }
            set
            {
                strap = value;
            }
        }
        public const string tagServiceName = "iplature";
    }
}
