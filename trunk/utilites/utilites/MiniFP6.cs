using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Reflection;
using System.IO.Ports;

namespace com.sbs.dll.utilites
{
    public class MiniFP6
    {
        public State State_;

        private Type fiscalDevice = null;
        private Object fiscalDeviceInst = null;

        public MiniFP6()
        {
            State_ = new State();
            fiscalDevice = Type.GetTypeFromProgID("OLE_MiniFP6.FP6");
            fiscalDeviceInst = Activator.CreateInstance(fiscalDevice);
        }

        /// <summary>
        /// Назначение:Регистрация в чеке очередной продажи товара/услуги.
        /// После успешного выполнения операции – чек открыт.
        /// В первой строке индикатора клиента отображается промежуточный итог по чеку.
        /// Если параметр Show = true, во второй строке индикатора клиента отображается название товара и сумма по этому товару.
        /// Если в принтере режим печати чека = OnLine (смотри PrinterState_, SetPrintMode_),  печатается очередная строка чека.
        /// Примечание:Закрытие чека производится при выполнении метода Pay_.
        /// </summary>
        /// <param name="pNcom">номер COM-порта (1 – 8)</param>
        /// <param name="pCode">код товара/услуги  (0 – 4294967295)</param>
        /// <param name="pName">наименование товара/услуги  (до 50 символов)</param>
        /// <param name="pQuantity">количество  (макс.значение ~ 16777,215)</param>
        /// <param name="pPrice">цена  (-21474836,47   значение   21474836,47)
        ///                     отрицательная цена применяется для аннулирования предыдущих продаж в открытом чеке </param>
        /// <param name="pTaxGroup">номер налоговой группы (1,2,3,4,5,6) . Налоговая ставка группы 6 всегда = 0.</param>
        /// <param name="pShow">режим использования внешнего индикатора клиента 
        ///                     (True – отображать во 2-й строке индикатора название товара и сумму по товару; False – не отображать)</param>
        /// <returns>Истина – операция выполнена; Ложь – операция не выполнена.</returns>
        public bool Sale_(int pNcom, string pCode, string pName, double pQuantity, double pPrice, int pTaxGroup, bool pShow)
        {
            if (fiscalDeviceInst == null) return false;

            fiscalDevice.InvokeMember("Sale_", BindingFlags.InvokeMethod, null, fiscalDeviceInst, new object[] { pNcom, pCode, pName, pQuantity, pPrice, pTaxGroup, pShow});

            return true;
        }

        /// <summary>
        /// Назначение: Регистрация оплаты/выплаты и печать чека.
        /// Разрешается комбинированная оплата/выплата чека (различными видами оплат).
        /// Если общая сумма, предъявленная к оплате, совпадает или больше  итога чека – чек печатается и закрывается.
        /// Если общая сумма, предъявленная к оплате, меньше чем итог чека – принтер остается в режиме ожидания следующей доплаты.
        /// Если общая сумма, предъявленная к оплате, больше чем итог чека – чек печатается и закрывается. На чеке также печатается сумма сдачи (сдачи допустимо только для вида оплаты – наличные!) .
        /// На индикаторе клиента отображается итог по чеку и сумма сдачи.
        /// Данные регистрируются в накопительных регистрах принтера.
        /// </summary>
        /// <param name="pNcom">номер COM-порта (1 – 8)</param>
        /// <param name="pSum">сумма, предъявленная клиентом к оплате
        ///•	Sum > Итого по чеку - чек закрывается по Итогу с расчетом Сдачи; на индикаторе отображается Сумма сдачи, если Show=true;
        ///•	Sum = 0 - чек закрывается по Итогу;
        ///•	Sum < Итого по чеку - накапливается Сумма оплаты, на индикаторе отображается Сумма остатка оплаты, если Show=true;</param>
        /// <param name="pKind">вид оплаты: 0 - платежная карточка; 1 - кредит; 2 - чек; 3 - наличные</param>
        /// <param name="pShow">режим использования внешнего индикатора клиента 
        ///                     (True – отображать во 2-й строке индикатора сумму сдачи или доплаты; False – не отображать)</param>
        /// <param name="pRemainder">Если > 0 - сумма сдачи; Если < 0 - сумма недоплаты.</param>
        /// <returns>Истина – операция выполнена; Ложь – операция не выполнена.</returns>
        public bool Pay_(int pNcom, double pSum, int pKind, bool pShow, out double pRemainder)
        {
            pRemainder = 0;

            if (fiscalDeviceInst == null) return false;

            fiscalDevice.InvokeMember("Pay_", BindingFlags.InvokeMethod, null, fiscalDeviceInst, new object[] { pNcom, pSum, pKind, pShow, pRemainder });

            return true;
        }

