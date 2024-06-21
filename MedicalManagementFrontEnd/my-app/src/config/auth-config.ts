import { LogLevel } from "@azure/msal-browser";

export const msalConfig = {
    auth: {
      clientId: '84b11a45-014a-4eab-b07a-6641910f07a1', // This is the ONLY mandatory field that you need to supply.
      authority: 'https://login.microsoftonline.com/bd175ac7-a5c7-49fa-9f86-3a3bb957da80', // Choose SUSI as your default authority.
      redirectUri: 'http://localhost:5173/login', // Update to match your redirect URI
      postLogoutRedirectUri: 'http://localhost:5173',
      navigateToLoginRequestUrl: false, // If 'true', will navigate back to the original request location before processing the auth code response.
    },
    cache: {
      cacheLocation: 'sessionStorage', // Configures cache location. 'sessionStorage' is more secure, but 'localStorage' gives you SSO between tabs.
      storeAuthStateInCookie: false, // Set this to 'true' if you are having issues on IE11 or Edge
    },

    system: {	
      loggerOptions: {	
          loggerCallback: (level: LogLevel, message: string, containsPii: boolean) => {	
              if (containsPii) {		
                  return;		
              }		
              switch (level) {
                  case LogLevel.Error:
                      console.error(message);
                      return;
                  case LogLevel.Info:
                      console.info(message);
                      return;
                  case LogLevel.Verbose:
                      console.debug(message);
                      return;
                  case LogLevel.Warning:
                      console.warn(message);
                      return;
                  default:
                      return;
              }	
          }	
      }	
  }
};

export const loginRequest = {
  scopes: ["User.Read"]
};
  