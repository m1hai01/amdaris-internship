/* eslint-disable @typescript-eslint/no-unused-vars */
// src/components/AddDiagnosisForm.tsx
import React from "react";
import { useForm, SubmitHandler } from "react-hook-form";
import { Button, TextField, Box, Typography } from "@mui/material";
import { useState } from "react";
import { Diagnoses } from "../../api/axios";

interface AddDiagnosisFormProps {
  patientId: string;
  refetch: () => void;
}

interface DiagnosisFormInputs {
  name: string;
}

const AddDiagnosisForm: React.FC<AddDiagnosisFormProps> = ({
  patientId,
  refetch
  // function to refecth
}) => {
  const {
    register,
    handleSubmit,
    formState: { errors },
  } = useForm<DiagnosisFormInputs>();
  const [submissionError, setSubmissionError] = useState<string | null>(null);

  const onSubmit: SubmitHandler<DiagnosisFormInputs> = async (data) => {
    try {
      await Diagnoses.createDiagnosis({ ...data, patientId });
      await refetch();
    } catch (error) {
      setSubmissionError("Failed to create diagnosis. Please try again.");
      console.error("Error creating diagnosis:", error);
    }
  };

  return (
    <Box component="form" onSubmit={handleSubmit(onSubmit)} noValidate>
      <TextField
        label="Diagnosis Name"
        {...register("name", { required: "Diagnosis Name is required" })}
        fullWidth
        margin="normal"
      />
      {errors.name && (
        <Typography color="error">{errors.name.message}</Typography>
      )}
      {submissionError && (
        <Typography color="error">{submissionError}</Typography>
      )}

      <Button type="submit" variant="contained" color="primary">
        Submit
      </Button>
    </Box>
  );
};

export default AddDiagnosisForm;
