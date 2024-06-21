// src/pages/DoctorDashboard.tsx
import React from "react";
import PatientsList from "../sections/PatientsList";
import { Box, Typography } from "@mui/material";

const DoctorDashboard: React.FC = () => {
  return (
    <Box
      display="flex"
      flexDirection="column"
      justifyContent="center"
      alignItems="center"
    >
      <Typography sx={{ mt: 4, mb: 2, display: "flex" }} variant="h4">
        Doctor dashboard
      </Typography>
      <PatientsList />
    </Box>
  );
};

export default DoctorDashboard;
