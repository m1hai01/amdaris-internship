// src/hooks/useMedicalRecordForm.ts
import { useForm, SubmitHandler } from 'react-hook-form';
import { yupResolver } from '@hookform/resolvers/yup';
import * as yup from 'yup';
import { useCallback } from 'react';
import { MedicalRecords } from '../api/axios';

interface IMedicalRecordFormInput {
//   patientName: string;
  doctorName: string;
  diagnosis: string;
  treatment: string;
  notes: string;
}

const schema = yup.object().shape({
//   patientName: yup.string().required('Patient name is a required field'),
  doctorName: yup.string().required('Doctor name is a required field'),
  diagnosis: yup.string().required('Diagnosis is a required field'),
  treatment: yup.string().required('Treatment is a required field'),
  notes: yup.string().required('Notes are a required field'),
});

const useMedicalRecordForm = (patientId: string) => {
  const { register, handleSubmit, formState: { errors } } = useForm<IMedicalRecordFormInput>({
    resolver: yupResolver(schema),
  });

  const onSubmit: SubmitHandler<IMedicalRecordFormInput> = useCallback(async (data) => {
    try {
        await MedicalRecords.create({
            patientId,
            ...data
        })
        .then((response)=> {
            console.log("🚀 ~ .then ~ response:", response)
            
        })
        .catch((error) => console.log(error))
      // Make an API call to submit the medical record
      console.log('Medical record submitted for patient:', patientId, data);
      alert('Medical record submitted successfully!');
    } catch (error) {
      console.error('Error submitting medical record:', error);
    }
  }, [patientId]);

  return {
    register,
    handleSubmit,
    errors,
    onSubmit,
  };
};

export default useMedicalRecordForm;
