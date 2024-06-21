import React from 'react';

const Appointments: React.FC = () => (
  <section id="appointments">
    <h2>Appointments</h2>
    <p>Upcoming appointments:</p>
    <table>
      <thead>
        <tr>
          <th>Patient</th>
          <th>Doctor</th>
          <th>Date</th>
          <th>Time</th>
        </tr>
      </thead>
      <tbody>
        <tr>
          <td>Ion Popescu</td>
          <td>Dr. Ana Rusu</td>
          <td>2024-07-01</td>
          <td>10:00 AM</td>
        </tr>
        <tr>
          <td>Maria Ionescu</td>
          <td>Dr. Gheorghe Bălan</td>
          <td>2024-07-02</td>
          <td>2:00 PM</td>
        </tr>
      </tbody>
    </table>
  </section>
);

export default Appointments;
