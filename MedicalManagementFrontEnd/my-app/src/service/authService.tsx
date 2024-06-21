// src/service/authService.ts
import { AccountInfo, InteractionRequiredAuthError } from '@azure/msal-browser';
import msalInstance from '../config/msalInstance';

class AuthService {
  private currentUser: AccountInfo | null = null;

  constructor() {
    this.currentUser = msalInstance.getActiveAccount();
    console.log("🚀 ~ AuthService ~ constructor ~ currentUser:", this.currentUser)
  }

  getCurrentUser() {
    return this.currentUser;
  }

  async getCurrentToken() {
    console.log("start GetCurrentUser function");
    if (this.currentUser) {
      console.log("🚀 ~ AuthService ~ getCurrentToken ~ currentUser:", this.currentUser)
      const accounts = msalInstance.getAllAccounts();
      if (accounts.length > 0) {
        try {
          console.log('Trying to acquire ID token silently...');
          const response = await msalInstance.acquireTokenSilent({
            account: accounts[0],
            scopes: ['openid', 'profile'],
          });
          console.log('ID token acquired silently:', response.idToken);
          return response.idToken;
        } catch (error) {
          console.log('Silent ID token acquisition failed:', error);
          if (error instanceof InteractionRequiredAuthError) {
            console.log('Falling back to popup method for ID token acquisition...');
            const response = await msalInstance.acquireTokenPopup({
              account: accounts[0],
              scopes: ['openid', 'profile'],
            });
            console.log('ID token acquired via popup:', response.idToken);
            return response.idToken;
          }
        }
      }
    }
    return null;
  }

  async getAccessToken() {
    if (this.currentUser) {
      const accounts = msalInstance.getAllAccounts();
      if (accounts.length > 0) {
        try {
          const response = await msalInstance.acquireTokenSilent({
            account: accounts[0],
            scopes: ['User.Read'],
          });
          return response.accessToken;
        } catch (error) {
          if (error instanceof InteractionRequiredAuthError) {
            // fallback to interactive method if silent token acquisition fails
            const response = await msalInstance.acquireTokenPopup({
              account: accounts[0],
              scopes: ['User.Read'],
            });
            return response.accessToken;
          }
        }
      }
    }
    return null;
  }

  async getUserRole() {
    const token = await this.getCurrentToken();
    console.log('Current token:', token);
    if (token) {
      const payload = JSON.parse(atob(token.split('.')[1]));
      console.log('Token payload:', payload);
      if (payload.roles && payload.roles.length > 0) {
        console.log('User role:', payload.roles[0]);
        return payload.roles[0];
      } else {
        console.log('No roles found in token.');
      }
    } else {
      console.log('No token found.');
    }
    return null;
  }
  
  

  logout() {
    msalInstance.logoutRedirect();
  }
}

const authService = new AuthService();
export default authService;
