import React from 'react';
import { TextField, TextFieldProps } from '@mui/material';

type TextInputProps = TextFieldProps & {
  label: string;
};

const TextInput: React.FC<TextInputProps> = ({ label, ...props }) => (
  <TextField label={label} variant="outlined" fullWidth {...props} />
);

export default TextInput;