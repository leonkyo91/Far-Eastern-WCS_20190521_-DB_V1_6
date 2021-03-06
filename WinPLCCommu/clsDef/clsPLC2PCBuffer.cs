﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirle.WinPLCCommu
{
    public class clsPLC2PCBuffer
    {
        #region 列舉
        /// <summary>
        /// 讀取通知列舉 : 0: 無 1: 通知PC讀取RFID 2: 板號正確 3: 板號不符
        /// </summary>
        public enum enuReadNotice
        {
            None = 0,
            Read = 1,
            IDPass = 2,
            IDFail = 3,
        }

        /// <summary>
        /// 命令模式列舉
        /// </summary>
        public enum enuCmdMode
        {
            None = 0,
            Left = 1,
            Right = 2,
            Both = 3,
        }

        /// <summary>
        /// Ready列舉 :無 1:入庫RDY 2:出庫RDY
        /// </summary>
        public enum enuReady
        {
            NoReady = 0,
            InReady = 1,
            OutReady = 2,
        }

        /// <summary>
        /// 站口模式列舉
        /// </summary>
        public enum enuStnMode
        {
            None = 0,
            InMode = 1,
            OutMode = 2,
            Pibk = 3,
        }

        /// <summary>
        /// 初始通知列舉
        /// </summary>
        public enum enuFunNotice
        {
            None = 0,
            Init = 1
        }
        #endregion 列舉

        #region 屬性
        /// <summary>
        /// 右序號
        /// </summary>
        public string RightCmdSno
        {
            get;
            set;
        }

        /// <summary>
        /// 序號
        /// </summary>
        public string LeftCmdSno
        {
            get;
            set;
        }

        /// <summary>
        /// 命令模式; 1:左 3:左右(單板靠左)
        /// </summary>
        public int CmdMode
        {
            get;
            set;
        }

        /// <summary>
        /// 站口模式; 1:入庫 2:出庫 3:撿料
        /// </summary>
        public int StnMode
        {
            get;
            set;
        }

        /// <summary>
        /// 荷資超寬超高
        /// </summary>
        public int OverSize
        {
            get;
            set;
        }

        #region 錯誤碼

        /// <summary>
        /// 錯誤碼_1
        /// </summary>
        public int Error
        {
            get;
            set;
        }

        /// <summary>
        /// 錯誤碼_2
        /// </summary>
        public int Error_2
        {
            get;
            set;
        }

        /// <summary>
        /// 錯誤碼緊急停止
        /// </summary>
        public bool Error_Stop
        {
            get;
            set;
        }
        #endregion 錯誤碼


        public clsAlarmData[] AlarmSignal
        {
            get;
            set;
        }

        /// <summary>
        /// 功能通知: 0:無 1:接收到初始訊號(需在自動下可出始,並判斷荷無)
        /// </summary>
        public int FunNotice
        {
            get;
            set;
        }

        /// <summary>
        /// Ready; 0:NO READY 1:入庫READY 2:出庫READY
        /// </summary>
        public int Ready
        {
            get;
            set;
        }

        /// <summary>
        /// 讀取通知列舉 : 0: 無 1: 通知PC讀取RFID 2: 板號正確 3: 板號不符
        /// </summary>
        public int ReadNotice
        {
            get;
            set;
        }

        /// <summary>
        /// 路徑通知
        /// </summary>
        public int PathNotice
        {
            get;
            set;
        }
        /// <summary>
        /// 站口切換 0:不可切換,1:可切換
        /// </summary>
        public int StnChange
        {
            get;
            set;
        }
        /// <summary>
        /// 功能通知 0:無,1:高儲位,2:低儲位
        /// </summary>
        public int LocHLNotice
        {
            get;
            set;
        }
        /// <summary>
        /// 使用率 1:25%,2:50%,3:75%,4:100% 
        /// </summary>
        public int Avail 
        {
            get;
            set;
        }
        /// <summary>
        /// 站口模式碼 Bit0:無模式
        /// </summary>
        public bool StnModeCode_None
        {
            get;
            set;
        }

        /// <summary>
        /// 站口模式碼 Bit1:入庫模式
        /// </summary>
        public bool StnModeCode_In
        {
            get;
            set;
        }

        /// <summary>
        /// 站口模式碼 Bit2:出庫模式
        /// </summary>
        public bool StnModeCode_Out
        {
            get;
            set;
        }

        
        /// <summary>
        /// 站口模式碼 Bit4:異常
        /// </summary>
        public bool StnModeCode_Error
        {
            get;
            set;
        }
        /// <summary>
        /// 站口模式碼 Bit5:自動
        /// </summary>
        public bool StnModeCode_Auto
        {
            get;
            set;
        }

        /// <summary>
        /// 站口模式碼 Bit6:手動
        /// </summary>
        public bool StnModeCode_Manual
        {
            get;
            set;
        }
        // 遠紡調整 By Leon 
        /// <summary>
        /// 站口模式碼 Bit7:棧板荷有
        /// </summary>
        public bool StnModeCode_PalletLoad
        {
            get;
            set;
        }

        /// <summary>
        /// 站口模式碼 Bit8:貨物荷有
        /// </summary>
        public bool StnModeCode_CargoLoad
        {
            get;
            set;
        }
        /// <summary>
        /// 站口模式碼 Bit9:定位
        /// </summary>
        public bool StnModeCode_Position
        {
            get;
            set;
        }

        /// <summary>
        /// 站口模式碼 Bit10:作業完了
        /// </summary>
        public bool StnModeCode_Finish
        {
            get;
            set;
        }

        /// <summary>
        /// 站口模式碼 Bit11:緊急停止
        /// </summary>
        public bool StnModeCode_Stop
        {
            get;
            set;
        }
        #endregion 屬性

        #region 建構函式
        /// <summary>
        /// 初始化 Mirle.WinPLCCommu.clsPLC2PCBuffer 類別的新執行個體
        /// </summary>
        public clsPLC2PCBuffer()
        {
            LeftCmdSno = string.Empty;
            RightCmdSno = string.Empty;
            //FunNotice = 0;
            //CmdMode = 0;
            //StnMode = 0;
            //ReadNotice = 0;
            //Ready = 0;
            Error = 0;
            
            AlarmSignal = new clsAlarmData[32];
            for(int intCount = 0; intCount < 32; intCount++)
                AlarmSignal[intCount] = new clsAlarmData();

            StnModeCode_Auto = false;
            StnModeCode_Finish = false;
            StnModeCode_In = false;
            StnModeCode_Error = false;
            StnModeCode_PalletLoad = false;
            StnModeCode_Manual = false;
            StnModeCode_None = false;
            StnModeCode_Out = false;
            StnModeCode_Position = false;
            StnModeCode_CargoLoad = false;
            StnModeCode_Stop = false;
        }
        #endregion 建構函式
    }
}
