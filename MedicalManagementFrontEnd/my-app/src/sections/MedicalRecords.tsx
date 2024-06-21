import axios from "axios";
import authService from "../service/authService";

const MedicalRecords: React.FC = () => {

  const handleFetchRecords = async () => {
    const token = await authService.getCurrentToken();
    console.log('Fetched token:', token);
    try {
      const response = await axios.post('https://localhost:7225/users', {}, {
        headers: {
          Authorization: `Bearer ${token}`
        }
      });
      console.log('Medical records:', response.data);
    } catch (error) {
      if (axios.isAxiosError(error)) {
        // Cast error to AxiosError to access response property
        console.error('Error response:', error.response);
      } else {
        // Handle unexpected errors
        console.error('Unexpected error:', error);
      }
    }
  };
  return (
    <section id="medical-records">
      <h2>Medical Records</h2>
      <button onClick={handleFetchRecords}>Fetch Medical Records</button>
      <p>Recent medical records:</p>
      <table>
        <thead>
          <tr>
            <th>Patient</th>
            <th>Doctor</th>
            <th>Date</th>
            <th>Diagnosis</th>
            <th>Treatment</th>
          </tr>
        </thead>
        <tbody>
          <tr>
            <td>Vasile Munteanu</td>
            <td>Dr. Elena Ciobanu</td>
            <td>2024-06-25</td>
            <td>Diabetes</td>
            <td>Insulin Therapy</td>
          </tr>
          <tr>
            <td>Ion Popescu</td>
            <td>Dr. Ana Rusu</td>
            <td>2024-06-20</td>
            <td>Hypertension</td>
            <td>Medication</td>
          </tr>
        </tbody>
      </table>
    </section>
  );
};

export default MedicalRecords;
