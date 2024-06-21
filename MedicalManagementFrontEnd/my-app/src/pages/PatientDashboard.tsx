import React from 'react';
import CurrentTreatments from '../sections/CurrentTreatments';
import MedicalRecords from '../sections/MedicalRecords';
import Appointments from '../sections/Appointments';

const PatientDashboard: React.FC = () => (
  <div>
    <h2>Patient Dashboard</h2>
    <CurrentTreatments />
    <MedicalRecords />
    <Appointments />
  </div>
);

export default PatientDashboard;
