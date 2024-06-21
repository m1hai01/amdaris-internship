// src/styles/theme.ts
import { createTheme } from '@mui/material/styles';

const theme = createTheme({
  palette: {
    primary: {
      main: '#007bff', // Customize the primary color
    },
  },
  components: {
    MuiTextField: {
      styleOverrides: {
        root: {
          '& .MuiOutlinedInput-root': {
            '& fieldset': {
              borderColor: '#007bff', // Customize the border color
            },
            '&:hover fieldset': {
              borderColor: '#0056b3', // Customize the border color on hover
            },
            '&.Mui-focused fieldset': {
              borderColor: '#0056b3', // Customize the border color when focused
            },
          },
          '& .MuiInputLabel-root': {
            color: '#007bff', // Customize the label color
          },
          '& .MuiInputLabel-root.Mui-focused': {
            color: '#0056b3', // Customize the label color when focused
          },
        },
      },
    },
  },
});

export default theme;
