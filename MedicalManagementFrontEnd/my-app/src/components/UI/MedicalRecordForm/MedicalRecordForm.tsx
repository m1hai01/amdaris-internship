// src/components/UI/MedicalRecordForm/MedicalRecordForm.tsx
import React from 'react';
import useMedicalRecordForm from '../../../hooks/useMedicalRecordForm';
import './Form.css';
import { TextField } from '@mui/material';

interface MedicalRecordFormProps {
  patientId: string;
}

const MedicalRecordForm: React.FC<MedicalRecordFormProps> = ({ patientId }) => {
  const { register, handleSubmit, errors, onSubmit } = useMedicalRecordForm(patientId);

  return (
    <section id="medical-record-form">
      <h2>Medical Record Form</h2>
      <form onSubmit={handleSubmit(onSubmit)}>
        {/* <label>Patient Name</label>
        <input {...register('patientName')} />
        {errors.patientName && <p>{errors.patientName.message}</p>} */}

        <label>Doctor Name</label>
        <input {...register('doctorName')} />
        {errors.doctorName && <p>{errors.doctorName.message}</p>}

        <label>Diagnosis</label>
        <TextField {...register('diagnosis')} />
        {errors.diagnosis && <p>{errors.diagnosis.message}</p>}

        <label>Treatment</label>
        <input {...register('treatment')} />
        {errors.treatment && <p>{errors.treatment.message}</p>}

        <label>Notes</label>
        <textarea {...register('notes')} rows={4} />
        {errors.notes && <p>{errors.notes.message}</p>}

        <input type="submit" />
      </form>
    </section>
  );
};

export default MedicalRecordForm;
