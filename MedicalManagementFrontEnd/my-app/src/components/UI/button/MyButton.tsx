// src/components/UI/button/MyButton.tsx
import React from 'react';
import { Button, ButtonProps } from '@mui/material';

interface MyButtonProps extends ButtonProps {
  children: React.ReactNode;
}

const MyButton: React.FC<MyButtonProps> = ({ children, ...props }) => (
  <Button {...props}>
    {children}
  </Button>
);

export default MyButton;
