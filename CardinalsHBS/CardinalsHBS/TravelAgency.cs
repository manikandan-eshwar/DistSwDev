using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Threading;

namespace CardinalsHBS
{
    /// <summary>
    /// Travel agency performs call back handling in the event of price cut and places order appropriately
    /// </summary>
    class TravelAgency
    {
        //To hold the credit card details
        public static String[] CreditCards = new String[5]; 
        private static int i = 0;
        private OrderClass CurrentOrder;

        //Object of Random Class for calculating no of rooms
        Random rand = new Random();

        //Default Constructor 
        public TravelAgency()
        {

        }

        /// <summary>
        /// Setter for  Order Object
        /// </summary>
        /// <param name="CurrentOrder"></param>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public void setCurrentOrder(OrderClass CurrentOrder)
        {
            this.CurrentOrder = CurrentOrder;
        }

        /// <summary>
        /// Getter for Order Object
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public OrderClass getCurrentOrder()
        {
            return this.CurrentOrder;
        }
        
     
        /// <summary>
        /// Encoder Method for Coverting Order Object to String 
        /// </summary>
        /// <param name="CurrentOrder">Instance of Order Object</param>
        /// <returns>String with order information separated by '-'</returns>
        public String Encoder(OrderClass CurrentOrder)
        {
            String OrderToString = null;
            if (CurrentOrder != null)
            {
                OrderToString = CurrentOrder.getSenderID() + "-" + CurrentOrder.getNoOfRooms()+"-"+CurrentOrder.getCardNo()+"-"+CurrentOrder.getReceiverID()+"-"+CurrentOrder.getNoOfDays();
            }
            return OrderToString;
        }

