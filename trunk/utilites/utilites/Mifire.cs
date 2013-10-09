using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading;

namespace com.sbs.dll.utilites
{
    public class Mifire
    {
        private int hContext = 0, hCard, Protocol;
        private string rName;

        public Mifire()
        {
            int indx, retCode, pcchReaders = 0;

            retCode = ModWinsCard.SCardEstablishContext(ModWinsCard.SCARD_SCOPE_USER, 0, 0, ref hContext);

            if (retCode != ModWinsCard.SCARD_S_SUCCESS)
            {
                throw new Exception("Не удалось определить reader." + Environment.NewLine + "ErrorCode: " + retCode);
            }

            retCode = ModWinsCard.SCardListReaders(hContext, null, null, ref pcchReaders);

            if (retCode != ModWinsCard.SCARD_S_SUCCESS)
            {
                uMessage.Show("Не удалось получить перечень reader-ов." + Environment.NewLine + "ErrorCode: " + retCode, SystemIcons.Information);
                return;
            }

            byte[] ReadersList = new byte[pcchReaders];

            // Fill reader list
            retCode = ModWinsCard.SCardListReaders(hContext, null, ReadersList, ref pcchReaders);

            if (retCode != ModWinsCard.SCARD_S_SUCCESS)
            {
                uMessage.Show("SCardListReaders Error: " + ModWinsCard.GetScardErrMsg(retCode), SystemIcons.Information);
                return;
            }

            rName = "";
            indx = 0;

            //Convert reader buffer to string
            while (ReadersList[indx] != 0)
            {

                while (ReadersList[indx] != 0)
                {
                    rName = rName + (char)ReadersList[indx];
                    indx = indx + 1;
                }

                indx = indx + 1;
            }
        }

        public string readMifire()
        {
            int retCode, xCount = 0;
            string keyId = "";
            bool inPlace = false;

            while (xCount != 7)
            {
                retCode = ModWinsCard.SCardConnect(hContext, rName, ModWinsCard.SCARD_SHARE_SHARED,
                                      ModWinsCard.SCARD_PROTOCOL_T0 | ModWinsCard.SCARD_PROTOCOL_T1, ref hCard, ref Protocol);

                switch (retCode)
                {
                    case ModWinsCard.SCARD_S_SUCCESS:
                        inPlace = true;
                        break;

                    case ModWinsCard.SCARD_W_REMOVED_CARD:  // ожидаем браслет 1,5 сек
                        Thread.Sleep(1000);
                        xCount += 1;
                        break;

                    default:
                        throw new Exception("ErrorCode: " + retCode + Environment.NewLine + "ErrorMessage: " + ModWinsCard.GetScardErrMsg(retCode));
                }

                ModWinsCard.SCardDisconnect(hContext, ModWinsCard.SCARD_LEAVE_CARD);

                if (xCount == 7) return ""; // так и не дождались браслета
                if (inPlace) break;
            }
                       

            ModWinsCard.SCARD_IO_REQUEST sioreq = new ModWinsCard.SCARD_IO_REQUEST();
            sioreq.dwProtocol = 0;// ModWinsCard.SCARD_PROTOCOL_T0; // SCARD_PROTOCOL_T1
            sioreq.cbPciLength = 8;

            ModWinsCard.SCARD_IO_REQUEST rioreq = new ModWinsCard.SCARD_IO_REQUEST();
            rioreq.dwProtocol = 0;// ModWinsCard.SCARD_PROTOCOL_T0; // SCARD_PROTOCOL_T1
            rioreq.cbPciLength = 8;

            byte[] receivebuffer = new byte[262];
            int sendbufferLen = 0;
            int receivebufferLen = 0;

            byte[] SendBuff = new byte[5];
            SendBuff[0] = 0xFF;                                      // CLA     
            SendBuff[1] = 0xCA;                                      // INS
            SendBuff[2] = 0x00;                                      // P1
            SendBuff[3] = 0x00;                                      // P2 : Block No.
            SendBuff[4] = 0x04;

            sendbufferLen = 0x05;
            receivebufferLen = 262;

            int retval = ModWinsCard.SCardTransmit(hCard, ref sioreq, ref SendBuff[0], sendbufferLen, ref rioreq, ref receivebuffer[0], ref receivebufferLen);

            switch (retval)
            {
                case ModWinsCard.SCARD_S_SUCCESS:
                    for (int i = 0; i <= receivebufferLen; i++)
                    {
                        keyId += receivebuffer[i];
                    }
                    break;

                default:
                    uMessage.Show("ErrorCode: " + retval + Environment.NewLine + "ErrorMessage: " + ModWinsCard.GetScardErrMsg(retval), SystemIcons.Information);
                    break;
            }

            ModWinsCard.SCardDisconnect(hContext, ModWinsCard.SCARD_LEAVE_CARD);

            return keyId;
        }
    }
}
