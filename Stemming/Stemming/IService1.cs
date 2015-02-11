using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Stemming
{
   
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        string Stemming(String input);
    }


  
}
