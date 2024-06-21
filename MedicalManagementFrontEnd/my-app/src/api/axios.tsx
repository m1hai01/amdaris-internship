/* eslint-disable @typescript-eslint/no-explicit-any */
// src/api/axios.ts
import axios from "axios";
import authService from "../service/authService";

const BASE_URL = "https://localhost:7225";

const api = axios.create({
  baseURL: BASE_URL,
  headers: {
    "Content-Type": "application/json",
  },
});

// Response handler
const responseBody = (response: any) => (response ? response.data : null);

// Request interceptor to add the Authorization header with JWT
api.interceptors.request.use(
  async (config) => {
    const token = await authService.getCurrentToken(); // Ensure this gets the current token asynchronously
    if (token) {
      config.headers.Authorization = `Bearer ${token}`;
    }
    return config;
  },
  (error) => Promise.reject(error)
);

// Axios API methods
const Users = {
  doctorRegister: (body: { name: string; email: string; password: string }) =>
    api.post("/signup/doctor", body).then(responseBody),

  patientRegister: (body: { name: string; email: string; password: string }) =>
    api.post("/signup/patient", body).then(responseBody),

  login: (body: { email: string; password: string }) =>
    api.post("/auth/login", body).then(responseBody),

  createUser: (body: {
    Username: string;
    Password: string;
    Email: string;
    Name: string;
    DateOfBirth: string;
    Gender: string;
    PhoneNumber: string;
  }) => api.post("/users", body).then(responseBody),
  getAllPatients: (params: { Page: number; PageSize: number }) =>
    api.get("/users", { params }).then(responseBody),
  getUserById: (userId: string) =>
    api.get(`/users/${userId}`).then(responseBody),

  getPatientWithDiagnoses: (patientId: string) =>
    api.get(`/patient/diagnoses/${patientId}`).then(responseBody),
};

const MedicalRecords = {
  getByPatientId: (patientId: string) =>
    api.get(`/patients/${patientId}/medical-records`).then(responseBody),

  create: (data: {
    patientId: string;
    doctorName: string;
    diagnosis: string;
    treatment: string;
    notes: string;
  }) => api.post("/medical-records", data).then(responseBody),
};

const Treatments = {
  createTreatment: (data: any) => api.post("/treatments", data),
  getTreatmentById: (id: string) => api.get(`/treatments/${id}`),
  // other treatment methods
};

const Diagnoses = {
  createDiagnosis: (data: any) => api.post("/diagnoses", data),
  // getDiagnosis: (id: string) => api.get('diagnoses')
  // other diagnosis methods
};

const Files = {
  upload: (data: FormData, id: string | number) =>
    api.post(`/upload/${id}`, data, {
      headers: {
        "Content-Type": "multipart/form-data",
      },
    }),

  get: (id: string) => api.get(`/files/${id}`),
};

export { Users, MedicalRecords, Diagnoses, Treatments, Files };