        /// <summary>
        /// Call back Handler method which handles the priceCut Event based
        /// </summary>
        /// <param name="price">New Low price of the respective hotel</param>
        /// <param name="HotelName"></param>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public void RoomsPriceCut(Int32 price, String HotelName)
        {
            Console.WriteLine();
            Console.WriteLine("{0} rooms are on sale with a low price  ${1} ", HotelName, price);
            Console.WriteLine("No. of Rooms Available at {0} are: {1}", HotelName, HotelSupplier.getRoomsAvailable(HotelName));
            Console.WriteLine();

            if (HotelName.Equals("HotelSupplier1"))
            {
                OrderClass CurrentOrder1 = new OrderClass();
                CurrentOrder1.setSenderID("TravelAgency1");
                CurrentOrder1.setReceieverID(HotelName);
                CurrentOrder1.setNoOfRooms(calculateNoOfRooms(price));//Calulates Rooms Required
                CurrentOrder1.setNoOfDays(2);
                CurrentOrder1.setCardNo(CreditCards[0]);
                CardinalMain.TravelAgency1.setCurrentOrder(CurrentOrder1);

                OrderClass CurrentOrder2 = new OrderClass();
                CurrentOrder2.setSenderID("TravelAgency2");
                CurrentOrder2.setReceieverID(HotelName);
                CurrentOrder2.setNoOfRooms(calculateNoOfRooms(price));//Calulates Rooms Required
                CurrentOrder2.setNoOfDays(4);
                CurrentOrder2.setCardNo(CreditCards[1]);
                CardinalMain.TravelAgency2.setCurrentOrder(CurrentOrder2);


                OrderClass CurrentOrder3 = new OrderClass();
                CurrentOrder3.setSenderID("TravelAgency3");
                CurrentOrder3.setReceieverID(HotelName);
                CurrentOrder3.setNoOfRooms(calculateNoOfRooms(price));//Calulates Rooms Required
                CurrentOrder3.setNoOfDays(3);
                CurrentOrder3.setCardNo(CreditCards[2]);
                CardinalMain.TravelAgency3.setCurrentOrder(CurrentOrder3);


                OrderClass CurrentOrder4 = new OrderClass();
                CurrentOrder4.setSenderID("TravelAgency4");
                CurrentOrder4.setReceieverID(HotelName);
                CurrentOrder4.setNoOfRooms(calculateNoOfRooms(price));//Calulates Rooms Required
                CurrentOrder4.setNoOfDays(4);
                CurrentOrder4.setCardNo(CreditCards[3]);
                CardinalMain.TravelAgency4.setCurrentOrder(CurrentOrder4);

                OrderClass CurrentOrder5 = new OrderClass();
                CurrentOrder5.setSenderID("TravelAgency5");
                CurrentOrder5.setReceieverID(HotelName);
                CurrentOrder5.setNoOfRooms(calculateNoOfRooms(price));//Calulates Rooms Required
                CurrentOrder5.setNoOfDays(5);
                CurrentOrder5.setCardNo(CreditCards[4]);
                CardinalMain.TravelAgency5.setCurrentOrder(CurrentOrder5);
                i=1;
            }
            else if (HotelName.Equals("HotelSupplier2"))
            {
                OrderClass CurrentOrder1 = new OrderClass();
                CurrentOrder1.setSenderID("TravelAgency1");
                CurrentOrder1.setReceieverID(HotelName);
                CurrentOrder1.setNoOfRooms(calculateNoOfRooms(price));//Calulates Rooms Required
                CurrentOrder1.setNoOfDays(4);
                CurrentOrder1.setCardNo(CreditCards[0]);
                CardinalMain.HTravelAgency1.setCurrentOrder(CurrentOrder1);


                OrderClass CurrentOrder2 = new OrderClass();
                CurrentOrder2.setSenderID("TravelAgency2");
                CurrentOrder2.setReceieverID(HotelName);
                CurrentOrder2.setNoOfRooms(calculateNoOfRooms(price));//Calulates Rooms Required
                CurrentOrder2.setNoOfDays(2);
                CurrentOrder2.setCardNo(CreditCards[1]);
                CardinalMain.HTravelAgency2.setCurrentOrder(CurrentOrder2);

                OrderClass CurrentOrder3 = new OrderClass();
                CurrentOrder3.setSenderID("TravelAgency3");
                CurrentOrder3.setReceieverID(HotelName);
                CurrentOrder3.setNoOfRooms(calculateNoOfRooms(price));//Calulates Rooms Required
                CurrentOrder3.setNoOfDays(4);
                CurrentOrder3.setCardNo(CreditCards[2]);
                CardinalMain.HTravelAgency3.setCurrentOrder(CurrentOrder3);
             
                OrderClass CurrentOrder4 = new OrderClass();
                CurrentOrder4.setSenderID("TravelAgency4");
                CurrentOrder4.setReceieverID(HotelName);
                CurrentOrder4.setNoOfRooms(calculateNoOfRooms(price));//Calulates Rooms Required
                CurrentOrder4.setNoOfDays(3);
                CurrentOrder4.setCardNo(CreditCards[3]);
                CardinalMain.HTravelAgency4.setCurrentOrder(CurrentOrder4);

                OrderClass CurrentOrder5 = new OrderClass();
                CurrentOrder5.setSenderID("TravelAgency5");
                CurrentOrder5.setReceieverID(HotelName);
                CurrentOrder5.setNoOfRooms(calculateNoOfRooms(price));//Calulates Rooms Required
                CurrentOrder5.setNoOfDays(3);
                CurrentOrder5.setCardNo(CreditCards[4]);
                CardinalMain.HTravelAgency5.setCurrentOrder(CurrentOrder5);
                i=2;
                
            }
            else if (HotelName.Equals("HotelSupplier3"))
            {
                OrderClass CurrentOrder1 = new OrderClass();
                CurrentOrder1.setSenderID("TravelAgency1");
                CurrentOrder1.setReceieverID(HotelName);
                CurrentOrder1.setNoOfRooms(calculateNoOfRooms(price));//Calulates Rooms Required
                CurrentOrder1.setNoOfDays(5);
                CurrentOrder1.setCardNo(CreditCards[0]);
                CardinalMain.STravelAgency1.setCurrentOrder(CurrentOrder1);

                OrderClass CurrentOrder2 = new OrderClass();
                CurrentOrder2.setSenderID("TravelAgency2");
                CurrentOrder2.setReceieverID(HotelName);
                CurrentOrder2.setNoOfRooms(calculateNoOfRooms(price));//Calulates Rooms Required
                CurrentOrder2.setNoOfDays(2);
                CurrentOrder2.setCardNo(CreditCards[1]);
                CardinalMain.STravelAgency2.setCurrentOrder(CurrentOrder2);

                OrderClass CurrentOrder3 = new OrderClass();
                CurrentOrder3.setSenderID("TravelAgency3");
                CurrentOrder3.setReceieverID(HotelName);
                CurrentOrder3.setNoOfRooms(calculateNoOfRooms(price));//Calulates Rooms Required
                CurrentOrder3.setNoOfDays(6);
                CurrentOrder3.setCardNo(CreditCards[2]);
                CardinalMain.STravelAgency3.setCurrentOrder(CurrentOrder3);

                OrderClass CurrentOrder4 = new OrderClass();
                CurrentOrder4.setSenderID("TravelAgency4");
                CurrentOrder4.setReceieverID(HotelName);
                CurrentOrder4.setNoOfRooms(calculateNoOfRooms(price));//Calulates Rooms Required
                CurrentOrder4.setNoOfDays(3);
                CurrentOrder4.setCardNo(CreditCards[3]);
                CardinalMain.STravelAgency4.setCurrentOrder(CurrentOrder4);

                OrderClass CurrentOrder5 = new OrderClass();
                CurrentOrder5.setSenderID("TravelAgency5");
                CurrentOrder5.setReceieverID(HotelName);
                CurrentOrder5.setNoOfRooms(calculateNoOfRooms(price));//Calulates Rooms Required
                CurrentOrder5.setNoOfDays(5);
                CurrentOrder5.setCardNo(CreditCards[4]);
                CardinalMain.STravelAgency5.setCurrentOrder(CurrentOrder5);
                i=3;

            }
            {
                //All Travel Agencies Start Placing Orders to the Hotel Supplier which generated an Event 
                CardinalMain.startOrders(i);
            }
        }
          