        public bool AnnulCheck_(int pNcom)
        {
            object retVal = null;

            if (fiscalDeviceInst == null) return false;

            retVal = fiscalDevice.InvokeMember("AnnulCheck_", BindingFlags.InvokeMethod, null, fiscalDeviceInst, new object[] { pNcom });

            return true.Equals(retVal);
        }

        public string GetLastErr_()
        {
            string retval = string.Empty;

            retval = (string)fiscalDevice.InvokeMember("GetLastErr_", BindingFlags.InvokeMethod, null, fiscalDeviceInst, new object[] { });

            return retval;
        }

        public bool DiscountMarkUp_(int pNcom, int pType1, int pType2, string pType3, double pValue, bool pShow, string pComment)
        {
            if (fiscalDeviceInst == null) return false;

            fiscalDevice.InvokeMember("DiscountMarkUp_", BindingFlags.InvokeMethod, null, fiscalDeviceInst,
                new object[] { pNcom, pType1, pType2, pType3, pValue, pShow, pComment });

            return true;
        }

        public bool DayReport_(int pNcom)
        {
            object retVal = null;

            if (fiscalDeviceInst == null) return false;

            retVal = fiscalDevice.InvokeMember("DayReport_", BindingFlags.InvokeMethod, null, fiscalDeviceInst, new object[] { pNcom });

            return true.Equals(retVal);
        }

        public bool DayClrReport_(int pNcom)
        {
            object retVal = null;

            if (fiscalDeviceInst == null) return false;

            retVal = fiscalDevice.InvokeMember("DayClrReport_", BindingFlags.InvokeMethod, null, fiscalDeviceInst, new object[] { pNcom });

            return true.Equals(retVal);
        }

        public bool PrintCopy_(int pNcom)
        {
            object retVal = null;

            if (fiscalDeviceInst == null) return false;

            retVal = fiscalDevice.InvokeMember("PrintCopy_", BindingFlags.InvokeMethod, null, fiscalDeviceInst, new object[] { pNcom });

            return true.Equals(retVal);
        }

        public bool PrinterState_(int pNcom, out State pState )
        {
            object retVal = null;

            pState = new State();

            int AbortLastCommang = 0;
            int Fiscal = 0;
            int NewTax = 0;
            int OpenCheck = 0;
            int SaleYes = 0;
            int TypeTax = 0;
            int LastCheck = 0;
            int OnLine = 0;
            int ExtInd = 0;
            string SerialNumber = string.Empty;
            string DateSerialNumber = string.Empty;
            string RegNumber = string.Empty;
            string DateFiscal = string.Empty;
            string TimeFiscal = string.Empty;
            string Str1 = string.Empty;
            string Str2 = string.Empty;
            string Str3 = string.Empty;
            string Str4 = string.Empty;
            string Vers = string.Empty;
            int Dh1 = 0;
            int Dh2 = 0;
            int Dh3 = 0;
            int Dh4 = 0;
            int Dw1 = 0;
            int Dw2 = 0;
            int Dw3 = 0;
            int Dw4 = 0;

 
            if (fiscalDeviceInst == null) return false;

            fiscalDevice.InvokeMember("PrinterState_", BindingFlags.InvokeMethod, null, fiscalDeviceInst,
                new object[] { pNcom,
                            pState.AbortLastCommang,
                            pState.Fiscal,
                            pState.NewTax,
                            pState.OpenCheck,
                            pState.SaleYes,
                            pState.TypeTax,
                            pState.LastCheck,
                            pState.OnLine,
                            pState.ExtInd,
                            pState.SerialNumber,
                            pState.DateSerialNumber,
                            pState.RegNumber,
                            pState.DateFiscal,
                            pState.TimeFiscal,
                            pState.Str1,
                            pState.Str2,
                            pState.Str3,
                            pState.Str4,
                            pState.Vers,
                            pState.Dh1,
                            pState.Dh2,
                            pState.Dh3,
                            pState.Dh4,
                            pState.Dw1,
                            pState.Dw2,
                            pState.Dw3,
                            pState.Dw4});

            return true.Equals(retVal);
        }

        public class State
        { 
            /// <summary>
            /// True – аварийное завершение последней команды
            /// False – нормальное завершение последней команды
            /// </summary>
            public int AbortLastCommang { get; set; }

