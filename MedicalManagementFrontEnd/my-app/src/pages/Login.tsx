// src/pages/Login.tsx
import React, { useEffect } from 'react';
import { useMsal } from '@azure/msal-react';
import { useNavigate } from 'react-router-dom';
import { loginRequest } from '../config/auth-config';
import authService from '../service/authService';

const Login: React.FC = () => {
  const { instance } = useMsal();
  const navigate = useNavigate();

  const handleLogin = async () => {
    try {
      await instance.loginPopup(loginRequest);
      const role = await authService.getUserRole();
      console.log('User role:', role); // Debugging line
      if (role === 'Doctor') {
        navigate('/doctor');
      } else if (role === 'Patient') {
        navigate('/patient');
      } else {
        console.error('Unknown role');
      }
    } catch (error) {
      console.error('Failed to retrieve token', error);
    }
  };

  useEffect(() => {
    const checkAccount = async () => {
      const currentUser = authService.getCurrentUser();
      if (currentUser) {
        const role = await authService.getUserRole();
        console.log('Current user role:', role); // Debugging line
        if (role === 'Doctor') {
          navigate('/doctor');
        } else if (role === 'Patient') {
          navigate('/patient');
        }
      }
    };
    checkAccount();
  }, [navigate]);

  return (
    <div>
      <h2>Login</h2>
      <button onClick={handleLogin}>Login with Microsoft</button>
    </div>
  );
};

export default Login;
