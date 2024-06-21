/* eslint-disable @typescript-eslint/no-unused-vars */
// src/components/CreateTreatmentForm.tsx
import React from 'react';
import { useForm, SubmitHandler } from 'react-hook-form';
import { Button, TextField, Box } from '@mui/material';

interface CreateTreatmentFormProps {
  patientId: string;
}

interface TreatmentFormInputs {
  name: string;
  duration: number;
  durationUnit: string;
}

const CreateTreatmentForm: React.FC<CreateTreatmentFormProps> = ({ patientId }) => {
  const { register, handleSubmit, formState: { errors } } = useForm<TreatmentFormInputs>();

  const onSubmit: SubmitHandler<TreatmentFormInputs> = data => {
    console.log('Treatment data:', data);
  };

  return (
    <Box component="form" onSubmit={handleSubmit(onSubmit)}>
      <TextField label="Treatment Name" {...register('name', { required: 'Treatment Name is required' })} fullWidth margin="normal" />
      {errors.name && <p>{errors.name.message}</p>}
      
      <TextField label="Duration" type="number" {...register('duration', { required: 'Duration is required' })} fullWidth margin="normal" />
      {errors.duration && <p>{errors.duration.message}</p>}
      
      <TextField label="Duration Unit" {...register('durationUnit', { required: 'Duration Unit is required' })} fullWidth margin="normal" />
      {errors.durationUnit && <p>{errors.durationUnit.message}</p>}
      
      <Button type="submit" variant="contained" color="primary">Submit</Button>
    </Box>
  );
};

export default CreateTreatmentForm;
