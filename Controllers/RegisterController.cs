// FILE: D:/New Folder (22)/UserPackage/Register.cs

// In this section you can add your own using directives
// section -87--2-87--42--46e34135:1711ce644e4:-8000:0000000000000AB7 begin
// section -87--2-87--42--46e34135:1711ce644e4:-8000:0000000000000AB7 end
using StorePackage;
using System.Web.Http;

namespace UserPackage {

/// <summary>
    ///  A class that represents ...
    /// 
    ///  @see OtherClasses
    ///  @author your_name_here
     /// </summary>
public class RegisterController: ApiController, IRegister
{
        IUserFinder userFinder = new RegisteredUsersController();

        IAddUserRepo normalUserRepo = new NormalUserDataBase();
        IAddUserRepo storeOwnerRepo = new StoreOwnerDataBase();

        ISearchStoreRepo onlineStoreSearcher = new OnlineStoreDataBase();
        IAddStoreRepo onlineStoreAdder = new OnlineStoreDataBase();

        ISearchStoreRepo onsiteStoreSearcher = new OnSiteStoreDataBase();
        IAddStoreRepo onsiteStoreAdder = new OnSiteStoreDataBase();

        [HttpPost]
        public NormalUser registerNormalUser(string email, string userName, string password, [FromBody]string value)
        {
            User user = userFinder.findUser(email);
            if (user != null)
                return null;

            NormalUser normalUser = new NormalUser(email, userName, password);
            normalUserRepo.addUser(normalUser);
            return normalUser;
        }

        [HttpPost]
        public StoreOwner registerStoreOwnerForOnlineStore(string email,string userName,string password, string storeName, string storeAddress, [FromBody]string value)
        {
            User user = userFinder.findUser(email);
            if (user != null)
                return null;

            Store store = onlineStoreSearcher.searchStoreByName(storeName);
            if (store != null)
                return null;

            onlineStoreAdder.addStore(new OnlineStore(storeName, storeAddress));
            StoreOwner storeOwnerUser = new StoreOwner(email, userName, password);
            storeOwnerRepo.addUser(storeOwnerUser);
            return storeOwnerUser;
        }

        [HttpPost]
        public StoreOwner registerStoreOwnerForOnSiteStore(string email, string userName, string password, string storeName, string storeAddress, [FromBody]string value)
        {
            User user = userFinder.findUser(email);
            if (user != null)
                return null;

            Store store = onsiteStoreSearcher.searchStoreByName(storeName);
            if (store != null)
                return null;

            onsiteStoreAdder.addStore(new OnSiteStore(storeName, storeAddress));
            StoreOwner storeOwnerUser = new StoreOwner(email, userName, password);
            storeOwnerRepo.addUser(storeOwnerUser);
            return storeOwnerUser;
        }


    } /* end class Register */

}
