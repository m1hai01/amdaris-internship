import React from 'react';
import { TextField, TextFieldProps } from '@mui/material';

type TextAreaProps = TextFieldProps & {
  label: string;
};

const TextArea: React.FC<TextAreaProps> = ({ label, ...props }) => (
  <TextField label={label} variant="outlined" fullWidth multiline {...props} />
);

export default TextArea;
