using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Threading;

namespace CardinalsHBS
{
    /// <summary>
    /// The instances of this class is used as a buffer for placing, receiving and confirming order.
    /// </summary>
    class MultiCellBuffer
    {

        private String OneCell;
        private bool writeable = true;

        //Constructor
        public MultiCellBuffer()
        {
        }

        /// <summary>
        /// Setter for Buffer cell with Order Information in String Format
        /// </summary>
        /// <param name="OneCell">Order Information in string format</param>
        public void setOneCell(String OneCell)
        {
            while (!writeable)
            {
                try
                {
                    Monitor.Wait(this);
                }
                catch(ThreadInterruptedException ex)
                {
                    Console.WriteLine("Stack Trace: " + ex.StackTrace);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Buffer Cell Error: "+e.StackTrace);
                }
            }
            this.OneCell = OneCell;
            writeable = false;
            Monitor.PulseAll(this);
        }

        /// <summary>
        /// Getter for Buffer CEll with order information in string format
        /// </summary>
        /// <returns>order information in string format</returns>
        public String getOneCell()
        {
            while (writeable)
            {
                try
                {
                    Monitor.Wait(this);
                }
                catch (ThreadInterruptedException ex)
                {
                    Console.WriteLine("Stack Trace: " + ex.StackTrace);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Buffer Cell Error: " + e.StackTrace);
                }
            }
            writeable = true;
            Monitor.PulseAll(this);
            return this.OneCell;
        }
    }
}
