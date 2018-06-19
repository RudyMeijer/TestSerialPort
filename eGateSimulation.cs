/*================================================================================
          ASH Control Panel-project ASCS
          Copyright(c) Aebi Schmidt Nederland B.V., 2012 - 2016
================================================================================*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//using ASCS.Lib.Board.Serial;
using ASCS.Lib.Common;
using System.Diagnostics;
//using ASCS.Lib.Common.Timers;

namespace ASCS.Lib.RemoteGatewayComponent.GPRS.Test
{
    class eGateSimulation 
    {
        private const byte RES = 0x00;
        private const byte STX = 0x02;
        private const byte ETX = 0x03;
        private const byte NAK = 0x04;
        private const byte ACK = 0x05;
        private const byte DLE = 0x10;

        private const int EGateResponseMsgBufferLength = 9;
        private const int IdAndPortPosition = 2;
        private const int DelayReadWriteTime_ms = 60;

        private byte[] mDefaultMsgHeader = new byte[3] { STX, RES, 0x87 };
        private byte[] mDefaultMsgFooter = new byte[4] { DLE, ETX, 0x00, 0x00 };

        private List<byte> mEGateResponseMsgBuffer = new List<byte>();
        private object mEGateResponseCountLockObject = new object();

        private byte mPacketRunningId = 0x10;

        //public int Read(byte[] aBuffer, int aReadCount)
        //{
        //    System.Threading.Thread.Sleep(DelayReadWriteTime_ms);

        //    int returnCode = 0;
        //    return returnCode;
        //}

        //public bool Close()
        //{
        //    return true;
        //}

        //public bool FlushRxBuffer()
        //{
        //    return true;
        //}

        //public bool FlushTxBuffer()
        //{
        //    return true;
        //}

        //public bool Open(string aPortName)
        //{
        //    return true;
        //}

        //public bool Open(string aPortName, string aBaudRate)
        //{
        //    return true;
        //}

        //public bool Write(byte[] aBuffer, int aLength)
        //{
        //    System.Threading.Thread.Sleep(DelayReadWriteTime_ms);

        //    GenerateAckMessage(aBuffer);
        //    if (!IsSyncMessage(aBuffer))
        //    {
        //        GenerateReturnMessage(aBuffer);
        //    }

        //    return true;
        //}

        public List<Byte> GenerateAckMessage(byte[] aReceivedMsgBuffer)
        {
            List<Byte> responseData = DetermineResponseData(null);
            List<Byte> dataBytes = GenerateDataLinkLayerFrame(aReceivedMsgBuffer, responseData);

            //lock (mEGateResponseCountLockObject)
            //{
            //    mEGateResponseMsgBuffer.AddRange(dataBytes);
            //}
            return dataBytes;
        }

        public List<Byte> GenerateReturnMessage(byte[] aReceivedMsgBuffer)
        {
            List<Byte> responseData = DetermineResponseData(aReceivedMsgBuffer);
            List<Byte> dataBytes = GenerateDataLinkLayerFrame(aReceivedMsgBuffer, responseData);

            //lock (mEGateResponseCountLockObject)
            //{
            //    mEGateResponseMsgBuffer.AddRange(dataBytes);
            //}
            return dataBytes;
        }

        private List<Byte> GenerateDataLinkLayerFrame(byte[] aReceivedMsgBuffer, List<Byte> aResponseData)
        {
            List<Byte> dataBytes = new List<byte>();
            
            byte IdAndPort = GetIdAndPort(aReceivedMsgBuffer);

            dataBytes.Add(RES);
            dataBytes.Add(IdAndPort);
            dataBytes.AddRange(aResponseData);

            UInt16 crc = CRC16_CCITT.Calculate(dataBytes);
            byte[] crcBytes = BitConverter.GetBytes(crc);

            dataBytes.Insert(0, STX);
            dataBytes.AddRange(mDefaultMsgFooter);

            int dataBytesCount = dataBytes.Count;

            dataBytes[dataBytesCount - 2] = crcBytes[0];
            dataBytes[dataBytesCount - 1] = crcBytes[1];
            return dataBytes;
        }

        private List<byte> DetermineResponseData(byte[] aReceivedMsgBuffer)
        {
            List<byte> response = new List<byte>();

            if (aReceivedMsgBuffer == null)
            {
                response.Add(DLE);
                response.Add(ACK);
            }
            else
            {
                response.Add(0x00);
                response.Add(0x00);
            }

            return response;
        }

        private bool IsSyncMessage(byte[] aBuffer)
        {
            return ((aBuffer[IdAndPortPosition] & 0x80) == 1);
        }

        private byte GetIdAndPort(byte[] aBuffer)
        {
            if (IsSyncMessage(aBuffer))
            {
                return (byte)GetDestinationPort(aBuffer);
            }
            else
            {
                return (byte)(GetNextRunningId() + GetDestinationPort(aBuffer));
            }
        }

        private int GetDestinationPort(byte[] aData)
        {
            return aData[2] & 0x0f;
        }

        private byte GetNextRunningId()
        {
            mPacketRunningId += 0x10;

            if (mPacketRunningId > 0x30)
            {
                mPacketRunningId = 0;
            }

            return mPacketRunningId;
        }

        //[Conditional("DEBUG_EGATE_SIMULATION")]
        //private void DebugWriteLine(string aLine)
        //{
        //    Debug.WriteLine(string.Format("{0}: {1}", Environment.TickCount, aLine));
        //}
    }
}
