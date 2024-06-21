/* eslint-disable @typescript-eslint/no-explicit-any */
// src/components/ViewTreatment.tsx
import React from 'react';
import { Box, Typography } from '@mui/material';

interface ViewTreatmentProps {
  treatment: any;
}

const ViewTreatment: React.FC<ViewTreatmentProps> = ({ treatment }) => {
  if (!treatment) {
    return <Typography>No treatment selected.</Typography>;
  }

  return (
    <Box>
      <Typography variant="h6">Treatment Name: {treatment.name}</Typography>
      <Typography>Duration: {treatment.duration} {treatment.durationUnit}</Typography>
    </Box>
  );
};

export default ViewTreatment;
