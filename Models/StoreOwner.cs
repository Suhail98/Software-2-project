// FILE: D:/New Folder (22)/UserPackage/StoreOwner.cs

// In this section you can add your own using directives
// section -87--2-87--42--4267bcd9:1710d3b46a2:-8000:000000000000096C begin
// section -87--2-87--42--4267bcd9:1710d3b46a2:-8000:000000000000096C end
using StorePackage;
using System.Collections.Generic;

namespace UserPackage {

/// <summary>
    ///  A class that represents ...
    /// 
    ///  @see OtherClasses
    ///  @author your_name_here
     /// </summary>
public class StoreOwner : User
{
    // Attributes

    public List<Store> stores = new List<Store>();
        
       
        public StoreOwner(string email, string userName, string password) : base(email,userName,password)
        {
          //  stores = new List<Store>();
        }
        public void addStore(Store store)
        {
            stores.Add(store);
        }
    } /* end class StoreOwner */

}