        /// <summary>
        /// This method writes the order object to multi-cell buffer from where hotel supplier reads the order object
        /// </summary>
 
        public void placeOrder()
        {
            String Semaphore = this.getCurrentOrder().getReceiverID();

            if (Semaphore.Equals("HotelSupplier1"))
            {
                if (Monitor.TryEnter(CardinalMain.n1))
                {
                    try
                    {
                        CardinalMain.n1.setOneCell(Encoder(this.getCurrentOrder()));//Encoding the Order Object to String
                        Console.WriteLine("Order Placed by Travel Agency: " + this.getCurrentOrder().getSenderID()+" to "+this.getCurrentOrder().getReceiverID()+" at "+ DateTime.Now.ToString());
                    }
                    finally
                    {
                        Monitor.Exit(CardinalMain.n1);
                    }
                }
            }
            if (Semaphore.Equals("HotelSupplier2"))
            {
                if (Monitor.TryEnter(CardinalMain.n2))
                {
                    try
                    {
                        CardinalMain.n2.setOneCell(Encoder(this.getCurrentOrder()));//Encoding the Order Object to String
                        Console.WriteLine("Order Placed by Travel Agency: " + this.getCurrentOrder().getSenderID()+" to "+this.getCurrentOrder().getReceiverID()+" at "+ DateTime.Now.ToString());
                    }
                    finally
                    {
                        Monitor.Exit(CardinalMain.n2);
                    }
                }
            }
            if (Semaphore.Equals("HotelSupplier3"))
            {
                if (Monitor.TryEnter(CardinalMain.n3))
                {
                    try
                    {
                        CardinalMain.n3.setOneCell(Encoder(this.getCurrentOrder()));//Encoding the Order Object to String
                        Console.WriteLine("Order Placed by Travel Agency: " + this.getCurrentOrder().getSenderID() + " to " + this.getCurrentOrder().getReceiverID() + " at " + DateTime.Now.ToString());
                    }
                    finally
                    {
                        Monitor.Exit(CardinalMain.n3);
                    }
                }
            }
        }

        
        /// <summary>
        /// This method is used to receive the order status and print it
        /// </summary>
        public void receiveOrderConfirmation()
        {
            if (Monitor.TryEnter(CardinalMain.n4))
            {
                try
                {
                    String orderStatus= CardinalMain.n4.getOneCell();
                    String[] result = orderStatus.Split('|');
                    int i = 0;
                    Console.WriteLine();
                    while (i<result.Length)
                    {
                        Console.WriteLine(result[i]);
                        i++;
                    }
                }
                finally
                {
                    Monitor.Exit(CardinalMain.n4);
                }
            }
        }

        /// <summary>
        /// Calcualtes No. of Rooms to book based on Hotel Price
        /// </summary>
        /// <param name="price">New Low Price</param>
        /// <returns>No of rooms to book</returns>
        public int calculateNoOfRooms(int price)
        {
               if (price < 3000)
                {
                    return rand.Next(4, 6);
                }
                else if (price > 3000 && price < 5000)
                {
                    return rand.Next(3, 5);
                }
               else 
               {
                    return rand.Next(2, 4);
                }
        }
             
        }
    }

