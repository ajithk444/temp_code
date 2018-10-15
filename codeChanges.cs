 public ActionResult Login()
        {
            if (CurrentUser.CurrentUSER != null && CurrentUser.IsLoggedIn)
            {
                int userID = CurrentUser.CurrentUSER.UserID;                
                string uniqueSessionID = Session["UserSessionID"].ToString();
                //update session id as not active in usersession table                
            }
            return View();
        }



_______________________________________________________________________________________________


login method:
  
                if (user != null)
                {
                 //check if a session is active for the user from db
                  var session = userHelper.UserRepository.Get_UserSession(user.ID);
                 if(session!=null && session.isActive ==true)
                 {
                    // redirect to login page with error message or show a popup to override old session.
                 }
                 
                    HttpRequest req = System.Web.HttpContext.Current.Request;
                    string browserName = req.Browser.Browser;
                    Session["UserSessionID"] = Guid.NewGuid().ToString();
                    //insert or update the usersession table. (userid, logindate,isactive,sessionid)
                     userHelper.InitializeCurrentUser(user);
                 
                 
__________________________________________________________________________________________________
 
 
 logoff method:
             
                 
                  int userID = CurrentUser.CurrentUSER.UserID;                
                string uniqueSessionID = Session["UserSessionID"].ToString();
                //update session id as not active in usersession table                