            /// <summary>
            /// True – фискальный принтер фискализирован
            /// False – фискальный принтер не фискализирован
            /// </summary>
            public int Fiscal { get; set; }

            /// <summary>
            /// True – введены новые налоговые ставки
            /// False – налоговые ставки прежние
            /// </summary>
            public int NewTax { get; set; }

            /// <summary>
            /// True – есть открытый чек; 
            /// False – нет открытого чека;
            /// </summary>
            public int OpenCheck { get; set; }

            /// <summary>
            /// True – после выдачи Z-отчета были продажи/выплаты
            /// False – после выдачи Z-отчета не было продаж/выплат
            /// </summary>
            public int SaleYes { get; set; }

            /// <summary>
            /// True – вид налога ~ НДС наложенный;
            /// False – вид налога ~ НДС вложенный;
            /// </summary>
            public int TypeTax { get; set; }

            /// <summary>
            /// True – последний чек – выплата;
            /// False – последний чек - продажи;
            /// </summary>
            public int LastCheck { get; set; }

            /// <summary>
            /// True – OnLine режим печати чека (печать чека осуществляется при регистрации товара (методы Sale_ и Disburse_) и при оплате чека (метод Pay_) )
            /// False – OffLine режим печати чека (распечатка всего чека осуществляется при оплате чека (метод Pay_)
            /// </summary>
            public int OnLine { get; set; }

            /// <summary>
            /// True – Подключен внешний индикатор клиента; 
            /// False – не подключен;
            /// </summary>
            public int ExtInd { get; set; }
            
            /// <summary>
            /// Серийный номер принтера (10 символов)
            /// </summary>
            public string SerialNumber { get; set; }
            
            /// <summary>
            /// Дата заводского номера (изготовления) в формате:  ДД-ММ-ГГ
            /// </summary>
            public string DateSerialNumber { get; set; }

            /// <summary>
            /// Регистрационный (фискальный) № принтера
            /// </summary>
            public string RegNumber { get; set; }

            /// <summary>
            /// Дата фискализации принтера в формате:  ДДММГГ
            /// </summary>
            public string DateFiscal { get; set; }

            /// <summary>
            /// Время фискализации принтера в формате:  ЧЧММ
            /// </summary>
            public string TimeFiscal { get; set; }

            /// <summary>
            /// Текст 1-й строки заголовка чека
            /// </summary>
            public string Str1 { get; set; }

            /// <summary>
            /// Текст 2-й строки заголовка чека
            /// </summary>
            public string Str2 { get; set; }

            /// <summary>
            /// Текст 3-й строки заголовка чека
            /// </summary>
            public string Str3 { get; set; }

            /// <summary>
            /// Текст 4-й строки заголовка чека
            /// </summary>
            public string Str4 { get; set; }

            /// <summary>
            /// Версия фискального принтера
            /// </summary>
            public string Vers { get; set; }

            /// <summary>
            /// Тип шрифта 1 строк заголовка чека  (True – двойная высота шрифта;  
            ///                                     False – одинарная высота)
            /// </summary>
            public int Dh1 { get; set; }

            /// <summary>
            /// Тип шрифта 2 строк заголовка чека  (True – двойная высота шрифта;  
            ///                                     False – одинарная высота)
            /// </summary>
            public int Dh2 { get; set; }

            /// <summary>
            /// Тип шрифта 3 строк заголовка чека  (True – двойная высота шрифта;  
            ///                                     False – одинарная высота)
            /// </summary>
            public int Dh3 { get; set; }

            /// <summary>
            /// Тип шрифта 4-й строк заголовка чека  (True – двойная высота шрифта;  
            ///                                       False – одинарная высота)
            /// </summary>
            public int Dh4 { get; set; }
            
            /// <summary>
            /// Тип шрифта 1 строк заголовка чека  (True – двойная ширина шрифта; 
            ///                                     False – одинарная ширина)
            /// </summary>
            public int Dw1 { get; set; }

            /// <summary>
            /// Тип шрифта 2 строк заголовка чека  (True – двойная ширина шрифта; 
            ///                                     False – одинарная ширина)
            /// </summary>
            public int Dw2 { get; set; }

            /// <summary>
            /// Тип шрифта 3 строк заголовка чека  (True – двойная ширина шрифта; 
            ///                                     False – одинарная ширина)
            /// </summary>
            public int Dw3 { get; set; }

            /// <summary>
            /// Тип шрифта 4-й строк заголовка чека  (True – двойная ширина шрифта; 
            ///                                       False – одинарная ширина)
            /// </summary>
            public int Dw4 { get; set; }
        }
    }
}
