using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CardinalsHBS
{ 
    /// <summary>
    /// This is a Plain C# class whose instances carry information of one single order.
    /// </summary>
    class OrderClass
    {
        private String CardNo;//Credit Card Number
        private int Amount;
        private String SenderID; //Travel agency Name
        private String ReceiverID; //Hotel Supplier Name
        private int NoOfRooms; //No of Rooms to be booked
        private int NoOfDays; //No of days the rooms to be booked

        public OrderClass() { }

        /// <summary>
        /// Setter for Credit Card No.
        /// </summary>
        /// <param name="CardNo">Card Number</param>
        public void setCardNo(String CardNo)
        {
            this.CardNo = CardNo;
        }
        
        /// <summary>
        /// Getter for Credit Card No.
        /// </summary>
        /// <returns>Credit Card Number in String Format</returns>
        public String getCardNo()
        {
            return this.CardNo;
        }

        
        public void setAmount(int Amount)
        {
            this.Amount= Amount;
        }

        public int getAmount()
        {
            return this.Amount;
        }
      
        /// <summary>
        /// Setter for Travel Agency Name
        /// </summary>
        /// <param name="SenderID">Travel Agency Name</param>
        public void setSenderID(String SenderID)
        {
            this.SenderID = SenderID;
        }

        /// <summary>
        /// Getter for Travel Agency Name
        /// </summary>
        /// <returns>Travel Agency Name</returns>
        public String getSenderID()
        {
            return this.SenderID;
        }

        /// <summary>
        /// Setter for Hotel Supplier Name
        /// </summary>
        /// <param name="ReceiverID">Hotel Supplier Name</param>
        public void setReceieverID(String ReceiverID)
        {
            this.ReceiverID=ReceiverID;
        }

        /// <summary>
        /// Getter for Hotel Supplier Name
        /// </summary>
        /// <returns>Hotel Supplier Name</returns>
        public String getReceiverID()
        {
            return this.ReceiverID;
        }

        /// <summary>
        /// Setter for No. of rooms
        /// </summary>
        /// <param name="NoOfRooms">No. of Rooms required to book</param>
        public void setNoOfRooms(int NoOfRooms)
        {
            this.NoOfRooms = NoOfRooms;
        }


        /// <summary>
        /// Getter for No. of Rooms
        /// </summary>
        /// <returns>No. of Rooms to book</returns>
        public int getNoOfRooms()
        {
            return this.NoOfRooms;
        }

        /// <summary>
        /// Setter for No. of Days
        /// </summary>
        /// <param name="NoOfDays">No of Days to book rooms</param>
        public void setNoOfDays(int NoOfDays)
        {
            this.NoOfDays = NoOfDays;
        }

        /// <summary>
        /// Getter for No. of Days
        /// </summary>
        /// <returns>No. of Days for which rooms are to be booked</returns>
        public int getNoOfDays()
        {
            return this.NoOfDays;
        }

    }
}
